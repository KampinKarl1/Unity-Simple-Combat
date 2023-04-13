using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class Hitmarker : Singleton<Hitmarker>
    {

        [SerializeField] private ImageAffector hitmarker = null;

        private void Awake()
        {
            SetInstance(this);
        }

        public static void MarkHit()
        {
            if (!instance || !instance.hitmarker)
                return;

            instance.hitmarker.ScaleUp(1.8f, .075f, Color.white);
        }
        public static void MarkKill()
        {
            if (!instance || !instance.hitmarker)
                return;

            instance.hitmarker.ScaleUp(1.8f, .075f, Color.red);
        }
    }
}