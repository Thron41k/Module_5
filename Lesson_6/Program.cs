ShowUserData(GetUserData());
Console.WriteLine();
Console.WriteLine("Нажмите любую клавишу для выхода.");
Console.ReadKey();
return;

static void ShowUserData((string Name, string Surname, int Age, string[] Pets, string[] FavColors) userData)
{
    Console.WriteLine();
    Console.WriteLine($"Вас зовут: {userData.Name} {userData.Surname}");
    Console.WriteLine($"Ваш возраст: {userData.Age}");
    if (userData.Pets.Length > 0)
    {
        Console.Write("Ваши домашние питомцы: ");
        foreach (var pet in userData.Pets)
        {
            Console.Write(pet);
            if(pet != userData.Pets[^1]) Console.Write(", ");
        }
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("У вас нет домашних питомцев.");
    }

    if (userData.FavColors.Length > 0)
    {
        Console.Write("Ваши любимые цвета: ");
        foreach (var color in userData.FavColors)
        {
            Console.Write(color);
            if (color != userData.FavColors[^1]) Console.Write(", ");   
        }
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("У вас нет любимых цветов.");
    }
    
}
static (string Name, string Surname, int Age, string[] Pets, string[] FavColors) GetUserData()
{
    (string Name, string Surname, int Age, string[] Pets, string[] FavColors) userData;
    Console.WriteLine("Введите своё имя:");
    userData.Name = ReadInputString();
    Console.WriteLine("Введите свою фамилию:");
    userData.Surname = ReadInputString();
    Console.WriteLine("Введите свой возраст:");
    userData.Age = ReadInputNumerical();
    userData.Pets = Array.Empty<string>();
    Console.WriteLine("У вас есть домашние питомцы?(Да/Нет):");
    if (YesNoQuestion())
    {
        Console.WriteLine("Сколько у вас домашних питомцев?:");
        var petsCount = ReadInputNumerical();
        userData.Pets = GetInputStringArray(petsCount, "Введите имя домашнего питомца ");
    }
    Console.WriteLine("Сколько у вас любимых цветов?:");
    userData.FavColors = GetInputStringArray(ReadInputNumerical(true), "Введите любимый цвет №");
    return userData;
}
static string[] GetInputStringArray(int arraySize,string question)
{
    var array = new string[arraySize];
    for (var i = 0; i < arraySize; i++)
    {
        Console.WriteLine($"{question}{i + 1}:");
        array[i] = ReadInputString();
    }
    return array;
}
static bool YesNoQuestion()
{
    while (true)
    {
        var data = Console.ReadLine();
        if (CheckInputString(data))
        {
            switch (data)
            {
                case "Да":
                    return true;
                case "Нет":
                    return false;
                default:
                    WriteRedError("Некорректное значение.");
                    continue;
            }
        }
    }
}
static string ReadInputString()
{
    while (true)
    {
        var data = Console.ReadLine();
        if (CheckInputString(data)) return data!;
    }
}
static int ReadInputNumerical(bool zeroAllowed = false)
{
    while (true)
    {
        var data = Console.ReadLine();
        if (!CheckInputNumerical(data, out var num)) continue;
        if (!zeroAllowed && num == 0)
        {
            WriteRedError("Значение не может быть нулевым.");
        }
        else { return num; }
    }
}
static bool CheckInputString(string? data)
{
    try
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            WriteRedError("Строка не может быть пустой.");
            return false;
        }
        if (!int.TryParse(data, out _)) return true;
        WriteRedError("Данные не должны содержать цифры.");
        return false;
    }
    catch (Exception ex)
    {
        WriteRedError(ex.Message);
    }
    return false;
}
static bool CheckInputNumerical(string? data, out int num)
{
    num = 0;
    try
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            WriteRedError("Строка не может быть пустой.");
            return false;
        }
        var ageResult = int.TryParse(data, out num);
        if (ageResult)
        {
            return true;
        }
        WriteRedError("Данные должны содержать число.");
        return false;
    }
    catch (Exception ex)
    {
        WriteRedError(ex.Message);
    }
    return false;
}
static void WriteRedError(string error)
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine($"{error} Попробуйте ещё раз.");
    Console.BackgroundColor = ConsoleColor.Black;
}
