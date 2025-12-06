public class TranspilationData
{
    public static Dictionary<string, string> Conversions = new Dictionary<string, string>()
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
        { "and", "&&" },
        { "or", "||" },
        { "not", "!=" }
    };

    public static List<string> invalidSyntax = new List<string>()
    {
        { "-" },
        { "*"},
        { ">"}
    };

};
