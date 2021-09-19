using System;
using Solitario.Domain.Interface;

namespace Solitario.Domain
{
    public class Card : ICard
    {
        public Suit Suit { get; private set; }
        public Rank Value { get; private set; }
        public bool FaceUp { get; private set; }

        private Card()
        {
            Suit = Suit.Unknown;
            Value = Rank.Unknown;
        }

        public Card(int suit, int value) : this()
        {
            if ((suit > Enum.GetValues(typeof(Suit)).Length) || 
                (value > Enum.GetValues(typeof(Rank)).Length))
            {
                throw new InvalidOperationException($"Wrong values to card properties");
            }
            
            Suit = (Suit) suit;
            Value = (Rank) value;
        }

        public void Flip()
        {
            FaceUp = !FaceUp;
        }
    }
}