using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    public class AudioSourceCallback : MonoBehaviour
    {
        public AudioSource audioSource;
        public string playCallbackName;
        public string stopCallbackName;
        CallbackRegistry callbackRegistry;
        // Start is called before the first frame update
        void Start()
        {
            callbackRegistry = GetComponent<CallbackRegistry>();
            callbackRegistry.AddCallback(new Callback(
                playCallbackName,
                () =>
                {
                    if (audioSource.isPlaying == false)
                    {
                        audioSource.Play();
                    }
                }
            ));
            callbackRegistry.AddCallback(new Callback(
                stopCallbackName,
                () => audioSource.Stop()
            ));
        }
    }
}
