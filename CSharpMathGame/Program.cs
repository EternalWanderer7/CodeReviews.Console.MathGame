using System.Net.Mail;
using System.Runtime.InteropServices.JavaScript;

public class CSharpMathgame
{
    private static int _gameScore = 0;
    private static List<List<string>> _history = [];
    private static List<string> _currentHistoryArray = [];
    private static string _currentHistory = "";


    public static void Main(string[] args)
    {
        Menu();
    }

    private static class Helpers
    {
        public static string ValidateResult(string input)
        {
            while (!int.TryParse(input, out _))
            {
                Console.WriteLine("Invalid input! Please enter a valid number:");
                input = Console.ReadLine();
            }

            return input;
        }
    }


    private enum MathOperation
    {
        addition,
        subtraction,
        division,
        multiplication
    }
    

    public static int Reroll(string symbol,string diff, int x, int y)
    {
        Random random = new Random();
        if (symbol == "/")
        {
            while (x%y != 0)
            {
                switch (diff)
                {
                    case "Easy":
                    
                        y = random.Next(1, 10);
                        break;
                    case "Medium":
                        y =  random.Next(1, 100);
                        break;
                    default:
                        y =  random.Next(1, 1000);
                        break;
                }
            }
            
        }
        return y;
    }

    public static void Menu()
    {
        Console.WriteLine("Play");
        Console.WriteLine("History");
        Console.WriteLine("Quit");
        var a = Console.ReadLine();
        switch (a)
            {
                case "Play":
                    Game();
                    break;

                case "History":
                    History();
                    break;

                case "Quit":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    throw  new ArgumentException("GoodBye!");
            }
        }
    

    private static void Game()
    {

        _gameScore = 0;
        Random random = new Random();
        Console.WriteLine("\nWhat difficulty would you like to play in:\nEasy \nMedium \nHard");
        var d = Console.ReadLine();
        int x;
        int y;
        for (var i = 0; i < 5; i++)
        {
            switch (d)
            {
                case "Easy":
                    x = random.Next(1, 10);
                    y = random.Next(1, 10);
                    break;
                case "Medium":
                    x = random.Next(1, 100);
                    y = random.Next(1, 100);
                    break;
                case "Hard":
                    x = random.Next(1, 1000);
                    y = random.Next(1, 1000);
                    break;
                default:
                    throw new ArgumentException("Not an Difficulty");
            }
            _currentHistory = "";
            int firstNumber = x;
            int secondNumber = y;
            Console.WriteLine($"\nWhat would you like to do: \nAddition \nSubtraction \nMultiplication \nDivision\n");
            var answer = Console.ReadLine();
            MathOperation l = Enum.Parse<MathOperation>(answer.ToLower());
            string operatorSymbol = l switch
            {
                MathOperation.addition => "+",
                MathOperation.subtraction => "-",
                MathOperation.multiplication => "*",
                MathOperation.division => "/",
                _ => throw new ArgumentException("Invalid operation")
            };
            secondNumber = Reroll(operatorSymbol, d, firstNumber, secondNumber);
            
            Console.WriteLine($"What is {firstNumber} {operatorSymbol} {secondNumber}?");
            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            int correctAnswer = l switch
            {
                MathOperation.addition => firstNumber + secondNumber,
                MathOperation.subtraction => firstNumber - secondNumber,
                MathOperation.multiplication => firstNumber * secondNumber,
                MathOperation.division => firstNumber / secondNumber,
                _ => throw new ArgumentException("Invalid operation")
            };

            if (int.Parse(result) == correctAnswer)
            {
                Console.WriteLine("Your answer was correct!");
                _gameScore++;
                _currentHistory = $"Correct, Score: {_gameScore}, Problem: {answer}.";
            }
            else
            {
                Console.WriteLine("Your answer wasn't correct!");
                _currentHistory = $"Wrong, Score: {_gameScore}, Problem: {answer}.";
            }

            _currentHistoryArray.Add(_currentHistory);

        }
        _history.Add(_currentHistoryArray);
        Console.WriteLine($"Your final score  is {_gameScore}.");
        Console.WriteLine("Would you like to the menu or play again?");
        var b = Console.ReadLine();
        if (b.ToLower() == "menu")
        {
            Menu();
        }
        else if (b.ToLower() == "play")
        {
            Game();
        }
        else
        {
            Console.WriteLine("Goodbye!");
        }

    }
    
    private static void History()
    {
        foreach (var item in _history)
        {
            foreach (var jtem in item)
            {
                Console.WriteLine(jtem);
            }
        }
        Console.WriteLine("\nType 1 to go back to Menu");
        string a = Console.ReadLine();
        switch (a)
        {
            case "1":
                Menu();
                break;
            default:
                throw new ArgumentException("Nope");
        }
    }
}