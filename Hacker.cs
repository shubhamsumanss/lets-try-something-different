using System.Globalization;
using UnityEngine;

public class Hacker : MonoBehaviour 
{

    //game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;

    // use this for intiallization
    void Start()
    {
        ShowMainMenu();
        print("Hello" + "World");
    }
    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What Would you like to hack into?");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for police station");
        Terminal.WriteLine("Enter your selection: ");
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
            currentScreen = Screen.MainMenu;    
        }

        else if (currentScreen == Screen.MainMenu)
        {
           RunMainMenu(input);
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame(level);
        }
        else if (input == "2")
        {
            level = 2;
            StartGame(level);
        }
        else if (input == "3")
        {
            level = 3;
            StartGame(level);
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void StartGame(int levelnumber)
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen " + levelnumber);
        Terminal.WriteLine("Please enter your password ");
    }
}
