Console.WriteLine("Напишите что-то");
var str = Console.ReadLine();
Console.WriteLine("Укажите глубину эха");
var deep = int.Parse(Console.ReadLine() ?? "1");
Echo(str, deep);
Console.ReadKey();
return;

static void Echo(string? phrase, int deep)
{
    Console.WriteLine(phrase);
    if (deep > 1)
    {
        Echo(phrase, deep - 1);
    }
}
