using Solitario.Domain.Interface;

namespace Solitario.Service.Interface
{
    public interface IGameService : IService
    {
        IDeck Deck { get; }
        void StartGame();
        void SortCards();
    }
}