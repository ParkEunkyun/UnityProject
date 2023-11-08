using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPsystem : MonoBehaviour
{
    public Slider EXPbar1;   
    public Text EXPtext;
    public Stat _stat;
    public Text LvUI;
    void Start()
    {
        EXPbar1.maxValue = _stat.maxExp;
        EXPbar1.value = DataManager.instance.nowPlayer.curExp;
        EXPtext.text = EXPbar1.value.ToString() + " / " + _stat.maxExp.ToString();
        LvUI.text = _stat.Level.ToString();
    }

    public void Update()
    {      
        LevelUP();
    }
    public void LateUpdate()
    {
        EXPandHP();
        //EXPbar1.maxValue = _stat.maxExp;
        //EXPbar1.value = DataManager.instance.nowPlayer.curExp;
        //EXPtext.text = EXPbar1.value.ToString() + " / " + _stat.maxExp.ToString();
        //LvUI.text = _stat.Level.ToString();
    }

    public LevelUpEffect effect;

    public Text myRanking;
    public Text myNickName;
    public Text myPower;

    public void EXPandHP()    {
        
        EXPbar1.maxValue = DataManager.instance.nowPlayer.maxExp;
        EXPbar1.value = DataManager.instance.nowPlayer.curExp;
        EXPtext.text = DataManager.instance.nowPlayer.curExp.ToString() + " / " + DataManager.instance.nowPlayer.maxExp.ToString();
        LvUI.text = DataManager.instance.nowPlayer.Level.ToString();
    }
    public void LevelUP()
    {

        while (DataManager.instance.nowPlayer.curExp >= EXPbar1.maxValue)
        {
            DataManager.instance.nowPlayer.Level++;
            DataManager.instance.nowPlayer.curExp = DataManager.instance.nowPlayer.curExp - DataManager.instance.nowPlayer.maxExp;
            DataManager.instance.nowPlayer.Pp = DataManager.instance.nowPlayer.Pp + 5;
            DataManager.instance._skill.SkillPoint = DataManager.instance._skill.SkillPoint + 2;
            LvUI.text = DataManager.instance.nowPlayer.Level.ToString();
            effect.ActiveLvUpEffect();

            if (DataManager.instance.nowPlayer.Level < 30)
            {
                DataManager.instance.nowPlayer.maxExp = DataManager.instance.nowPlayer.maxExp + 10;
            }
            else if (DataManager.instance.nowPlayer.Level < 50)
            {
                DataManager.instance.nowPlayer.maxExp = DataManager.instance.nowPlayer.maxExp + 100;
            }
            else if (DataManager.instance.nowPlayer.Level < 100)
            {
                DataManager.instance.nowPlayer.maxExp = DataManager.instance.nowPlayer.maxExp + 1000;
            }

            if (DataManager.instance.nowPlayer.curExp < DataManager.instance.nowPlayer.maxExp)
            {
                break;
            }

        }

        //ExpBar2.maxValue = nowPlayer.maxExp;
        //ExpBar2.value = nowPlayer.curExp;
        EXPbar1.maxValue = DataManager.instance.nowPlayer.maxExp;
        EXPbar1.value = DataManager.instance.nowPlayer.curExp;
        EXPtext.text = DataManager.instance.nowPlayer.curExp.ToString() + " / " + DataManager.instance.nowPlayer.maxExp.ToString();
        _stat.curExp = DataManager.instance.nowPlayer.curExp;
        _stat.maxExp = DataManager.instance.nowPlayer.maxExp;
        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();
    }

    

}
