using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Metroidvania.Characters
{
    public class HealthBarHandler : MonoBehaviour
    {

        public MainCharacterLifeField healthBarManager;
        public TextMeshProUGUI uiCurrentHealthPoints;
        public TextMeshProUGUI uiMaxHealthPoints;

        void Start()
        {
            healthBarManager.currentLife = healthBarManager.maxLife;
        }

        void Update()
        {

            healthBarManager.currentLife = Mathf.Round(healthBarManager.currentLife);
            healthBarManager.maxLife = Mathf.Round(healthBarManager.maxLife);
            uiCurrentHealthPoints.text = healthBarManager.currentLife.ToString();
            uiMaxHealthPoints.text = healthBarManager.maxLife.ToString();
        }

    }
}
