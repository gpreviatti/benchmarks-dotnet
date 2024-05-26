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
| MapsterLookingForConstructor |  64.88 ns | 1.286 ns | 2.902 ns | 0.0446 |     280 B |
| Mapster                      |  66.37 ns | 1.615 ns | 4.687 ns | 0.0446 |     280 B |
| Native                       |  89.93 ns | 1.813 ns | 3.536 ns | 0.0560 |     352 B |
| AutoMapper                   | 101.56 ns | 2.031 ns | 2.977 ns | 0.0446 |     280 B |

### Hints

Outliers

MappersBenchmarks.MapsterLookingForConstructor: Default -> 2 outliers were removed (74.52 ns, 75.49 ns)

MappersBenchmarks.Mapster: Default                      -> 3 outliers were removed (79.88 ns..83.38 ns)

MappersBenchmarks.Native: Default                       -> 1 outlier  was  removed (112.52 ns)

## Mapping lists results

| Method                       | amountPeople | amountAccounts | Mean      | Error     | StdDev    | Median    | Gen0       | Gen1      | Gen2     | Allocated |
|----------------------------- |------------- |--------------- |----------:|----------:|----------:|----------:|-----------:|----------:|---------:|----------:|
| MapsterLookingForConstructor | 1            | 10             |  1.253 ms | 0.0109 ms | 0.0085 ms |  1.253 ms |   250.0000 |  246.0938 |        - |    1.5 MB |
| Mapster                      | 1            | 10             |  1.274 ms | 0.0227 ms | 0.0177 ms |  1.271 ms |   250.0000 |  246.0938 |        - |    1.5 MB |
| Native                       | 1            | 10             |  1.293 ms | 0.0255 ms | 0.0497 ms |  1.268 ms |   250.0000 |  246.0938 |        - |   1.51 MB |
| AutoMapper                   | 1            | 10             |  1.401 ms | 0.0281 ms | 0.0806 ms |  1.385 ms |   250.0000 |  246.0938 |        - |   1.51 MB |
| Native                       | 10           | 100            |  8.023 ms | 0.1491 ms | 0.1245 ms |  8.039 ms |  1406.2500 |  625.0000 |  31.2500 |    8.4 MB |
| MapsterLookingForConstructor | 10           | 100            |  9.280 ms | 0.4008 ms | 1.1627 ms |  9.177 ms |  1421.8750 |  640.6250 |  31.2500 |   8.39 MB |
| Mapster                      | 10           | 100            |  9.411 ms | 0.2757 ms | 0.8043 ms |  9.177 ms |  1421.8750 |  640.6250 |  31.2500 |   8.39 MB |
| AutoMapper                   | 10           | 100            |  9.726 ms | 0.1943 ms | 0.4012 ms |  9.678 ms |  1421.8750 |  625.0000 |  31.2500 |   8.41 MB |
| MapsterLookingForConstructor | 100          | 200            | 83.670 ms | 1.7074 ms | 4.9536 ms | 83.132 ms | 13333.3333 | 3000.0000 | 333.3333 |  78.52 MB |
| Native                       | 100          | 200            | 83.711 ms | 1.6645 ms | 4.5285 ms | 83.284 ms | 13333.3333 | 3000.0000 | 333.3333 |  78.55 MB |
| AutoMapper                   | 100          | 200            | 83.970 ms | 1.6683 ms | 4.4531 ms | 83.977 ms | 13333.3333 | 2666.6667 | 333.3333 |  78.77 MB |
| Mapster                      | 100          | 200            | 86.039 ms | 1.7039 ms | 4.6356 ms | 85.576 ms | 13500.0000 | 3250.0000 | 500.0000 |  78.52 MB |

### Hints

Outliers

MappersListsBenchmarks.MapsterLookingForConstructor: Default -> 3 outliers were removed (1.31 ms..1.39 ms)

MappersListsBenchmarks.Mapster: Default                      -> 3 outliers were removed (1.36 ms..1.37 ms)

MappersListsBenchmarks.AutoMapper: Default                   -> 5 outliers were removed (1.61 ms..1.81 ms)

MappersListsBenchmarks.Native: Default                       -> 2 outliers were removed, 3 outliers were detected (7.63 ms, 8.41 ms, 8.46 ms)

MappersListsBenchmarks.MapsterLookingForConstructor: Default -> 3 outliers were removed (13.29 ms..13.86 ms)

MappersListsBenchmarks.Mapster: Default                      -> 2 outliers were removed (11.90 ms, 12.48 ms)

MappersListsBenchmarks.AutoMapper: Default                   -> 3 outliers were removed (10.87 ms..11.02 ms)

MappersListsBenchmarks.MapsterLookingForConstructor: Default -> 3 outliers were removed (98.38 ms..104.76 ms)

MappersListsBenchmarks.Native: Default                       -> 1 outlier  was  removed (98.95 ms)

MappersListsBenchmarks.AutoMapper: Default                   -> 4 outliers were removed (100.50 ms..109.20 ms)

MappersListsBenchmarks.Mapster: Default                      -> 1 outlier  was  removed (100.83 ms)

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
