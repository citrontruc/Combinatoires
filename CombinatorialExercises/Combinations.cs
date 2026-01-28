/*
A class to generate combinations from a list of elements.
*/

public static class Combinations
{
    public static readonly Dictionary<int, List<string>> dictT9 = new()
    {
        {
            1,
            new() { "a", "b", "c" }
        },
        {
            2,
            new() { "d", "e", "f" }
        },
        {
            3,
            new() { "g", "h", "i" }
        },
        {
            4,
            new() { "j", "k", "l" }
        },
        {
            5,
            new() { "m", "n", "o" }
        },
        {
            6,
            new() { "p", "q", "r", "s" }
        },
        {
            7,
            new() { "t", "u", "v" }
        },
        {
            8,
            new() { "w", "x", "y", "z" }
        },
        {
            9,
            new() { " " }
        },
    };

    /// <summary>
    /// /// If all the characters of listCharacters are different, we then have n! combinations.
    /// If we have duplicates in our listCharacters, some combinations might be equal.
    /// </summary>
    /// <param name="listCharacters">List of characters for whom we must generate combinations.</param>
    /// <returns>A list of the list of all the combinations.</returns>
    public static List<string> GenerateCombinations(List<string> listCharacters)
    {
        if (listCharacters.Count() == 0)
        {
            return new();
        }

        if (listCharacters.Count() == 1)
        {
            return listCharacters;
        }

        List<string> result = new();
        for (int i = 0; i < listCharacters.Count(); i++)
        {
            List<string> interList = GenerateCombinations(
                listCharacters.Where((item, index) => index != i).ToList()
            );
            interList = interList.Select(listElement => listCharacters[i] + listElement).ToList();
            result.AddRange(interList);
        }

        return result.Distinct().ToList();
    }

    /// <summary>
    /// Helper method to create new combinations by adding all the possible values for the next character in front of all the existing combinations.
    /// </summary>
    /// <param name="listStrings">The values to add to our combinations</param>
    /// <param name="currentCombinations">Our existing combinations of size n</param>
    /// <returns>All the combinations of n + 1 values</returns>
    private static List<List<string>> MergeLists(
        List<string> listStrings,
        List<List<string>>? currentCombinations
    )
    {
        List<List<string>> result = new();

        if (currentCombinations is null)
        {
            for (int i = 0; i < listStrings.Count(); i++)
            {
                result.Add(new() { listStrings[i] });
            }
            return result;
        }

        for (int i = 0; i < currentCombinations.Count(); i++)
        {
            for (int j = 0; j < listStrings.Count(); j++)
            {
                result.Add(
                    currentCombinations[i]
                        .Select(oneCombination => listStrings[j] + oneCombination)
                        .ToList()
                );
            }
        }
        return result;
    }

    /// <summary>
    /// Simuler l'écriture T9 : étant donné une série de chiffres 1 à 9 quels sont tous les mots pouvant être écrit (1 => a ou b ou c, 2=> d, e, f, ....) 3 puissance n possibilités.
    /// e.g 112 => [aad],[aae],[aaf],[abd],[abe],[abf],[acd],[ace],[acf]
    /// [bad],[bae],[baf],[bbd],[bbe],[bbf],[bcd],[bce],[bcf]
    /// [cad],[cae],[caf],[cbd],[cbe],[cbf],[ccd],[cce],[ccf]
    /// </summary>
    /// <param name="listCharacters">List of numbers from 1 to 9 to use.</param>
    /// <returns></returns>
    public static List<List<string>> GetT9Combinations(List<int> listCharacters)
    {
        if (listCharacters.Count() == 0)
        {
            return new();
        }

        List<List<string>> result = new();
        List<List<string>> listT9Equivalent = new();
        for (int i = 0; i < listCharacters.Count(); i++)
        {
            listT9Equivalent.Add(dictT9[listCharacters[i]]);
        }

        for (int i = 1; i < listCharacters.Count() + 1; i++)
        {
            result = MergeLists(listT9Equivalent[^i], result);
        }

        int numTotalCombinations = listT9Equivalent
            .Select(listElement => listElement.Count())
            .Aggregate(1, (a, b) => a * b);

        return result;
    }
}
