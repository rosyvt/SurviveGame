using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using General;
using GameUI;

namespace Player
{
    public class ConsumeHealthPotion : MonoBehaviour
    {
        public SliderLimits potionSlider;
        HealthManager healthManager;

        // Start is called before the first frame update
        void Start()
        {
            healthManager = GetComponent<HealthManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                float missingHealth = (healthManager.maxHealth - healthManager.GetCurrentHealth()) * 100 / healthManager.maxHealth;
                float amount = Mathf.Min(missingHealth, potionSlider.value);
                healthManager.TakeDamage(amount * healthManager.maxHealth / 100);
                potionSlider.AddValue(-amount);
            }
        }
    }
}
