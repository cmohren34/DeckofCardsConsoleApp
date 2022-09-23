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
        private Suit suit;
        private Face face;
        private bool isFaceCard;
        private bool isRed;

        public Suit Suit { get => suit; set => suit = value; }
        public Face Face { get => face; set => face = value; }
        public bool IsFaceCard { get => isFaceCard; private set => isFaceCard = value; }
        public bool IsRed { get => isRed; private set => isRed = value; }

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
