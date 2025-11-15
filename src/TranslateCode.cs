using System.Text.RegularExpressions;

public class Translator
{
    Dictionary<string, string> Conversions = new Dictionary<string, string>()
    {
        { "vd", "void" },
        { "in", "int" },
        { "tdf", "typedef"},
        { "dt", "delete" },
        { "ptf", "printf"},
        { "str", "struct"},
        { "rt", "return"},
        { "fl", "float"},
        { "ch", "char"},
        { "use", "using"},
        { "name", "namespace"},
        { "inc", "include"},
        { "mut", "mutable" },
        { "vec", "vector"},
        { "conpr", "constexpr" },
        { "conva", "consteval"},
        { "conit", "constinit"},
        { "cnst", "const" },
        { "cls", "class"},
    };

    List<string> invalidSyntax = new List<string>()
    {
        { "-" },
        { "*"},
        { ">"}
    };

    Dictionary<string, string> replaceFunctions = new Dictionary<string, string>()
    {
        { "ptf", "printf, std::cout"},
        { "inp", "scanf, std::cin"}
    };

    bool isToC = false;

    public void ProcessData(string? path, string? language)
    {
        isToC = (language?.ToLower() == "c") ? true : false;

        int errors = 0;

        if (path == null || !path.Contains(".particle") || !File.Exists(path))
            return;

        string data = File.ReadAllText(path);
        string[] lines = data.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        for (int i = 0; i < lines.Length; i++)
        {
            if (checkForErrors(lines[i]) == true)
            {
                errors++;
                Console.WriteLine(lines[i]);
            }

            foreach (var syntax in Conversions)
            {
                lines[i] = Regex.Replace(lines[i], @$"\b{syntax.Key}\b", syntax.Value);
                lines[i] = Regex.Replace(lines[i], @"->", ".");
            }
        }
        if (errors != 0)
        {
            Console.WriteLine("\nTranspile failed.");
            Console.WriteLine("Invalid syntax");
            Console.WriteLine($"{errors.ToString()} error{ ((errors > 1) ? "s" : "") } found");

            return;
        }


        string result = string.Join(Environment.NewLine, lines);
        Console.WriteLine("\nWhere would you like the result?");

        string? writePath = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(writePath))
            return;

        try
        {
            File.WriteAllText(writePath, result);
        }
        catch
        {
            Console.WriteLine("\nERROR, please try again.");
        }
    }

    bool checkForErrors(string line)
    {
        char[] chars = line.ToCharArray();

        bool isQuote = false;
        string storedLine = string.Empty;

        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i].ToString() == "'" || chars[i] == '"')
                isQuote = !isQuote;

            if (chars[i] == '*' && !isQuote)
                return true;
        }

        return false;
    }

    void functionReplacements(string line)
    {
        foreach (var syntax in replaceFunctions)
        {
            if (line.Contains(syntax.Key))
                goto hasSyntax;
        }

    hasSyntax:
        if (!isToC)
        {
            
        }
    }
}