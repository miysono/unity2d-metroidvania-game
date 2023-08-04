using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Metroidvania
{
    public class ItemCollector : MonoBehaviour
    {

        public int coinCount = 0;
        public int gemCount = 0;
        public TextMeshProUGUI coinCounterUI;
        public TextMeshProUGUI gemCounterUI;

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Coin")){
                coinCount+=2;
                Destroy(other.gameObject);
                }

            if(other.CompareTag("Gem")){
                gemCount++;
                Destroy(other.gameObject);
            }
        }

        void Update()
        {
            coinCounterUI.text = coinCount.ToString();
            gemCounterUI.text = gemCount.ToString();
        }
    }

    
}
