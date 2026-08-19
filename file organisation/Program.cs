string ? readResult;

//ask for folder, read result, check if the folder exists.
Console.WriteLine("Enter the folder you want to organize.");

readResult = Console.ReadLine();

bool folderExists = Directory.Exists(readResult);

if(folderExists)
{
    //continue with organisation
    Console.WriteLine("Folder found");
}
else
{
    Console.WriteLine("That folder does not exist");
}
Console.WriteLine("Files in folder:\n\n");
//get files in folder
static string[] GetFiles(string path)
{
    return Directory.GetFiles(path);
}
if (folderExists)
{
    string[] files = GetFiles(readResult);
    
    foreach (string file in files)
    {
        Console.WriteLine($"{file}");
    }
    Console.WriteLine($"\n\nTotal files: {files.Length}");
}
