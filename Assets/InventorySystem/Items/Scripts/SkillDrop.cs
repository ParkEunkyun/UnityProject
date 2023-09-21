using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDrop : MonoBehaviour
{
    public SkillObject _skill;
    private void OnTriggerEnter2D(Collider2D other) // 추후 아이템 획득 로직으로 변경
    {
        if(other.tag.Equals("Player"))
        {
            _skill.SkillPoint++;
            DataManager.instance.SaveData();
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
            //GoldObjectPool.ReturnObject(this.gameObject);
        }
        
    }
}
