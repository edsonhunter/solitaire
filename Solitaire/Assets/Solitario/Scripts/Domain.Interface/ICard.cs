namespace Solitario.Domain.Interface
{
    public interface ICard
    {
        public Suit Suit { get; }
        public Rank Value { get; }
        public bool FaceUp { get; }

        void Flip();
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades,
        Unknown
    }

    public enum Rank
    {
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
        King,
        Unknown
    }
}