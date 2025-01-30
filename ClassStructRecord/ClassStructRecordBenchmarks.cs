using BenchmarkDotNet.Attributes;

namespace ClassStructRecord;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class ClassStructRecordBenchmarks
{
    [Benchmark(Description = "Classes")]
    public PersonClass Classes() => new();

    [Benchmark(Description = "SeleadClass")]
    public PersonSeleadClass SeleadClass() => new();

    [Benchmark(Description = "Records")]
    public PersonRecord Records() => new();

    [Benchmark(Description = "RecordsStructs")]
    public PersonRecordStruct RecordsStructs() => new();

    [Benchmark(Description = "Structs")]
    public PersonStruct Structs() => new();
}