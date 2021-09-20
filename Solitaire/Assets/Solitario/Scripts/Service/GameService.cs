using System;
using System.Collections.Generic;
using System.Linq;
using Solitario.Domain;
using Solitario.Domain.Interface;
using Solitario.Service.Interface;

namespace Solitario.Service
{
    public class GameService : IGameService
    {
        public IDeck Deck { get; private set; }
        public ITableau Tableau { get; private set; }

        public void StartGame()
        {
            IList<ICard> cards = (from Suit suit in Enum.GetValues(typeof(Suit))
                where suit != Suit.Unknown
                from Rank rank in Enum.GetValues(typeof(Rank))
                where rank != Rank.Unknown
                select new Card((int) suit, (int) rank)).Cast<ICard>().ToList();

            Deck = new Deck(cards);
            Deck.Shuffle();
        }

        public void SortCards()
        {
            for (var i = 0; i < 7; i++)
            {
                for (var j = i; j < 7; j++)
                {
                    
                }
            }
        }
    }
}