using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
     public class WeaponUser : MonoBehaviour
    {
        [SerializeField] private Transform[] transformsWithWeapons = new Transform[0];
        private IWeapon[] weapons = new IWeapon[0];
        private IWeapon currentWeapon = null;

        // Start is called before the first frame update
        void Start()
        {
            var tempWeaps = new List<IWeapon>();

            var audio = GetComponent<AudioSource>();

            for (int i = 0; i < transformsWithWeapons.Length; i++)
            {
                if (transformsWithWeapons[i].TryGetComponent(out IWeapon weapon))
                {
                    tempWeaps.Add(weapon);

                    if (weapon is Gun)
                        (weapon as Gun).source = audio;
                }

            }

            weapons = tempWeaps.ToArray();

            if (weapons == null || weapons.Length == 0)
                print("No current weapon");

            else
                currentWeapon = weapons[0];
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (Input.GetKeyDown((KeyCode)i + 48))
                    currentWeapon = weapons[i];
            }

            if (Input.GetMouseButtonDown(0) && currentWeapon != null)
                currentWeapon.UseWeapon();

            if (Input.GetKeyDown(KeyCode.R) && currentWeapon is Gun)
            {
                (currentWeapon as Gun).Reload();
            }
        }

    }
}
