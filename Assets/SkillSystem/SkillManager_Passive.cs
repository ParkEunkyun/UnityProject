using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class SkillManager_Passive : MonoBehaviour
{
    public SkillObject _skill;
    public Text SkillPoint;    
    public GameObject[] PassiveSkillSlot;
    //0:호크아이, 1:마그넷 캐치, 2:샤프니스, 3:퀵스로잉 4:크리티컬 스로잉
    public Text[] PassiveSkillLevelText;
    public Text[] PassiveSkillOptionText;
    public Slider[] PassiveSkillExp;
    public Button[] PassiveSkillExpUpButton;
    public Text[] PassiveSkillExpText;
    public GameObject[] Magnet;

    public GameObject Character;

    public bool[] isClick;
    public float[] timer;


    private void Start() 
    {
        isClick[0] = false;
        isClick[1] = false;
        isClick[2] = false;
        isClick[3] = false;
        isClick[4] = false;
        SkillPoint.text = _skill.SkillPoint.ToString();

        //ActiveSkillExpUpButton[0].onClick.AddListener(MultiShotLevelUp);
        //ActiveSkillExpUpButton[1].onClick.AddListener(PierceShotLevelUp);
        //ActiveSkillExpUpButton[2].onClick.AddListener(PosionSmogLevelUp);
        //ActiveSkillExpUpButton[3].onClick.AddListener(SpritWeaponLevelUp);

        //초기 스킬 경험치
        PassiveSkillExp[0].maxValue = _skill.ViewRadiusMaxExp;
        PassiveSkillExp[1].maxValue = _skill.MagnetMaxExp;
        PassiveSkillExp[2].maxValue = _skill.AttackMaxExp;
        PassiveSkillExp[3].maxValue = _skill.AttackSpeedMaxExp;
        PassiveSkillExp[4].maxValue = _skill.CriticalMaxExp;

        if (_skill.ViewRadiusMaxExp == 160 && _skill.ViewRadiusLv == 5)
        {
            PassiveSkillExp[0].value = PassiveSkillExp[0].maxValue;
            PassiveSkillExpText[0].text = "MAX";
            PassiveSkillLevelText[0].text = "Lv. MAX";
        }
        else
        {
            PassiveSkillExpText[0].text = _skill.ViewRadiusCurExp.ToString() + " / " + _skill.ViewRadiusMaxExp.ToString();
            PassiveSkillExp[0].value = _skill.ViewRadiusCurExp;
            PassiveSkillLevelText[0].text = "Lv. " + _skill.ViewRadiusLv.ToString();
        }

        if (_skill.MagnetMaxExp == 160 && _skill.MagnetLv == 5)
        {
            PassiveSkillExp[1].value = PassiveSkillExp[1].maxValue;
            PassiveSkillExpText[1].text = "MAX";
            PassiveSkillLevelText[1].text = "Lv. MAX";

        }
        else
        {
            PassiveSkillExpText[1].text = _skill.MagnetCurExp.ToString() + " / " + _skill.MagnetMaxExp.ToString();
            PassiveSkillExp[1].value = _skill.MagnetCurExp;
            PassiveSkillLevelText[1].text = "Lv. " + _skill.MagnetLv.ToString();
        }

        if (_skill.MagnetLv == 1)
        {
            Magnet[1].SetActive(true);
            Magnet[0].SetActive(false);
        }
        else if (_skill.MagnetLv == 2)
        {
            Magnet[2].SetActive(true);
            Magnet[1].SetActive(false);
        }
        else if (_skill.MagnetLv == 3)
        {
            Magnet[3].SetActive(true);
            Magnet[2].SetActive(false);
        }
        else if (_skill.MagnetLv == 4)
        {
            Magnet[4].SetActive(true);
            Magnet[3].SetActive(false);
        }
        else if (_skill.MagnetLv == 5)
        {
            Magnet[5].SetActive(true);
            Magnet[4].SetActive(false);
        }

        if (_skill.AttackMaxExp == 160 && _skill.AttackLv == 5)
        {
            PassiveSkillExp[2].value = PassiveSkillExp[2].maxValue;
            PassiveSkillExpText[2].text = "MAX";
            PassiveSkillLevelText[2].text = "Lv. MAX";
        }
        else
        {
            PassiveSkillExpText[2].text = _skill.AttackCurExp.ToString() + " / " + _skill.AttackMaxExp.ToString();
            PassiveSkillExp[2].value = _skill.AttackCurExp;
            PassiveSkillLevelText[2].text = "Lv. " + _skill.AttackLv.ToString();
        }

        if(_skill.AttackSpeedMaxExp == 160 && _skill.AttackSpeedLv == 5)
        {
            PassiveSkillExp[3].value = PassiveSkillExp[3].maxValue;
            PassiveSkillExpText[3].text = "MAX";
            PassiveSkillLevelText[3].text = "Lv. MAX";
        }
        else
        {
            PassiveSkillExpText[3].text = _skill.AttackSpeedCurExp.ToString() + " / " + _skill.AttackSpeedMaxExp.ToString();
            PassiveSkillExp[3].value = _skill.AttackSpeedCurExp;
            PassiveSkillLevelText[3].text = "Lv. " + _skill.AttackSpeedLv.ToString();
        }

        if (_skill.CriticalMaxExp == 160 && _skill.CriticalLv == 5)
        {
            PassiveSkillExp[4].value = PassiveSkillExp[4].maxValue;
            PassiveSkillExpText[4].text = "MAX";
            PassiveSkillLevelText[4].text = "Lv. MAX";
        }
        else
        {
            PassiveSkillExpText[4].text = _skill.CriticalCurExp.ToString() + " / " + _skill.CriticalMaxExp.ToString();
            PassiveSkillExp[4].value = _skill.CriticalCurExp;
            PassiveSkillLevelText[4].text = "Lv. " + _skill.CriticalLv.ToString();
        }
        HawkEyesAttribute();
        MagnetAttribute();
        SharpnessAttribute();
        QuickThrowingAttribute();
        CriticalThrowingAttribute();
    }
    

    public void HawkEyesLevelUp() // 배열[0]
    {
        if (_skill.ViewRadiusLv != 5 && _skill.SkillPoint > 0)
        {
            _skill.ViewRadiusCurExp++;
            _skill.SkillPoint--;
            SkillPoint.text = _skill.SkillPoint.ToString();
            PassiveSkillExp[0].value = _skill.ViewRadiusCurExp;
            PassiveSkillExpText[0].text = _skill.ViewRadiusCurExp.ToString() + " / " + _skill.ViewRadiusMaxExp.ToString();
        }

        if (_skill.ViewRadiusCurExp != PassiveSkillExp[0].maxValue)
        {
            return;
        }
        else
        {
            _skill.ViewRadiusLv++;
            if (Character.GetComponent<AutoThrowing>().viewRadius == 3.0f)
            {
                _skill.SkillViewRadius = 3.5f;
                Character.GetComponent<AutoThrowing>().viewRadius = _skill.SkillViewRadius;
            }
            else if (Character.GetComponent<AutoThrowing>().viewRadius == 3.5f)
            {
                Character.GetComponent<AutoThrowing>().viewRadius = 4.0f;
            }
            else if (Character.GetComponent<AutoThrowing>().viewRadius == 4.0f)
            {
                Character.GetComponent<AutoThrowing>().viewRadius = 4.5f;
            }
            else if (Character.GetComponent<AutoThrowing>().viewRadius == 4.5f)
            {
                Character.GetComponent<AutoThrowing>().viewRadius = 5.0f;
            }
            else if (Character.GetComponent<AutoThrowing>().viewRadius == 5.0f)
            {
                Character.GetComponent<AutoThrowing>().viewRadius = 6.0f;
            }

            _skill.ViewRadiusCurExp = _skill.ViewRadiusCurExp - _skill.ViewRadiusMaxExp;
            PassiveSkillLevelText[0].text = "Lv. " + _skill.ViewRadiusLv.ToString();

            if (_skill.ViewRadiusLv < 5)
            {
                _skill.ViewRadiusMaxExp = _skill.ViewRadiusMaxExp * 2;
                PassiveSkillExpText[0].text = _skill.ViewRadiusCurExp.ToString() + " / " + _skill.ViewRadiusMaxExp.ToString();
                PassiveSkillExp[0].maxValue = _skill.ViewRadiusMaxExp;
                PassiveSkillExp[0].value = _skill.ViewRadiusCurExp;
            }
            else
            {
                PassiveSkillLevelText[0].text = "Lv. MAX";
                PassiveSkillExpText[0].text = "MAX";
                PassiveSkillExpUpButton[0].enabled = false;
                PassiveSkillExp[0].value = PassiveSkillExp[0].maxValue;
            }
        }

        HawkEyesAttribute();
    }
    public void HawkEyesAttribute()
    {
        if(_skill.ViewRadiusLv == 0)
        {
            _skill.SkillViewRadius = 3.0f;
            PassiveSkillOptionText[0].text = "사거리 증가 : 3칸";
        }
        else if(_skill.ViewRadiusLv == 1)
        {
            _skill.SkillViewRadius = 3.5f;
            PassiveSkillOptionText[0].text = "사거리 증가 : 3.5칸";
        }
        else if(_skill.ViewRadiusLv == 2)
        {
            _skill.SkillViewRadius = 4.0f;
            PassiveSkillOptionText[0].text = "사거리 증가 : 4칸";
        }
        else if(_skill.ViewRadiusLv == 3)
        {
            _skill.SkillViewRadius = 4.5f;
            PassiveSkillOptionText[0].text = "사거리 증가 : 4.5칸";
        }
        else if(_skill.ViewRadiusLv == 4)
        {
            _skill.SkillViewRadius = 5.0f;
            PassiveSkillOptionText[0].text = "사거리 증가 : 5칸";
        }
        else if(_skill.ViewRadiusLv == 5)
        {
            _skill.SkillViewRadius = 6.0f;
            PassiveSkillOptionText[0].text = "사거리 증가 : 6칸";
        }
        //PassiveSkillLevelText[0].text = "Lv. " + _skill.ViewRadiusLv.ToString();
        SkillPoint.text = _skill.SkillPoint.ToString();
        DataManager.instance.SaveData();
    }

    public void MagnetLevelUp() // 배열[2]
    {
        if (_skill.MagnetLv != 5 && _skill.SkillPoint > 0)
        {
            _skill.MagnetCurExp++;
            _skill.SkillPoint--;
            SkillPoint.text = _skill.SkillPoint.ToString();
            PassiveSkillExp[1].value = _skill.MagnetCurExp;
            PassiveSkillExpText[1].text = _skill.MagnetCurExp.ToString() + " / " + _skill.MagnetMaxExp.ToString();
        }

        if (_skill.MagnetCurExp != PassiveSkillExp[1].maxValue)
        {
            return;
        }
        else
        {
            _skill.MagnetLv++;
            if (Magnet[0].activeSelf == true)
            {
                Magnet[1].SetActive(true);
                Magnet[0].SetActive(false);
            }
            else if (Magnet[1].activeSelf == true)
            {
                Magnet[2].SetActive(true);
                Magnet[1].SetActive(false);
            }
            else if (Magnet[2].activeSelf == true)
            {
                Magnet[3].SetActive(true);
                Magnet[2].SetActive(false);
            }
            else if (Magnet[3].activeSelf == true)
            {
                Magnet[4].SetActive(true);
                Magnet[3].SetActive(false);
            }
            else if (Magnet[4].activeSelf == true)
            {
                Magnet[5].SetActive(true);
                Magnet[4].SetActive(false);
            }
            else if (Magnet[5].activeSelf == true)
            {
                Magnet[6].SetActive(true);
                Magnet[5].SetActive(false);
            }
            _skill.MagnetCurExp = _skill.MagnetCurExp - _skill.MagnetMaxExp;
            PassiveSkillLevelText[1].text = "Lv. " + _skill.MagnetLv.ToString();

            if (_skill.MagnetLv < 5)
            {
                _skill.MagnetMaxExp = _skill.MagnetMaxExp * 2;
                PassiveSkillExpText[1].text = _skill.MagnetCurExp.ToString() + " / " + _skill.MagnetMaxExp.ToString();
                PassiveSkillExp[1].maxValue = _skill.MagnetMaxExp;
                PassiveSkillExp[1].value = _skill.MagnetCurExp;
            }
            else
            {
                PassiveSkillLevelText[1].text = "Lv. MAX";
                PassiveSkillExpText[1].text = "MAX";
                PassiveSkillExpUpButton[1].enabled = false;
                PassiveSkillExp[1].value = PassiveSkillExp[1].maxValue;
            }
        }

        MagnetAttribute();
    }
    public void MagnetAttribute()
    {
        if (_skill.MagnetLv == 0)
        {
            PassiveSkillOptionText[1].text = "범위 : 1칸";
        }
        else if (_skill.MagnetLv == 1)
        {
            PassiveSkillOptionText[1].text = "범위 :1.5칸";
        }
        else if (_skill.MagnetLv == 2)
        {
            PassiveSkillOptionText[1].text = "범위 : 2칸";
        }
        else if (_skill.MagnetLv == 3)
        {
            PassiveSkillOptionText[1].text = "범위 : 2.5칸";
        }
        else if (_skill.MagnetLv == 4)
        {
            PassiveSkillOptionText[1].text = "범위 : 3칸";
        }
        else if (_skill.MagnetLv == 5)
        {
            PassiveSkillOptionText[1].text = "범위 : 3.5칸";
        }
        //PassiveSkillLevelText[1].text = "Lv. " + _skill.MagnetLv.ToString();
        SkillPoint.text = _skill.SkillPoint.ToString();
        DataManager.instance.SaveData();
    }
    public void SharpnessLevelUp() // 배열[2]
    {
        if (_skill.AttackLv != 5 && _skill.SkillPoint > 0)
        {
            _skill.AttackCurExp++;
            _skill.SkillPoint--;
            SkillPoint.text = _skill.SkillPoint.ToString();
            PassiveSkillExp[2].value = _skill.AttackCurExp;
            PassiveSkillExpText[2].text = _skill.AttackCurExp.ToString() + " / " + _skill.AttackMaxExp.ToString();
        }

        if (_skill.AttackCurExp != PassiveSkillExp[2].maxValue)
        {
            return;
        }
        else
        {
            _skill.AttackLv++;
            if (_skill.SkillAttack == 0)
            {
                _skill.SkillAttack = 100;
            }
            else if (_skill.SkillAttack == 100)
            {
                _skill.SkillAttack = 200;
            }
            else if (_skill.SkillAttack == 200)
            {
                _skill.SkillAttack = 400;
            }
            else if (_skill.SkillAttack == 400)
            {
                _skill.SkillAttack = 700;
            }
            else if (_skill.SkillAttack == 700)
            {
                _skill.SkillAttack = 1100;
            }
            _skill.AttackCurExp = _skill.AttackCurExp - _skill.AttackMaxExp;
            PassiveSkillLevelText[2].text = "Lv. " + _skill.AttackLv.ToString();

            if (_skill.AttackLv < 5)
            {
                _skill.AttackMaxExp = _skill.AttackMaxExp * 2;
                PassiveSkillExpText[2].text = _skill.AttackCurExp.ToString() + " / " + _skill.AttackMaxExp.ToString();
                PassiveSkillExp[2].maxValue = _skill.AttackMaxExp;
                PassiveSkillExp[2].value = _skill.AttackCurExp;
            }
            else
            {
                PassiveSkillLevelText[2].text = "Lv. MAX";
                PassiveSkillExpText[2].text = "MAX";
                PassiveSkillExpUpButton[2].enabled = false;
                PassiveSkillExp[2].value = PassiveSkillExp[2].maxValue;
            }
        }

        SharpnessAttribute();
    }
    public void SharpnessAttribute()
    {
        if(_skill.AttackLv == 0)
        {
            PassiveSkillOptionText[2].text = "공격력 증가 : 0";
        }
        else if(_skill.AttackLv == 1)
        {
            PassiveSkillOptionText[2].text = "공격력 증가 : 100";
        }
        else if(_skill.AttackLv == 2)
        {
            PassiveSkillOptionText[2].text = "공격력 증가 : 200";
        }
        else if(_skill.AttackLv == 3)
        {
            PassiveSkillOptionText[2].text = "공격력 증가 : 400";
        }
        else if(_skill.AttackLv == 4)
        {
            PassiveSkillOptionText[2].text = "공격력 증가 : 700";
        }
        else if(_skill.AttackLv == 5)
        {
            PassiveSkillOptionText[2].text = "공격력 증가 : 1100";
        }
        //PassiveSkillLevelText[2].text = "Lv. " + _skill.AttackLv.ToString();
        SkillPoint.text = _skill.SkillPoint.ToString();
        DataManager.instance.SaveData();
    }
    public void QuickThowingLevelUp() // 배열[3]
    {
        if (_skill.AttackSpeedLv != 5 && _skill.SkillPoint > 0)
        {
            _skill.AttackSpeedCurExp++;
            _skill.SkillPoint--;
            SkillPoint.text = _skill.SkillPoint.ToString();
            PassiveSkillExp[3].value = _skill.AttackSpeedCurExp;
            PassiveSkillExpText[3].text = _skill.AttackSpeedCurExp.ToString() + " / " + _skill.AttackSpeedMaxExp.ToString();
        }

        if (_skill.AttackSpeedCurExp != PassiveSkillExp[3].maxValue)
        {
            return;
        }
        else
        {
            _skill.AttackSpeedLv++;
            if (_skill.SkillAttackSpeed == 0)
            {
                _skill.SkillAttackSpeed = 100;
            }
            else if (_skill.SkillAttackSpeed == 100)
            {
                _skill.SkillAttackSpeed = 200;
            }
            else if (_skill.SkillAttackSpeed == 200)
            {
                _skill.SkillAttackSpeed = 300;
            }
            else if (_skill.SkillAttackSpeed == 300)
            {
                _skill.SkillAttackSpeed = 400;
            }
            else if (_skill.SkillAttackSpeed == 400)
            {
                _skill.SkillAttackSpeed = 500;
            }
            _skill.AttackSpeedCurExp = _skill.AttackSpeedCurExp - _skill.AttackSpeedMaxExp;
            PassiveSkillLevelText[3].text = "Lv. " + _skill.AttackSpeedLv.ToString();

            if (_skill.AttackSpeedLv < 5)
            {
                _skill.AttackSpeedMaxExp = _skill.AttackSpeedMaxExp * 2;
                PassiveSkillExpText[3].text = _skill.AttackSpeedCurExp.ToString() + " / " + _skill.AttackSpeedMaxExp.ToString();
                PassiveSkillExp[3].maxValue = _skill.AttackSpeedMaxExp;
                PassiveSkillExp[3].value = _skill.AttackSpeedCurExp;
            }
            else
            {
                PassiveSkillLevelText[3].text = "Lv. MAX";
                PassiveSkillExpText[3].text = "MAX";
                PassiveSkillExpUpButton[3].enabled = false;
                PassiveSkillExp[3].value = PassiveSkillExp[3].maxValue;
            }
        }

        QuickThrowingAttribute();
    }
    public void QuickThrowingAttribute()
    {
        if(_skill.AttackSpeedLv == 0)
        {            
            PassiveSkillOptionText[3].text = "공격속도 증가 : 0";
        }
        else if(_skill.AttackSpeedLv == 1)
        {
            PassiveSkillOptionText[3].text = "공격속도 증가 : 100";
        }
        else if(_skill.AttackSpeedLv == 2)
        {
            PassiveSkillOptionText[3].text = "공격속도 증가 : 200";
        }
        else if(_skill.AttackSpeedLv == 3)
        {
            PassiveSkillOptionText[3].text = "공격속도 증가 : 300";
        }
        else if(_skill.AttackSpeedLv == 4)
        {
            PassiveSkillOptionText[3].text = "공격속도 증가 : 400";
        }
        else if(_skill.AttackSpeedLv == 5)
        {
            PassiveSkillOptionText[3].text = "공격속도 증가 : 500";
        }
        //PassiveSkillLevelText[3].text = "Lv. " + _skill.AttackSpeedLv.ToString();
        SkillPoint.text = _skill.SkillPoint.ToString();
        DataManager.instance.SaveData();
    }

    public void CriticalThrowingLevelUp() // 배열[4]
    {
        if (_skill.CriticalLv != 5 && _skill.SkillPoint > 0)
        {
            _skill.CriticalCurExp++;
            _skill.SkillPoint--;
            SkillPoint.text = _skill.SkillPoint.ToString();
            PassiveSkillExp[4].value = _skill.CriticalCurExp;
            PassiveSkillExpText[4].text = _skill.CriticalCurExp.ToString() + " / " + _skill.CriticalMaxExp.ToString();
        }

        if (_skill.CriticalCurExp != PassiveSkillExp[4].maxValue)
        {
            return;
        }
        else
        {
            _skill.CriticalLv++;
            if (_skill.SkillCritical == 0)
            {
                _skill.SkillCritical = 50;
            }
            else if (_skill.SkillCritical == 50)
            {
                _skill.SkillCritical = 100;
            }
            else if (_skill.SkillCritical == 100)
            {
                _skill.SkillCritical = 150;
            }
            else if (_skill.SkillCritical == 150)
            {
                _skill.SkillCritical = 200;
            }
            else if (_skill.SkillCritical == 200)
            {
                _skill.SkillCritical = 250;
            }
            _skill.CriticalCurExp = _skill.CriticalCurExp - _skill.CriticalMaxExp;
            PassiveSkillLevelText[4].text = "Lv. " + _skill.CriticalLv.ToString();

            if (_skill.CriticalLv < 5)
            {
                _skill.CriticalMaxExp = _skill.CriticalMaxExp * 2;
                PassiveSkillExpText[4].text = _skill.CriticalCurExp.ToString() + " / " + _skill.CriticalMaxExp.ToString();
                PassiveSkillExp[4].maxValue = _skill.CriticalMaxExp;
                PassiveSkillExp[4].value = _skill.CriticalCurExp;
            }
            else
            {
                PassiveSkillLevelText[4].text = "Lv. MAX";
                PassiveSkillExpText[4].text = "MAX";
                PassiveSkillExpUpButton[4].enabled = false;
                PassiveSkillExp[4].value = PassiveSkillExp[4].maxValue;
            }
        }

        CriticalThrowingAttribute();
    }
    public void CriticalThrowingAttribute()
    {
        if (_skill.CriticalLv == 0)
        {
            PassiveSkillOptionText[4].text = "치명타 확률 증가 : 0%";
        }
        else if (_skill.CriticalLv == 1)
        {
            PassiveSkillOptionText[4].text = "치명타 확률 증가 : 10%";
        }
        else if (_skill.CriticalLv == 2)
        {
            PassiveSkillOptionText[4].text = "치명타 확률 증가 : 20%";
        }
        else if (_skill.CriticalLv == 3)
        {
            PassiveSkillOptionText[4].text = "치명타 확률 증가 : 30%";
        }
        else if (_skill.CriticalLv == 4)
        {
            PassiveSkillOptionText[4].text = "치명타 확률 증가 : 40%";
        }
        else if (_skill.CriticalLv == 5)
        {
            PassiveSkillOptionText[4].text = "치명타 확률 증가 : 50%";
        }
        //PassiveSkillLevelText[4].text = "Lv. " + _skill.CriticalLv.ToString();
        SkillPoint.text = _skill.SkillPoint.ToString();
        DataManager.instance.SaveData();
    }

    private void Update()
    {
        if (isClick[0])
        {
            timer[0] += Time.deltaTime;
            if (timer[0] >= 0.2f)
            {
                HawkEyesLevelUp(); // 1초마다 A 함수 실행
                timer[0] = 0.0f;
            }
        }
        else if (isClick[1])
        {
            timer[1] += Time.deltaTime;
            if (timer[1] >= 0.2f)
            {
                MagnetLevelUp(); // 1초마다 A 함수 실행
                timer[1] = 0.0f;
            }
        }
        else if (isClick[2])
        {
            timer[2] += Time.deltaTime;
            if (timer[2] >= 0.2f)
            {
                SharpnessLevelUp(); // 1초마다 A 함수 실행
                timer[2] = 0.0f;
            }
        }
        else if (isClick[3])
        {
            timer[3] += Time.deltaTime;
            if (timer[3] >= 0.2f)
            {
                QuickThowingLevelUp(); // 1초마다 A 함수 실행
                timer[3] = 0.0f;
            }
        }
        else if (isClick[4])
        {
            timer[4] += Time.deltaTime;
            if (timer[4] >= 0.2f)
            {
                CriticalThrowingLevelUp(); // 1초마다 A 함수 실행
                timer[4] = 0.0f;
            }
        }
        else
        {
            return;
        }
    }

    public void OnButtonPress(int i)
    {
        if (i == 0)
        {
            HawkEyesLevelUp();
        }
        else if (i == 1)
        {
            MagnetLevelUp();
        }
        else if (i == 2)
        {
            SharpnessLevelUp();
        }
        else if (i == 3)
        {
            QuickThowingLevelUp();
        }
        else if (i == 4)
        {
            CriticalThrowingLevelUp();
        }
        isClick[i] = true;
    }

    public void OnButtonRelease(int i)
    {
        isClick[i] = false;
        timer[i] = 0.0f;
    }

}
