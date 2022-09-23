using System;
using DeckofCardsConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        string input;
        string upper;
        var deck = new Deck();

        Header();

        do
        {
            input = getInput();
            upper = input.ToUpper();

            switch (upper)
            {
                case "N":
                    deck = new Deck();
                    NewDeckMessage();
                    break;
                case "D":
                    Console.WriteLine(deck.Draw());
                    break;
                case "R":
                    for(int i = 0; i < deck.Size; i++)
                    {
                        Console.WriteLine(deck.Draw());
                    }
                    break;
                case "S":
                    deck.Shuffle();
                    break;
                default:
                    InvalidInput();
                    break;
            }

        } while (upper != "Q");
        Environment.Exit(0);
    }

    private static void Header()
    {
        Console.WriteLine($"\nYou have a deck of 52 cards.\n");
    }
    private static string getInput()
    {
        System.Console.WriteLine("\n\nSelect any of the following: ");
        System.Console.WriteLine("\nN : Get a new deck ");
        System.Console.WriteLine("D : Draw a card ");
        System.Console.WriteLine("R : Reveal all cards ");
        System.Console.WriteLine("S : Shuffle cards ");
        System.Console.WriteLine("Q : Quit \n\n");
        var inputStr = System.Console.ReadLine();

        return inputStr;
    }
    private static void NewDeckMessage()
    {
        System.Console.WriteLine("\n==============================================================");
        Console.WriteLine("You now have a new deck!");
        System.Console.WriteLine("==============================================================");
    }
    private static void InvalidInput()
    {
        Console.WriteLine("\n**Invalid input. Please try again.\n");
    }
}