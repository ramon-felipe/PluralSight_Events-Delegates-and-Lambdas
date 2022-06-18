// See https://aka.ms/new-console-template for more information

using EventsDelegatesLambdas;

Method1();
Method2();
Method3();



static void Method1()
{
    static void WorkPerformed1(WorkPerformedEventArgs e) =>
    Console.WriteLine("WorkPerformed1. Worker performed {0} for {1} hours", e.WorkType, e.Hours);

    static void WorkPerformed2(WorkPerformedEventArgs e) =>
        Console.WriteLine("WorkPerformed2. Worker performed {0} for {1} hours", e.WorkType, e.Hours);

    static void WorkPerformed3(WorkPerformedEventArgs e) =>
        Console.WriteLine("WorkPerformed3. Worker performed {0} for {1} hours", e.WorkType, e.Hours);

    static void WorkCompleted(object? sender, EventArgs e) =>
        Console.WriteLine("WORK COMPLETED!!");


    var delArgs = new WorkPerformedEventArgs(2, WorkType.Golf);

    Console.WriteLine("Hello, World!");

    var del1 = WorkPerformed1;
    var del2 = WorkPerformed2;
    var del3 = WorkPerformed3;

    var del4 = new EventHandler(WorkCompleted);

    del1 += del2 + del3;
    del1 += (args) => Console.WriteLine("Last call del1 lambda...");

    var worker = new Worker(del1, del4);
    worker.DoWork(null, delArgs);
}

static void Method2()
{
    var delArgs = new WorkPerformedEventArgs(2, WorkType.Golf);

    var w2 = new Worker();
    w2.WorkPerformed += Work_OnWorkPerformed;
    w2.WorkCompleted += Work_OnWorkCompleted;
    w2.WorkCompletedWithNoArgs += Work_OnWorkCompletedWithNoArgs;
    w2.WorkCompletedWithNoArgs += () =>
    {
        Console.WriteLine("testing...");
    };

    w2.DoWork(null, delArgs);

    static void Work_OnWorkPerformed(WorkPerformedEventArgs args)
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

    AddDelegate ad = (a, b) => a + b;
    var result = ad(1, 10);
    Console.WriteLine("Resultado: {0}", result);


    Func<bool> BoolFunc = () =>
    {
        Console.WriteLine("Testing func...");
        return true;
    };

    Console.WriteLine("Resultado BoolFunc: {0}", BoolFunc());
}


static void Method3()
{
    var processData = new ProcessData();
    BizRulesDelegate delAdd = (int x, int y) => x + y;
    BizRulesDelegate delMult = (int x, int y) => x * y;

    Console.WriteLine($"{nameof(BizRulesDelegate)}: ({nameof(delAdd)}): " + processData.Process(2, 3, delAdd));
    Console.WriteLine($"{nameof(BizRulesDelegate)}: ({nameof(delMult)}): " + processData.Process(2, 3, delMult));
}

public delegate int AddDelegate(int a, int b);
public delegate int BizRulesDelegate(int x, int y);

