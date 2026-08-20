string? readResult;
bool folderExists;

do
{
    Console.WriteLine("====================================");
    Console.WriteLine("          FILE ORGANIZER");
    Console.WriteLine("====================================");
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
    static string[] GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }
    if (folderExists)
    {
        string[] files = GetFiles(readResult!);
        string[] directories = Directory.GetDirectories(readResult!);
        Console.WriteLine($"\nFiles found: {files.Length}");
        Console.WriteLine($"\nFolders found: {directories.Length}");

        foreach (string file in files)
        {
            //get file extension  
            string fileExtension = Path.GetExtension(file);
            string fileName = Path.GetFileNameWithoutExtension(file).Replace(" ", "").ToLower();
            
            Console.WriteLine("====================================");
            Console.WriteLine($"Checking: {fileName} {fileExtension}");
             Console.WriteLine("====================================");
            foreach (string folder in directories)
            {
               
                string folderName = Path.GetFileName(folder).Replace(" ", "").ToLower();
                Console.WriteLine($"  Comparing with: {folderName}");
                
                if (fileName == folderName)
                {
                    Console.WriteLine($"Match: {folderName}");
                }
            }
        }
    }


}
