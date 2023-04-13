

namespace WeaponSystem
{
    public interface IDamageable
    {
        bool Alive();
        void TakeDamage(DamageInstance damInst);
    }
}