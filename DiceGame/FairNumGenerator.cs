public static class FairNumGenerator
{
    public static Dictionary<int, List<string>> Protocole(int min, int max){
        var keys_nums_hmacs = new Dictionary<int, List<string>>();
        var num = Generator.GenerateRandomInt(min, max);
        var list = new List<string>
        {
            Generator.GenerateSecureKey()
        };
        list.Add(Generator.GenerateHMAC(list[0], num));
        
        keys_nums_hmacs.Add(num, list);
        return keys_nums_hmacs;
    }
}