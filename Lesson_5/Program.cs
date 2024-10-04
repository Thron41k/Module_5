﻿//Console.WriteLine("Напишите что-то");
//var str = Console.ReadLine();
//Console.WriteLine("Укажите глубину эха");
//var deep = int.Parse(Console.ReadLine() ?? "1");
//Echo(str, deep);
Console.WriteLine(Factorial(20));
Console.ReadKey();
return;

static void Echo(string? phrase, int deep)
{
    var modif = phrase;
    if (modif is { Length: > 2 })
    {
        modif = modif.Remove(0, 2);
    }
    Console.BackgroundColor = (ConsoleColor)deep;
    Console.WriteLine($"...{modif}");
    if (deep > 1)
    {
        Echo(modif, deep - 1);
    }
}

static int Factorial(int x)
{
    if (x == 0)
    {
        return 1;
    }
    return x * Factorial(x - 1);
}
