using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metroidvania
{
    public class DoorManager : MonoBehaviour
    {
        public Transform teleportLocation;
        public Transform playerTransform;

        public GameObject UIDoorDescription;
        public KeyManager keyManager;
        bool isDoorOpened = false;


        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(PlayerColliding(other))
                UIDoorDescription.SetActive(true);
        }


        private void OnTriggerExit2D(Collider2D other) 
        {
            if(PlayerColliding(other))
                UIDoorDescription.SetActive(false);
        }

        private void OnTriggerStay2D(Collider2D other) 
        {
            if(PlayerColliding(other) && Input.GetKey(KeyCode.F) && !isDoorOpened && keyManager.keyCount>=1)
            {
                playerTransform.transform.position = teleportLocation.transform.position;
                keyManager.keyCount -= 1;
                isDoorOpened = true;
            } 
            else if(isDoorOpened && PlayerColliding(other) && Input.GetKey(KeyCode.F))
            {
                playerTransform.transform.position = teleportLocation.transform.position;
            }
            else UIDoorDescription.SetActive(true);
        }

        private bool PlayerColliding(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player"))
            return true;
            else return false;
        }
    }
}
