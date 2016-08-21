# Argum
Very small libary to extract arguments from cmd input.<br/>
The expected input should be in the next format: --key1=val1 --key2=val2 <br/>
## Usage example:
```c#
var argum = new ArgumExtractor(args);
var strArg = argum.GetArgument<string>("key1");
var intArg = argum.GetArgument<int>("key2");
var boolArg = argum.GetArgument<bool>("key3");
var doubleArg = argum.GetArgument<double>("key4");
var dateTimeArg = argum.GetArgument<DateTime>("key5");
```
