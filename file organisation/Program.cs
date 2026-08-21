
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
            double lowestNormalizedDistance = double.MaxValue;
            foreach (string folder in directories)
            {

                string folderName = Path.GetFileName(folder).Replace(" ", "").ToLower();
                Console.WriteLine($"  Comparing with: {folderName}");

                // compare file names against folder names
                if (fileName.Contains(folderName))
                {
                    Console.WriteLine($"  Match: {folderName}");
                }
                (int distance, string part, double normalizedDistance) = GetPartialLevenshteinDistance(fileName, folderName);
                {
                    Console.WriteLine($"  Best part: {part}");
                    Console.WriteLine($"  Distance: {distance}");
                    Console.WriteLine($" Normalized distance: {normalizedDistance}");

                    if (normalizedDistance < lowestNormalizedDistance)
                    {
                        lowestNormalizedDistance = normalizedDistance;
                        lowestDistance = distance;
                        bestFolderMatch = folder;
                    }
                }
            }
            Console.WriteLine($"Best folder match: {Path.GetFileName(bestFolderMatch)}");
            Console.WriteLine($"Best normalized distance: {lowestNormalizedDistance}");


        }
    }


}
static int GetLevenshteinDistance(string first, string second)
{
    if (first == second)
    {
        return 0;
    }
    if (first.Length == 0)
    {
        return second.Length;
    }
    if (second.Length == 0)
    {
        return first.Length;
    }

    int[,] distance = new int[first.Length + 1, second.Length + 1];

    for (int i = 0; i <= first.Length; i++)
    {
        distance[i, 0] = i;
    }
    for (int j = 0; j <= second.Length; j++)
    {
        distance[0, j] = j;
    }
    for (int i = 1; i <= first.Length; i++)
    {
        for (int j = 1; j <= second.Length; j++)
        {
            char firstChar = first[i - 1];
            char secondChar = second[j - 1];

            int cost;

            if (firstChar == secondChar)
            {
                cost = 0;
            }
            else
            {
                cost = 1;
            }
            int deletion = distance[i - 1, j] + 1;
            int insertion = distance[i, j - 1] + 1;
            int substitution = distance[i - 1, j - 1] + cost;

            distance[i, j] = Math.Min(deletion, Math.Min(insertion, substitution));

        }
    }
    return distance[first.Length, second.Length];
}
static (int distance, string part, double normalizedDistance) GetPartialLevenshteinDistance(string fileName, string folderName)
{
    int lowestDistance = int.MaxValue;
    double lowestNormalizedDistance = double.MaxValue;
    double normalizedDistance = double.MaxValue;
    string bestPart = "";

    if (folderName.Length > fileName.Length)
    {
        return (int.MaxValue, string.Empty, double.MaxValue);
    }
    for (int i = 0; i <= fileName.Length - folderName.Length; i++)
    {
        string part = fileName.Substring(i, folderName.Length);
        int distance = GetLevenshteinDistance(part, folderName);
        int longestLength = Math.Max(part.Length, folderName.Length);
        normalizedDistance = (double)distance / longestLength;

        if (normalizedDistance < lowestNormalizedDistance)
        {
            lowestNormalizedDistance = normalizedDistance;
            lowestDistance = distance;
            bestPart = part;
        }
    }
    return (lowestDistance, bestPart, lowestNormalizedDistance);
}
