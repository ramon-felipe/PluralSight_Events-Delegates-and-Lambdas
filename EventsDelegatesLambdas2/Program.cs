// See https://aka.ms/new-console-template for more information
using EventsDelegatesLambdas2;

Console.WriteLine("Hello, World!");

var worker = new Worker();
var addArgs = new WorkerArgs { N1 = 11, N2 = 21 };
AddDelegate add = (a, b) => a + b;
var act = () => Console.WriteLine("My action");
var func = () =>
{
    Console.WriteLine("My func");
    return true;
};

var resultDoAdd = worker.DoAdd(add, addArgs);
worker.DoWork(act);
var resultDoFuncTrue = worker.DoWork(func);

Func<bool>? fnull = null;
var resultDoFuncFalse = worker.DoWork(fnull);

Console.WriteLine("resultDoAdd: {0}", resultDoAdd);
Console.WriteLine("resultDoFuncTrue: {0}", resultDoFuncTrue);
Console.WriteLine("resultDoFuncFalse: {0}", resultDoFuncFalse);

var testFuncTuple = DataProcessor.Process(10, DoSomething);
Console.WriteLine($"{nameof(testFuncTuple)}: {testFuncTuple}");

static (int, string) DoSomething(int x)
{
    var r = x *= 2;
    return (r, $"test: {r}");
}