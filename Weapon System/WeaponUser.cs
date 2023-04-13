using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class WeaponUser : MonoBehaviour
    {
        private IWeapon currentWeapon = null;

        // Start is called before the first frame update
        void Start()
        {
            if (!TryGetComponent(out currentWeapon))
                print("No current weapon");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && currentWeapon != null)
                currentWeapon.UseWeapon();
        }
    }
}