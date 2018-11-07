# Why?

To manage programmatically AutoCAD's licenses you have to deal with the `adskflex.opt` file.
The options file takes several options. To deal with them easily, you may use this library.

# How?

``` csharp
try
{
    var lines = AutoCadFile.GetLines(fileContent);
    var options = AutoCadFile.GetOptions(lines);
    var adskflex = new ADSKFlex(options);

    // now you'd change adskflex object to later call .ToString()
}
catch (InvalidAutoCadOption ex)
{
    // your way to deal with the exception
}
```

# Tests

`dotnet test ADSKFlexCoreTests`
