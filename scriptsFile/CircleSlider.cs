using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class CircleSlider : MonoBehaviour
    {
        public Image targetImage;
        Slider slider;

        // Start is called before the first frame update
        void Start()
        {
            slider = GetComponent<Slider>();
        }

        // Update is called once per frame
        void Update()
        {
            targetImage.fillAmount = slider.value;
        }
    }
}
