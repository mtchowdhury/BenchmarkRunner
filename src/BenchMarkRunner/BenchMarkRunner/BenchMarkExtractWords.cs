using BenchmarkDotNet.Attributes;

namespace BenchMarkRunner;

[MemoryDiagnoser]
[RankColumn]
public class BenchMarkExtractWords
{
    [Params("This is a sentence.",
        "Performance is always very important aspect in software development.",
        "Witches' hair (Cuscata), also known by the equally spooky name of strangleweed (and the less scary dodder), is a genus of over 200 different parasitic plants. It is native to tropical climates but also appear in temperate areas - including the UK. Cuscata is often identifiable as a mass of green, brown or orange spaghetti-like substance hanging from other trees. It lacks chlorophyll so it needs to feed from other plants (not unlike a vampire) to reproduce. Even stranger, Cuscata can identify the plants around it based on smell alone.")]
    public string Book { get; set; }



    [Benchmark]
    public int ParseWithString()
    {
        var firstIndex = 0; 
        var lastIndex=0;
        var wordCount = 0;
        foreach (var c in Book)
        {
            lastIndex++;
            if (c == ' ' || c == '.' || c == ',' || c == ';' || c == '!')
            {
                var word = Book.Substring(firstIndex, lastIndex - firstIndex - 1);
                wordCount++;
                firstIndex = lastIndex;
            }
        }

        return wordCount;
    }

    [Benchmark]
    public int ParseWithSpan()
    {
        var bookSpan = Book.AsSpan();
        var firstIndex = 0;
        var lastIndex = 0;
        var wordCount = 0;
        foreach (var c in bookSpan)
        {
            lastIndex++;
            if (c == ' ' || c == '.' || c == ',' || c == ';' || c == '!')
            {
                var word = bookSpan.Slice(firstIndex, lastIndex - firstIndex - 1);
                wordCount++;
                firstIndex = lastIndex;
            }
        }

        return wordCount;
    }
}
