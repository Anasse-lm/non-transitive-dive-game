using Dices;

public static class Menu
{
    public static void Display_exit_help(){
        System.Console.WriteLine("X - exit");
        System.Console.WriteLine("? - help");
    }
    public static List<string> Display_Range(List<int> range){
        var choices = new List<string>(); 
        for (int i = 0; i < range.Count; i++)
        {
            System.Console.WriteLine(i + " - " + range[i]);
            choices.Add(i + "");
        }
        Display_exit_help();
        return choices;
    }
    public static List<string> Display_Dices_Menu(List<Dice> dices){
        System.Console.WriteLine("Choose your dice:");
        int i = 0;
        var choices = new List<string>();   
        foreach (var item in dices)
        {
            choices.Add(i+"");
            System.Console.WriteLine(i + " - " + item.DisplayDice());
            i++;
        }
        Display_exit_help();
        return choices;
    }
}