using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class Gun : MonoBehaviour, IWeapon
    {
       [SerializeField] private Transform firepoint = null;
        internal AudioSource source = null;
        [SerializeField] private SoundBank shotSounds = new SoundBank();
        [SerializeField] private SoundBank emptyMagSounds = new SoundBank();
        [SerializeField] private Launcher shellEjector = null;

        [SerializeField] private int currentAmmo = 5;

        //This should go into a data file for guns of this type (An AK47 would generally have 30 rounds in each clip. It doesn't need to be an instance member)
        [SerializeField] private int maxAmmoPerMagazine = 12;
        [SerializeField] private int totalAmmo = 100;


        [SerializeField] private float reloadTime = 1.0f;
        
        [SerializeField] private float range = 100f;

        //========DMG===========
        [Space, Header("Damage")]
        [SerializeField] private float minDamage = 25f;
        [SerializeField] private float maxDamage = 75f;
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
        private bool CanFire => currentAmmo > 0 && Time.time >= nextTimeCanFire;
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
                randomDamages[i] = Random.Range(minDamage, maxDamage);
            }
        }

        public void UseWeapon()
        {
            if (!CanFire) //CANT fire
            {
                PlayEmptySound();
                return; //EXIT THE ROUTINE 
            }

            //Doesn't get here if out of ammo or too little time has passed.
            ResetShotCD();

            UseAmmo();

            FireGun();

            PlayShotSound();

            if (shellEjector)
                shellEjector.LaunchProjectile();
        }

        private void PlayShotSound()
        {
            shotSounds.PlayRandom(source);
        }

        private void PlayEmptySound() 
        {
            emptyMagSounds.PlayRandom(source);
        }

        #region ammo
        private void UseAmmo() 
        {
            currentAmmo--;
        }

        Coroutine reloadRoutine;

        internal void Reload() 
        {
            reloadRoutine = StartCoroutine(DoReload());
        }

        IEnumerator DoReload() 
        {
            yield return new WaitForSeconds(reloadTime);

            if (totalAmmo < maxAmmoPerMagazine)            
                currentAmmo = totalAmmo;
            else
                currentAmmo = maxAmmoPerMagazine;

            totalAmmo -= currentAmmo;   
            
        }

        #endregion
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

        public void MakeActive()
        {

        }

        public void PutAway()
        {
            StopCoroutine(reloadRoutine);
        }
    }
}
