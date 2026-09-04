# Changelog

All notable changes to Pure.Primitives.DateTime.Operations are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.4.0] — 2025-11-23

### Changed
- Target frameworks expanded from `net9.0` to multi-targeting `net7.0`, `net8.0`, `net9.0`, and `net10.0`.
- `LangVersion` set to `latest`.

---

## [0.3.0] — 2025-11-01

### Added
- `AfterCondition.BoolValue`, `BeforeCondition.BoolValue`, `EqualCondition.BoolValue`, `NotAfterCondition.BoolValue`, `NotBeforeCondition.BoolValue`, and `NotEqualCondition.BoolValue` are now public properties (previously accessible only through the explicit `IBool` interface implementation).

---

## [0.2.0] — 2025-11-01

### Changed
- Package declared as AOT-compatible (`IsAotCompatible` enabled, with trim and AOT analyzers).
- **Breaking:** `AfterCondition`, `BeforeCondition`, `EqualCondition`, `NotAfterCondition`, `NotBeforeCondition`, and `NotEqualCondition` now expose a single `params IEnumerable<IDateTime>` constructor instead of separate array (`params IDateTime[]`) and `IEnumerable<IDateTime>` overloads.

---

## [0.1.0] — 2025-06-19

### Added
- `EqualCondition` — `IBool` condition that is `true` when all supplied `IDateTime` values are equal down to nanosecond precision.
- `NotEqualCondition` — `IBool` condition that is `true` when at least one supplied `IDateTime` value differs from the others.
- `AfterCondition` — `IBool` condition that is `true` when the supplied `IDateTime` values are in strictly descending chronological order.
- `BeforeCondition` — `IBool` condition that is `true` when the supplied `IDateTime` values are in strictly ascending chronological order.
- `NotBeforeCondition` — `IBool` condition that is `true` when the supplied `IDateTime` values are in non-ascending chronological order.
- `NotAfterCondition` — `IBool` condition that is `true` when the supplied `IDateTime` values are in non-descending chronological order.
