using System;
using UnityEngine;
public class Hacker : MonoBehaviour
{
    //Game configurations data
    string[] level1passwords = { "Books", "Aisle","Self","Password","Font","Borrow"};
    string[] level2passwords = { "Prisoners", "Handcuff", "Holster", "Uniform", "Arrest" };
    //game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    string password;

    // use this for intiallization
    void Start()
    {
        ShowMainMenu();
        
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
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    } 
      void RunMainMenu(string input)
      {
        bool isValidlevelNumber = (input == "1" || input == "2");
        if (isValidlevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
      }
    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                password = level1passwords[0];
                break;
            case 2:
                password = level2passwords[0];
                break;
            default:
                Debug.LogError("invalid level number");
                break;
        }
        Terminal.WriteLine("Please enter your password ");
    }
    void CheckPassword(string input)
    {
        if (password == input)
        {
            Terminal.WriteLine("well Done");
        }
        else
        {
            Terminal.WriteLine("sorry bro, wrong password");
        }
    }

}
