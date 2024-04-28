# BenchMarks most used mapper libraries

# Hardware configuration

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)

11th Gen Intel Core i5-11400H 2.70GHz, 1 CPU, 12 logical and 6 physical cores

.NET SDK 8.0.204

[Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

## Simple mapping results

| Method     | Mean     | Error    | StdDev   | Gen0   | Allocated |
|----------- |---------:|---------:|---------:|-------:|----------:|
| Mapster    | 58.63 ns | 0.507 ns | 0.450 ns | 0.0446 |     280 B |
| Native     | 87.87 ns | 1.225 ns | 1.086 ns | 0.0560 |     352 B |
| AutoMapper | 97.79 ns | 2.243 ns | 6.398 ns | 0.0446 |     280 B |

### Hints

Outliers

MappersBenchmarks.Mapster: Default    -> 1 outlier  was  removed (63.25 ns)

MappersBenchmarks.Native: Default     -> 1 outlier  was  removed (95.29 ns)

MappersBenchmarks.AutoMapper: Default -> 6 outliers were removed (125.40 ns..141.40 ns)

## Mapping lists results

| Method     | amountPeople | amountAccounts | Mean      | Error     | StdDev    | Median    | Gen0       | Gen1      | Gen2     | Allocated |
|----------- |------------- |--------------- |----------:|----------:|----------:|----------:|-----------:|----------:|---------:|----------:|
| AutoMapper | 1            | 10             |  1.313 ms | 0.0145 ms | 0.0135 ms |  1.317 ms |   250.0000 |  246.0938 |        - |    1.5 MB |
| Native     | 1            | 10             |  1.314 ms | 0.0135 ms | 0.0126 ms |  1.310 ms |   250.0000 |  246.0938 |        - |   1.51 MB |
| Mapster    | 1            | 10             |  1.316 ms | 0.0102 ms | 0.0096 ms |  1.315 ms |   250.0000 |  246.0938 |        - |    1.5 MB |
| AutoMapper | 10           | 100            |  7.845 ms | 0.1531 ms | 0.1572 ms |  7.874 ms |  1421.8750 |  609.3750 |  31.2500 |   8.41 MB |
| Native     | 10           | 100            |  7.882 ms | 0.1573 ms | 0.2496 ms |  8.062 ms |  1406.2500 |  625.0000 |  31.2500 |    8.4 MB |
| Mapster    | 10           | 100            |  8.044 ms | 0.1536 ms | 0.1509 ms |  8.108 ms |  1406.2500 |  625.0000 |  31.2500 |   8.39 MB |
| AutoMapper | 100          | 200            | 72.820 ms | 1.4452 ms | 2.8187 ms | 73.629 ms | 13333.3333 | 2666.6667 | 333.3333 |  78.77 MB |
| Mapster    | 100          | 200            | 73.818 ms | 1.4724 ms | 3.4994 ms | 74.524 ms | 13333.3333 | 3000.0000 | 333.3333 |  78.52 MB |
| Native     | 100          | 200            | 74.210 ms | 1.4637 ms | 2.6017 ms | 75.042 ms | 13333.3333 | 3000.0000 | 333.3333 |  78.54 MB |

### Warnings
MultimodalDistribution

MappersListsBenchmarks.Native: Default     -> It seems that the distribution is bimodal (mValue = 3.67)

MappersListsBenchmarks.AutoMapper: Default -> It seems that the distribution is bimodal (mValue = 3.91)

MappersListsBenchmarks.Mapster: Default    -> It seems that the distribution is bimodal (mValue = 3.93)

MappersListsBenchmarks.Native: Default     -> It seems that the distribution can have several modes (mValue = 2.92)

### Hints

Outliers

MappersListsBenchmarks.Mapster: Default -> 1 outlier  was  removed, 3 outliers were detected (7.61 ms, 7.76 ms, 8.58 ms)

MappersListsBenchmarks.Mapster: Default -> 2 outliers were removed (89.86 ms, 91.87 ms)

MappersListsBenchmarks.Native: Default  -> 1 outlier  was  removed (89.84 ms)


## Legends

Mean      : Arithmetic mean of all measurements

Error     : Half of 99.9% confidence interval

StdDev    : Standard deviation of all measurements

Median    : Value separating the higher half of all measurements (50th percentile)

Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

1 us      : 1 Microsecond (0.000001 sec)

If you want to test the results or change the data just clone and enjoy.
