# Argum
Libary to interact with command line arguments.<br/>
Supports primitive types, arrays and DateTime.<br/>
## Usage example:
```c#
class Program
{
    [ArgumAttribute(name: "username", isMandatory: true, description: "Username argument.")]
    static public string Username { get; set; }

    [ArgumAttribute(name: "roles", isMandatory: true, description: "User roles argument.")]
    static public string[] Roles { get; set; }

    [ArgumAttribute(name: "bday", isMandatory: false, description: "Birthday argument.")]
    static public DateTime BDay { get; set; }

    static void Main(string[] args)
    {
        var argum = new ArgumExtractor<Program>(args);

        var helpMessage = argum.GetHelpMessage(); // Generates help message from ArgumAttributes
        Console.WriteLine(helpMessage);

        argum.Setup(); // Maps user input to ArgumAttributes

        Console.Write($"{Username}");
    }
}
```
