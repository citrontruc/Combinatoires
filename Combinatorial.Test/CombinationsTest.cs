/*
Our test file to check if all combinations of a string list are generated.
*/

using static Combinations;

namespace Combinatorial.Test;

public class CombinationGenerationTests
{
    [Fact]
    public void GenerateCombinations_WithInputWithOnlyDistinctElements_ReturnsAllCombinations()
    {
        // Arrange
        List<string> listInput = new() { "a", "b", "c" };
        List<string> listExpectedResult = new() { "abc", "acb", "bca", "bac", "cab", "cba" };

        // Act
        List<string> combinationsGenerated = GenerateCombinations(listInput);

        // Assert
        Assert.Equivalent(listExpectedResult, combinationsGenerated);
    }

    [Fact]
    public void GenerateCombinations_WithInputWithDuplicateElements_ReturnsAllCombinations()
    {
        // Arrange
        List<string> listInput = new() { "a", "b", "a", "a", "a", "a" };
        List<string> listExpectedResult = new()
        {
            "aaaaab",
            "aaaaba",
            "aaabaa",
            "aabaaa",
            "abaaaa",
            "baaaaa",
        };

        // Act
        List<string> combinationsGenerated = GenerateCombinations(listInput);

        // Assert
        Assert.Equivalent(listExpectedResult, combinationsGenerated);
    }

    [Fact]
    public void GetT9Combinations_WithShortInput_ReturnsAllCombinations()
    {
        // Arrange
        List<int> listInput = new() { 1, 1, 2 };
        List<List<string>> listExpectedResult = new()
        {
            new() { "aad" },
            new() { "bad" },
            new() { "cad" },
            new() { "abd" },
            new() { "bbd" },
            new() { "cbd" },
            new() { "acd" },
            new() { "bcd" },
            new() { "ccd" },
            new() { "aae" },
            new() { "bae" },
            new() { "cae" },
            new() { "abe" },
            new() { "bbe" },
            new() { "cbe" },
            new() { "ace" },
            new() { "bce" },
            new() { "cce" },
            new() { "aaf" },
            new() { "baf" },
            new() { "caf" },
            new() { "abf" },
            new() { "bbf" },
            new() { "cbf" },
            new() { "acf" },
            new() { "bcf" },
            new() { "ccf" },
        };

        // Act
        List<List<string>> combinationsGenerated = GetT9Combinations(listInput);

        // Assert
        Assert.Equivalent(listExpectedResult, combinationsGenerated);
    }
}
