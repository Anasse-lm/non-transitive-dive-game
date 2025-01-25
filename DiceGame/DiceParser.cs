using Dices;

public static class DiceParser
{
    public static List<Dice>? CheckArgs(string[] args) {
        if (args.Length < 3)
        {
            Console.WriteLine(args.Length!=0?$"user specified only {args.Length} dice(s)": "user specified no dice at all");
            System.Console.WriteLine("You should specify at least 3");
            return null;
        }
        else
        {
            var dices = new List<Dice>();
            Dice dice;

            // Checking each dice if it has non intergers or if it has less/more than faces
            string[] numbers;
            foreach(string arg in args)
            {
                if(arg.Length > 11 || arg.Length < 11){
                    System.Console.WriteLine("number of faces should be 6.\nPlease enter dices in this form: 3 or more strings, each containing 6 comma-separated integer");
                    return null;
                }
                numbers = arg.Split(',');
                dice = new Dice();
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (!int.TryParse(numbers[i], out _)) 
                    {
                        Console.WriteLine($"{arg} contains non integer.\nPlease enter dices in this form: 3 or more strings, each containing 6 comma-separated integers");
                        return null;
                    }
                    dice.SetDice(int.Parse(numbers[i]));
                }
                dices.Add(dice);
            }
            return dices;
        }
    }
}