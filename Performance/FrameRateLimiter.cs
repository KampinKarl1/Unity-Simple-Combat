using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasyUtils
{
    public class FrameRateLimiter : MonoBehaviour
    {
        [SerializeField] bool limitFramerate = false;
        [SerializeField] int frameLimit = 60;

        const int UNITY_DEFAULT_TO_UNLIMIT = -1;

        private void Awake()
        {
            Application.targetFrameRate = limitFramerate ? frameLimit : UNITY_DEFAULT_TO_UNLIMIT;

        }
    }
}
