using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Metroidvania.Characters.Knight
{
    public class AttackDamageManager : MonoBehaviour
    {
        public TextMeshProUGUI attackDamageNumber;
        public KnightData knightData;
        
        // Update is called once per frame
        void Update()
        {
            attackDamageNumber.text = knightData.firstAttack.damage.ToString();
        }
    }
}
