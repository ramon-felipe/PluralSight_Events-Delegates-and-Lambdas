// See https://aka.ms/new-console-template for more information

using EventsDelegatesLambdas;
using System.Reflection;

static void WorkPerformed1(object? sender, WorkPerformedEventArgs e)
{
    Console.WriteLine("WorkPerformed1 called");
    Console.WriteLine("Worker performed {0} for {1} hours", e.WorkType, e.Hours);
}
static void WorkPerformed2(object? sender, WorkPerformedEventArgs e)
{
    Console.WriteLine("WorkPerformed2 called");

    Console.WriteLine("Worker performed {0} for {1} hours", e.WorkType, e.Hours);
}
static void WorkPerformed3(object? sender, WorkPerformedEventArgs e)
{
    Console.WriteLine("WorkPerformed3 called");

    Console.WriteLine("Worker performed {0} for {1} hours", e.WorkType, e.Hours);
}
static void WorkCompleted(object? sender, EventArgs e)
{
    Console.WriteLine("WORK COMPLETED!!");
}

var delArgs = new WorkPerformedEventArgs(2, WorkType.Golf); 

Console.WriteLine("Hello, World!");

var del1 = new EventHandler<WorkPerformedEventArgs>(WorkPerformed1);
var del2 = new EventHandler<WorkPerformedEventArgs>(WorkPerformed2);
var del3 = new EventHandler<WorkPerformedEventArgs>(WorkPerformed3);
var del4 = new EventHandler(WorkCompleted);

del1 += del2 + del3;

var worker = new Worker(del1, del4);
worker.DoWork(null, delArgs);


var w2 = new Worker();
w2.WorkPerformed += Work_OnWorkPerformed;
w2.WorkCompleted += Work_OnWorkCompleted;
w2.WorkCompletedWithNoArgs += Work_OnWorkCompletedWithNoArgs;
w2.DoWork(null, delArgs);

static void Work_OnWorkPerformed(object? sender, WorkPerformedEventArgs args)
{
    Console.WriteLine("Performing work. From Program...");
}

static void Work_OnWorkCompleted(object? sender, EventArgs args)
{
    Console.WriteLine("Work Completed! From Program...");
}

static void Work_OnWorkCompletedWithNoArgs()
{
    Console.WriteLine("Work Completed With No Args! From Program...");
}

