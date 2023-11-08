using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDrop : MonoBehaviour
{
    public SkillObject _skill;

    public GettingItemUI Getting;
    private void OnTriggerEnter2D(Collider2D other) // 추후 아이템 획득 로직으로 변경
    {

        Getting = GameObject.Find("Getscript").GetComponent<GettingItemUI>();

        if (other.tag.Equals("Player"))
        {
            _skill.SkillPoint++;
            Getting.Getskill();
            DataManager.instance.SaveData();
            //this.gameObject.SetActive(false);
            this.GetComponent<CircleCollider2D>().isTrigger = false;
            Destroy(this.gameObject);
            //GoldObjectPool.ReturnObject(this.gameObject);
        }
        
    }
}
