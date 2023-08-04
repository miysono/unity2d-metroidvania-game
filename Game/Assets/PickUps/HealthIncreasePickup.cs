using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metroidvania.Characters
{
    public class HealthIncreasePickup : MonoBehaviour
    {
        public GameObject UIItemDescription;
        float healthIncreaser = 0.20f;
        public HealthBarHandler healthBarHandler;
        public MainCharacterLifeSlider hpSlider;
        private void Start() {
            UIItemDescription.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                UIItemDescription.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if(other.gameObject.CompareTag("Player"))
            {
                UIItemDescription.SetActive(false);
            }
        }

        private void OnTriggerStay2D(Collider2D other) {
            if(other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.F)){
                healthBarHandler.healthBarManager.currentLife = healthBarHandler.healthBarManager.currentLife + healthBarHandler.healthBarManager.currentLife * healthIncreaser;
                healthBarHandler.healthBarManager.maxLife = healthBarHandler.healthBarManager.maxLife + healthBarHandler.healthBarManager.maxLife * healthIncreaser;
                hpSlider._slider.maxValue = healthBarHandler.healthBarManager.maxLife + healthBarHandler.healthBarManager.maxLife * healthIncreaser;
                Destroy(this.gameObject);
            }
        }
    }
}
