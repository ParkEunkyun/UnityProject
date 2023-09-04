using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager_Active : MonoBehaviour
{
    public SkillObject _skill;
    public Text SkillPoint;    
    public GameObject[] ActiveSkillSlot;
    //0:멀티샷, 1:피어스샷, 2:포이즌스모그, 3:스피릿웨폰
    public Text[] ActiveSkillLevelText;
    public Text[] ActiveSkillOptionText;
    public Slider[] ActiveSkillExp;
    public Button[] ActiveSkillExpUpButton;
    public Text[] ActiveSkillExpText;

    private void Start() 
    {
        SkillPoint.text = _skill.SkillPoint.ToString();

        ActiveSkillExpUpButton[0].onClick.AddListener(MultiShotLevelUp);
        ActiveSkillExpUpButton[1].onClick.AddListener(PierceShotLevelUp);
        ActiveSkillExpUpButton[2].onClick.AddListener(PosionSmogLevelUp);
        ActiveSkillExpUpButton[3].onClick.AddListener(SpritWeaponLevelUp);
        
        //초기 스킬 경험치
        ActiveSkillExp[0].maxValue = _skill.MultiShotMaxExp;
        ActiveSkillExp[1].maxValue = _skill.PierceShotMaxExp;
        ActiveSkillExp[2].maxValue = _skill.AreaSkillMaxExp;
        ActiveSkillExp[3].maxValue = _skill.AroundSkillMaxExp;

        MultiShotLevelUp();
        _skill.MultiShotCurExp--;
        _skill.SkillPoint++;
        //ActiveSkillExp[0].value--;
        ActiveSkillExp[0].value = _skill.MultiShotCurExp;
        ActiveSkillExpText[0].text = _skill.MultiShotCurExp.ToString() + " / " + _skill.MultiShotMaxExp.ToString();
        
        PierceShotLevelUp();
        _skill.PierceShotCurExp--;
        _skill.SkillPoint++;
        //ActiveSkillExp[1].value--;
        ActiveSkillExp[1].value = _skill.PierceShotCurExp;
        ActiveSkillExpText[1].text = _skill.PierceShotCurExp.ToString() + " / " + _skill.PierceShotMaxExp.ToString();  

        PosionSmogLevelUp();
        _skill.AreaSkillCurExp--;
        _skill.SkillPoint++;
        //ActiveSkillExp[2].value--;
        ActiveSkillExp[2].value = _skill.AreaSkillCurExp;
        ActiveSkillExpText[2].text = _skill.AreaSkillCurExp.ToString() + " / " + _skill.AreaSkillMaxExp.ToString();

        SpritWeaponLevelUp();
        _skill.AroundSkillCurExp--;
        _skill.SkillPoint++;
        //ActiveSkillExp[3].value--;
        ActiveSkillExp[3].value = _skill.AroundSkillCurExp;
        ActiveSkillExpText[3].text = _skill.AroundSkillCurExp.ToString() + " / " + _skill.AroundSkillMaxExp.ToString();

        
        //DataManager.instance.nowPlayer.SkillPoint = DataManager.instance.nowPlayer.SkillPoint + 4;
        SkillPoint.text = _skill.SkillPoint.ToString();
    }
    private void OnEnable()
    {
        SkillPoint.text = _skill.SkillPoint.ToString();
    }
    
    public void MultiShotLevelUp() // 배열[0]
    {        
       if(_skill.MultiShotLv != 5 && _skill.SkillPoint > 0)
        {
            _skill.MultiShotCurExp++;
            _skill.SkillPoint--;
            while(_skill.MultiShotCurExp >= ActiveSkillExp[0].maxValue)
            {
                _skill.MultiShotLv++;
                _skill.MultiShotCurExp = _skill.MultiShotCurExp - _skill.MultiShotMaxExp;
                ActiveSkillLevelText[0].text = "Lv. " + _skill.MultiShotLv.ToString();            

                if(_skill.MultiShotLv < 5)
                {
                    _skill.MultiShotMaxExp = _skill.MultiShotMaxExp * 2;
                }           

                if(_skill.MultiShotCurExp < _skill.MultiShotMaxExp)
                {
                    break;
                }            
            }
        }
        
        ActiveSkillExp[0].maxValue = _skill.MultiShotMaxExp;
        ActiveSkillExp[0].value = _skill.MultiShotCurExp;        
        
        if(_skill.MultiShotLv != 5)
        {
            ActiveSkillExpText[0].text = _skill.MultiShotCurExp.ToString() + " / " + _skill.MultiShotMaxExp.ToString();
        }

        if(_skill.MultiShotLv == 5)
        {
            ActiveSkillLevelText[0].text = "Lv. MAX";
            ActiveSkillExpText[0].text = "MAX";
            ActiveSkillExpUpButton[0].enabled = false;
            ActiveSkillExp[0].value = ActiveSkillExp[0].maxValue;
        }

        MultiShotAttribute();
        //Debug.Log("정상동작");
    }
    public void MultiShotAttribute()
    {
        if(_skill.MultiShotLv == 0)
        {            
            _skill.MultiShotDuring = 0;
            _skill.MultiShotUseMP = 0;
            _skill.MultiShotCooltime = 0;
            ActiveSkillOptionText[0].text = "발사체 수량 : 0개";
        }
        else if(_skill.MultiShotLv == 1)
        {
            _skill.MultiShotDuring = 10;
            _skill.MultiShotUseMP = 10;
            _skill.MultiShotCooltime = 15;
            ActiveSkillOptionText[0].text = "발사체 수량 : 2개";
        }
        else if(_skill.MultiShotLv == 2)
        {
            _skill.MultiShotDuring = 15;
            _skill.MultiShotUseMP = 20;
            _skill.MultiShotCooltime = 20;
            ActiveSkillOptionText[0].text = "발사체 수량 : 3개";
        }
        else if(_skill.MultiShotLv == 3)
        {
            _skill.MultiShotDuring = 20;
            _skill.MultiShotUseMP = 30;
            _skill.MultiShotCooltime = 25;
            ActiveSkillOptionText[0].text = "발사체 수량 : 4개";
        }
        else if(_skill.MultiShotLv == 4)
        {
            _skill.MultiShotDuring = 25;
            _skill.MultiShotUseMP = 40;
            _skill.MultiShotCooltime = 30;
            ActiveSkillOptionText[0].text = "발사체 수량 : 5개";
        }
        else if(_skill.MultiShotLv == 5)
        {
            _skill.MultiShotDuring = 30;
            _skill.MultiShotUseMP = 50;
            _skill.MultiShotCooltime = 35;
            ActiveSkillOptionText[0].text = "발사체 수량 : 6개";
        }
        ActiveSkillLevelText[0].text = "Lv. " + _skill.MultiShotLv.ToString();
        SkillPoint.text = _skill.SkillPoint.ToString();
        DataManager.instance.SaveData();
    }
    public void PierceShotLevelUp() // 배열[1]
    {        
        if(_skill.PierceShotLv != 5 && _skill.SkillPoint > 0)
        {
            _skill.PierceShotCurExp++;
            _skill.SkillPoint--;
            while(_skill.PierceShotCurExp >= ActiveSkillExp[3].maxValue)
            {
                _skill.PierceShotLv++;
                _skill.PierceShotCurExp = _skill.PierceShotCurExp - _skill.PierceShotMaxExp;
                ActiveSkillLevelText[1].text = "Lv. " + _skill.PierceShotLv.ToString();            

                if(_skill.PierceShotLv < 5)
                {
                    _skill.PierceShotMaxExp = _skill.PierceShotMaxExp * 2;
                }           

                if(_skill.PierceShotCurExp < _skill.PierceShotMaxExp)
                {
                    break;
                }            
            }
        }
        
        ActiveSkillExp[1].maxValue = _skill.PierceShotMaxExp;
        ActiveSkillExp[1].value = _skill.PierceShotCurExp;        
        
        if(_skill.PierceShotLv != 5)
        {
            ActiveSkillExpText[1].text = _skill.PierceShotCurExp.ToString() + " / " + _skill.PierceShotMaxExp.ToString();
        }

        if(_skill.PierceShotLv == 5)
        {
            ActiveSkillLevelText[1].text = "Lv. MAX";
            ActiveSkillExpText[1].text = "MAX";
            ActiveSkillExpUpButton[1].enabled = false;
            ActiveSkillExp[1].value = ActiveSkillExp[1].maxValue;
        }

        PierceShotAttribute();
        //Debug.Log("정상동작");
    }
    public void PierceShotAttribute()
    {
        if(_skill.PierceShotLv == 0)
        {
            _skill.PierceShotCount = 0;
            _skill.PierceShotUseMP = 0;
            _skill.PierceShotCooltime = 0;
            ActiveSkillOptionText[1].text = "최대 관통 횟수 : 0개";
        }
        else if(_skill.PierceShotLv == 1)
        {
            _skill.PierceShotCount = 1;
            _skill.PierceShotUseMP = 10;
            _skill.PierceShotCooltime = 15;
            ActiveSkillOptionText[1].text = "최대 관통 횟수 : 1개";
        }
        else if(_skill.PierceShotLv == 2)
        {
            _skill.PierceShotCount = 2;
            _skill.PierceShotUseMP = 20;
            _skill.PierceShotCooltime = 20;
            ActiveSkillOptionText[1].text = "최대 관통 횟수 : 2개";
        }
        else if(_skill.PierceShotLv == 3)
        {
            _skill.PierceShotCount = 3;
            _skill.PierceShotUseMP = 30;
            _skill.PierceShotCooltime = 25;
            ActiveSkillOptionText[1].text = "최대 관통 횟수 : 3개";
        }
        else if(_skill.PierceShotLv == 4)
        {
            _skill.PierceShotCount = 4;
            _skill.PierceShotUseMP = 40;
            _skill.PierceShotCooltime = 30;
            ActiveSkillOptionText[1].text = "최대 관통 횟수 : 4개";
        }
        else if(_skill.PierceShotLv == 5)
        {
            _skill.PierceShotCount = 5;
            _skill.PierceShotUseMP = 50;
            _skill.PierceShotCooltime = 35;
            ActiveSkillOptionText[1].text = "최대 관통 횟수 : 5개";
        }
        ActiveSkillLevelText[1].text = "Lv. " + _skill.PierceShotLv.ToString();
        SkillPoint.text = _skill.SkillPoint.ToString();
        DataManager.instance.SaveData();
    }
    public void PosionSmogLevelUp() // 배열[2]
    {        
        if(_skill.AreaSkillLv != 5 && _skill.SkillPoint > 0)
        {
            _skill.AreaSkillCurExp++;
            _skill.SkillPoint--;
            while(_skill.AreaSkillCurExp >= ActiveSkillExp[3].maxValue)
            {
                _skill.AreaSkillLv++;
                _skill.AreaSkillCurExp = _skill.AreaSkillCurExp - _skill.AreaSkillMaxExp;
                ActiveSkillLevelText[2].text = "Lv. " + _skill.AreaSkillLv.ToString();            

                if(_skill.AreaSkillLv < 5)
                {
                    _skill.AreaSkillMaxExp = _skill.AreaSkillMaxExp * 2;
                }           

                if(_skill.AreaSkillCurExp < _skill.AreaSkillMaxExp)
                {
                    break;
                }            
            }
        }
        
        ActiveSkillExp[2].maxValue = _skill.AreaSkillMaxExp;
        ActiveSkillExp[2].value = _skill.AreaSkillCurExp;        
        
        if(_skill.AreaSkillLv != 5)
        {
            ActiveSkillExpText[2].text = _skill.AreaSkillCurExp.ToString() + " / " + _skill.AreaSkillMaxExp.ToString();
        }

        if(_skill.AreaSkillLv == 5)
        {
            ActiveSkillLevelText[2].text = "Lv. MAX";
            ActiveSkillExpText[2].text = "MAX";
            ActiveSkillExpUpButton[2].enabled = false;
            ActiveSkillExp[2].value = ActiveSkillExp[2].maxValue;
        }

        PosionSmogAttribute();
        //Debug.Log("정상동작");
    }
    public void PosionSmogAttribute()
    {
        if(_skill.AreaSkillLv == 0)
        {
            _skill.AreaSkillDamage = 0;
            _skill.AreaSkillDuring = 0;
            _skill.AreaSkillUseMP = 0;
            _skill.AreaSkillCooltime = 0;
            ActiveSkillOptionText[2].text = "지속시간 : 0초\n범위 : 0칸";
        }
        else if(_skill.AreaSkillLv == 1)
        {
            _skill.AreaSkillDamage = 10;
            _skill.AreaSkillDuring = 5;
            _skill.AreaSkillUseMP = 10;
            _skill.AreaSkillCooltime = 15;
            ActiveSkillOptionText[2].text = "지속시간 : 5초\n범위 :1.5칸";
        }
        else if(_skill.AreaSkillLv == 2)
        {
            _skill.AreaSkillDamage = 20;
            _skill.AreaSkillDuring = 10;
            _skill.AreaSkillUseMP = 20;
            _skill.AreaSkillCooltime = 20;
            ActiveSkillOptionText[2].text = "지속시간 : 10초\n범위 : 2칸";
        }
        else if(_skill.AreaSkillLv == 3)
        {
            _skill.AreaSkillDamage = 30;
            _skill.AreaSkillDuring = 15;
            _skill.AreaSkillUseMP = 30;
            _skill.AreaSkillCooltime = 25;
            ActiveSkillOptionText[2].text = "지속시간 : 15초\n범위 : 2.5칸";
        }
        else if(_skill.AreaSkillLv == 4)
        {
            _skill.AreaSkillDamage = 40;
            _skill.AreaSkillDuring = 20;
            _skill.AreaSkillUseMP = 40;
            _skill.AreaSkillCooltime = 30;
            ActiveSkillOptionText[2].text = "지속시간 : 20초\n범위 : 3칸";
        }
        else if(_skill.AreaSkillLv == 5)
        {
            _skill.AreaSkillDamage = 50;
            _skill.AreaSkillDuring = 20;
            _skill.AreaSkillUseMP = 50;
            _skill.AreaSkillCooltime = 35;
            ActiveSkillOptionText[2].text = "지속시간 : 20초\n범위 : 3.5칸";
        }
        ActiveSkillLevelText[2].text = "Lv. " + _skill.AreaSkillLv.ToString();
        SkillPoint.text = _skill.SkillPoint.ToString();
        DataManager.instance.SaveData();
    }
    public void SpritWeaponLevelUp() // 배열[3]
    {
        if(_skill.AroundSkillLv != 5 && _skill.SkillPoint > 0)
        {
            _skill.AroundSkillCurExp++;
            _skill.SkillPoint--;
            while(_skill.AroundSkillCurExp >= ActiveSkillExp[3].maxValue)
            {
                _skill.AroundSkillLv++;
                _skill.AroundSkillCurExp = _skill.AroundSkillCurExp - _skill.AroundSkillMaxExp;
                ActiveSkillLevelText[3].text = "Lv. " + _skill.AroundSkillLv.ToString();            

                if(_skill.AroundSkillLv < 5)
                {
                    _skill.AroundSkillMaxExp = _skill.AroundSkillMaxExp * 2;
                }           

                if(_skill.AroundSkillCurExp < _skill.AroundSkillMaxExp)
                {
                    break;
                }            
            }
        }
        
        ActiveSkillExp[3].maxValue = _skill.AroundSkillMaxExp;
        ActiveSkillExp[3].value = _skill.AroundSkillCurExp;        
        
        if(_skill.AroundSkillLv != 5)
        {
            ActiveSkillExpText[3].text = _skill.AroundSkillCurExp.ToString() + " / " + _skill.AroundSkillMaxExp.ToString();
        }

        if(_skill.AroundSkillLv == 5)
        {
            ActiveSkillLevelText[3].text = "Lv. MAX";
            ActiveSkillExpText[3].text = "MAX";
            ActiveSkillExpUpButton[3].enabled = false;
            ActiveSkillExp[3].value = ActiveSkillExp[3].maxValue;
        }

        SpritWeaponAttribute();
        //Debug.Log("정상동작");
    }
    public void SpritWeaponAttribute()
    {
        if(_skill.AroundSkillLv == 0)
        {
            _skill.AroundSkillDamage = 0;
            _skill.AroundSkillDuring = 0;
            _skill.AroundSkillUseMP = 0;
            _skill.AroundSkillCooltime = 0;
            ActiveSkillOptionText[3].text = "스피릿 웨폰 수량 : 0개";
        }
        else if(_skill.AroundSkillLv == 1)
        {
            _skill.AroundSkillDamage = 10;
            _skill.AroundSkillDuring = 10;
            _skill.AroundSkillUseMP = 10;
            _skill.AroundSkillCooltime = 15;
            ActiveSkillOptionText[3].text = "스피릿 웨폰 수량 : 1개";
        }
        else if(_skill.AroundSkillLv == 2)
        {
            _skill.AroundSkillDamage = 20;
            _skill.AroundSkillDuring = 15;
            _skill.AroundSkillUseMP = 20;
            _skill.AroundSkillCooltime = 20;
            ActiveSkillOptionText[3].text = "스피릿 웨폰 수량 : 2개";
        }
        else if(_skill.AroundSkillLv == 3)
        {
            _skill.AroundSkillDamage = 30;
            _skill.AroundSkillDuring = 20;
            _skill.AroundSkillUseMP = 30;
            _skill.AroundSkillCooltime = 25;
            ActiveSkillOptionText[3].text = "스피릿 웨폰 수량 : 3개";
        }
        else if(_skill.AroundSkillLv == 4)
        {
            _skill.AroundSkillDamage = 40;
            _skill.AroundSkillDuring = 25;
            _skill.AroundSkillUseMP = 40;
            _skill.AroundSkillCooltime = 30;
            ActiveSkillOptionText[3].text = "스피릿 웨폰 수량 : 4개";
        }
        else if(_skill.AroundSkillLv == 5)
        {
            _skill.AroundSkillDamage = 50;
            _skill.AroundSkillDuring = 30;
            _skill.AroundSkillUseMP = 50;
            _skill.AroundSkillCooltime = 35;
            ActiveSkillOptionText[3].text = "스피릿 웨폰 수량 : 5개";
        }
        ActiveSkillLevelText[3].text = "Lv. " + _skill.AroundSkillLv.ToString();
        SkillPoint.text = _skill.SkillPoint.ToString();
        DataManager.instance.SaveData();
    }

}
