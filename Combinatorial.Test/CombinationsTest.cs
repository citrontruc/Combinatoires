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
}
