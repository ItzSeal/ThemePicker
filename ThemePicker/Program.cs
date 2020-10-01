using System;
using System.Runtime.CompilerServices;

namespace ThemePicker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Theme Picker!"; // Sets the title of the console.
            ThemeHandler.Load(); // Loads the themes from file
            Menu(); // Draws the menu to the screen.
        }

        public static void Menu()
        {
            Console.WriteLine("/-------------------\\");
            Console.WriteLine("|        MENU       |");
            Console.WriteLine("\\-------------------/");
            Console.WriteLine("");
            Console.WriteLine("1) Get Theme(s)");
            Console.WriteLine("2) List Themes");
            Console.WriteLine("3) Add Theme");
            Console.WriteLine("4) Remove Theme");
            Console.WriteLine("5) Exit");
            Console.WriteLine("");

            int _value = int.Parse(Console.ReadLine()); // Gets value from user.

            switch (_value)
            {
                case 1:
                    GetThemes(); // Get one or more themes
                    return;

                case 2:
                    ListThemes(); // List all the themes
                    return;

                case 3:
                    AddTheme(); // Add a theme
                    return;

                case 4:
                    RemoveTheme(); // Remove a theme
                    return;

                case 5:
                    Environment.Exit(0); // Exit the programme
                    break;
            }

            // The user entered a value that is not valid
            Console.Clear(); // Clear the screen
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unknown Input... Try again...");
            Console.ForegroundColor = ConsoleColor.White;
            Menu(); // Draws the menu to the screen.
        }

        public static void ListThemes()
        {
            Console.Clear();
            Console.WriteLine("/-------------------\\");
            Console.WriteLine("|       THEMES      |");
            Console.WriteLine("\\-------------------/");
            Console.WriteLine("");

            for(int  i = 0; i < ThemeHandler.Themes.Count; i++) // Go through all the different themes
            {
                Console.WriteLine($"{i}) {ThemeHandler.Themes[i].ThemeName}"); // Write themes to screen
            }

            Console.ReadKey();
            Console.Clear();
            Menu(); // Draws the menu to the screen.
        }

        public static void RemoveTheme()
        {
            Console.Clear();
            Console.WriteLine("/-------------------\\");
            Console.WriteLine("|   REMOVE THEMES   |");
            Console.WriteLine("\\-------------------/");
            Console.WriteLine("");

            for (int i = 0; i < ThemeHandler.Themes.Count; i++) // Go through all the different themes
            {
                Console.WriteLine($"{i}) {ThemeHandler.Themes[i].ThemeName}"); // Write themes to screen
            }

            int _value = int.Parse(Console.ReadLine()); // Get number of the theme that should be deleted

            if (ThemeHandler.Themes[_value] != null)
                ThemeHandler.RemoveTheme(ThemeHandler.Themes[_value]); // Remove said theme
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unknown Input... Try again...");
                Console.ForegroundColor = ConsoleColor.White;
                RemoveTheme();
            }

            Console.Clear();
            Menu(); // Draws the menu to the screen.

        }

        public static void AddTheme()
        {
            Console.Clear();
            Console.WriteLine("/-------------------\\");
            Console.WriteLine("|     ADD THEMES    |");
            Console.WriteLine("\\-------------------/");
            Console.WriteLine("");
            Console.WriteLine("What is the theme you wish to add?");
            Console.WriteLine("");

            string _themeName = Console.ReadLine(); // Theme that should be added

            ThemeHandler.AddTheme(new Theme(_themeName)); // Add the theme

            Console.Clear();
            Console.WriteLine("/-------------------\\");
            Console.WriteLine("|    BACK TO MENU?   |");
            Console.WriteLine("\\-------------------/");
            Console.WriteLine("");
            Console.WriteLine("(Y / N)");
            Console.WriteLine("");

            string _answer = Console.ReadKey().ToString().ToLower(); // Should the programme go back to the menu?

            if (_answer == "y")
            {
                Console.Clear();
                Menu(); // Draws the menu to the screen.
            }

            Console.Clear();
            AddTheme(); // Add another theme
        }

        public static void GetThemes()
        {
            Console.Clear();
            Console.WriteLine("How many themes do you require?"); // Get how many themes the user requires.
            int _value = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("/-------------------\\");
            Console.WriteLine("|  YOUR THEMES ARE  |");
            Console.WriteLine("\\-------------------/");
            Console.WriteLine("");
            for(int i = 1; i <= _value; i++) // lists the themes
            {
                var _random = new Random();
                Theme _theme = ThemeHandler.Themes[_random.Next(0, ThemeHandler.Themes.Count)];
                Console.WriteLine($"{i}) {_theme.ThemeName}");
            }

            Console.WriteLine("");
            Console.WriteLine("Press ANY key to go back to the menu...");
            Console.ReadKey();
            Console.Clear();
            Menu(); // Draws the menu to the screen.
        }
    }
}
