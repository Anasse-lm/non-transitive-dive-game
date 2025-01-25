using Dices;

public static class Game
{
    public static void Start(List<Dice> dices){
        int computer_choice = -1;
        Dice computer_dice;
        int computer_throw;
        string user_input = "";
        Dice user_dice;
        int user_throw;
        var keys_dic = FairNumGenerator.Protocole(0, 1);
        var random_key = "";
        var unchanged_dices = dices.ToList();

        System.Console.WriteLine("Let's determine who makes the first move.");
        // since i have only one key in the dictionary
        System.Console.WriteLine("I selected a random value in the range 0..1");
        foreach (var (key, value) in keys_dic)
        {
            computer_choice = key;
            random_key = value[0];
            System.Console.WriteLine($"(HMAC={value[1]})");
        }
        // Part 1
        do
        {
            System.Console.WriteLine("Try to guess my selection.");
            user_input = Display(Menu.Display_Range(Range(0, 1)), user_input);
            if(user_input == "?"){
                Help(unchanged_dices);
            }
            else if(user_input == "X"){
                Exit();
                return;
            }
        } while (user_input == "?");

        //The computer plays first
        if(computer_choice != int.Parse(user_input)){
            System.Console.WriteLine($"My selection was {computer_choice} (KEY={random_key})");
            computer_choice = Generator.GenerateRandomInt(0, dices.Count - 1);
            System.Console.WriteLine($"I make the first move and choose the {dices[computer_choice].DisplayDice()} dice.");
            computer_dice = dices[computer_choice];
            dices.Remove(dices[computer_choice]);
            do
            {
                user_input = Display(Menu.Display_Dices_Menu(dices), user_input);
                if(user_input == "?"){
                    Help(unchanged_dices);
                }
                else if(user_input == "X"){
                    Exit();
                    return;
                }
            } while (user_input == "?");
            System.Console.WriteLine($"You choose the {dices[int.Parse(user_input)].DisplayDice()} dice.");
            user_dice = dices[int.Parse(user_input)];
            System.Console.WriteLine("It's time for my throw.");
            System.Console.WriteLine("I selected a random value in the range 0..5");
            keys_dic = FairNumGenerator.Protocole(0, 5);
            foreach (var (key, value) in keys_dic)
            {
                computer_choice = key;
                random_key = value[0];
                System.Console.WriteLine($"(HMAC={value[1]})");
            }
            System.Console.WriteLine("Add your number modulo 6.");
            do
            {
                user_input = Display(Menu.Display_Range(Range(0, 5)), user_input);
                if(user_input == "?"){
                    Help(unchanged_dices);
                }
                else if(user_input == "X"){
                    Exit();
                    return;
                }
            } while (user_input == "?");
            System.Console.WriteLine($"My number is {computer_choice} (KEY={random_key})");
            System.Console.WriteLine($"The result is {computer_choice} + {user_input} = {(computer_choice + int.Parse(user_input)) % 6} (mod 6).");
            computer_throw = computer_dice.GetDice()[(computer_choice + int.Parse(user_input)) % 6];
            System.Console.WriteLine($"My throw is {computer_throw}");
            System.Console.WriteLine("It's time for your throw.");
            System.Console.WriteLine("I selected a random value in the range 0..5");
            keys_dic = FairNumGenerator.Protocole(0, 5);
            foreach (var (key, value) in keys_dic)
            {
                computer_choice = key;
                random_key = value[0];
                System.Console.WriteLine($"(HMAC={value[1]})");
            }
            System.Console.WriteLine("Add your number modulo 6.");
            do
            {
                user_input = Display(Menu.Display_Range(Range(0, 5)), user_input);
                if(user_input == "?"){
                    Help(unchanged_dices);
                }
                else if(user_input == "X"){
                    Exit();
                    return;
                }
            } while (user_input == "?");
            System.Console.WriteLine($"My number is {computer_choice} (KEY={random_key})");
            System.Console.WriteLine($"The result is {computer_choice} + {user_input} = {(computer_choice + int.Parse(user_input)) % 6} (mod 6).");
            user_throw = user_dice.GetDice()[(computer_choice + int.Parse(user_input)) % 6];
            System.Console.WriteLine($"Your throw is {user_throw}");
            Winner(user_throw, computer_throw);
        }else{
            // Part 2 if the user plays first 
            System.Console.WriteLine($"My selection was {computer_choice} (KEY={random_key})");
            System.Console.WriteLine("Niice!! You got it right");
            do
            {
                user_input = Display(Menu.Display_Dices_Menu(dices), user_input);
                if(user_input == "?"){
                    Help(unchanged_dices);
                }
                else if(user_input == "X"){
                    Exit();
                    return;
                }
            } while (user_input == "?");
            System.Console.WriteLine($"You choose the {dices[int.Parse(user_input)].DisplayDice()} dice.");
            user_dice = dices[int.Parse(user_input)];
            dices.Remove(dices[int.Parse(user_input)]);
            computer_choice = Generator.GenerateRandomInt(0, dices.Count - 1);
            System.Console.WriteLine($"I choose the {dices[computer_choice].DisplayDice()} dice.");
            computer_dice = dices[computer_choice];
            System.Console.WriteLine("It's time for your throw.");
            System.Console.WriteLine("I selected a random value in the range 0..5");
            keys_dic = FairNumGenerator.Protocole(0, 5);
            foreach (var (key, value) in keys_dic)
            {
                computer_choice = key;
                random_key = value[0];
                System.Console.WriteLine($"(HMAC={value[1]})");
            }
            System.Console.WriteLine("Add your number modulo 6.");
            do
            {
                user_input = Display(Menu.Display_Range(Range(0, 5)), user_input);
                if(user_input == "?"){
                    Help(unchanged_dices);
                }
                else if(user_input == "X"){
                    Exit();
                    return;
                }
            } while (user_input == "?");
            System.Console.WriteLine($"My number is {computer_choice} (KEY={random_key})");
            System.Console.WriteLine($"The result is {computer_choice} + {user_input} = {(computer_choice + int.Parse(user_input)) % 6} (mod 6).");
            user_throw = user_dice.GetDice()[(computer_choice + int.Parse(user_input)) % 6];
            System.Console.WriteLine($"Your throw is {user_throw}");

            // Computer throw  
            System.Console.WriteLine("It's time for my throw.");
            System.Console.WriteLine("I selected a random value in the range 0..5");
            keys_dic = FairNumGenerator.Protocole(0, 5);
            foreach (var (key, value) in keys_dic)
            {
                computer_choice = key;
                random_key = value[0];
                System.Console.WriteLine($"(HMAC={value[1]})");
            }
            System.Console.WriteLine("Add your number modulo 6.");
            do
            {
                user_input = Display(Menu.Display_Range(Range(0, 5)), user_input);
                if(user_input == "?"){
                    Help(unchanged_dices);
                }
                else if(user_input == "X"){
                    Exit();
                    return;
                }
            } while (user_input == "?");
            System.Console.WriteLine($"My number is {computer_choice} (KEY={random_key})");
            System.Console.WriteLine($"The result is {computer_choice} + {user_input} = {(computer_choice + int.Parse(user_input)) % 6} (mod 6).");
            computer_throw = computer_dice.GetDice()[(computer_choice + int.Parse(user_input)) % 6];
            System.Console.WriteLine($"My throw is {computer_throw}");
            Winner(user_throw, computer_throw);
        }
    }
    private static void Exit(){
        Console.Clear();
    }
    private static void Help(List<Dice> dices){
        TableGeneration.DisplayProbabilityTable(dices);
    }
    private static string Display(List<string> choices, string user_input){
        do{
            System.Console.Write("Your selection: ");
            user_input =  Console.ReadLine() + "";
            if(!choices.Contains(user_input) && user_input!="X" && user_input!="?"){
                System.Console.WriteLine("Enter valid choice!");
            }
        }while(!choices.Contains(user_input) && user_input!="X" && user_input!="?");
        return user_input;
    }
    private static List<int> Range(int min, int max){
        var range = new List<int>();
        for (int i = min; i <= max; i++)
        {
            range.Add(i);
        }
        return range;
    }
    private static void Winner(int user_throw, int computer_throw) {
        if(user_throw == computer_throw)
        {
            System.Console.WriteLine($"Even game ({user_throw} = {computer_throw})!");
        }else if (user_throw > computer_throw){
            System.Console.WriteLine($"You win ({user_throw} > {computer_throw})!");
        }else{
            System.Console.WriteLine($"You lose ({user_throw} < {computer_throw})!");
        }
    }
}