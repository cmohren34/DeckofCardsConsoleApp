using System;

namespace DeckofCardsConsoleApp
{
    interface ICard
    {
        Suit Suit { get; set; }
        Face Face { get; set; }
        bool IsFaceCard { get; }
        bool IsRed { get; }
    }

    public enum Suit
    {
        Hearts, Clubs, Diamonds, Spades
    }

    public enum Face
    {
        Ace, Two, Three, Four,
        Five, Six, Seven, Eight,
        Nine, Ten, King, Queen, Jack
    }

    class Card : ICard
    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }
        public bool IsFaceCard { get; private set; }
        public bool IsRed { get; private set; }

        public Card(Suit suit, Face face)
        {
            Suit = suit;
            Face = face;

            FaceCard(face);
            Color(suit);
        }

        public void FaceCard(Face face)
        {
            // 12 face cards
            switch (face)
            {
                case Face.King:
                case Face.Queen:
                case Face.Jack:
                    IsFaceCard = true;
                    break;
                default:
                    IsFaceCard = false;
                    break;
            }
        }

        public void Color(Suit suit)
        {
            // 26 colored cards
            switch (suit)
            {
                case Suit.Hearts:
                case Suit.Diamonds:
                    IsRed = true;
                    break;
                default:
                    IsRed = false;
                    break;
            }
        }

        public override string ToString()
        {
            var FaceCard = IsFaceCard ? "Face Card" : "Not a Face Card";
            var coloredCard = IsRed ? "Red" : "Black";

            return $"{Face} of {Suit}.    Color: {coloredCard}    ({FaceCard})";
        }
    }
}
