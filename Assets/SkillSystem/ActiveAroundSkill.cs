using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAroundSkill : MonoBehaviour
{
    public SkillObject _skill;
    public float AroundSkilltimer = 0;
    public bool Active = false;
    public GameObject[] AroundLv;
    WeaponChange _weaponchange;
    
    private void Update()
    {
        if(Active)
        {
            AroundSkilltimer += Time.deltaTime;
        }
        
        if(AroundSkilltimer >= _skill.AroundSkillDuring)
        {
            UnActiveSkill();
        }                
    }

    public void ActiveSkill()
    {
        if(_skill.AroundSkillLv == 0)
        {
            return;
        }
        else{

            for(int i = 1; i < 7; i++)
            {
                
                if(_skill.AroundSkillLv == i)
                {
                    _weaponchange = AroundLv[i].GetComponent<WeaponChange>();
                    changeimage();
                    Active = true;
                    AroundLv[i].SetActive(true);
                }               
            }
        }
    }
    public void UnActiveSkill()
    {
        for(int i = 1; i < 7; i++)
        {
            if(_skill.AroundSkillLv == i)
            {
                Active = false;
                AroundLv[i].SetActive(false);
                AroundSkilltimer = 0;
            }               
        }
    }
    private void changeimage() 
    {        
        if(DataManager.instance.equipmentObject.Slots[1].item.id == 20) {_weaponchange.Itemcode50001();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 21) {_weaponchange.Itemcode50002();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 22) {_weaponchange.Itemcode50003();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 23) {_weaponchange.Itemcode50004();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 24) {_weaponchange.Itemcode50005();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 25) {_weaponchange.Itemcode50006();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 26) {_weaponchange.Itemcode50007();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 27) {_weaponchange.Itemcode50008();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 28) {_weaponchange.Itemcode50009();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == -1) {_weaponchange.Itemcode50000();}  
    }
}

