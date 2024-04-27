# BenchMarks most used mapper libraries

## Results

| Method     | Mean     | Error    | StdDev   | Gen0   | Allocated |
|----------- |---------:|---------:|---------:|-------:|----------:|
| Mapster    | 55.24 ns | 0.408 ns | 0.362 ns | 0.0446 |     280 B |
| AutoMapper | 91.33 ns | 1.124 ns | 1.878 ns | 0.0446 |     280 B |
| Native     | 91.59 ns | 1.778 ns | 1.902 ns | 0.0560 |     352 B |

If you want to test the results or change the data just clone and enjoy.

## Legends

Mean      : Arithmetic mean of all measurements

Error     : Half of 99.9% confidence interval

StdDev    : Standard deviation of all measurements

Median    : Value separating the higher half of all measurements (50th percentile)

Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

1 us      : 1 Microsecond (0.000001 sec)
