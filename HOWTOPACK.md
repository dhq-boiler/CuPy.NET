
# How to pack

bin�t�H���_��obj�t�H���_�͎��O�ɍ폜���܂��B

```
dotnet clean
dotnet build -c Release -r win-x64 .\src\Cupy\Cupy.csproj
dotnet pack .\src\Cupy\Cupy.csproj -c Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg /p:PackageVersion=4.1.4 -p:RuntimeIdentifier=win-x64 --no-build
```