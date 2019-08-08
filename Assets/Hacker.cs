using UnityEngine;

public class Hacker : MonoBehaviour
{
    //game config data
    const string menuHint = "You may type \"menu\" at any time.";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "gay", "fucker", "gayz", "dodatshit", "doit", "lendmesomemoney" };
    string[] level3Passwords = { "apple", "pineapple", "watermelon", "orange", "cranberry", "strawberry" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win}
    Screen currentScreen = Screen.MainMenu;
    string password;
    
    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
	}
    
	// Update is called once per frame

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        var greeting = "Hello Niki";
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library!");
        Terminal.WriteLine("Press 2 for the police station!");
        Terminal.WriteLine("Press 3 for the fruits!");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
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

    private bool ValidateLevel(string input)
    {
        bool validLevel = false;
        if (input == "1" || input == "2" || input == "3")
            validLevel = true;
        return validLevel;
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = ValidateLevel(input);
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }

        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond");
        }

        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (password == input)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"    
        _______
       /      //
      /      //
     /______//
    (______(/"
                );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key");
                Terminal.WriteLine(@"    
     __
    /0 \_______
    \__/-=' = '
");
            break;

            case 3:
                Terminal.WriteLine("You got the pineapple fruit!");
                Terminal.WriteLine(@"
          \||/
          \||/
        .<><><>.
       .<><><><>.
       '<><><><>'
        '<><><>'
");
                break;
            default:
                break;
        }

    }
}
