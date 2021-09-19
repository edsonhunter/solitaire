using System.Collections.Generic;

namespace Solitario.Domain.Interface
{
    public interface IDeck
    {
        IList<ICard> Cards { get; }

        void Shuffle();
        void Deal();
    }
}