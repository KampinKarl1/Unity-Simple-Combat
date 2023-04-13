using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField] private Transform ejectPoint = null;
        [SerializeField] private GameObject projectilePrefab = null;

        [SerializeField] private float force = 3f;
        [SerializeField] private float torqueForce = 3f;

        internal void LaunchProjectile()
        {
            var o = Instantiate(projectilePrefab, ejectPoint.position, ejectPoint.rotation);

            if (o.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce(ejectPoint.forward * force, ForceMode.Impulse);

                if (Mathf.Abs( torqueForce ) > float.Epsilon)
                    rb.AddTorque(rb.transform.up * torqueForce, ForceMode.Impulse);
            }
        }
    }
}