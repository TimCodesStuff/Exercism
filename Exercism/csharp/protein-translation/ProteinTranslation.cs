using System;
using System.Linq;
using System.Collections.Generic;

public static class ProteinTranslation
{
    public static Dictionary<string, string> ProteinDictionary = new Dictionary<string, string>()
    {
        { "AUG","Methionine" },
        { "UUU","Phenylalanine" },
        { "UUC","Phenylalanine" },
        { "UUA","Leucine" },
        { "UUG","Leucine" },
        { "UCU","Serine" },
        { "UCC","Serine" },
        { "UCA","Serine" },
        { "UCG","Serine" },
        { "UAU","Tyrosine" },
        { "UAC","Tyrosine" },
        { "UGU","Cysteine" },
        { "UGC","Cysteine" },
        { "UGG","Tryptophan" },
        { "UAA","STOP" },
        { "UAG","STOP" },
        { "UGA","STOP" },
    };

    public static IEnumerable<string> ChunkBySize(string input, int chunkSize)
    {
        return Enumerable.Range(0, input.Length / chunkSize)
               .Select(i => input.Substring(i * chunkSize, chunkSize));
    }

    public static string[] Proteins(string strand)
    {
        return ChunkBySize(strand, 3)
               .Select(codon => ProteinDictionary.GetValueOrDefault(codon))
               .TakeWhile(protein => protein != "STOP").ToArray();
    }
}