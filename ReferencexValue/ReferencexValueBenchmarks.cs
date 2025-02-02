using BenchmarkDotNet.Attributes;

namespace ReferencexValue;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class ReferencexValueBenchmarks
{
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    [Arguments(100, 500)]
    [Arguments(1000000, 5000000)]
    [Benchmark(Description = "With Value")]
    public int WithValue(int value1, int value2) => SumWithValue(value1, value2);

    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    [Arguments(100, 500)]
    [Arguments(1000000, 5000000)]
    [Benchmark(Description = "With Ref")]
    public int WithRef(ref int value1, ref int value2) => SumWithRef(ref value1, ref value2);

    private int SumWithValue(int value1, int value2) => value1 + value2;
    private int SumWithRef(ref int value1, ref int value2) => value1 + value2;
}