# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet build --no-restore -warnaserror /p:RunAnalyzers=true
dotnet format --verify-no-changes             # check code style (CI enforces this)
dotnet format && csharpier format .           # auto-fix code style
dotnet test --no-build --verbosity normal     # run xUnit tests
dotnet pack --configuration Release -p:PackageVersion=<version> --output .
```

## Architecture

This is a **condition library** — six public `sealed record` types and one internal comparer, all in the `Pure.Primitives.DateTime.Operations` namespace.

**Public API:**

| Type | True when |
|------|-----------|
| `EqualCondition` | All values represent the same moment |
| `AfterCondition` | Sequence is strictly ascending in time |
| `BeforeCondition` | Sequence is strictly descending in time |
| `NotEqualCondition` | Not all values are equal |
| `NotAfterCondition` | Sequence is not strictly ascending |
| `NotBeforeCondition` | Sequence is not strictly descending |

All six types implement `IBool` from `Pure.Primitives.Abstractions` and accept `params IEnumerable<IDateTime>`. The internal `DateTimeComparer` orders `IDateTime` values field-by-field: year → month → day → hour → minute → second → millisecond → microsecond → nanosecond. `GetHashCode` and `ToString` throw `NotSupportedException` on all public types by design.

**Dependency on `Pure.Primitives.Abstractions`:** the library consumes `IBool`, `IDateTime` (which composes `IDate` and `ITime`), and their `INumber<ushort>` fields. No concrete implementations are shipped here.

**Multi-targeting:** `net7.0`, `net8.0`, `net9.0`, `net10.0`. `IsAotCompatible = true` — no reflection.

**Test project:** `Pure.Primitives.DateTime.Operations.Tests` targets `net10.0` only and uses xUnit with 98% coverage enforcement.

**Publishing:** triggered automatically by pushing a semver tag (e.g., `git tag 1.2.3 && git push origin 1.2.3`). The tag becomes the `PackageVersion`. Publishes to both GitHub Packages and NuGet.org.

## Code Style

Enforced via `.editorconfig` and `dotnet format --verify-no-changes` in CI:

- No `var` — always use explicit types
- Expression-bodied members for properties, indexers, accessors, and lambdas; **not** for methods or constructors
- File-scoped namespaces (`namespace Foo;`)
- `using` directives outside the namespace
- Max line length: 90 characters
- `System.*` usings first, no blank lines between using groups
- Namespace must match folder structure
- Private fields: `_camelCase`; interfaces: `I`-prefixed PascalCase; generic type parameters: `T`-prefixed PascalCase

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
