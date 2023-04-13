using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    //Poorly named class. 
    //This is a shell that would be launched from something like a gun. It gets automatically destroyed after a certain time 
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
            //make a sound then die (TODO: add the sound with something like AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("/Audio/Weapons/ShellImpactFloor"), transform.position);)
            Destroy(gameObject, disappearAfter);
        }
    }
}
