//Gist example of what an Entity class would look like

using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
  public class Entity : Monobehaviour, IDamageable
  {
    [SerializeField] private float health = 100f;
  
  [Header("Use this to turn off components and stuff that shouldn't run when dead.")]
[SerializeField] private Behaviour [] disableOnDeath = new Behaviour [0];

[Header("Trigger a ragdoll action or whatever you want with this.")]
  [SerializeField] private UnityEvent onDeath = new UnityEvent();
  
        public bool Alive() => health > 0f;
        
        public void TakeDamage(DamageInstance damInst)
        {
          if (health <= 0f)
            return; //Don't waste your time or accidentally credit more stats for killing a dead entity
            
            health -= damInst.amount;
            
            if (health <= 0f)
              Die();
        }
        
        private void Die()
        {
          print (name + ": owy");
          
          for (int i = 0; i < disableOnDeath.Length; i++)
          {
            disableOnDeath[i].enabled = false;
          }
          
          onDie?.Invoke();
        }
  }
}
