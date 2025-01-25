using ConsoleTables;
using Dices;

public static class TableGeneration
{
    public static void DisplayProbabilityTable(List<Dice> dices)
    {
        var headers = new List<string> { "User dice v" };
        headers.AddRange(dices.Select(d => string.Join(",", d.GetDice())));

        var table = new ConsoleTable(headers.ToArray());

        for (int i = 0; i < dices.Count; i++)
        {
            var row = new List<object> { string.Join(",", dices[i].GetDice()) };

            for (int j = 0; j < dices.Count; j++)
            {
                double probability = Probabilty.CalculateWinProbability(dices[i], dices[j]);
                if (i == j)
                {
                    row.Add($"- ({probability:F4})");
                }
                else
                {
                    row.Add($"{probability:F4}");
                }
            }

            table.AddRow(row.ToArray());
        }
        Console.WriteLine("Probability of the win for the user:");
        table.Write();
    }
}
