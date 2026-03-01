using BenchmarkDotNet.Attributes;

namespace ListsAndSpans;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class CopyListsAndSpansBenchmarks
{
    [Params(1000, 10000, 100000)]
    public int N;

    private int[] array = null!;
    private List<int> list = null!;
    private ICollection<int> collection = null!;
    private IEnumerable<int> enumerable = null!;

    [GlobalSetup]
    public void Setup()
    {
        array = new int[N];
        for (int i = 0; i < N; i++)
            array[i] = i;

        list = [.. array];
        collection = list;
        enumerable = list;
    }

    [Benchmark(Description = "Copy array -> span")]
    public void CopyArrayToSpan()
    {
        var dest = new int[N];
        array.AsSpan().CopyTo(dest);
    }

    [Benchmark(Description = "Copy list -> array")]
    public void CopyListToArray()
    {
        var dest = new int[N];
        list.CopyTo(dest);
    }
}