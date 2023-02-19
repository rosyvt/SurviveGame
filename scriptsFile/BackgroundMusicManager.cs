using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    public class BackgroundMusicManager : MonoBehaviour
    {
        public List<AudioClip> stage1Clips;
        public List<AudioClip> stage2Clips;
        public List<AudioClip> bossClips;
        AudioSource audioSource;
        int stage = 0;
        int index = 0;
        int maxIndex = 0;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (stage == 0)
            {
                index = 0;
                maxIndex = stage1Clips.Count;
                audioSource.clip = stage1Clips[index];
            }
            else if (stage == 1)
            {
                index = 0;
                maxIndex = stage2Clips.Count;
                audioSource.clip = stage2Clips[index];
            }
            else if (stage == 2)
            {
                index = 0;
                maxIndex = bossClips.Count;
                audioSource.clip = bossClips[index];
            }
            if (!audioSource.isPlaying)
            {
                index++;
                audioSource.Play();
                if (index == maxIndex)
                {
                    index = 0;
                }
            }
        }
        
        public void SetStage(int index)
        {
            stage = index;
        }
    }
}
