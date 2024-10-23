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

[![Mutation testing badge](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2Fpatstha%2Fmydotnet%2Fmaster)](https://dashboard.stryker-mutator.io/reports/github.com/patstha/mydotnet/master)



```powershell
cd "C:\Users\kushal\src\mydotnet\"; date; dotnet clean; date; dotnet build; date; dotnet test; date; cd "C:\Users\kushal\src\mydotnet\tests\"; date; dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura; reportgenerator -reports:coverage.cobertura.xml -targetdir:coverage-report; date; Move-Item -Path "C:\Users\kushal\src\mydotnet\tests\coverage-report\*" -Destination "C:\Users\kushal\src\mydotnet\docs" -Force; date; cd  "C:\Users\kushal\src\mydotnet\"; git add .; date; git status; date; git commit --message "build application" --message "from the terminal" --verbose; date; git pull --rebase origin master --verbose; date; git push origin master --verbose; date;
```