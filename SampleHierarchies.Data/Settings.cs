using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Data;

/// <summary>
/// Animals collection.
/// </summary>
public class Settings : ISettings
{
    //fields for colors

    public string Version { get; set; }

    public ConsoleColor MainScreen { get; set; }
    public ConsoleColor AnimalsScreen { get; set; }
    public ConsoleColor MammalsScreen { get; set; }
    public ConsoleColor DogScreen { get; set; }

    //settings if program can`t find json for colors

    public Settings()
    {
        Version = "1.0";
        MainScreen = ConsoleColor.DarkRed;
        AnimalsScreen = ConsoleColor.DarkCyan;
        MammalsScreen = ConsoleColor.Yellow;
        DogScreen = ConsoleColor.Green;
    }

    //method display for settings

    public void Display()
    {
        Console.WriteLine($"Version is: {Version}, MainScreen color is: {MainScreen}, MammalsScreen color is: {MammalsScreen} and DogScreen color is: {DogScreen}");
    }

}
