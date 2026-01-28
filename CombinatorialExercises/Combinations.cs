/*
A class to generate combinations from a list of elements.
*/

public static class Combinations
{
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
}
