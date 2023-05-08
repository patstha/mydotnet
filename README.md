# Hello

This project is a playground for .NET core and github actions.

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=patstha_mydotnet&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=patstha_mydotnet)

Add a very aggressive code clean up
![added all options in code cleanup profile in visual studio 2022](docs/assets/code-cleanup.png)

Github pages: 
[https://patstha.github.io/mydotnet/](https://patstha.github.io/mydotnet/) 


Learning Benchmark dotnet

``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1635/22H2/2022Update/SunValley2)
AMD Ryzen 7 5800X, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.203
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


```
| Method |        Mean |     Error |    StdDev |
|------- |------------:|----------:|----------:|
| Bubble | 62,200.1 μs | 116.72 μs | 109.18 μs |
|  Merge |    291.4 μs |   2.73 μs |   2.56 μs |

