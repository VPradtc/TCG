namespace TCG.Core.Cards
{
    public interface Card : IPlayable
    {
        string Name { get; set; }
        string Description { get; set; }
        CardRarity Rarity { get; set; }
        int Manacost { get; set; }
    }
}
