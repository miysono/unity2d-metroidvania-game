using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Metroidvania
{
    public class KeyManager : MonoBehaviour
    {
        public GameObject UIKeyDescription;
        public TextMeshProUGUI keyCounterUIText;
        public int keyCount;

        void Update()
        {
            keyCounterUIText.text = keyCount.ToString();
        }
        private void OnTriggerEnter2D(Collider2D other) {
            if(CollisionChecker(other)) UIKeyDescription.SetActive(true);
        }

        private void OnTriggerStay2D(Collider2D other) {
            if(CollisionChecker(other) && Input.GetKey(KeyCode.F))
            {
                keyCount++;
                Destroy(other.gameObject);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other) {
            if(CollisionChecker(other)) UIKeyDescription.SetActive(false);
        }




        private bool CollisionChecker(Collider2D other)
        {
            if(other.gameObject.CompareTag("Key"))
            return true;
            else return false;
        }

    }
}

