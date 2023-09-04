using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMultiShotSkill : MonoBehaviour
{
    public SkillObject _skill;
    public float MultiShotSkilltimer = 0;
    public bool Active = false;
    public GameObject[] MultiShotLv;
    
    private void Update()
    {
        if(Active)
        {
            MultiShotSkilltimer += Time.deltaTime;
        }
        
        if(MultiShotSkilltimer >= _skill.MultiShotDuring)
        {
            UnActiveSkill();
        }                
    }

    public void ActiveSkill()
    {
        if(_skill.MultiShotLv == 0)
        {
            return;
        }
        else{

            for(int i = 1; i < 7; i++)
            {
                if(_skill.MultiShotLv == i)
                {
                    Active = true;
                    MultiShotLv[i].SetActive(true);
                }               
            }
        }
    }
    public void UnActiveSkill()
    {
        for(int i = 1; i < 7; i++)
        {
            if(_skill.MultiShotLv == i)
            {
                Active = false;
                MultiShotLv[i].SetActive(false);
                MultiShotSkilltimer = 0;
            }               
        }
    }    
}
