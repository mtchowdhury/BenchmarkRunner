// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using BenchMarkRunner;


//BenchmarkRunner.Run<BenchMarkExtractWords>();
//BenchmarkRunner.Run<BenchMarkLinkAll>();
BenchmarkRunner.Run<BenchMarkValidPassword>();


Console.ReadKey(true);
