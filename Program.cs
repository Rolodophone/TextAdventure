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
        Console.WriteLine(paragraph.text);
        printOptions(paragraph.options);
        Option option = handleOptionsInput(paragraph.options);
        playParagraph(option.nextParagraph);
    }

    public static void printOptions(Option[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            string option_string = $"{i + 1}) {options[i].name}";
            Console.WriteLine(option_string);
        }

    }

    public static Option handleOptionsInput(Option[] options)
    {
        Console.WriteLine("What option do you want to choose?");

        int userOption = int.Parse(Console.ReadLine());
        // if(userOption.tryParse() != true){
        // 	Console.WriteLine("That input is not valid. Please enter a number representing the option you want to choose.");
        // 	userOption = int.Parse(Console.ReadLine());
        // }
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
    public string name;
    public Paragraph nextParagraph;

    public Option(string s, Paragraph paragraph)
    {
        this.nextParagraph = paragraph;
        this.name = s;
    }
}