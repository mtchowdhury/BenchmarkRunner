using BenchmarkDotNet.Attributes;

namespace BenchMarkRunner;

[MemoryDiagnoser]
[RankColumn]
public class BenchMarkLinkAll
{
    public List<int> Numbers { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(99);

        Numbers = Enumerable
            .Range(0, 10000)
            .Select( _ => random.Next(1, int.MaxValue))
            .ToList();
    }

    [Benchmark]
    public bool WithAll()
    {
        return Numbers.All(n => n > 0);
    }

    [Benchmark]
    public bool WithTrueForAll()
    {
        return Numbers.TrueForAll(n => n > 0);
    }
}
