using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDrop : MonoBehaviour
{
    public int minGold;
    public int maxGold;    
    private void OnTriggerEnter2D(Collider2D other) // 추후 아이템 획득 로직으로 변경
    {
        if(other.tag.Equals("Player"))
        {            
                DataManager.instance.nowPlayer.gold = DataManager.instance.nowPlayer.gold + Random.Range(minGold,maxGold);
                DataManager.instance.SaveData();
                Destroy(this.gameObject);
        }
        
    }
}
