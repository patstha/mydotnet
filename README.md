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

```bash
cd "/home/kushal/src/dotnet/mydotnet/"; date; time dotnet clean; date; time dotnet build; date; time dotnet test; date; cd "/home/kushal/src/dotnet/mydotnet/tests"; date; time dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura; reportgenerator -reports:coverage.cobertura.xml -targetdir:coverage-report; date; time mv -f "/home/kushal/src/dotnet/mydotnet/tests/coverage-report/*" "/home/kushal/src/dotnet/mydotnet/docs"; date; cd  "/home/kushal/src/dotnet/mydotnet/"; git add .; date; git status; date; git commit --message "build application" --message "from the terminal" --verbose; date; git pull --rebase origin master --verbose; date; git push origin master --verbose; date;
```

```
kushal@kusfedora2024:~/src/cpp$ cd "/home/kushal/src/dotnet/mydotnet/"; date; time dotnet clean; date; time dotnet build; date; time dotnet test; date; cd "/home/kushal/src/dotnet/mydotnet/tests"; date; time dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura; reportgenerator -reports:coverage.cobertura.xml -targetdir:coverage-report; date; time mv -f "/home/kushal/src/dotnet/mydotnet/tests/coverage-report/*" "/home/kushal/src/dotnet/mydotnet/docs"; date; cd  "/home/kushal/src/dotnet/mydotnet/"; git add .; date; git status; date; git commit --message "build application" --message "from the terminal" --verbose; date; git pull --rebase origin master --verbose; date; git push origin master --verbose; date;
Tue Dec  3 03:27:29 PM EST 2024

Build succeeded in 1.4s

real	0m1.702s
user	0m1.107s
sys	0m0.211s
Tue Dec  3 03:27:30 PM EST 2024
Restore complete (1.3s)
  hellolib succeeded (0.7s) → hellolib/bin/Debug/net9.0/hellolib.dll
  hello succeeded (0.7s) → hello/bin/Debug/net9.0/hello.dll
  tests succeeded (1.3s) → tests/bin/Debug/net9.0/tests.dll
  hellobenchamarks succeeded (1.5s) → hellobenchamarks/bin/Debug/net9.0/hellobenchamarks.dll

Build succeeded in 3.9s

real	0m4.208s
user	0m2.797s
sys	0m0.399s
Tue Dec  3 03:27:35 PM EST 2024
Restore complete (1.0s)
  hellolib succeeded (0.1s) → hellolib/bin/Debug/net9.0/hellolib.dll
  tests succeeded (0.2s) → tests/bin/Debug/net9.0/tests.dll
[xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v2.8.2+699d445a1a (64-bit .NET 9.0.0)
[xUnit.net 00:00:00.11]   Discovering: tests
[xUnit.net 00:00:00.23]   Discovered:  tests
[xUnit.net 00:00:00.24]   Starting:    tests
[xUnit.net 00:00:08.88]   Finished:    tests
  tests test succeeded (10.0s)

Test summary: total: 333, failed: 0, succeeded: 333, skipped: 0, duration: 10.0s
Build succeeded in 11.7s

real	0m12.001s
user	0m1.718s
sys	0m0.262s
Tue Dec  3 03:27:47 PM EST 2024
Tue Dec  3 03:27:47 PM EST 2024
Restore complete (0.3s)
  hellolib succeeded (0.1s) → /home/kushal/src/dotnet/mydotnet/hellolib/bin/Debug/net9.0/hellolib.dll
  tests succeeded (0.1s) → bin/Debug/net9.0/tests.dll
[xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v2.8.2+699d445a1a (64-bit .NET 9.0.0)
[xUnit.net 00:00:00.05]   Discovering: tests
[xUnit.net 00:00:00.11]   Discovered:  tests
[xUnit.net 00:00:00.11]   Starting:    tests
[xUnit.net 00:00:06.58]   Finished:    tests
  tests                                                                                   GenerateCoverageResult (7.5s)

+----------+------+--------+--------+
| Module   | Line | Branch | Method |
+----------+------+--------+--------+
| hellolib | 100% | 99.64% | 100%   |
+----------+------+--------+--------+

+---------+------+--------+--------+
|         | Line | Branch | Method |
+---------+------+--------+--------+
| Total   | 100% | 99.64% | 100%   |
+---------+------+--------+--------+
| Average | 100% | 99.64% | 100%   |
+---------+------+--------+--------+
  tests test succeeded (7.6s)

Test summary: total: 333, failed: 0, succeeded: 333, skipped: 0, duration: 7.1s
Build succeeded in 8.4s

real	0m8.588s
user	0m12.640s
sys	0m1.142s
bash: reportgenerator: command not found...
Tue Dec  3 03:27:56 PM EST 2024
mv: cannot stat '/home/kushal/src/dotnet/mydotnet/tests/coverage-report/*': No such file or directory

real	0m0.001s
user	0m0.000s
sys	0m0.001s
Tue Dec  3 03:27:56 PM EST 2024
Tue Dec  3 03:27:56 PM EST 2024
On branch master
Your branch is up to date with 'origin/master'.

Changes to be committed:
  (use "git restore --staged <file>..." to unstage)
	modified:   README.md
	modified:   tests/coverage.cobertura.xml

Tue Dec  3 03:27:56 PM EST 2024
[master e2027aa] build application
 2 files changed, 50 insertions(+), 46 deletions(-)
Tue Dec  3 03:27:56 PM EST 2024
From github.com:patstha/mydotnet
 * branch            master     -> FETCH_HEAD
 = [up to date]      master     -> origin/master
Current branch master is up to date.
Tue Dec  3 03:27:56 PM EST 2024
Pushing to github.com:patstha/mydotnet.git
Enumerating objects: 9, done.
Counting objects: 100% (9/9), done.
Delta compression using up to 16 threads
Compressing objects: 100% (5/5), done.
Writing objects: 100% (5/5), 1.12 KiB | 1.12 MiB/s, done.
Total 5 (delta 4), reused 0 (delta 0), pack-reused 0 (from 0)
remote: Resolving deltas: 100% (4/4), completed with 4 local objects.
To github.com:patstha/mydotnet.git
   3c5a5f1..e2027aa  master -> master
updating local tracking ref 'refs/remotes/origin/master'
Tue Dec  3 03:27:57 PM EST 2024
```
