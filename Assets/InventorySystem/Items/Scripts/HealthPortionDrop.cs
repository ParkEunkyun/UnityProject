using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPortionDrop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // 추후 아이템 획득 로직으로 변경
    {
        if(other.tag.Equals("Player"))
        {            
            DataManager.instance.nowPlayer.HealthPotion++;
             
            DataManager.instance.SaveData();
            //Destroy(this.gameObject);
            //this.gameObject.SetActive(false);
            this.GetComponent<CircleCollider2D>().isTrigger = false;
            HealthPortionObjectPool.ReturnObject(this.gameObject);
        }        
    }
}
