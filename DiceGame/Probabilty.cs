using Dices;

public static class Probabilty
{
    public static double CalculateWinProbability(Dice die1, Dice die2)
    {
        int winCount = 0;
        int totalComparisons = 0;

        foreach (int face1 in die1.GetDice())
        {
            foreach (int face2 in die2.GetDice())
            {
                totalComparisons++;
                if (face1 > face2)
                {
                    winCount++;
                }
            }
        }
        return (double)winCount / totalComparisons;
    }
}
