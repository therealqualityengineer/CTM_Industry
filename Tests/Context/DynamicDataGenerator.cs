using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.RegularExpressions;

namespace Tests.Context;

public class DynamicDataGenerator
{
    private static readonly ThreadLocal<Random> _random =
        new(() => new Random());

    private const string Alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Digits = "0123456789";

    private string RandomWord(int length = 6)
    {
        return Generate(Alphabets, length);
    }

    private string RandomNumber(int length = 6)
    {
        return Generate(Digits, length);
    }

    private string RandomEmail()
    {
        return $"testuser_{Timestamp()}_{RandomWord(3).ToLower()}@gmail.com";
    }
    
    private string Timestamp()
    {
        return DateTime.Now.ToString("yyyyMMddHHmmssfff");
    }

    public string Resolve(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        input = input.Replace("<uniqueString>", RandomWord(7), StringComparison.OrdinalIgnoreCase);
        input = input.Replace("<uniqueNumber>", RandomNumber(7), StringComparison.OrdinalIgnoreCase);
        input = input.Replace("<uniqueEmail>", RandomEmail(), StringComparison.OrdinalIgnoreCase);
        input = input.Replace("<timestamp>", Timestamp(), StringComparison.OrdinalIgnoreCase);

        // ✅ Dynamic getDate handling
        input = Regex.Replace(input, @"<getDate\+(\d+)>", match =>
        {
            return GetDate(match.Value);
        }, RegexOptions.IgnoreCase);

        return input;
    }

    private string Generate(string chars, int length)
    {
        var builder = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            builder.Append(chars[_random.Value.Next(chars.Length)]);
        }

        return builder.ToString();
    }

    private string GetDate(string token)
    {
        var days = int.Parse(Regex.Match(token, @"\d+").Value);
        return DateTime.Today.AddDays(days).ToString("dd-MM-yyyy");
    }
}