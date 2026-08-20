
string? readResult;
bool folderExists;

do
{
    // Ask for a folder, read the result, and check if the folder exists.
    Console.WriteLine("Enter the folder you want to organize.");
    readResult = Console.ReadLine();
    Console.WriteLine($"You entered: [{readResult}]");
    folderExists = Directory.Exists(readResult);

    if (folderExists)
    {
        Console.WriteLine("Folder found");
    }
    else
    {
        Console.WriteLine("That folder does not exist");
    }
}
while (!folderExists);

//get files in folder
if (folderExists)
{
    Console.WriteLine("Files in folder:\n\n");
    static string[] GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }
    if (folderExists)
    {
        string[] files = GetFiles(readResult!);

        foreach (string file in files)
        {     
            string fileExtension = Path.GetExtension(file);
            Console.WriteLine($"{file}\t\t{fileExtension}");           
        }
        Console.WriteLine($"\n\nTotal files: {files.Length}");
    }
}
