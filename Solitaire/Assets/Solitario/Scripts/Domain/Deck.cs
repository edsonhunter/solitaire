using System.Collections.Generic;
using Solitario.Domain.Interface;
using UnityEngine;

namespace Solitario.Domain
{
    public class Deck : IDeck
    {
        public IList<ICard> Cards { get; private set; }
        
        private Deck()
        {
            Cards = new List<ICard>();
        }

        public Deck(IList<ICard> cards) : this()
        {
            Cards = new List<ICard>(cards);
        }
        
        public void Shuffle()
        {
            var rand = new System.Random();
            var n = Cards.Count;
            while (n > 1)
            {
                var k = rand.Next(n);
                n--;
                var temp = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = temp;
            }
        }

        public void Deal()
        {
            
        }

    }
}