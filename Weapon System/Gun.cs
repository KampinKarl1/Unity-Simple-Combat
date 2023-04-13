using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform firepoint = null;
        [SerializeField] private SoundBank shotSounds = new SoundBank();
        [SerializeField] private Launcher shellEjector = null;

        
        [SerializeField] private float range = 100f;

        //========DMG===========
        [Space,Header("Damage")]
        float[] randomDamages = new float[50];
        int nextDamage = 0;
        float randDam()
        {
            float result = randomDamages[nextDamage];

            nextDamage++;
            if (nextDamage == randomDamages.Length)
                nextDamage = 0;

            return result;
        }

        #region Firerate
        [Space,Header("Firerate")]
        private float nextTimeCanFire = 0f;
        [SerializeField] private float fireRate = 20f;
        private float timeBetweenShots = 0f;
        private void SetTimeBetweenShots() => timeBetweenShots = 1 / fireRate;
        private bool CanFire => Time.time >= nextTimeCanFire;
        private void ResetShotCD() => nextTimeCanFire = Time.time + timeBetweenShots;
        #endregion
        void OnValidate()
        {
            SetTimeBetweenShots();
        }

        void Start()
        {
            SetTimeBetweenShots();

            for (int i = 0; i < randomDamages.Length; i++)
            {
                randomDamages[i] = Random.Range(25f, 70f);
            }
        }

        public void UseWeapon()
        {
            if (CanFire)
            {
                ResetShotCD();

                FireGun();

                PlayShotSound();

                if (shellEjector)
                    shellEjector.LaunchProjectile();
            }
        }

        private void PlayShotSound()
        {
            shotSounds.PlayRandom(GetComponent<AudioSource>());
        }

        private void FireGun()
        {
            RaycastHit[] hits = Physics.RaycastAll(firepoint.position, firepoint.forward, range);

            bool gotHit = false;
            bool gotKill = false;

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.TryGetComponent(out Hitbox hitbox))
                {
                    bool wasAlive = hitbox.Alive();

                    hitbox.TakeDamage(new DamageInstance(randDam(), hits[i].transform.position - transform.position));

                    gotHit = wasAlive;

                    if (!gotKill && wasAlive)
                        gotKill = !hitbox.Alive();
                }
            }

            if (gotKill)
            {
                Hitmarker.MarkKill();
                //todo play kill sound
                AudioFeedback.PlayImpactSound();
            }
            else if (gotHit)
            {
                Hitmarker.MarkHit();
                AudioFeedback.PlayImpactSound();
            }
        }
    }
}