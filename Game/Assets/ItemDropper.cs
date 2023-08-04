using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metroidvania.Entities.Units
{
    public class ItemDropper : MonoBehaviour
    {
        public GameObject[] itemDrops;
        public SkeletonBehaviour skeleton;
        int rngDropper;
        bool itemsDropped = false;
        void Update()
        {
            if(skeleton.life<=0 && itemsDropped == false)
            {
                ItemDrop();
                itemsDropped = true;
            }
        }





        private void ItemDrop()
        {
            rngDropper = Random.Range(4, itemDrops.Length);
            for(int i=0; i<=rngDropper; i++)
            {
                Instantiate(itemDrops[i], transform.position + new Vector3(Random.Range(1f, 4f), Random.Range(1f, 5f), 0), Quaternion.identity);
            }
        }
    } 
}  
