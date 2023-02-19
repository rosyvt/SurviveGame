using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

namespace Misc
{
    public class TimedCallback : MonoBehaviour
    {
        public float time;
        public List<string> callbackNames;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(TimedEnableCoroutine());
        }

        IEnumerator TimedEnableCoroutine()
        {
            yield return new WaitForSeconds(time);
            GetComponent<CallbackRegistry>().callbacks.ForEach(
                callback => callback.action()
            );
        }
    }
}
