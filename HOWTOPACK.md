
# How to pack

binフォルダとobjフォルダは事前に削除します。

```
dotnet clean
dotnet build
dotnet pack Cupy.csproj -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg /p:PackageVersion=2.0.0 -c Release
```