using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metroidvania
{
    public class ChestHandler : MonoBehaviour
    {
        public Animator animator;
        public GameObject[] chestDropper;
        public GameObject UIChestInfo;
        bool isOpened = false;

        void Start()
        {
            for(int i=0; i<chestDropper.Length; i++)
            {
                chestDropper[i].SetActive(true);
            }
            StartCoroutine(ChestPickUpHandler());
        }
        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.CompareTag("Player") && !isOpened)
            {
                UIChestInfo.SetActive(true);
            }
        }

        private void OnTriggerStay2D(Collider2D other) {
            if(other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.F) && !isOpened)
            {   
                StartCoroutine(ChestOpener());
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if(other.gameObject.CompareTag("Player")){
                UIChestInfo.SetActive(false);
            }
        }


        IEnumerator ChestOpener()
        {
            isOpened = true;
            UIChestInfo.SetActive(false);
            animator.Play("Base Layer.Chest Open", 0, 0);
            yield return new WaitForSeconds(0.5f);
            for(int i=0; i<chestDropper.Length; i++)
            {
                chestDropper[i].SetActive(true);
            }
        }

        IEnumerator ChestPickUpHandler()
        {
            yield return new WaitForSeconds(0.5f);
            for(int i=0; i<chestDropper.Length; i++)
            {
                chestDropper[i].SetActive(false);
            }
        }
    }
}
