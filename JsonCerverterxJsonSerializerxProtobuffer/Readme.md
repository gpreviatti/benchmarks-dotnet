# BenchMarks serializing and deserializing objects with System.Text.Json and Newtonsoft.Json

## Results Deserialization

| Method                                             | amountPeople | amountAccounts | Mean       | Error     | StdDev     | Gen0       | Gen1      | Gen2      | Allocated |
|--------------------------------------------------- |------------- |--------------- |-----------:|----------:|-----------:|-----------:|----------:|----------:|----------:|
| 'Deserialize object with JsonSeriealizer'          | 1            | 10             |   2.114 ms | 0.0408 ms |  0.0419 ms |   382.8125 |  242.1875 |         - |   2.32 MB |
| 'Deserialize with Protobuffer'                     | 1            | 10             |   2.170 ms | 0.0382 ms |  0.0548 ms |   382.8125 |  234.3750 |         - |   2.32 MB |
| 'Deserialize object with JsonConvert (NewtonSoft)' | 1            | 10             |   2.172 ms | 0.0401 ms |  0.0535 ms |   382.8125 |  250.0000 |         - |   2.33 MB |
| 'Deserialize object with JsonSeriealizer Async'    | 1            | 10             |   2.231 ms | 0.0446 ms |  0.0870 ms |   382.8125 |  250.0000 |         - |   2.33 MB |
| 'Deserialize with Protobuffer'                     | 10           | 100            |  17.430 ms | 0.3406 ms |  0.4307 ms |  2937.5000 |  781.2500 |   93.7500 |  17.22 MB |
| 'Deserialize object with JsonSeriealizer'          | 10           | 100            |  17.751 ms | 0.3524 ms |  0.6355 ms |  2846.1538 |  692.3077 |   76.9231 |  17.18 MB |
| 'Deserialize object with JsonSeriealizer Async'    | 10           | 100            |  20.850 ms | 0.4333 ms |  1.2434 ms |  3076.9231 | 1000.0000 |  230.7692 |  17.93 MB |
| 'Deserialize object with JsonConvert (NewtonSoft)' | 10           | 100            |  21.141 ms | 0.6575 ms |  1.9387 ms |  3166.6667 |  916.6667 |  250.0000 |  18.44 MB |
| 'Deserialize with Protobuffer'                     | 100          | 200            | 173.368 ms | 3.4526 ms |  5.6728 ms | 29000.0000 | 5500.0000 | 1000.0000 | 174.27 MB |
| 'Deserialize object with JsonSeriealizer'          | 100          | 200            | 176.887 ms | 2.8846 ms |  4.6582 ms | 27000.0000 | 3000.0000 |         - | 174.65 MB |
| 'Deserialize object with JsonConvert (NewtonSoft)' | 100          | 200            | 190.851 ms | 4.3196 ms | 12.5321 ms | 31000.0000 | 5000.0000 | 1000.0000 | 199.35 MB |
| 'Deserialize object with JsonSeriealizer Async'    | 100          | 200            | 193.663 ms | 3.8528 ms |  9.5231 ms | 30000.0000 | 5000.0000 | 2000.0000 | 187.82 MB |

## Results Serialization

| Method                                           | amountPeople | amountAccounts | Mean       | Error     | StdDev    | Gen0       | Gen1      | Gen2     | Allocated |
|------------------------------------------------- |------------- |--------------- |-----------:|----------:|----------:|-----------:|----------:|---------:|----------:|
| 'Serialize object with JsonSeriealizer'          | 1            | 10             |   2.030 ms | 0.0358 ms | 0.0536 ms |   382.8125 |  250.0000 |        - |   2.31 MB |
| 'Serialize with Protobuffer'                     | 1            | 10             |   2.030 ms | 0.0404 ms | 0.0807 ms |   382.8125 |  242.1875 |        - |   2.31 MB |
| 'Serialize object with JsonSeriealizerAsync'     | 1            | 10             |   2.030 ms | 0.0403 ms | 0.0565 ms |   382.8125 |  242.1875 |        - |   2.31 MB |
| 'Serialize object with JsonConvert (NewtonSoft)' | 1            | 10             |   2.094 ms | 0.0406 ms | 0.0866 ms |   382.8125 |  257.8125 |        - |   2.32 MB |
| 'Serialize with Protobuffer'                     | 10           | 100            |  16.758 ms | 0.3340 ms | 0.8131 ms |  2857.1429 |  642.8571 |  71.4286 |  16.95 MB |
| 'Serialize object with JsonConvert (NewtonSoft)' | 10           | 100            |  16.776 ms | 0.3253 ms | 0.3995 ms |  2923.0769 |  769.2308 |  76.9231 |  17.41 MB |
| 'Serialize object with JsonSeriealizerAsync'     | 10           | 100            |  16.835 ms | 0.2353 ms | 0.2201 ms |  2875.0000 |  750.0000 |  93.7500 |  16.99 MB |
| 'Serialize object with JsonSeriealizer'          | 10           | 100            |  16.940 ms | 0.3203 ms | 0.7422 ms |  2843.7500 |  750.0000 |  93.7500 |  16.85 MB |
| 'Serialize object with JsonSeriealizerAsync'     | 100          | 200            | 157.552 ms | 2.9680 ms | 3.1757 ms | 27500.0000 | 3000.0000 | 500.0000 |  169.3 MB |
| 'Serialize object with JsonSeriealizer'          | 100          | 200            | 158.790 ms | 1.4767 ms | 1.3091 ms | 27000.0000 | 3000.0000 |        - | 168.04 MB |
| 'Serialize with Protobuffer'                     | 100          | 200            | 159.209 ms | 2.2055 ms | 1.9551 ms | 27000.0000 | 3000.0000 |        - | 169.09 MB |
| 'Serialize object with JsonConvert (NewtonSoft)' | 100          | 200            | 165.813 ms | 3.1189 ms | 5.2961 ms | 28000.0000 | 3000.0000 |        - | 178.89 MB |


If you want to test the results or change the data just clone and enjoy.

## Legends

Mean      : Arithmetic mean of all measurements

Error     : Half of 99.9% confidence interval

StdDev    : Standard deviation of all measurements

Median    : Value separating the higher half of all measurements (50th percentile)

Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

1 us      : 1 Microsecond (0.000001 sec)
