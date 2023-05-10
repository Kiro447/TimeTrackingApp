using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackingAppUI.Helpers;

public static class StringHelpers
{
    public static void ColorChanger(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    public static string GetInput(string text)
    {
        Console.Write(text);
        return Console.ReadLine();
    }

}

