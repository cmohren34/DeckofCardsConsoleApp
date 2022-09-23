using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckofCardsConsoleApp
{
    interface IDeck
    {
        int Size { get; }
        int Counter { get; }
        IEnumerable<Card> CreateDeck { get; }
    }

    internal class Deck : IDeck
    {
        private int size;
        private int counter;
        private Random random;
        private List<Card> deck;

        public int Counter { get => counter; set => counter = value; }
        public int Size { get { return size; } }

        public Deck()
        {
            size = 52;
            counter = 0;
            deck = CreateDeck.ToList();
        }

        // doing this creates the list on the fly
        //as soon as it creates a playing card it spits it out of the function
        public IEnumerable<Card> CreateDeck
        {
            get
            {
                random = new Random();

                for (var i = 0; i < Enum.GetValues(typeof(Suit)).Length; i++)
                {
                    for (var j = 0; j < Enum.GetValues(typeof(Face)).Length; j++)
                    {
                        yield return new Card((Suit)i, (Face)j);
                    }
                }
            }
        }

        public Card Draw()
        {
            if (counter < deck.Count)
                return deck[counter++];
            else
                DrawWarning();
            return null;
        }

        public void Shuffle()
        {
            deck = deck.OrderBy(c => random.Next(size)).ToList();
            ShuffleMessage();
        }

        public void ShuffleMessage()
        {
            System.Console.WriteLine("\n==============================================================");
            System.Console.WriteLine("The deck has been shuffled. ");
            System.Console.WriteLine("==============================================================");
        }
        public void DrawWarning()
        {
            System.Console.WriteLine("\n**The deck is empty.**\n");
        }
    }
}
