using BenchmarkDotNet.Attributes;

namespace ListsAndSpans;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class RandomAccessListsAndSpansBenchmarks
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

    [Benchmark(Description = "Random access array")]
    public int RandomArray()
    {
        int sum = 0;
        int idx = 0;
        for (int i = 0; i < N; i++)
        {
            idx = (idx + 37) % N;
            sum += array[idx];
        }
        return sum;
    }

    [Benchmark(Description = "Random access list")]
    public int RandomList()
    {
        int sum = 0;
        int idx = 0;
        for (int i = 0; i < N; i++)
        {
            idx = (idx + 37) % N;
            sum += list[idx];
        }
        return sum;
    }

    [Benchmark(Description = "Random access span")]
    public int RandomSpan()
    {
        var localSpan = array.AsSpan();
        int sum = 0;
        int idx = 0;
        for (int i = 0; i < N; i++)
        {
            idx = (idx + 37) % N;
            sum += localSpan[idx];
        }
        return sum;
    }
}