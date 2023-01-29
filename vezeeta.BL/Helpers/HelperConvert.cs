namespace vezeeta.BL;
using System.Security.Cryptography;
public partial class Helper
{
    public static int RandomNum(int min = 1000, int max = 9999)
    {
        var random = new Random();
        return random.Next(min, max);
    }

    public static string? cutString(string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
    }
    
}