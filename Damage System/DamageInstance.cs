
using UnityEngine;

namespace WeaponSystem
{
    public struct DamageInstance
    {
        public DamageInstance(float _damage, Vector3 dir)
        {
            amount = _damage;
            direction = dir;
        }

        public DamageInstance(float dmg)
        {
            amount = dmg;
            direction = Vector3.zero;
        }

        public float amount;

        public Vector3 direction;
    }
}