namespace TCG.Core.Cards
{
    public interface IAttackTarget
    {
        void TakeDamage(int damage);
        void Decease();
    }
}
