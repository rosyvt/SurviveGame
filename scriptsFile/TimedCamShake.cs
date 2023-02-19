using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControlledCamera;

namespace Misc
{
    public class TimedCamShake : MonoBehaviour
    {
        public float time;
        public float duration;
        public float amp;
        public float f;
        public VCamManager vCamManager;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(TimedCamShakeCoroutine());
        }

        IEnumerator TimedCamShakeCoroutine()
        {
            yield return new WaitForSeconds(time);
            vCamManager.Shake(amp, f, duration);
        }
    }
}
