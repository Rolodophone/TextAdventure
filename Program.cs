using Newtonsoft.Json;
using System;

class MainClass
{
    public static void Main(string[] args)
    {
        startGame();
    }

    public static void startGame()
    {
        string level1String = System.IO.File.ReadAllText(@"room1.json");
        Paragraph level1Paragraph = JsonConvert.DeserializeObject<Paragraph>(level1String);
        playParagraph(level1Paragraph);
    }

    public static void playParagraph(Paragraph paragraph)
    {
        if (paragraph.options.Length == 0)
        {
            Console.WriteLine(paragraph.text);
            Console.WriteLine("Game over! Press 1 to try again and press 2 to quit");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                startGame();
            }
            else
            {
                System.Environment.Exit(1);
            }

        }
        Console.WriteLine(paragraph.text);
        printOptions(paragraph.options);
        Option option = handleOptionsInput(paragraph.options);
        playParagraph(option.nextParagraph);
    }

    public static void printOptions(Option[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            string option_string = $"{i + 1}) {options[i].title}";
            Console.WriteLine(option_string);
        }

    }

    public static Option handleOptionsInput(Option[] options)
    {
        Console.WriteLine("Which option do you want to choose?");
        int userOption;

        while (true)
        {
            string userOptionString = Console.ReadLine();

            if (!int.TryParse(userOptionString, out userOption) || userOption > options.Length)
            {
                Console.WriteLine("That input is not valid. Please enter a number representing the option you want to choose.");
                continue;
            }
            else
            {
                break;
            }
        }

        Option option = options[userOption - 1];
        return option;
    }
}

class Paragraph
{
    public string text;
    public Option[] options;

    public Paragraph(string s, Option[] options)
    {
        this.text = s;
        this.options = options;
    }
}


class Option
{
    public string title;
    public Paragraph nextParagraph;

    public Option(string s, Paragraph paragraph)
    {
        this.nextParagraph = paragraph;
        this.title = s;
    }
}
