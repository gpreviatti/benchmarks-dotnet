# BenchMarks serializing and deserializing objects with System.Text.Json and Newtonsoft.Json

## Results Deserialization

|                                             Method | amountPeople | amountAccounts |           Mean |         Error |        StdDev |         Median |      Gen 0 |     Gen 1 |     Gen 2 |    Allocated |
|--------------------------------------------------- |------------- |--------------- |---------------:|--------------:|--------------:|---------------:|-----------:|----------:|----------:|-------------:|
|                     'Deserialize with Protobuffer' |            1 |             10 |       5.638 us |     0.1119 us |     0.3209 us |       5.616 us |     2.0752 |    0.0916 |         - |     12.76 KB |
|                     'Deserialize with Protobuffer' |           10 |            100 |     998.925 us |     6.7186 us |     6.2846 us |     999.073 us |   128.9063 |   74.2188 |   37.1094 |    744.35 KB |
|    'Deserialize object with JsonSeriealizer Async' |            1 |             10 |   2,044.080 us |    21.9917 us |    19.4951 us |   2,040.547 us |   382.8125 |  226.5625 |         - |   2382.21 KB |
|                 'Deserialize with Protobuffer-net' |            1 |             10 |   2,118.045 us |    41.5201 us |    62.1453 us |   2,126.375 us |   382.8125 |  242.1875 |         - |   2368.06 KB |
|          'Deserialize object with JsonSeriealizer' |            1 |             10 |   2,131.175 us |    41.7044 us |    57.0854 us |   2,124.323 us |   382.8125 |  250.0000 |         - |   2372.59 KB |
| 'Deserialize object with JsonConvert (NewtonSoft)' |            1 |             10 |   2,300.899 us |    82.9622 us |   244.6160 us |   2,230.401 us |   382.8125 |  250.0000 |         - |   2390.71 KB |
|                 'Deserialize with Protobuffer-net' |           10 |            100 |  17,128.400 us |   339.4705 us |   594.5553 us |  17,174.638 us |  2846.1538 |  769.2308 |   76.9231 |  17421.72 KB |
|          'Deserialize object with JsonSeriealizer' |           10 |            100 |  17,798.473 us |   355.7111 us |   852.2610 us |  17,653.588 us |  2833.3333 |  666.6667 |   83.3333 |  17599.93 KB |
|    'Deserialize object with JsonSeriealizer Async' |           10 |            100 |  18,337.641 us |   361.0854 us |   354.6341 us |  18,271.204 us |  3071.4286 |  785.7143 |  214.2857 |   18362.7 KB |
| 'Deserialize object with JsonConvert (NewtonSoft)' |           10 |            100 |  18,927.644 us |   374.6461 us |   431.4430 us |  18,838.208 us |  3166.6667 |  916.6667 |  250.0000 |  18882.19 KB |
|                     'Deserialize with Protobuffer' |          100 |            200 |  25,485.875 us |   509.1789 us | 1,376.5949 us |  25,334.581 us |  2625.0000 | 1593.7500 |  562.5000 |  14715.99 KB |
|                 'Deserialize with Protobuffer-net' |          100 |            200 | 160,108.308 us | 2,139.9759 us | 2,856.8063 us | 160,065.300 us | 27000.0000 | 3000.0000 |         - |  174524.8 KB |
|    'Deserialize object with JsonSeriealizer Async' |          100 |            200 | 172,549.561 us | 3,299.2319 us | 4,172.4720 us | 171,267.800 us | 29000.0000 | 4000.0000 | 1000.0000 | 192354.84 KB |
|          'Deserialize object with JsonSeriealizer' |          100 |            200 | 176,799.348 us | 3,498.0597 us | 7,224.0999 us | 175,879.650 us | 27000.0000 | 3000.0000 |         - | 178801.52 KB |
| 'Deserialize object with JsonConvert (NewtonSoft)' |          100 |            200 | 187,486.431 us | 3,661.2058 us | 3,595.7936 us | 186,476.400 us | 31000.0000 | 5000.0000 | 1000.0000 | 204098.57 KB |

