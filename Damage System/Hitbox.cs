
using UnityEngine;

namespace WeaponSystem
{
    public class Hitbox : MonoBehaviour, IDamageable
    {
        [SerializeField] private float health = 100f;

        public bool Alive() => health > 0;

        public void TakeDamage(DamageInstance damInst)
        {
            if (health <= 0)
                return;

            health -= damInst.amount;

            if (health <= 0)
                Die(damInst);
        }

        private void Die(DamageInstance damInst)
        {
            Destroy(gameObject, 2.0f);
        }
    }
}
