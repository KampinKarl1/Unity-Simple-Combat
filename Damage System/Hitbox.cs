
using UnityEngine;

namespace WeaponSystem
{
    public class Hitbox : MonoBehaviour, IDamageable
    {
        [SerializeField] private float health = 100f;
        
        //If you were to use Entities, this is where it would go
        //[SerializeField] private Entity mainBody = null; //Allowed to be null so if this is like a red barrel or something, all it has to do is die and explode.
        //[SerializeField] private float damageMultiplier = 1.0f;
        
        public bool Alive() => health > 0;

        public void TakeDamage(DamageInstance damInst)
        {
            //Entity stuff if you're so inclined to use it
            /*
                if (mainBody != null)
                {
                    damInst.amount *= damageMultiplier;
                    mainBody.TakeDamage( damInst);
                
                    return; //DONT DO THE STUFF AFTER HERE
                }
            */
        
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
