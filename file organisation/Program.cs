string? readResult;
bool folderExists;

do
{
    // Ask for a folder, read the result, and check if the folder exists.
    Console.WriteLine("Enter the folder you want to organize.");
    readResult = Console.ReadLine();
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
        string[] directories = Directory.GetDirectories(readResult!);
        Console.WriteLine($"\n\nTotal files: {files.Length}");
        Console.WriteLine($"\nFound {directories.Length} existing folders\n");
        
        foreach (string file in files)
        {
            //get file extension  
            string fileExtension = Path.GetExtension(file);
            string fileName = Path.GetFileNameWithoutExtension(file).Replace(" ", "").ToLower();
            
            Console.WriteLine($"{fileName}\t\t{fileExtension}");

            foreach (string folder in directories)
            {

                string folderName = Path.GetFileName(folder).Replace(" ", "").ToLower();
                Console.WriteLine($"Existing folders: {folderName}");

            }
        }
    }


}
