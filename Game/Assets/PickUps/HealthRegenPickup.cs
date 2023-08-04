using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Metroidvania.Characters
{
    public class HealthRegenPickup : MonoBehaviour


    {

        public GameObject UIItemDescription;
        public HealthBarHandler healthHandler;
        float healthRegen = 0.25f;
        // Start is called before the first frame update

        void Start()
        {
            UIItemDescription.SetActive(false);
        }    

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                UIItemDescription.SetActive(true);
                
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                UIItemDescription.SetActive(false);
            }
        }


        void OnTriggerStay2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.F))
                {
                    healthHandler.healthBarManager.currentLife = healthHandler.healthBarManager.currentLife + healthHandler.healthBarManager.maxLife * healthRegen;
                    Destroy(this.gameObject);
                }
        }
    }
}
