using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Misc
{
    public class TimedEnable : MonoBehaviour
    {
        public float time;
        public MonoBehaviour component;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(TimedEnableCoroutine());
        }

        IEnumerator TimedEnableCoroutine()
        {
            yield return new WaitForSeconds(time);
            component.enabled = true;
        }
    }
}
