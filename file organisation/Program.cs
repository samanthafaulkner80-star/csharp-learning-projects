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

            string? bestFolderMatch = null;
            int lowestDistance = int.MaxValue;

            foreach (string folder in directories)
            {

                string folderName = Path.GetFileName(folder).Replace(" ", "").ToLower();
                Console.WriteLine($"  Comparing with: {folderName}");

                // compare file names against folder names
                if (fileName.Contains(folderName))
                {
                    Console.WriteLine($"  Match: {folderName}");
                }
                int distance = GetPartialLevenshteinDistance(fileName, folderName);
                {
                    if (distance < lowestDistance)
                    {
                        lowestDistance = distance;
                        bestFolderMatch = folder;
                    }
                }
            }



        }
    }


}
static int GetLevenshteinDistance(string first, string second)
{
    
}
static int GetPartialLevenshteinDistance(string fileName, string folderName)
{
    int lowestDistance = int.MaxValue;
    if (folderName.Length > fileName.Length)
    {
        return int.MaxValue;
    }
    for (int i = 0; i <= fileName.Length - folderName.Length; i++)
    {
        string part = fileName.Substring(i, folderName.Length);
        int distance = GetLevenshteinDistance(part, folderName);
        
        if (distance < lowestDistance)
        {
            lowestDistance = distance;
        }
    }
    return lowestDistance; 
}
