using System.Security.Cryptography;
using System.Text;

public static class Generator
{
    public static int GenerateRandomInt(int min, int max)
    {
        if (max < min)
            throw new ArgumentOutOfRangeException(nameof(min), "min must be less than or equal to max");

        if (min == max)
            return min;

        long range = (long)max - min + 1;

        if (range <= 0 || range > int.MaxValue)
            throw new ArgumentOutOfRangeException(nameof(max), "The range is too large or invalid.");

        byte[] randomBytes = new byte[4];
        using (var rng = RandomNumberGenerator.Create())
        {
            while (true)
            {
                rng.GetBytes(randomBytes);
                uint randomNumber = BitConverter.ToUInt32(randomBytes, 0);

                if (randomNumber < uint.MaxValue - (uint.MaxValue % range))
                {
                    return (int)(randomNumber % range) + min;
                }
            }
        }
    }
    public static string GenerateSecureKey(){
        byte[] randomBytes = RandomNumberGenerator.GetBytes(32);
        string key = Convert.ToHexString(randomBytes);
        return key;
    }
    public static string GenerateHMAC(string key, int randomNum){
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] randomNumBytes = BitConverter.GetBytes(randomNum);
        byte[] hmacBytes;

        using (HMACSHA3_256 hmac = new HMACSHA3_256(keyBytes))
        {
            hmacBytes = hmac.ComputeHash(randomNumBytes);
        }
        return Convert.ToHexString(hmacBytes);
    }
}