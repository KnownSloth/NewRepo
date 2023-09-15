using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Animals screen.
    /// </summary>
    private ISettingsService _settingsService;
    private DogsScreen _dogsScreen;
    private AfricanelephantsScreen _africanelephantsScreen;
    private PolarBearsScreen _polarBearsScreen;
    private ChimpanzeesScreen _chimmanzee;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="settingsService">Settings service reference</param>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    public MammalsScreen(ISettingsService settingsService, DogsScreen dogsScreen, AfricanelephantsScreen africanelephantsScreen, PolarBearsScreen polarBearsScreen, ChimpanzeesScreen chimpanzeesScreen)
    {
        _settingsService = settingsService;
        _dogsScreen = dogsScreen;
        _africanelephantsScreen = africanelephantsScreen;
        _polarBearsScreen = polarBearsScreen;
        _chimmanzee = chimpanzeesScreen;
    }
   
    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            Console.BackgroundColor = _settingsService.settings.MammalsScreen;
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Dogs");
            Console.WriteLine("2. African elephant");
            Console.WriteLine("3. Polar bear");
            Console.WriteLine("4. Chimpanzee");
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

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show();
                        break;
                    case MammalsScreenChoices.Elephant:
                        _africanelephantsScreen.Show(); 
                        break;
                    case MammalsScreenChoices.Bear:
                        _polarBearsScreen.Show();
                        break;
                    case MammalsScreenChoices.Chimpanzee:
                        _chimmanzee.Show();
                        break;

                    case MammalsScreenChoices.Exit:
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
}
