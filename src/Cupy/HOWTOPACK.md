
# How to pack

binフォルダとobjフォルダは事前に削除します。

```
dotnet clean
dotnet build -a x64 -c Release Cupy.csproj
dotnet pack Cupy.csproj -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg /p:PackageVersion=0.1.0 -c Release
```