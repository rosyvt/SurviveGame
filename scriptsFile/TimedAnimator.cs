using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Misc
{
    public class TimedAnimator : MonoBehaviour
    {
        public float time;

        void Start()
        {
            StartCoroutine(TimedDestroyCoroutine());
        }

        IEnumerator TimedDestroyCoroutine()
        {
            yield return new WaitForSeconds(time);
            Animator anim = GetComponent<Animator>();
            anim.enabled = true;
        }
    }
}
