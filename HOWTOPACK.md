
# How to pack

bin�t�H���_��obj�t�H���_�͎��O�ɍ폜���܂��B

```
dotnet clean
dotnet build
dotnet pack Cupy.csproj -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg /p:PackageVersion=2.0.0 -c Release
```