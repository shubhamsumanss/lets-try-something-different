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
                int index = Random.Range(0, level1passwords.Length);
                password = level1passwords[index];
                break;
            case 2:
                int index2 = Random.Range(0, level2passwords.Length);
                password = level2passwords[index2];
                break;
            default:
                Debug.LogError("invalid level number");
                break;
        }
        Terminal.WriteLine("Please enter your password ");
    }
    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("sorry bro, wrong password");
        }
    }
    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

     void ShowLevelReward()
    {
        switch(level)
            {
        case 1:
            Terminal.WriteLine("Have a Book...");    
                    Terminal.WriteLine(@"
    _______
   /     / /
  /     / /
 /     / / 
(_____( /
"
            );
            break;
        }
    }
}
