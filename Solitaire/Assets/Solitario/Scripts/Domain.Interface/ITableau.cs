using System.Collections.Generic;

namespace Solitario.Domain.Interface
{
    public interface ITableau
    {
        IDictionary<int, IList<ICard>> TableauOfCards { get; }
        
        void AddCardToRow(int row, ICard card);
        void RemoveCardFromRow(int row, ICard card);
    }
}