using UnityEngine;

public class Hacker : MonoBehaviour
{

    int level;
    string password;
    const string menu = "you can enter menu at any time ";
    string[] level1passwords = { "ready", "hacker", "terminal", "proper" };
    string[] level2passwords = { "highlevel", "source", "goggles", "hplaptop" };
    string[] level3passwords = { "environment", "hyderabad", "armyforce", "ropelaunch" };

    
    enum Screen { menupage, difficultylevel, password, gamepage }
    Screen presentscreen = Screen.menupage;
    void Start()
    {
        mainmenu();
    }

    void mainmenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("select an engine to work for ");
    }
    void OnUserInput(string order)
    {
        if (order == "menu")
        {
            mainmenu();
            presentscreen = Screen.menupage;
        }
        else if (presentscreen == Screen.menupage)
        {
            selectengine(order);
        }
        else if (presentscreen == Screen.difficultylevel)
        {
            passwordfixing(order);
        }
        else if (presentscreen == Screen.password)
        {
            passwordverification(order);
        }
    }

    void passwordverification(string order)
    {
        if (order == password)
        {
            gameplay();
        }
        else
        {
            Terminal.WriteLine("you have entered incorrect password");
            Terminal.WriteLine(menu);
        }
    }

    void gameplay()
    {
        Terminal.ClearScreen();
        presentscreen = Screen.gamepage;
        displayrewards();
    }

    void displayrewards()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("congratulations, you have won the fuel for completing level 1");
                Terminal.WriteLine(@"
        __
 ______/ /
(        |
| petrol |
| :) :)  |
| 1 litre|
(________)
                          ");
                break;
            case 2:
                Terminal.WriteLine("congratulations, you have won bullets and 100$ for completing level 2");
                Terminal.WriteLine(@"
 __________________
|100$  ___         |   
|     |^ ^|        | & /^\  /^\  /^\  /^\
|     |_~_|        |   | |  | |  | |  | |
|__________________|   |_|  |_|  |_|  |_|
                                 ");
                break;
            case 3:
                Terminal.WriteLine("congratulations, you have won the army force for completing level 3");
                Terminal.WriteLine(@"
          ____
         | ^ ^|
         |__~_|     
        ___||___   
       ||      ||
       ||      ||           
       ||______||                           
        |      |       
        |  /\  |
        | /  \ |
        ||    ||


                                 ");
                break;
        }

    }

    void passwordfixing(string order)
    {
        if (order == "1" || order == "2" || order == "3")
        {
            level = int.Parse(order);
            switch (level)
            {
                case 1:

                    level = 1;
                    password = level1passwords[Random.Range(0, level1passwords.Length)];
                    gamefunction();
                    break;
                case 2:

                    level = 2;
                    password = level2passwords[Random.Range(0, level2passwords.Length)];
                    gamefunction();
                    break;
                case 3:

                    level = 3;
                    password = level3passwords[Random.Range(0, level3passwords.Length)];
                    gamefunction();
                    break;

            }
        }
        else
        {
            Terminal.WriteLine("invalid level");
            Terminal.WriteLine(menu);
        }
    }
    //asking for engine
    void selectengine(string input)
    {
        if (input == "aero")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("you have chosen aeroplane for battle");
            Terminal.WriteLine("choose a level");
            presentscreen = Screen.difficultylevel;
        }
        else if (input == "Helicopter")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You have chosen Helicopter for battle ");
            Terminal.WriteLine("choose a level ");
            presentscreen = Screen.difficultylevel;
        }
        else
        {
            mainmenu();
            Terminal.WriteLine("please select a valid engine");
            Terminal.WriteLine(menu);
        }
    }

    //asking for passwords 
    void gamefunction()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("you have chosen level" + level);
        Terminal.WriteLine("enter the game password + hint " + password.Anagram());
        presentscreen = Screen.password;
    }
}