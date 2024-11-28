using EZInventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour, IPointerClickHandler
{
    public Text Name; public Text Level;
    public Text STR; public Text CON; public Text DEX; public Text INT; public Text LUK; public Text PP;
    public Text ATK; public Text maxHP; public Text ASP; public Text Cri; public Text CriDmg; public Text MSP;
    public Text RCH; public Text DEF; public Text Cool; public Text Exp; public Text maxMP; public Text RCM;
    public Text itemSTR; public Text itemCON; public Text itemDEX; public Text itemINT; public Text itemLUK;
    public Text itemATK; public Text itemmaxHP; public Text itemASP; public Text itemCri; public Text itemCriDmg; public Text itemMSP;
    public Text itemRCH; public Text itemDEF; public Text itemCool; public Text itemmaxMP; public Text itemRCM;
    public Slider ExpBar;
    public Stat stat;
    public SkillObject _skill;
    public GameObject AlertWindow;
    public Text AlertText;

    public bool[] isClick;
    public float[] timer;

    public bool isPuchase;
    public GameObject buttonCover; // 버튼을 어둡게 해주는 창
    public string CurrentTimeStr; // 시작시간 문자열
    public string FinishTimeStr; // 종료시간 문자열
    DateTime StartTimeDt;    // 시작시간
    DateTime EndTimeDt;   // 목표시간
    TimeSpan DelayTimeTs;   // 대기 시간
    TimeSpan CountTimeTs;   // 감소 시간
    TimeSpan RemainTimeTs;   // 남은 시간
    public Text TimeText; //화면에 노출되는 텍스트   

    public void infoupdate()
    {
        Name.text = DataManager.instance.nowPlayer.name;
        Level.text = DataManager.instance.nowPlayer.Level.ToString();
        ExpBar.maxValue = DataManager.instance.nowPlayer.maxExp;
        ExpBar.value = DataManager.instance.nowPlayer.curExp;
        Textupdate();
    }
    #region 레벨업 스탯분배
    public void PlusPointSTR()
    {

        if (DataManager.instance.nowPlayer.Pp > 0) { DataManager.instance.nowPlayer.Str++; DataManager.instance.nowPlayer.Pp--; }
        Textupdate();
        DataManager.instance.SaveData();
    }
    public void PlusPointCON()
    {

        if (DataManager.instance.nowPlayer.Pp > 0) { DataManager.instance.nowPlayer.Con++; DataManager.instance.nowPlayer.Pp--; }
        Textupdate();
        DataManager.instance.SaveData();
    }
    public void PlusPointDEX()
    {

        if (DataManager.instance.nowPlayer.Pp > 0) { DataManager.instance.nowPlayer.Dex++; DataManager.instance.nowPlayer.Pp--; }
        Textupdate();
        DataManager.instance.SaveData();
    }
    public void PlusPointINT()
    {

        if (DataManager.instance.nowPlayer.Pp > 0) { DataManager.instance.nowPlayer.Int++; DataManager.instance.nowPlayer.Pp--; }
        Textupdate();
        DataManager.instance.SaveData();
    }
    public void PlusPointLUK()
    {

        if (DataManager.instance.nowPlayer.Pp > 0) { DataManager.instance.nowPlayer.Luk++; DataManager.instance.nowPlayer.Pp--; }
        Textupdate();
        DataManager.instance.SaveData();
    }

    private void Update()
    {
        if (isClick[0])
        {
            timer[0] += Time.deltaTime;
            if (timer[0] >= 0.2f)
            {
                PlusPointSTR(); // 1초마다 A 함수 실행
                timer[0] = 0.0f;
            }
        }
        else if (isClick[1])
        {
            timer[1] += Time.deltaTime;
            if (timer[1] >= 0.2f)
            {
                PlusPointCON(); // 1초마다 A 함수 실행
                timer[1] = 0.0f;
            }
        }
        else if (isClick[2])
        {
            timer[2] += Time.deltaTime;
            if (timer[2] >= 0.2f)
            {
                PlusPointDEX(); // 1초마다 A 함수 실행
                timer[2] = 0.0f;
            }
        }
        else if (isClick[3])
        {
            timer[3] += Time.deltaTime;
            if (timer[3] >= 0.2f)
            {
                PlusPointINT(); // 1초마다 A 함수 실행
                timer[3] = 0.0f;
            }
        }
        else if (isClick[4])
        {
            timer[4] += Time.deltaTime;
            if (timer[4] >= 0.2f)
            {
                PlusPointLUK(); // 1초마다 A 함수 실행
                timer[4] = 0.0f;
            }
        }
        else
        {
            return;
        }

        if (!isPuchase && StartTimeDt >= EndTimeDt)
        {
            Debug.Log("코루틴 종료" + EndTimeDt);
            TimeText.text = "▶";
            StopCoroutine("PuchaseCor");
            buttonCover.SetActive(false);
            isPuchase = true;
        }
    }

    public void OnButtonPress(int i)
    {
        if (i == 0)
        {
            PlusPointSTR();
        }
        else if (i == 1)
        {
            PlusPointCON();
        }
        else if (i == 2)
        {
            PlusPointDEX();
        }
        else if (i == 3)
        {
            PlusPointINT();
        }
        else if (i == 4)
        {
            PlusPointLUK();
        }
        isClick[i] = true;
    }

    public void OnButtonRelease(int i)
    {
        isClick[i] = false;
        timer[i] = 0.0f;
    }

    #endregion
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

        if (clickedObject.name == "adsPP")
        {
            PPUPTEST();
        }
        else
        {
            return;
        }
    }
    public void PPUPTEST()
    {

        StatAdmob.instance.ShowAds();

        if (isPuchase)
        {
            CurrentTimeStr = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            StartTimeDt = DateTime.ParseExact(CurrentTimeStr, "yyyyMMddHHmmss", null);//CultureInfo.InvariantCulture);

            Debug.Log("현재시간" + StartTimeDt);

            DelayTimeTs = new TimeSpan(0, 5, 0); // 쿨타임
            CountTimeTs = new TimeSpan(0, 0, 1);
            EndTimeDt = StartTimeDt + DelayTimeTs;

            Debug.Log("목표시간" + EndTimeDt);

            buttonCover.SetActive(true);

            DataManager.instance.nowPlayer.Pp++;
            Textupdate();

            isPuchase = false;

            CurrentTimeStr = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            FinishTimeStr = EndTimeDt.ToString("yyyyMMddHHmmss");
            DataManager.instance.nowPlayer.StatTime = FinishTimeStr;
            
            StartCoroutine("PuchaseCor");
        }
        else
        {
            return;
        }
    }

    IEnumerator PuchaseCor()
    {
        while (true)
        {
            StartTimeDt = StartTimeDt + CountTimeTs;
            RemainTimeTs = EndTimeDt - StartTimeDt;
            string timer = string.Format("{0:00}:{1:00}:{2:00}",
            RemainTimeTs.Hours, RemainTimeTs.Minutes, RemainTimeTs.Seconds);
            TimeText.text = timer;



            Debug.Log("코루틴" + StartTimeDt);
            yield return new WaitForSeconds(1);
        }
    }

    public void OnEnable() // 저장한 시간을 불러왔을때 처리해야됨
    {
        CurrentTimeStr = DateTime.Now.ToString("yyyyMMddHHmmss");
        StartTimeDt = DateTime.ParseExact(CurrentTimeStr, "yyyyMMddHHmmss", null);

        FinishTimeStr = DataManager.instance.nowPlayer.StatTime;
        EndTimeDt = DateTime.ParseExact(FinishTimeStr, "yyyyMMddHHmmss", null);

        if (EndTimeDt > DateTime.Now)
        {
            Debug.Log("활성화 함수 실행");
            buttonCover.SetActive(true);
            CountTimeTs = new TimeSpan(0, 0, 1);
            isPuchase = false;
            StartCoroutine("PuchaseCor");
        }
        else
        {
            isPuchase = true;
            buttonCover.SetActive(false);
            TimeText.text = "▶";
        }
    }    
    /*
        public void LevelUP()
        {        
            while(DataManager.instance.nowPlayer.curExp >= ExpBar.maxValue)
            {
                DataManager.instance.nowPlayer.Level++;
                DataManager.instance.nowPlayer.curExp = DataManager.instance.nowPlayer.curExp - DataManager.instance.nowPlayer.maxExp;
                DataManager.instance.nowPlayer.Pp = DataManager.instance.nowPlayer.Pp + 5;
                Level.text = DataManager.instance.nowPlayer.Level.ToString();
                PP.text = DataManager.instance.nowPlayer.Pp.ToString();

                if(DataManager.instance.nowPlayer.Level < 30)
                {
                    DataManager.instance.nowPlayer.maxExp = DataManager.instance.nowPlayer.maxExp + 10;
                }
                else if(DataManager.instance.nowPlayer.Level < 50)
                {
                    DataManager.instance.nowPlayer.maxExp = DataManager.instance.nowPlayer.maxExp + 40;
                }
                else if(DataManager.instance.nowPlayer.Level < 100)
                {
                    DataManager.instance.nowPlayer.maxExp = DataManager.instance.nowPlayer.maxExp + 100;
                }

                if(DataManager.instance.nowPlayer.curExp < DataManager.instance.nowPlayer.maxExp)
                {
                    break;
                }
            }   

            ExpBar.maxValue = DataManager.instance.nowPlayer.maxExp;
            ExpBar.value = DataManager.instance.nowPlayer.curExp;
            Textupdate();
            DataManager.instance.SaveData();
        }
    */
    public void Textupdate()
    {
        Calcurate();

        STR.text = (stat.ItemStr + DataManager.instance.nowPlayer.Str).ToString();
        CON.text = (stat.ItemCon + DataManager.instance.nowPlayer.Con).ToString();
        DEX.text = (stat.ItemDex + DataManager.instance.nowPlayer.Dex).ToString();
        INT.text = (stat.ItemInt + DataManager.instance.nowPlayer.Int).ToString();
        LUK.text = (stat.ItemLuk + DataManager.instance.nowPlayer.Luk).ToString();
        PP.text = DataManager.instance.nowPlayer.Pp.ToString();

        ATK.text = stat.minAtk.ToString() + " ~ " + stat.maxAtk.ToString();
        maxHP.text = stat.maxHP.ToString();
        maxMP.text = stat.maxMP.ToString();
        Exp.text = stat.curExp.ToString() + " / " + stat.maxExp.ToString();
        ASP.text = (stat.AttackSpeed - 100).ToString() + "%";
        MSP.text = (stat.MoveSpeed - 300).ToString() + " %";
        RCH.text = stat.RecoveryHP.ToString() + " /5s";
        RCM.text = stat.RecoveryMP.ToString() + " /5s";
        Cri.text = (stat.Critical / 5).ToString() + " %";
        CriDmg.text = stat.CriticalDmg.ToString() + " %";
        DEF.text = "- " + stat.Def.ToString() + " %";
        Cool.text = "- " + stat.Cooltime.ToString() + " 초";

        itemSTR.text = "+ " + stat.ItemStr.ToString();
        itemCON.text = "+ " + stat.ItemCon.ToString();
        itemDEX.text = "+ " + stat.ItemDex.ToString();
        itemINT.text = "+ " + stat.ItemInt.ToString();
        itemLUK.text = "+ " + stat.ItemLuk.ToString();

        itemATK.text = "(+ " + stat.itemATK.ToString() + " )";
        itemmaxHP.text = "(+ " + stat.itemMaxHP.ToString() + " )";
        itemmaxMP.text = "(+ " + stat.itemMaxMP.ToString() + " )";
        itemASP.text = "(+ " + stat.itemAttackSpeed.ToString() + ")";
        itemMSP.text = "(+ " + stat.itemMoveSpeed.ToString() + ")";
        itemRCH.text = "(+ " + stat.itemRecoveryHP.ToString() + ")";
        itemRCM.text = "(+ " + stat.itemRecoveryMP.ToString() + ")";
        itemCri.text = "(+ " + (stat.itemCritical / 5).ToString() + " )";
        itemCriDmg.text = "(+ " + stat.itemCriticalDmg.ToString() + " )";
        itemDEF.text = "(- " + stat.itemDEF.ToString() + " )";
        itemCool.text = "(- " + stat.itemCooltime.ToString() + ")";

        if (stat.MoveSpeed >= 600)
        {
            itemASP.text = "(+ " + (stat.itemAttackSpeed + ((stat.itemMoveSpeed - 600) / 10)).ToString() + ")";
            itemMSP.text = "(+ " + 300 + ")";
        }
        if (stat.Def >= 99)
        {
            itemmaxHP.text = "(+ " + (stat.itemMaxHP + ((stat.itemDEF - 99) * 1000)).ToString() + ")";
            itemDEF.text = "(- " + 99 + ")";
        }
        if (stat.Critical >= 500)
        {
            itemCriDmg.text = "(+ " + (stat.itemCriticalDmg + ((stat.itemCritical + stat.ItemLuk) - 500)).ToString() + ")";
            itemCri.text = "(+ " + 100 + ")";
        }

    }

    public void Calcurate()
    {
        stat.Str = DataManager.instance.nowPlayer.Str;
        stat.Con = DataManager.instance.nowPlayer.Con;
        stat.Dex = DataManager.instance.nowPlayer.Dex;
        stat.Int = DataManager.instance.nowPlayer.Int;
        stat.Luk = DataManager.instance.nowPlayer.Luk;
        stat.Pp = DataManager.instance.nowPlayer.Pp;
        stat.Level = DataManager.instance.nowPlayer.Level;
        stat.curExp = DataManager.instance.nowPlayer.curExp;
        stat.maxExp = DataManager.instance.nowPlayer.maxExp;

        stat.minAtk = 0;
        stat.maxAtk = 0;
        stat.maxHP = 0;
        stat.maxMP = 0;
        stat.AttackSpeed = 100;
        stat.Critical = 0;
        stat.CriticalDmg = 150;
        stat.MoveSpeed = 300;
        stat.RecoveryHP = 0;
        stat.Def = 0;
        stat.Cooltime = 0;

        stat.minAtk = (stat.Str + stat.ItemStr) * 3 + stat.itemATK + _skill.SkillAttack;
        stat.maxAtk = (stat.Str + stat.ItemStr) * 4 + stat.itemATK + _skill.SkillAttack;
        stat.maxHP = (stat.Con + stat.ItemCon) * 10 + stat.itemMaxHP;
        stat.maxMP = (stat.Int + stat.ItemInt) * 5 + stat.itemMaxMP;
        stat.AttackSpeed = 100 + stat.Dex + stat.ItemDex + stat.itemAttackSpeed + _skill.SkillAttackSpeed;
        stat.Critical = stat.Luk + stat.ItemLuk + stat.itemCritical + _skill.SkillCritical;
        stat.CriticalDmg = 150 + ((stat.Str + stat.ItemStr) / 2) + stat.itemCriticalDmg;
        if (stat.Critical > 500)
        {
            stat.CriticalDmg = stat.CriticalDmg + (stat.Critical - 500);
            stat.Critical = 500;
        }

        stat.MoveSpeed = 300 + stat.itemMoveSpeed;
        if (stat.MoveSpeed > 600)
        {
            stat.AttackSpeed = stat.AttackSpeed + ((stat.itemMoveSpeed - 600) / 10);
            stat.MoveSpeed = 600;
        }
        stat.RecoveryHP = stat.Con + stat.ItemCon + stat.itemRecoveryHP;
        stat.RecoveryMP = stat.Int + stat.ItemInt; // 추후 스킬 추가
        stat.Def = stat.itemDEF;
        if (stat.Def > 98)
        {
            stat.maxHP = stat.maxHP + (stat.itemDEF - 99) * 1000;
            stat.Def = 99;
        }
        stat.Cooltime = ((stat.Int + stat.ItemInt) / 20) + stat.itemCooltime;
        DataManager.instance.nowPlayer.TotalScore = (stat.maxAtk * 2) + stat.maxHP + stat.AttackSpeed + stat.Critical + stat.CriticalDmg + stat.Def + stat.maxMP;

    }

    public void AlertClosed() // 툴팁 닫을때
    {

        AlertWindow.SetActive(false);

    }
    public void Alertopen() // 툴팁 열때
    {

        AlertWindow.SetActive(true);

    }
}
