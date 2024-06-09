# BenchMarks beetween Most Common Database frameworks for dotnet

Testes libraries
- Entity Framework, Version: 8.06
- Dapper, Version: 2.1.35

## Results of the benchmarks

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3593/23H2/2023Update/SunValley3)

11th Gen Intel Core i5-11400H 2.70GHz, 1 CPU, 12 logical and 6 physical cores

.NET SDK 8.0.301
  [Host]     : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

  DefaultJob : .NET 8.0.6 (8.0.624.26715), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

| Method                                    | Mean     | Error    | StdDev   | Median   | Gen0   | Allocated |
|------------------------------------------ |---------:|---------:|---------:|---------:|-------:|----------:|
| 'Dapper Select One With Fields'           | 423.0 us |  5.92 us |  7.48 us | 423.2 us |      - |    6.1 KB |
| 'Dapper Select One'                       | 439.9 us |  8.75 us | 22.60 us | 431.0 us | 0.9766 |   6.38 KB |
| 'Entity Framework Select One'             | 482.0 us |  9.53 us | 15.65 us | 477.3 us | 0.9766 |  10.34 KB |
| 'Entity Framework Select One No Tracking' | 507.8 us | 17.77 us | 48.94 us | 489.3 us | 0.9766 |  10.91 KB |

### Legends
  Mean      : Arithmetic mean of all measurements

  Error     : Half of 99.9% confidence interval

  StdDev    : Standard deviation of all measurements

  Median    : Value separating the higher half of all measurements (50th percentile)

  Gen0      : GC Generation 0 collects per 1000 operations

  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

  1 us      : 1 Microsecond (0.000001 sec)

