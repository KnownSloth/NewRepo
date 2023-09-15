using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Setting service.
    /// </summary>
    private ISettingsService _settingService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private AnimalsScreen _animalsScreen;
    /// <summary>
    /// Setting Screen.
    /// </summary>
    private SettingScreen _settingScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="settingaService">Settingservice reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    /// <param name="settingScreen">Setting Screen</param>
    public MainScreen(
        IDataService dataService,
    ISettingsService settingService,
        AnimalsScreen animalsScreen,
        SettingScreen settingScreen)
    {
        _dataService = dataService;
        _settingService = settingService;
        _animalsScreen = animalsScreen;
        _settingScreen = settingScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            Console.BackgroundColor = _settingService.settings.MainScreen;
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Animals");
            Console.WriteLine("2. Create a new settings");
            Console.Write("Please enter your choice: ");
            Console.BackgroundColor = ConsoleColor.Black;

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.Animals:
                        _animalsScreen.Show();
                        break;

                    case MainScreenChoices.Settings:
                        _settingScreen.Show();
                        break;

                    case MainScreenChoices.Exit:
                        Console.WriteLine("Goodbye.");
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
}