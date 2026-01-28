// See https://aka.ms/new-console-template for more information

using static Combinations;

Console.WriteLine("Hello, World!");

List<string> listInput = new() { "a", "b", "c" };
List<string> combinationsGenerated = GenerateCombinations(listInput);
Console.WriteLine(string.Join(", ", combinationsGenerated));

List<List<string>> result = GetT9Combinations(new() { 1, 1 });
for (int i = 0; i < result.Count(); i++)
{
    Console.WriteLine(string.Join(", ", result[i]));
}
