using BenchmarkDotNet.Running;
using hellobenchamarks;
Console.WriteLine("Hello, World!");
_ = BenchmarkRunner.Run<Md5VsSha256>();