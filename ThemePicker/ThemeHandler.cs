using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;

namespace ThemePicker
{
    class ThemeHandler
    {
        private static List<Theme> _themes;
        private static string _filePath = Directory.GetCurrentDirectory() + "/themes.txt";

        public static List<Theme> Themes { get { return _themes; } }

        /// <summary>
        /// Load every <seealso cref="Theme"/> from a text file
        /// </summary>
        public static void Load()
        {
            string[] _lines = LoadThemes();
            _themes = new List<Theme>();

            foreach (string _line in _lines) // For each line.
            {
                Theme _theme = new Theme(_line); // Create a theme with the text of the line.
                _themes.Add(_theme); // Add to the list.
            }
        }

        /// <summary>
        /// Removes a <see cref="Theme"/> from the complete list.
        /// </summary>
        /// <param name="_theme">The <see cref="Theme"/> to be removed</param>
        public static void RemoveTheme(Theme _theme)
        {
            _themes.Remove(_theme);
            SaveThemes();
        }

        /// <summary>
        /// Saves every <see cref="Theme"/> to the text file.
        /// </summary>
        private static void SaveThemes()
        {
            string _save = "";

            foreach(Theme _theme in _themes)
            {
                _save += _theme.ThemeName + "\n";
            }

            StreamWriter _streamWritter = new StreamWriter(_filePath);
            _streamWritter.Write(_save);
            _streamWritter.Close();
        }

        /// <summary>
        /// Loads the text file and split it into a seperate <see cref="string"/>
        /// </summary>
        /// <returns>Array of theme names</returns>
        private static string[] LoadThemes()
        {
            FileStream _stream; // Create variable for the file stream

            if (!File.Exists(_filePath)) // If the theme file doesn't exist
            {
                _stream = File.Create(_filePath); // Create the file
                _stream.Close(); // Close the file
                Load(); // Retry this function.
            }

            // If the file does exist
            StreamReader _streamReader = new StreamReader(_filePath); // Open the text file.
            string _fullText = _streamReader.ReadToEnd(); // Read the text file to the end.
            _streamReader.Close(); // Close the text file.
            return _fullText.Split("\n"); // Return the split text by the new line character
        }

        /// <summary>
        /// Gets the <see cref="Theme"/> from an ID
        /// </summary>
        /// <param name="id">The ID of the <see cref="Theme"/></param>
        /// <returns></returns>
        public static Theme GetTheme(int id)
        {
            return _themes[id];
        }

        /// <summary>
        /// Adds a <see cref="Theme"/> to the list.
        /// </summary>
        /// <param name="_theme">Adds a <see cref="Theme"/> to the list</param>
        public static void AddTheme(Theme _theme)
        {
            _themes.Add(_theme);
            SaveThemes();
        }
    }

    public class Theme 
    {
        private string _themeText = "";
        public string ThemeName { get { return _themeText; } set { _themeText = value; } }

        public Theme(string _themeName)
        {
            _themeText = _themeName;
        }
    }

}
