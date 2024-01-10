using MightyXOR.CLI.Handlers;
using MightyXOR.CLI.Options;
using System.Reflection;

namespace MightyXOR.CLI;

internal static class Program
{
    // https://patorjk.com/software/taag/#p=display&f=Standard&t=MightyXOR
    private const string AsciiArt = @"
  __  __ _       _     _        __  _____  ____  
 |  \/  (_) __ _| |__ | |_ _   _\ \/ / _ \|  _ \ 
 | |\/| | |/ _` | '_ \| __| | | |\  / | | | |_) |
 | |  | | | (_| | | | | |_| |_| |/  \ |_| |  _ < 
 |_|  |_|_|\__, |_| |_|\__|\__, /_/\_\___/|_| \_\
           |___/           |___/                 
    ";

    private static Parser? _commandLineParser;

    /// <summary>
    /// Key: Type of the CLI option.
    /// Value: Type of the corresponding handler class.
    /// </summary>
    private static readonly Dictionary<Type, Type> HandlerTypeDictionary = new()
    {
        { typeof(EncryptOptions), typeof(EncryptOptionsHandler) },
        { typeof(DecryptOptions), typeof(DecryptOptionsHandler) },
        { typeof(KeygenOptions), typeof(KeygenOptionsHandler) }
    };

    public static int Main(string[] args)
    {
        Console.WriteLine(AsciiArt);

        // Parse command line arguments
        _commandLineParser = new Parser(with =>
        {
            with.HelpWriter = Console.Out;
            with.CaseInsensitiveEnumValues = true;
        });

        Logger.Initialize();

        var types = LoadVerbs();
        var result = _commandLineParser.ParseArguments(args, types)
            .WithParsed(HandleCommandLineOptions);

        return result.Tag == ParserResultType.NotParsed ? 1 : 0;
    }

    private static Type[] LoadVerbs()
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();
    }

    private static void HandleCommandLineOptions(object options)
    {
        var correspondingHandlerType = HandlerTypeDictionary[options.GetType()];
        var optionHandler = (IOptionHandler?)Activator.CreateInstance(correspondingHandlerType, options);
        optionHandler?.Handle();
    }
}