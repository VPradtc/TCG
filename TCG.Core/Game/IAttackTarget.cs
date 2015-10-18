namespace TCG.Core.Game
{
    public interface IAttackTarget
    {
        void TakeDamage(int damage);
        void Decease();
    }
}
