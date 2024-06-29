using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        string regex = @"(<\S*>)";
        string template = ReadLine("Enter template > ");
        string[] values = ReadLine("Enter values > ").Split();

        MatchCollection matches = Regex.Matches(template, regex);

        for (int i = 0; i < matches.Count && i < values.Length; i++)
        {
            Match match = matches[i];
            string val = values[i];

            if (match.Success)
            {
                template = string.Concat(template.AsSpan(0, match.Index), val, template.AsSpan(match.Index + match.Length));
                matches = Regex.Matches(template, regex);
            }
        }

        Console.WriteLine(template);
    }

    private static string ReadLine(string prompt)
    {
        Console.Write(prompt);
        string? result = Console.ReadLine();
        return (result is not null) ? result : "";
    }
}