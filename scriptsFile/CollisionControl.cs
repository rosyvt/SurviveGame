using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Misc;
using ControlledCamera;
using General;

namespace Effect
{
    public class CollisionControl : MonoBehaviour
    {
        public LayerMask collideWith;
        public List<string> tags;
        public GameObject destroyEffect;
        public List<string> callbackNames;
        CallbackRegistry callbackRegistry;
        VCamManager vCamManager;
        // Start is called before the first frame update
        void Start()
        {
            vCamManager = Camera.main.GetComponent<VCamManager>();
            callbackRegistry = GetComponent<CallbackRegistry>();
        }

        void OnTriggerEnter(Collider other)
        {
            if ((1 << other.gameObject.layer | collideWith) == collideWith ||
                tags.IndexOf(other.tag) >= 0)
            {
                GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
                TimedCamShake timedCamShake = effect.GetComponent<TimedCamShake>();
                if (timedCamShake != null)
                {
                    timedCamShake.vCamManager = vCamManager;
                }
                if (callbackRegistry != null)
                {
                    callbackNames.ForEach(name => {
                        Callback callback = callbackRegistry.GetCallbackWithName(name);
                        if (callback != null)
                        {
                            callback.action();
                        }
                    });
                }
            }
        }

        void OnCollisionEnter(Collision other)
        {
            if ((1 << other.gameObject.layer | collideWith) == collideWith ||
                tags.IndexOf(other.gameObject.tag) >= 0)
            {
                GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
                TimedCamShake timedCamShake = effect.GetComponent<TimedCamShake>();
                if (timedCamShake != null)
                {
                    timedCamShake.vCamManager = vCamManager;
                }
                if (callbackRegistry != null)
                {
                    callbackNames.ForEach(name => {
                        Callback callback = callbackRegistry.GetCallbackWithName(name);
                        if (callback != null)
                        {
                            callback.action();
                        }
                    });
                }
            }
        }
    }
}
