
# How to pack

binフォルダとobjフォルダは事前に削除します。

```
dotnet clean
dotnet build -c Release -r win-x64 .\src\Cupy\Cupy.csproj
dotnet pack .\src\Cupy\Cupy.csproj -c Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg /p:PackageVersion=2.0.0 -p:RuntimeIdentifier=win-x64 --no-build
```