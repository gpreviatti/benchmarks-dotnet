# BenchMarks most used mapper libraries

# Hardware configuration

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)

11th Gen Intel Core i5-11400H 2.70GHz, 1 CPU, 12 logical and 6 physical cores

.NET SDK 8.0.204

[Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

## Simple mapping results

| Method                       | Mean      | Error    | StdDev   | Gen0   | Allocated |
|----------------------------- |----------:|---------:|---------:|-------:|----------:|
| ImplicitOperatorMapper       |  41.33 ns | 0.477 ns | 0.398 ns | 0.0446 |     280 B |
| Mapster                      |  61.49 ns | 1.134 ns | 1.114 ns | 0.0446 |     280 B |
| MapsterLookingForConstructor |  64.05 ns | 0.649 ns | 0.607 ns | 0.0446 |     280 B |
| Native                       |  89.90 ns | 1.824 ns | 3.289 ns | 0.0560 |     352 B |
| AutoMapper                   | 101.46 ns | 2.055 ns | 5.079 ns | 0.0446 |     280 B |

### Hints

Outliers

MappersBenchmarks.ImplicitOperatorMapper: Default -> 2 outliers were removed (44.34 ns, 44.38 ns)

MappersBenchmarks.AutoMapper: Default             -> 3 outliers were removed (119.95 ns..131.19 ns)

## Mapping lists results

| Method                       | amountPeople | amountAccounts | Mean      | Error     | StdDev    | Median    | Gen0       | Gen1      | Gen2     | Allocated |
|----------------------------- |------------- |--------------- |----------:|----------:|----------:|----------:|-----------:|----------:|---------:|----------:|
| Native                       | 1            | 10             |  1.218 ms | 0.0240 ms | 0.0257 ms |  1.216 ms |   250.0000 |  246.0938 |        - |   1.51 MB |
| MapsterLookingForConstructor | 1            | 10             |  1.231 ms | 0.0227 ms | 0.0270 ms |  1.222 ms |   250.0000 |  246.0938 |        - |    1.5 MB |
| AutoMapper                   | 1            | 10             |  1.258 ms | 0.0240 ms | 0.0295 ms |  1.256 ms |   250.0000 |  246.0938 |        - |   1.51 MB |
| Mapster                      | 1            | 10             |  1.263 ms | 0.0250 ms | 0.0511 ms |  1.236 ms |   250.0000 |  246.0938 |        - |    1.5 MB |
| ImplicitOperatorMapper       | 1            | 10             |  1.272 ms | 0.0249 ms | 0.0324 ms |  1.276 ms |   250.0000 |  246.0938 |        - |   1.51 MB |
| AutoMapper                   | 10           | 100            |  7.140 ms | 0.1415 ms | 0.1983 ms |  7.123 ms |  1375.0000 |  625.0000 |        - |   8.41 MB |
| ImplicitOperatorMapper       | 10           | 100            |  7.267 ms | 0.1421 ms | 0.2083 ms |  7.302 ms |  1421.8750 |  640.6250 |  31.2500 |    8.4 MB |
| Mapster                      | 10           | 100            |  7.358 ms | 0.1190 ms | 0.1055 ms |  7.408 ms |  1421.8750 |  640.6250 |  31.2500 |   8.39 MB |
| MapsterLookingForConstructor | 10           | 100            |  7.479 ms | 0.1432 ms | 0.1862 ms |  7.461 ms |  1421.8750 |  640.6250 |  31.2500 |   8.39 MB |
| Native                       | 10           | 100            |  7.502 ms | 0.1490 ms | 0.1656 ms |  7.546 ms |  1406.2500 |  625.0000 |  31.2500 |    8.4 MB |
| MapsterLookingForConstructor | 100          | 200            | 69.329 ms | 1.3406 ms | 1.4900 ms | 69.865 ms | 13400.0000 | 3000.0000 | 400.0000 |  78.52 MB |
| Native                       | 100          | 200            | 70.346 ms | 1.3498 ms | 1.8020 ms | 69.919 ms | 13500.0000 | 3250.0000 | 500.0000 |  78.55 MB |
| AutoMapper                   | 100          | 200            | 70.455 ms | 0.6181 ms | 0.5781 ms | 70.276 ms | 13333.3333 | 2666.6667 | 333.3333 |  78.77 MB |
| Mapster                      | 100          | 200            | 72.118 ms | 1.0477 ms | 0.9800 ms | 72.021 ms | 13500.0000 | 3250.0000 | 500.0000 |  78.52 MB |
| ImplicitOperatorMapper       | 100          | 200            | 72.336 ms | 0.5422 ms | 0.4233 ms | 72.459 ms | 13500.0000 | 3250.0000 | 500.0000 |  78.54 MB |

### Hints

Outliers

MappersListsBenchmarks.Native: Default                       -> 1 outlier  was  removed (1.32 ms)

MappersListsBenchmarks.MapsterLookingForConstructor: Default -> 2 outliers were removed (1.31 ms, 1.33 ms)

MappersListsBenchmarks.AutoMapper: Default                   -> 2 outliers were removed (1.36 ms, 1.36 ms)

MappersListsBenchmarks.Mapster: Default                      -> 1 outlier  was  removed (7.82 ms)

MappersListsBenchmarks.MapsterLookingForConstructor: Default -> 1 outlier  was  removed, 2 outliers were detected (6.96 ms, 8.04 ms)

MappersListsBenchmarks.Native: Default                       -> 1 outlier  was  removed, 4 outliers were detected (7.04 ms..7.20 ms, 7.99 ms)

MappersListsBenchmarks.MapsterLookingForConstructor: Default -> 2 outliers were removed (74.87 ms, 78.91 ms)

MappersListsBenchmarks.ImplicitOperatorMapper: Default       -> 3 outliers were removed (73.75 ms..80.04 ms)

## Legends

amountPeople   : Value of the 'amountPeople' parameter

amountAccounts : Value of the 'amountAccounts' parameter

Mean           : Arithmetic mean of all measurements

Error          : Half of 99.9% confidence interval

StdDev         : Standard deviation of all measurements

Median         : Value separating the higher half of all measurements (50th percentile)

Gen0           : GC Generation 0 collects per 1000 operations

Gen1           : GC Generation 1 collects per 1000 operations

Gen2           : GC Generation 2 collects per 1000 operations

Allocated      : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

1 ns          : 1 Nanosecond (0.000000001 sec)

1 ms           : 1 Millisecond (0.001 sec)
