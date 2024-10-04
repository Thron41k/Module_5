Console.WriteLine("Напишите что-то");
var str = Console.ReadLine();
Console.WriteLine("Укажите глубину эха");
var deep = int.Parse(Console.ReadLine() ?? "1");
for (var i = 0; i < deep; i++)
{
    Echo(str);
}
return;

static void Echo(string? saidword)
{
    Console.WriteLine(saidword);
}
