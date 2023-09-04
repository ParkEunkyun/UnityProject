using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAreaSkill : MonoBehaviour
{
    public SkillObject _skill;
    public float AreaSkilltimer = 0;
    public bool Active = false;
    public GameObject[] AreaLv;
    
    private void Update()
    {
        if(Active)
        {
            AreaSkilltimer += Time.deltaTime;
        }
        
        if(AreaSkilltimer >= _skill.AreaSkillDuring)
        {
            UnActiveSkill();
        }                
    }

    public void ActiveSkill()
    {
        if(_skill.AreaSkillLv == 0)
        {
            return;
        }
        else{

            for(int i = 1; i < 7; i++)
            {
                if(_skill.AreaSkillLv == i)
                {
                    Active = true;
                    AreaLv[i].SetActive(true);
                }               
            }
        }
    }
    public void UnActiveSkill()
    {
        for(int i = 1; i < 7; i++)
        {
            if(_skill.AreaSkillLv == i)
            {
                Active = false;
                AreaLv[i].SetActive(false);
                AreaSkilltimer = 0;
            }               
        }
    }    
}
