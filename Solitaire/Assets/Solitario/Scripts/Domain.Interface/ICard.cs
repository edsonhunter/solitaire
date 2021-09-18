namespace Solitario.Domain.Interface
{
    public interface ICard
    {
        public Suit Suit { get; }
        public Rank Value { get; }
        
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Rank
    {
        Unknown,
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
}