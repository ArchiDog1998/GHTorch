using System;
using System.Runtime.InteropServices;
using TorchSharp;

public class Demo
{
    public static void Main()
    {
        Console.WriteLine($"FrameworkDescription: {RuntimeInformation.FrameworkDescription}");

        Console.WriteLine(GHTorch.TorchSharp.Test.TestFunc());
        Console.ReadLine();
    }
}

