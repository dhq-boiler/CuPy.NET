**CuPy.NET** は Python における CuPy を .NET で使えるようにしたラッパーライブラリです。初期設定さえ済ませてしまえば比較的かんたんに .NETコードで GPUを使用する科学技術計算、機械学習、AIを実現できます。

**CuPy.NET** is a wrapper library for CuPy in Python. NET code to realize scientific and technical calculations, machine learning, and AI using GPUs with relative ease after the initial setup.

このリポジトリはNumpy.NETからフォークして、CuPy.NETに改名し、CuPyではサポートされていない numpy の関数をフォークしたものから除去して、ユニットテストを整えたものになります。サポートされていない numpyの関数については[こちら](https://docs.cupy.dev/en/stable/reference/comparison.html)をご覧ください。

This repository will be forked from Numpy.NET and renamed to CuPy.NET, with unit tests in place by removing numpy functions not supported by CuPy from the forked version. See [here](https://docs.cupy.dev/en/stable/reference/comparison.html) for unsupported numpy functions.

## インストール / Installation

お使いのPCで CuPy.NET を使用するには、以下のハードウェアとソフトウェアが事前にインストールされている必要があります。

To use CuPy.NET on your PC, the following hardware and software must be pre-installed.

### ハードウェア / Hardware

1. NVIDIA GPU

### ソフトウェア / Software

2. Visual Studio 2022
3. CUDA Toolkit 12.3
4. cuDNN

## ライセンス / License

Cupy.NET は`Python`、`pythonnet`、`Cupy`をパッケージ化して配布しています。これらの依存関係はすべてCupy.NETにライセンス条件を課している。C#ラッパー自体はMITライセンスである。

Cupy.NET packages and distributes `Python`, `pythonnet` as well as `Cupy`. All these dependencies imprint their license conditions upon Cupy.NET. The C# wrapper itself is MIT License. 

* Python: [PSF License](https://docs.python.org/3/license.html)
* Python for .NET (pythonnet): [MIT License](http://pythonnet.github.io/LICENSE)
* Cupy: [MIT License](https://github.com/cupy/cupy/blob/main/LICENSE)
* Cupy.NET: [MIT License](./LICENSE)
