using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPortionDrop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // 추후 아이템 획득 로직으로 변경
    {
        if(other.tag.Equals("Player"))
        {            
                DataManager.instance.nowPlayer.ManaPotion++;
                Destroy(this.gameObject);
        }
        
    }
}