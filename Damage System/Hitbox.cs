
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
            var rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(100f * (1 / damInst.direction.magnitude) * damInst.direction, ForceMode.Impulse);

            Destroy(gameObject, 2.0f);
        }

        // Start is called before the first frame update
        void Start()
        {
            var rb = gameObject.AddComponent<Rigidbody>();
            rb.mass = 5f * ((transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3f);
            rb.isKinematic = true;
        }
    }
}
