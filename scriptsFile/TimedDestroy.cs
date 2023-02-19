using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Misc
{
    public class TimedDestroy : MonoBehaviour
    {
        public float time;

        void Start()
        {
            StartCoroutine(TimedDestroyCoroutine());
        }

        IEnumerator TimedDestroyCoroutine()
        {
            yield return new WaitForSeconds(time);
            Destroy(this.gameObject);
        }
    }
}
