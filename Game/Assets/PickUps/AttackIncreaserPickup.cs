using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metroidvania.Characters.Knight
{
    public class AttackIncreaserPickup : MonoBehaviour
    {


        public KnightData knightData;
        public GameObject attackDamageUIElement;
        float attackDamageIncreaser = 0.25f;

        // Start is called before the first frame update
        void Start()
        {
        attackDamageUIElement.SetActive(false);
        knightData.firstAttack.damage = 10;
        knightData.secondAttack.damage = 10;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.CompareTag("Player"))
            {
                attackDamageUIElement.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if(other.gameObject.CompareTag("Player"))
            {
                attackDamageUIElement.SetActive(false);
            }
        }

        private void OnTriggerStay2D(Collider2D other) {
            if(Input.GetKey(KeyCode.F) && other.gameObject.CompareTag("Player"))
            {
                knightData.firstAttack.damage = Mathf.RoundToInt(knightData.firstAttack.damage + knightData.firstAttack.damage * attackDamageIncreaser);
                knightData.secondAttack.damage = Mathf.RoundToInt(knightData.secondAttack.damage + knightData.secondAttack.damage * attackDamageIncreaser);
                Destroy(this.gameObject);
            }
        }
    }
}
