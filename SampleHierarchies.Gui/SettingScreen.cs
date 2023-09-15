using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

public sealed class SettingScreen : Screen
{

    private ISettingsService _settingService;

    public SettingScreen(
        ISettingsService settingsService)
    {
        _settingService = settingsService;
    }


    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Settings");
            Console.WriteLine("2. Save to file");
            Console.WriteLine("3. Read from file");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                SettingsScreeenChoise choice = (SettingsScreeenChoise)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case SettingsScreeenChoise.Settings:
                        ListSettings();
                        break;

                    case SettingsScreeenChoise.Read:
                        ReadFromFile();
                        break;

                    case SettingsScreeenChoise.Save:
                        SaveToFile();
                        break;

                    case SettingsScreeenChoise.Exit:
                        Console.WriteLine("Going back to parent menu.");
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// Save to file.
    /// </summary>
    private void SaveToFile()
    {
        try
        {
            Console.Write("Press Enter to save the data to a file. ");
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _settingService.Write(fileName);
            Console.WriteLine("Data saving was successful.");
        }
        catch
        {
            Console.WriteLine("Data saving was not successful.");
        }
    }

    /// <summary>
    /// Read data from file.
    /// </summary>
    private void ReadFromFile()
    {
        try
        {
            Console.Write("To read data from the file, press Enter. ");
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _settingService.Read(fileName);
            Console.WriteLine("Data reading was successful.");
        }
        catch
        {
            Console.WriteLine("Data reading from was not successful.");
        }
    }

    private void ListSettings()
    {
        Console.WriteLine();
            Console.WriteLine("Here's your settings:");
        _settingService.settings.Display();
    }

    #endregion // Private Methods
}
