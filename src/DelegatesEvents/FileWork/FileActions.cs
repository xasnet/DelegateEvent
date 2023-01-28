namespace DelegatesEvents.FileWork;

public class FileActions
{
    public void FindFile(FileInfo fileInfo)
    {
        Console.WriteLine(fileInfo.FullName);
    }
}
