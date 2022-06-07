// See https://aka.ms/new-console-template for more information

using EventsDelegatesLambdas;
using System.Reflection;

static void WorkPerformed1(object? sender, WorkPerformedEventArgs e)
{
    var methodName = MethodBase.GetCurrentMethod()?.Name;

    Console.WriteLine("{0} called", methodName);
    Console.WriteLine("Worker performed {0} for {1} hours", e.WorkType, e.Hours);
}
static void WorkPerformed2(object? sender, WorkPerformedEventArgs e)
{
    var methodName = MethodBase.GetCurrentMethod()?.Name;

    Console.WriteLine("{0} called", methodName);
    Console.WriteLine("Worker performed {0} for {1} hours", e.WorkType, e.Hours);
}
static void WorkPerformed3(object? sender, WorkPerformedEventArgs e)
{
    var methodName = MethodBase.GetCurrentMethod()?.Name;

    Console.WriteLine("{0} called", methodName);
    Console.WriteLine("Worker performed {0} for {1} hours", e.WorkType, e.Hours);
}
static void WorkCompleted(object? sender, EventArgs e)
{
    Console.WriteLine("WORK COMPLETED!!");
}

var delArgs = new WorkPerformedEventArgs(4, WorkType.Golf); 

void DoWork(WorkPerformedHandler handler)
{
    handler?.Invoke(null, delArgs);
}

Console.WriteLine("Hello, World!");

var del1 = new WorkPerformedHandler(WorkPerformed1);
var del2 = new WorkPerformedHandler(WorkPerformed2);
var del3 = new WorkPerformedHandler(WorkPerformed3);

var del4 = new EventHandler(WorkCompleted);
//del1 += del2 + del3;

// First execution
//del1(1, WorkType.GeneralReports);

// Second execution
// DoWork(del1);

var worker = new Worker(del1, del4);

worker.DoWork(null, delArgs);