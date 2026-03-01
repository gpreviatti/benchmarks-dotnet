# Lists and Spans Benchmarks

This project compares iteration and summing performance across various collection types:
* Array (`T[]`)
* `List<T>`
* `ICollection<T>` (backed by `List<T>`)
* `IEnumerable<T>` (backed by `List<T>`)
* `Span<T>` over the underlying array

Additional scenarios include copy operations, span slicing, and random-index access so you can evaluate both sequential and non‑sequential workloads.

Run `dotnet run -c Release` to execute the benchmarks.

## Sample Results

The benchmark output (Release, .NET 9) produced the following rankings for iteration/summing:

* **Span<T>** – fastest across all sizes.
* **Array** – slightly slower than span.
* **List<T>** – marginally slower than array.
* **ICollection<T> / IEnumerable<T>** – significantly higher cost due to interface dispatch and allocations (~40 B per run).

Detailed results and exported reports (CSV/HTML) are available under `BenchmarkDotNet.Artifacts/results`.

### BenchmarkDotNet Summary

#### Sum Performance (ns)

| Method               | N      | Mean         | Error       | StdDev    | Gen0   | Allocated |
|--------------------- |------- |-------------:|------------:|----------:|-------:|----------:|
| 'Sum Span<T>'        | 1000   |     310.5 ns |     2.90 ns |   2.57 ns |      - |         - |
| 'Sum List<T>'        | 1000   |     388.5 ns |     1.85 ns |   1.64 ns |      - |         - |
| 'Sum array'          | 1000   |     390.7 ns |     7.00 ns |   7.49 ns |      - |         - |
| 'Sum ICollection<T>' | 1000   |   1,509.3 ns |    12.86 ns |  10.74 ns | 0.0057 |      40 B |
| 'Sum IEnumerable<T>' | 1000   |   1,565.6 ns |    28.42 ns |  26.58 ns | 0.0057 |      40 B |
| 'Sum Span<T>'        | 10000  |   3,026.7 ns |    13.72 ns |  12.83 ns |      - |         - |
| 'Sum array'          | 10000  |   3,768.3 ns |    74.89 ns |  94.71 ns |      - |         - |
| 'Sum List<T>'        | 10000  |   3,842.4 ns |    24.43 ns |  21.65 ns |      - |         - |
| 'Sum IEnumerable<T>' | 10000  |  14,958.4 ns |    68.01 ns |  63.61 ns |      - |      40 B |
| 'Sum ICollection<T>' | 10000  |  15,256.1 ns |   294.84 ns | 372.88 ns |      - |      40 B |
| 'Sum Span<T>'        | 100000 |  30,339.9 ns |   106.39 ns |  94.31 ns |      - |         - |
| 'Sum array'          | 100000 |  37,102.7 ns |   221.37 ns | 207.07 ns |      - |         - |
| 'Sum List<T>'        | 100000 |  37,915.0 ns |   142.08 ns | 118.64 ns |      - |         - |
| 'Sum IEnumerable<T>' | 100000 | 152,969.0 ns | 1,079.31 ns | 956.78 ns |      - |      40 B |
| 'Sum ICollection<T>' | 100000 | 153,270.8 ns |   807.63 ns | 715.94 ns |      - |      40 B |

#### Copy Performance (ns)

| Method               | N      | Mean        | Error       | StdDev      | Median      | Gen0     | Gen1     | Gen2     | Allocated |
|--------------------- |------- |------------:|------------:|------------:|------------:|---------:|---------:|---------:|----------:|
| 'Copy array -> span' | 1000   |    164.1 ns |     3.32 ns |     6.48 ns |    163.2 ns |   0.6413 |        - |        - |   3.93 KB |
| 'Copy list -> array' | 1000   |    166.7 ns |     3.43 ns |     9.84 ns |    164.8 ns |   0.6413 |        - |        - |   3.93 KB |
| 'Copy array -> span' | 10000  |  1,940.7 ns |    16.54 ns |    14.66 ns |  1,939.5 ns |   6.3286 |        - |        - |  39.09 KB |
| 'Copy list -> array' | 10000  |  1,991.3 ns |    37.24 ns |    69.02 ns |  1,962.3 ns |   6.3286 |        - |        - |  39.09 KB |
| 'Copy array -> span' | 100000 | 91,628.3 ns |   762.59 ns |   676.01 ns | 91,528.6 ns | 124.8779 | 124.8779 | 124.8779 | 390.69 KB |
| 'Copy list -> array' | 100000 | 91,736.6 ns | 1,160.08 ns | 1,085.14 ns | 91,598.8 ns | 124.8779 | 124.8779 | 124.8779 | 390.69 KB |

#### Random Access Performance (ns)

| Method                | N      | Mean       | Error     | StdDev    | Allocated |
|---------------------- |------- |-----------:|----------:|----------:|----------:|
| 'Random access list'  | 1000   |   3.850 μs | 0.0230 μs | 0.0215 μs |         - |
| 'Random access array' | 1000   |   3.911 μs | 0.0469 μs | 0.0392 μs |         - |
| 'Random access span'  | 1000   |   4.031 μs | 0.0804 μs | 0.0894 μs |         - |
| 'Random access span'  | 10000  |  39.070 μs | 0.1900 μs | 0.1685 μs |         - |
| 'Random access list'  | 10000  |  39.885 μs | 0.7671 μs | 1.0241 μs |         - |
| 'Random access array' | 10000  |  40.088 μs | 0.5863 μs | 0.5484 μs |         - |
| 'Random access array' | 100000 | 392.712 μs | 4.0779 μs | 3.6150 μs |         - |
| 'Random access list'  | 100000 | 393.489 μs | 7.4169 μs | 7.2844 μs |         - |
| 'Random access span'  | 100000 | 395.072 μs | 4.7583 μs | 4.8864 μs |         - |

The summary above highlights the major scenarios; detailed results are available in the generated HTML/CSV exports.

> **Key observations:**

> - **Span<T>** consistently wins for sequential access with zero heap allocations.
> - **Arrays and `List<T>`** are nearly identical in speed; use whichever fits your API.
> - **Interface-based iteration** (`ICollection` / `IEnumerable`) costs ~4–5× more due to virtual dispatch and enumerator allocations; avoid when performance matters.
> - **Copy operations** are inexpensive but pay allocation cost when creating the destination buffer.
> - **Random access** exhibits uniform performance across array/list/span; choose based on mutability and API convenience.

### When to use each type

* **Span<T> / Memory<T>** – high‑performance, stack/heap-agnostic slices for short-lived operations and tight loops. Use when you need zero allocations and can work with contiguous memory.
* **T[] (array)** – basic, efficient storage; ideal for fixed-size collections and interop.
* **List<T>** – dynamic sizing with similar raw access speed as arrays; use for growable collections.
* **ICollection<T>/IEnumerable<T>** – useful for abstraction and API flexibility but avoid in inner loops where performance is critical. Prefer concrete types or use `foreach` carefully when data size is small.

These guidelines can help you pick the right container depending on your scenario and performance needs.
