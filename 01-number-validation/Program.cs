string? readResult;
int number = 0;
int min = 1;
int max = 100;

Console.WriteLine($"Enter a number between {min} and {max}");

bool success;

do
{
    readResult = Console.ReadLine();
    success = int.TryParse(readResult, out number);

    if (!success)
    {
        Console.WriteLine("That's not a valid number. Try again.");
        continue;
    }

    if (number >= min && number <= max)
    {
        Console.WriteLine($"{number} has been accepted!");
        break;
    }
    else
    {
        Console.WriteLine($"Please enter a number between {min} and {max}.");
    }

} while (true);
