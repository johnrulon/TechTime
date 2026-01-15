
using System;

public abstract class Worker
{
    public virtual void Work()
    {
        // Default implementation for working
    }

    public virtual void Eat()
    {
        // Default implementation for eating
    }
}

// Derived class (OK)
public sealed class HumanWorker : Worker
{
    public override void Work()
    {
        Console.WriteLine("Writing code, attending meetings, shipping features.");
    }

    public override void Eat()
    {
        Console.WriteLine("Eating lunch.");
    }
}

// Incorrect derived class - violates LSP
public sealed class RobotWorker : Worker
{
    public override void Work()
    {
        Console.WriteLine("Executing tasks continuously.");
    }

    // Robots can't eat, but the base contract says they can.
    public override void Eat()
    {
        throw new InvalidOperationException("Robots do not eat.");
    }
}

// Client code that expects any Worker to be substitutable
public static class Client
{
    public static void RunShift(Worker worker)
    {
        worker.Work();
        worker.Eat(); // <- valid expectation per Worker contract
    }

    public static void Demo()
    {
        RunShift(new HumanWorker()); // OK
        RunShift(new RobotWorker()); // Breaks substitutability => LSP violation
    }
}
