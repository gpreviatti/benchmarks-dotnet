# BenchMarks most used mapper libraries

# Hardware configuration

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)

11th Gen Intel Core i5-11400H 2.70GHz, 1 CPU, 12 logical and 6 physical cores

.NET SDK 8.0.204

[Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

## Simple mapping results

| Method                       | Mean      | Error    | StdDev   | Median    | Gen0   | Allocated |
|----------------------------- |----------:|---------:|---------:|----------:|-------:|----------:|
| Mapster                      |  60.67 ns | 1.212 ns | 1.777 ns |  60.10 ns | 0.0446 |     280 B |
| MapsterLookingForConstructor |  63.33 ns | 1.261 ns | 2.923 ns |  63.49 ns | 0.0446 |     280 B |
| Native                       |  84.78 ns | 1.730 ns | 4.177 ns |  82.87 ns | 0.0560 |     352 B |
| AutoMapper                   | 102.23 ns | 2.059 ns | 2.529 ns | 102.84 ns | 0.0446 |     280 B |

### Hints

Outliers

MappersBenchmarks.Mapster: Default                      -> 1 outlier  was  removed (67.03 ns)
  
MappersBenchmarks.MapsterLookingForConstructor: Default -> 2 outliers were removed, 4 outliers were detected (57.27 ns, 57.27 ns, 73.93 ns, 75.74 ns)
  
 MappersBenchmarks.Native: Default                       -> 2 outliers were removed (100.70 ns, 101.55 ns)

## Mapping lists results

| Method                       | amountPeople | amountAccounts | Mean      | Error     | StdDev    | Median    | Gen0       | Gen1      | Gen2     | Allocated |
|----------------------------- |------------- |--------------- |----------:|----------:|----------:|----------:|-----------:|----------:|---------:|----------:|
| Native                       | 1            | 10             |  1.274 ms | 0.0176 ms | 0.0147 ms |  1.272 ms |   250.0000 |  246.0938 |        - |   1.51 MB |
| MapsterLookingForConstructor | 1            | 10             |  1.292 ms | 0.0258 ms | 0.0286 ms |  1.292 ms |   250.0000 |  246.0938 |        - |    1.5 MB |
| Mapster                      | 1            | 10             |  1.315 ms | 0.0147 ms | 0.0123 ms |  1.314 ms |   250.0000 |  246.0938 |        - |    1.5 MB |
| AutoMapper                   | 1            | 10             |  1.368 ms | 0.0222 ms | 0.0197 ms |  1.362 ms |   250.0000 |  246.0938 |        - |    1.5 MB |
| AutoMapper                   | 10           | 100            |  7.573 ms | 0.1145 ms | 0.1015 ms |  7.542 ms |  1375.0000 |  625.0000 |        - |   8.41 MB |
| MapsterLookingForConstructor | 10           | 100            |  7.935 ms | 0.1480 ms | 0.1312 ms |  7.919 ms |  1421.8750 |  640.6250 |  31.2500 |   8.39 MB |
| Native                       | 10           | 100            |  8.005 ms | 0.1500 ms | 0.1605 ms |  8.062 ms |  1406.2500 |  625.0000 |  31.2500 |    8.4 MB |
| Mapster                      | 10           | 100            |  8.017 ms | 0.1583 ms | 0.1555 ms |  7.970 ms |  1421.8750 |  640.6250 |  31.2500 |   8.39 MB |
| Mapster                      | 100          | 200            | 73.459 ms | 1.4433 ms | 2.5655 ms | 74.931 ms | 13333.3333 | 3000.0000 | 333.3333 |  78.52 MB |
| Native                       | 100          | 200            | 73.992 ms | 1.4687 ms | 2.2428 ms | 75.078 ms | 13333.3333 | 3000.0000 | 333.3333 |  78.54 MB |
| AutoMapper                   | 100          | 200            | 75.452 ms | 0.6480 ms | 0.6061 ms | 75.599 ms | 13333.3333 | 2666.6667 | 333.3333 |  78.77 MB |
| MapsterLookingForConstructor | 100          | 200            | 76.433 ms | 1.4834 ms | 3.4379 ms | 76.099 ms | 13500.0000 | 3250.0000 | 500.0000 |  78.52 MB |

### Warnings
MultimodalDistribution

MappersListsBenchmarks.Native: Default                       -> 2 outliers were removed (1.33 ms, 1.34 ms)
MappersListsBenchmarks.MapsterLookingForConstructor: Default -> 1 outlier  was  removed (1.56 ms)
MappersListsBenchmarks.Mapster: Default                      -> 2 outliers were removed (1.37 ms, 1.40 ms)
MappersListsBenchmarks.AutoMapper: Default                   -> 1 outlier  was  removed (1.44 ms)
MappersListsBenchmarks.AutoMapper: Default                   -> 1 outlier  was  removed (7.92 ms)
MappersListsBenchmarks.MapsterLookingForConstructor: Default -> 1 outlier  was  removed (8.30 ms)
MappersListsBenchmarks.Native: Default                       -> 2 outliers were removed, 5 outliers were detected (7.63 ms..7.73 ms, 8.61 ms, 8.71 ms)
MappersListsBenchmarks.Mapster: Default                      -> 1 outlier  was  removed (88.38 ms)
MappersListsBenchmarks.Native: Default                       -> 4 outliers were removed (91.61 ms..105.69 ms)
MappersListsBenchmarks.AutoMapper: Default                   -> 1 outlier  was  detected (73.86 ms)
MappersListsBenchmarks.MapsterLookingForConstructor: Default -> 5 outliers were removed (86.74 ms..100.90 ms)

### Hints

Outliers

MappersListsBenchmarks.Mapster: Default -> 1 outlier  was  removed, 3 outliers were detected (7.61 ms, 7.76 ms, 8.58 ms)

MappersListsBenchmarks.Mapster: Default -> 2 outliers were removed (89.86 ms, 91.87 ms)

MappersListsBenchmarks.Native: Default  -> 1 outlier  was  removed (89.84 ms)


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
