namespace _6._6._wiskundequiz_programma;

class Program
{
    // Variables
    



    enum MenuOptions { Normal=1, Level, Study, Exit };
    enum LevelOptions { Easy=1, Medium, Hard, MainMenu };
    static void Main(string[] args)
    {
        string playerName = "";


        // Show game intro
        GameIntro();
       
        // Ask playername
        playerName = Input.AskString("Geef je naam op: ");

        // Start game menu
        GameMenu(playerName);

    }

    // Methods
    //
    // Game intro
    static void GameIntro()
    {
        Console.WriteLine("Welkom in het wiskunde programma!");
    }

    // Game menu
    static void GameMenu(string playerName)
    {
        Console.WriteLine("Wat wil je doen?");
        Console.WriteLine("1. Standaard oefeningen opstarten, waarbij het niveau stijgt na elke 5 correcte antwoorden.");
        Console.WriteLine("2. Start oefeningen van een bepaald niveau.");
        Console.WriteLine("3. Start de studie modus, hierbij krijg je automatisch de correcte antwoorden");
        Console.WriteLine("4. Sluit het programma af. Genoeg geoefend voor vandaag?!");
        int userChoice = int.Parse(Console.ReadLine());

        MenuOptions choice = (MenuOptions)userChoice;

        switch (choice)
        {
            case MenuOptions.Normal:
                // Start game in Normal mode
                int result = PlayGameNormal();
                GameScore(playerName, result);
                GameMenu(playerName);

                break;
            case MenuOptions.Level:
                // Start game in Level mode
                int level = GameMenuLevels();
                
                int resultLevel = PlayGameLevel(level);
                GameScore(playerName, resultLevel);
                GameMenu(playerName);
                break;
            case MenuOptions.Study:
                // Start game in Study mode
                PlayGameStudy();
                GameMenu(playerName);
                break;
            case MenuOptions.Exit:
                System.Environment.Exit(1);
                break;
            default:
                Console.WriteLine("Geen geldige keuze");
                break;
        }
    }

    static int GameMenuLevels()
    {
        Console.WriteLine("Kies de moeilijheidsgraad voor de oefeningen:");
        Console.WriteLine("1. Gemakkelijk");
        Console.WriteLine("2. Middelmatig");
        Console.WriteLine("3. Moeilijk");
        Console.WriteLine("4. Hoofdmenu");

        int userChoice = int.Parse(Console.ReadLine());

        LevelOptions choice = (LevelOptions)userChoice;

        switch (choice)
        {
            case LevelOptions.Easy:
                return 1;
                break;
            case LevelOptions.Medium:
                return 2;
                break;
            case LevelOptions.Hard:
                return 3;
                break;
            case LevelOptions.MainMenu:
                return 4;
                break;
            default:
                // Console.WriteLine("Geen geldige keuze");
                // GameMenuLevels();
                return 0;
                break;
        }
    }

    // PlayGame method Normal mode
    static int PlayGameNormal()
        {
        int goodAnswers = 0;

        // main do loop, keeps running until wrong answer
        bool result = true;
        do
        {
            
            int basicLevel = 6; 
            int level = 0;
            int levelUp = 0;
            levelUp = VerifyLevel(goodAnswers);
            level = basicLevel + levelUp;
            Random rangen = new Random();

            int number1 = rangen.Next(1, 11);
            int number2 = rangen.Next(1, level);
          
            

            // Call MultiPlications function, which returns bool to indicate a good or a wrong answer, do loop exits on a wrong answer
            result = Multiplications(number1, number2);
            if(result)
            {
                goodAnswers++; // Calculate good answers
            }
           

        }
        while (result);

        return goodAnswers;

    }

    // PlayGame method Level mode
    static int PlayGameLevel( int gameLevel)
    {
        int levelUp = 0;
        if(gameLevel==1)
        {
            levelUp = 0;
        }
        else if(gameLevel==2)
        {
            levelUp = 5;
        }
        else if(gameLevel==3)
        {
            levelUp = 10;
        }
        int goodAnswers = 0;

        // main do loop, keeps running until wrong answer
        bool result = true;
        do
        {
            
            int basicLevel = 6; 
            int level = 0;
            
            level = basicLevel + levelUp;
            Random rangen = new Random();

            int number1 = rangen.Next(1, 11);
            int number2 = rangen.Next(1, level);
          
            

            // Call MultiPlications function, which returns bool to indicate a good or a wrong answer, do loop exits on a wrong answer
            result = Multiplications(number1, number2);
            if(result)
            {
                goodAnswers++; // Calculate good answers
            }
           

        }
        while (result);

        return goodAnswers;

    }

    // PlayGame method Study mode 
    static void PlayGameStudy()
    {
        for (int i = 0; i < 15; i++)
        {
            int basicLevel = 6;
            int levelUp = 0;
            int level = 0;
            if (i < 5)
            { 
                levelUp = 0; 
            }
            else if(i>=5 && i < 10)
            {
                levelUp = 5;
            }
            else if (i>=10)
            {
                levelUp = 10;
            }
            else{}

            level = basicLevel + levelUp;
            Random rangen = new Random();

            int number1 = rangen.Next(1, 11);
            int number2 = rangen.Next(1, level);

            Console.WriteLine($"{number1} x {number2} = {number1 * number2}");
            System.Threading.Thread.Sleep(5000);

        }
    }

    // Method to calculate multiplications
    static bool Multiplications(int number1, int number2)
    {
        int answer = Input.AskInteger($"{number1} x {number2} = ");
        if (answer == number1 * number2)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    // Method to print the game score to the user
    static void GameScore(string playerName, int goodAnswers)
    {
        Console.WriteLine($"{playerName} je scoorde {goodAnswers} correct(e) antwoord(en).");
    }

    // Method to verify level based on good answers, f.e. 5 good answers, level 1, 
    // 10 good answers level 2, etc.
    static int VerifyLevel(int goodAnswers)
    {
        if(goodAnswers < 5)
        {
            return 0;
        }
        else if (goodAnswers >= 5 && goodAnswers < 10)
        {
            return 5;
        }
        else
        {
            return 10;
        }    
                
    }
        
    // Class to verify valid integer or string input by user

    public static class Input
    {
        public static string AskString(string question)
        {
            Console.Write($"{question}");
            return Console.ReadLine() ?? string.Empty;
        }
        public static int AskInteger(string question)
        {
            while (true)
            {
                Console.Write($"{question}");
                if (int.TryParse(Console.ReadLine(), out int r))
                    return r;

            }
        }
    }
    
}



