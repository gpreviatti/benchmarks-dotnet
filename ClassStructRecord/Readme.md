# BenchMarks between .net complex object types

## Summary

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.26100.3037)

11th Gen Intel Core i5-11400H 2.70GHz, 1 CPU, 12 logical and 6 physical cores

.NET SDK=8.0.308
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX2

### Test 1

|         Method |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|--------------- |----------:|----------:|----------:|-------:|----------:|
| RecordsStructs | 0.0157 ns | 0.0074 ns | 0.0069 ns |      - |         - |
|        Structs | 0.2571 ns | 0.0155 ns | 0.0145 ns |      - |         - |
|        Classes | 4.7515 ns | 0.1593 ns | 0.2573 ns | 0.0115 |      72 B |
|    SeleadClass | 4.7760 ns | 0.1618 ns | 0.2703 ns | 0.0115 |      72 B |
|        Records | 4.8245 ns | 0.1356 ns | 0.1268 ns | 0.0115 |      72 B |

### Test 2

|         Method |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|--------------- |----------:|----------:|----------:|-------:|----------:|
| RecordsStructs | 0.0129 ns | 0.0142 ns | 0.0126 ns |      - |         - |
|        Structs | 0.2540 ns | 0.0109 ns | 0.0102 ns |      - |         - |
|        Classes | 4.6192 ns | 0.0833 ns | 0.0779 ns | 0.0115 |      72 B |
|        Records | 4.6223 ns | 0.0906 ns | 0.0757 ns | 0.0115 |      72 B |
|    SeleadClass | 5.0031 ns | 0.1636 ns | 0.3304 ns | 0.0115 |      72 B |

### Test 3

|         Method |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|--------------- |----------:|----------:|----------:|-------:|----------:|
| RecordsStructs | 0.0493 ns | 0.0313 ns | 0.0348 ns |      - |         - |
|        Structs | 0.1985 ns | 0.0364 ns | 0.0447 ns |      - |         - |
|        Classes | 4.6268 ns | 0.0834 ns | 0.0781 ns | 0.0115 |      72 B |
|    SeleadClass | 4.6900 ns | 0.1521 ns | 0.1348 ns | 0.0115 |      72 B |
|        Records | 4.9234 ns | 0.1650 ns | 0.3517 ns | 0.0115 |      72 B |


## Legends
  Mean      : Arithmetic mean of all measurements

  Error     : Half of 99.9% confidence interval

  StdDev    : Standard deviation of all measurements

  Gen0      : GC Generation 0 collects per 1000 operations

  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

  1 ns      : 1 Nanosecond (0.000000001 sec)