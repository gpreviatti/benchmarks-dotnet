using BenchmarkDotNet.Attributes;

namespace ListsAndSpans;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class ListsAndSpansBenchmarks
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

    [Benchmark(Description = "Sum array")]
    public int SumArray()
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
            sum += array[i];
        return sum;
    }

    [Benchmark(Description = "Sum List<T>")]
    public int SumList()
    {
        int sum = 0;
        for (int i = 0; i < list.Count; i++)
            sum += list[i];
        return sum;
    }

    [Benchmark(Description = "Sum ICollection<T>")]
    public int SumICollection()
    {
        int sum = 0;
        foreach (var x in collection)
            sum += x;
        return sum;
    }

    [Benchmark(Description = "Sum IEnumerable<T>")]
    public int SumIEnumerable()
    {
        int sum = 0;
        foreach (var x in enumerable)
            sum += x;
        return sum;
    }

    [Benchmark(Description = "Sum Span<T>")]
    public int SumSpan()
    {
        var localSpan = array.AsSpan();
        int sum = 0;
        for (int i = 0; i < localSpan.Length; i++)
            sum += localSpan[i];
        return sum;
    }
}