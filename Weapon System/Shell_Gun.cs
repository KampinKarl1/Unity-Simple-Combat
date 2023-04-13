using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class Shell_Gun : MonoBehaviour
    {
        [SerializeField] private float disappearAfter = 2.0f;

        private readonly static float MAX_LIFE = 10f;

        private void OnEnable()
        {
            Destroy(gameObject, MAX_LIFE);
        }

        private void OnCollisionEnter(Collision collision)
        {
            //make a sound then die
            Destroy(gameObject, disappearAfter);
        }
    }
}