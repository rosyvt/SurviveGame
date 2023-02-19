using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    public class BackgroundMusicChange : MonoBehaviour
    {
        public int stage;
        // Start is called before the first frame update
        void Start()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Camera.main.GetComponent<BackgroundMusicManager>().SetStage(stage);
            }
        }
    }
}
