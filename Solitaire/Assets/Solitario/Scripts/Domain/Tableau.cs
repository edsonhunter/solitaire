using System;
using System.Collections.Generic;
using Solitario.Domain.Interface;

namespace Solitario.Domain
{
    public class Tableau : ITableau
    {
        public IDictionary<int, IList<ICard>> TableauOfCards { get; }
        
        public void AddCardToRow(int row, ICard card)
        {
            if (row < 0)
                throw new InvalidOperationException($"{nameof(Tableau)} Row less than zero");
            TableauOfCards[row].Add(card);
        }

        public void RemoveCardFromRow(int row, ICard card)
        {
            if (row < 0)
                throw new InvalidOperationException($"{nameof(Tableau)} Row less than zero");
            
            if (!TableauOfCards[row].Contains(card))
            {
                throw new InvalidOperationException($"{nameof(Tableau)} Tableau do not contain that card");
            }

            TableauOfCards[row].Remove(card);
        }
    }
}