## Results Serialization

|                                           Method | amountPeople | amountAccounts |           Mean |         Error |        StdDev |      Gen 0 |     Gen 1 |   Gen 2 |    Allocated |
|------------------------------------------------- |------------- |--------------- |---------------:|--------------:|--------------:|-----------:|----------:|--------:|-------------:|
|                     'Serialize with Protobuffer' |            1 |             10 |       3.136 us |     0.0211 us |     0.0176 us |     0.7210 |    0.0114 |       - |      4.43 KB |
|                     'Serialize with Protobuffer' |           10 |            100 |     310.164 us |     4.7838 us |     4.4748 us |    75.6836 |   57.1289 | 31.2500 |    378.93 KB |
| 'Serialize object with JsonConvert (NewtonSoft)' |            1 |             10 |   1,938.626 us |    20.7856 us |    19.4429 us |   382.8125 |  257.8125 |       - |   2374.97 KB |
|     'Serialize object with JsonSeriealizerAsync' |            1 |             10 |   1,966.474 us |    37.9367 us |    35.4861 us |   382.8125 |  250.0000 |       - |    2365.6 KB |
|                 'Serialize with Protobuffer-net' |            1 |             10 |   1,978.336 us |    38.9530 us |    54.6067 us |   382.8125 |  242.1875 |       - |   2365.51 KB |
|          'Serialize object with JsonSeriealizer' |            1 |             10 |   1,999.924 us |    32.2517 us |    28.5903 us |   382.8125 |  242.1875 |       - |    2366.9 KB |
|                     'Serialize with Protobuffer' |          100 |            200 |   7,317.063 us |   143.7023 us |   153.7599 us |   914.0625 |  851.5625 | 31.2500 |   7522.93 KB |
|          'Serialize object with JsonSeriealizer' |           10 |            100 |  15,122.769 us |   275.9532 us |   358.8171 us |  2785.7143 |  642.8571 | 71.4286 |  17253.32 KB |
|                 'Serialize with Protobuffer-net' |           10 |            100 |  16,098.777 us |   280.4103 us |   218.9259 us |  2833.3333 |  666.6667 | 83.3333 |  17246.76 KB |
| 'Serialize object with JsonConvert (NewtonSoft)' |           10 |            100 |  16,850.602 us |   329.5242 us |   594.2002 us |  2937.5000 |  750.0000 | 93.7500 |  17822.25 KB |
|     'Serialize object with JsonSeriealizerAsync' |           10 |            100 |  17,057.296 us |   339.4220 us |   940.5367 us |  2843.7500 |  687.5000 | 93.7500 |  17393.24 KB |
|                 'Serialize with Protobuffer-net' |          100 |            200 | 157,419.591 us | 3,141.6983 us | 3,858.2876 us | 27000.0000 | 3000.0000 |       - | 171093.06 KB |
|     'Serialize object with JsonSeriealizerAsync' |          100 |            200 | 159,016.853 us | 3,115.0357 us | 5,536.9728 us | 27000.0000 | 3000.0000 |       - |  173349.3 KB |
|          'Serialize object with JsonSeriealizer' |          100 |            200 | 160,421.044 us | 3,151.9832 us | 5,683.6759 us | 27000.0000 | 3000.0000 |       - | 172048.41 KB |
| 'Serialize object with JsonConvert (NewtonSoft)' |          100 |            200 | 160,972.700 us | 2,472.9889 us | 2,748.7206 us | 28000.0000 | 3000.0000 |       - | 183190.95 KB |


If you want to test the results or change the data just clone and enjoy.

## Legends

Mean      : Arithmetic mean of all measurements

Error     : Half of 99.9% confidence interval

StdDev    : Standard deviation of all measurements

Median    : Value separating the higher half of all measurements (50th percentile)

Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

1 us      : 1 Microsecond (0.000001 sec)
