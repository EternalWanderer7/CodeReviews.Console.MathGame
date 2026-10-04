public class CSharpMathgame
{
    public static int d = 1;
    private static string _dif = "";
    private static int _x = 0;
    private static int _y = 0;
    private static int _gameScore = 0;
    private static List<List<string>> _history = new List<List<string>>();
    private static List<string> _currentHistoryArray = new List<string>();
    private static string _currentHistory = "";

    public static void Main(string[] args)
    {
        Console.WriteLine("Would you like to play a math game?");
        var a = Console.ReadLine();
        if (a.ToLower() == "yes")
        {
            Game();
        }
        else
        {
            Console.WriteLine("Goodbye!");
        }
    }


    private static void Game()
    {
        _gameScore = 0;
        Difficulty();
        for (int i = 0; i < 5; i++)
        {
            _currentHistory = "";
            var temp = Values();
            Console.WriteLine($"What would you like to do: \nAddition \nSubtraction \nMultiplication \nDivison");
            string answer = Console.ReadLine();
            bool indicator = true;
            while (indicator)
            {
                switch (answer.ToLower())
                {
                    case "addition":
                        Addition(temp[0], temp[1]);
                        indicator = false;
                        break;
                    case "subtraction":
                        Subtraction(temp[0], temp[1]);
                        indicator = false;
                        break;
                    case "multiplication":
                        Multiplication(temp[0], temp[1]);
                        indicator = false;
                        break;
                    case "division":
                        Division(temp[0], temp[1]);
                        indicator = false;
                        break;
                    default:
                        Console.WriteLine("Not Valid! Try again");
                        answer = Console.ReadLine();
                        break;
                }

            }
        }

        _history.Add(_currentHistoryArray);
        Console.WriteLine($"Your final score  is {_gameScore}.");
        Console.WriteLine("Would you like to play again or Look at your history?");
        var b = Console.ReadLine();
        if (b.ToLower() == "history")
        {
            foreach (var item in _history)
            {
                foreach (var jtem in item)
                {
                    Console.WriteLine(jtem);
                }
            }

            Console.WriteLine("Would you like to play again?");
            var c = Console.ReadLine();
            if (c.ToLower() == "yes")
            {
                Game();
            }
            else
            {
                Console.WriteLine("Goodbye!");
            }
        }
        else
        {
            Console.WriteLine("Goodbye!");
        }

    }

    private static int[] Values()
    {
        Random random = new Random();
        if (_dif == "easy")
        {
            _x = random.Next(1, 100);
            _y = random.Next(1, 100);
        }
        else if (_dif == "medium")
        {
            _x = random.Next(1, 1000);
            _y = random.Next(1, 1000);
        }
        else
        {
            _x = random.Next(1, 10000);
            _y = random.Next(1, 10000);
        }

        return [_x, _y];
    }

    private static void Difficulty()
    {
        bool indicator = true;
        while (indicator)
        {
            Console.WriteLine("What difficulty would you like to play in:\nEasy \nMedium \nHard");
            var answer = Console.ReadLine();
            switch (answer.ToLower())
            {
                case "easy":
                    _dif = "easy";
                    indicator = false;
                    break;
                case "medium":
                    _dif = "medium";
                    indicator = false;
                    break;
                case "hard":
                    _dif = "hard";
                    indicator = false;
                    break;
                default:
                    Console.WriteLine("That difficulty doesn't work! Try again");
                    break;

            }
        }

    }

    private static void Multiplication(int f, int g)
    {
        Console.WriteLine($"What is {f} times {g}?");
        var answer = Convert.ToInt32(Console.ReadLine());
        if (answer == f * g)
        {
            _gameScore++;
            Console.WriteLine($"Correct! Your score is {_gameScore}!");
            _currentHistory = $"Multiplication, Correct! Score: {_gameScore}!";
            _currentHistoryArray.Add(_currentHistory);
        }
        else
        {
            Console.WriteLine($"WRONG! The answer is: {f * g}. Your score is {_gameScore}!");
            _currentHistory = $"Multiplication, Wrong! Score: {_gameScore}!";
            _currentHistoryArray.Add(_currentHistory);
        }
    }

    private static void Division(int f, int g)
    {
        while (f % g != 0)
        {
            var temp = Values();
            g = temp[1];

        }

        Console.WriteLine($"What is {f}/{g}?");
        var answer = Convert.ToInt32(Console.ReadLine());
        if (answer == f / g)
        {
            _gameScore++;
            Console.WriteLine($"Correct! Your score is {_gameScore}!");
            _currentHistory = $"Division, Correct! Score: {_gameScore}!";
            _currentHistoryArray.Add(_currentHistory);
        }
        else
        {
            Console.WriteLine($"WRONG! The answer is: {f / g}. Your score is {_gameScore}!");
            _currentHistory = $"Division, Wrong! Score: {_gameScore}!";
            _currentHistoryArray.Add(_currentHistory);
        }
    }

    private static void Addition(int f, int g)
    {
        Console.WriteLine($"What is {f} + {g}?");
        var answer = Convert.ToInt32(Console.ReadLine());
        if (answer == f + g)
        {
            _gameScore++;
            Console.WriteLine($"Correct! Your score is {_gameScore}!");
            _currentHistory = $"Addition, Correct! Score: {_gameScore}!";
            _currentHistoryArray.Add(_currentHistory);
        }
        else
        {
            Console.WriteLine($"WRONG! The answer is: {f + g}. Your score is {_gameScore}!");
            _currentHistory = $"Addition, Wrong! Score: {_gameScore}!";
            _currentHistoryArray.Add(_currentHistory);
        }
    }

    private static void Subtraction(int f, int g)
    {
        Console.WriteLine($"What is {f} - {g}?");
        var answer = Convert.ToInt32(Console.ReadLine());
        if (answer == f - g)
        {
            _gameScore++;
            Console.WriteLine($"Correct! Your score is {_gameScore}!");
            _currentHistory = $"Subtraction, Correct! Score: {_gameScore}!";
            _currentHistoryArray.Add(_currentHistory);
        }
        else
        {
            Console.WriteLine($"WRONG! The answer is: {f - g}. Your score is {_gameScore}!");
            _currentHistory = $"Subtraction, Wrong! Score: {_gameScore}!";
            _currentHistoryArray.Add(_currentHistory);
        }
    }
}