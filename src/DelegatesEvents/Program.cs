using DelegatesEvents.Extensions;
using DelegatesEvents.FileWork;


Console.WriteLine("!!!START PROGRAM!!!");
string catalog = Directory.GetCurrentDirectory();
Console.WriteLine($"Finding files in program catalog: {catalog}");

FileProcessor fileProcessor = new();
fileProcessor.Cancellation = false;
fileProcessor.FileFound += FileProcessor_FileFound;
fileProcessor.Find(catalog);


Console.WriteLine("");
Console.WriteLine("Press any key to find Max element of numbers");
Console.ReadLine();

var floats = new List<string>() { "1", "2", "3.6", "-2" };
var maxNum = floats.GetMax<string>(MaxFloat);

Console.WriteLine($"Max number is {maxNum}");
Console.WriteLine("!!!END PROGRAM!!!");


static void FileProcessor_FileFound(object? sender, FileEventArgs e)
{
    //найденный результат выводим в консоль (имя, путь, размер, дата создания файла)
    Console.WriteLine("-->" + e.FileEventInfo.Name + " " + e.FileEventInfo.Length + "_байт"
    + " Создан: " + e.FileEventInfo.CreationTime);

    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("Do you want continue searching files (Y/N) ?");

        var cmd = Console.ReadLine()!.Trim().ToUpper();

        if (cmd != "Y" && cmd != "N")
        {
            Console.WriteLine("Enter correct command of : Y:(Yes), N:(No)");
        }
        else if (cmd == "Y")
        {
            ((FileProcessor)sender!).Cancellation = false;
            break;
        }
        else
        {
            ((FileProcessor)sender!).Cancellation = true;
            return;
        }
    }
}

float MaxFloat<T>(T values)
{
    if (float.TryParse(values!.ToString(), out var num))
    { return num; }
    else
    { return 0; }
}
