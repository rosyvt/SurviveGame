using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAudioPlay : MonoBehaviour
{
    public float time;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(TimedAudioPlayCoroutine());
    }

    IEnumerator TimedAudioPlayCoroutine()
        {
            yield return new WaitForSeconds(time);
            audioSource.Play();
        }
}
