# BenchMarks most used mapper libraries

# Hardware configuration

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3)

11th Gen Intel Core i5-11400H 2.70GHz, 1 CPU, 12 logical and 6 physical cores

.NET SDK 8.0.204

[Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

DefaultJob : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

## Results

| Method     | amountPeople | amountAccounts | Mean      | Error     | StdDev    | Gen0       | Gen1      | Gen2     | Allocated |
|----------- |------------- |--------------- |----------:|----------:|----------:|-----------:|----------:|---------:|----------:|
| Mapster    | 1            | 10             |  1.192 ms | 0.0074 ms | 0.0069 ms |   250.0000 |  246.0938 |        - |    1.5 MB |
| Native     | 1            | 10             |  1.200 ms | 0.0095 ms | 0.0089 ms |   250.0000 |  246.0938 |        - |   1.51 MB |
| AutoMapper | 1            | 10             |  1.201 ms | 0.0235 ms | 0.0345 ms |   250.0000 |  246.0938 |        - |    1.5 MB |
| AutoMapper | 10           | 100            |  6.681 ms | 0.0679 ms | 0.0602 ms |  1375.0000 |  625.0000 |        - |   8.41 MB |
| Mapster    | 10           | 100            |  6.988 ms | 0.0995 ms | 0.0831 ms |  1421.8750 |  640.6250 |  31.2500 |   8.39 MB |
| Native     | 10           | 100            |  7.197 ms | 0.0586 ms | 0.0548 ms |  1406.2500 |  625.0000 |  31.2500 |    8.4 MB |
| Native     | 100          | 200            | 67.938 ms | 1.3431 ms | 1.6495 ms | 13500.0000 | 3250.0000 | 500.0000 |  78.54 MB |
| Mapster    | 100          | 200            | 69.123 ms | 1.3488 ms | 1.1263 ms | 13500.0000 | 3250.0000 | 500.0000 |  78.52 MB |
| AutoMapper | 100          | 200            | 69.383 ms | 0.4647 ms | 0.3880 ms | 13500.0000 | 3000.0000 | 500.0000 |  78.77 MB |

## Hints

Outliers
MappersBenchmarks.AutoMapper: Default -> 3 outliers were removed (1.39 ms..1.53 ms)

MappersBenchmarks.AutoMapper: Default -> 1 outlier  was  removed (7.41 ms)

MappersBenchmarks.Mapster: Default    -> 2 outliers were removed, 5 outliers were detected (6.84 ms..6.86 ms, 7.21 ms, 7.24 ms)

MappersBenchmarks.Mapster: Default    -> 3 outliers were removed, 4 outliers were detected (65.64 ms, 72.34 ms..80.93 ms)

MappersBenchmarks.AutoMapper: Default -> 2 outliers were removed, 3 outliers were detected (68.50 ms, 73.44 ms, 73.74 ms)

## Legends

Mean      : Arithmetic mean of all measurements

Error     : Half of 99.9% confidence interval

StdDev    : Standard deviation of all measurements

Median    : Value separating the higher half of all measurements (50th percentile)

Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

1 us      : 1 Microsecond (0.000001 sec)

If you want to test the results or change the data just clone and enjoy.
