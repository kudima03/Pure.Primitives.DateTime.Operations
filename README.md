# Pure.Primitives.DateTime.Operations

Temporal comparison conditions and ordering checks for `IDateTime` values in the **Pure** ecosystem.

[![.NET build & test](https://github.com/kudima03/Pure.Primitives.DateTime.Operations/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.DateTime.Operations/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Primitives.DateTime.Operations/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.DateTime.Operations/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Primitives.DateTime.Operations)](https://www.nuget.org/packages/Pure.Primitives.DateTime.Operations)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Primitives.DateTime.Operations` provides six condition types that evaluate temporal relationships between `IDateTime` values. Every type implements `IBool`, so results compose naturally with other Pure primitives — no raw comparisons, no `bool` scalars leaking into your domain model.

## Types

| Type | True when |
|------|-----------|
| `EqualCondition` | All supplied `IDateTime` values represent the same moment |
| `AfterCondition` | Each value in the sequence is strictly after the previous (ascending order) |
| `BeforeCondition` | Each value in the sequence is strictly before the previous (descending order) |
| `NotEqualCondition` | Not all values represent the same moment |
| `NotAfterCondition` | The sequence is not strictly ascending |
| `NotBeforeCondition` | The sequence is not strictly descending |

All six types accept `params IEnumerable<IDateTime>` and implement `IBool` from `Pure.Primitives.Abstractions`. Comparison covers all nine temporal fields: year, month, day, hour, minute, second, millisecond, microsecond, and nanosecond.

## Design Principles

- **IBool results** — every condition is an `IBool`, not a raw `bool`, keeping results composable within the Pure type system.
- **Value semantics** — all types are `sealed record`s; `GetHashCode` and `ToString` are deliberately unsupported.
- **AOT-compatible** — no reflection; the library is fully compatible with Native AOT compilation.

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions/tree/4.3.0) — base interfaces (`IBool`, `IDateTime`, `IDate`, `ITime`, `INumber<T>`) for the Pure ecosystem

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```shell
dotnet add package Pure.Primitives.DateTime.Operations
```

## Usage

```csharp
using Pure.Primitives.DateTime.Operations;

IDateTime a = ...; // 2020-01-01T00:00:00
IDateTime b = ...; // 2024-06-15T12:00:00
IDateTime c = ...; // 2025-12-31T23:59:59

// Are the values in strictly ascending chronological order?
bool ascending = new AfterCondition(a, b, c).BoolValue; // true

// Are all values the same moment?
bool same = new EqualCondition(a, b).BoolValue; // false

// Is the sequence strictly descending?
bool descending = new BeforeCondition(c, b, a).BoolValue; // true
```
