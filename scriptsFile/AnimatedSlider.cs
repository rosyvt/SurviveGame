using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace GameUI
{
    public class AnimatedSlider : MonoBehaviour
    {
        public bool snap;
        public bool useFixedUpdate;
        Slider slider;
        float expectedValue;
        Action callback;
        IEnumerator coroutine;

        void Awake()
        {
            slider = GetComponent<Slider>();
            expectedValue = slider.value;
        }

        public float GetMaxValue()
        {
            return slider.maxValue;
        }

        public void SetMaxValue(float max)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            slider.value = expectedValue;
            slider.maxValue = max;
        }

        public void AddValue(float value, float rate = 1)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            if (snap)
            {
                slider.value = expectedValue;
            }
            expectedValue = slider.value + value;
            if (expectedValue < slider.minValue)
            {
                expectedValue = slider.minValue;
            }
            if (expectedValue > slider.maxValue)
            {
                expectedValue = slider.maxValue;
            }
            coroutine = AddValueCoroutine(value, rate);
            StartCoroutine(coroutine);
        }

        public float GetExpectedValue()
        {
            return expectedValue;
        }

        public float GetCurrentValue()
        {
            return slider.value;
        }

        public void SetCallback(Action callback)
        {
            this.callback = callback;
        }

        IEnumerator AddValueCoroutine(float newValue, float rate)
        {
            float diff = newValue * rate;
            while (slider.value != expectedValue)
            {
                if (Mathf.Abs(slider.value - expectedValue) <= Mathf.Abs(diff))
                {
                    slider.value = expectedValue;
                }
                else
                {
                    slider.value += diff;
                }
                yield return useFixedUpdate ? new WaitForFixedUpdate() :
                    new WaitForEndOfFrame();
            }
            yield return useFixedUpdate ? new WaitForFixedUpdate() :
                new WaitForEndOfFrame();
            if (callback != null)
            {
                callback();
            }
        }
    }
}
