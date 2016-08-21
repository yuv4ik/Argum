# Argum
Libary to interact with command line arguments.<br/>
## Usage example:
```c#
var argum = new ArgumExtractor(args);

argum.IsCaseInsensitive = false;
argum.KeyPrefix = "--";
argum.KeyPostfix = "=";

var strArg = argum.GetArgument<string>("key1");
var intArg = argum.GetArgument<int>("key2");
var boolArg = argum.GetArgument<bool>("key3");
var doubleArg = argum.GetArgument<double>("key4");
var dateTimeArg = argum.GetArgument<DateTime>("key5");
var floatArg = argum.GetArgument<DateTime>("key6");
var charArg = argum.GetArgument<DateTime>("key7");
```
