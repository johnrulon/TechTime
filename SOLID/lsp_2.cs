
using System;

public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

// Humans: can work and eat
public sealed class HumanWorker : IWorkable, IEatable
{
    public void Work()
    {
        Console.WriteLine("Writing code, attending meetings, shipping features.");
    }

    public void Eat()
    {
        Console.WriteLine("Eating lunch.");
    }
}

// Robots: can work, but not eat
public sealed class RobotWorker : IWorkable
{
    public void Work()
    {
        Console.WriteLine("Executing tasks continuously.");
    }
}

// Client code that expects any Worker to be substitutable
public static class Client
{
    public static void RunShift(IWorkable worker)
    {
        worker.Work(); // no assumption about eat()
    }

    public static void LunchBreak(IEatable eater)
    {
        eater.Eat();
    }

    public static void Demo()
    {
        RunShift(new HumanWorker());
        RunShift(new RobotWorker());

        LunchBreak(new HumanWorker());

        LunchBreak(new RobotWorker()); // Won't compile because RobotWorker doesn't implement IEatable
    }
}
