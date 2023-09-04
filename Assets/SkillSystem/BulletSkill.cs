using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSkill : MonoBehaviour
{
    public SkillObject _skill;
    public static int pierceStack;
    //public int pCounts;
    private void Start() 
    {
        pierceStack = 0;
    }
    public void ActivePierceShot()
    {
        pierceStack = _skill.PierceShotCount;
        Invoke("pierceShotTime", 10f);
        Debug.Log(pierceStack);
    }
    public void pierceShotTime()
    {
        pierceStack = 0;
        Debug.Log(pierceStack);
    }
}
