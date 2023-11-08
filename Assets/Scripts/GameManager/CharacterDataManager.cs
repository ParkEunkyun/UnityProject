using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public enum Character : int
{
    Non = -1,
    Human = 0,
    Skelleton = 1,
    Elf = 2
}
public class CharacterDataManager : MonoBehaviour
{
    public static CharacterDataManager instance;
    public Character SelectedCharacter;
    public int Exp;
    public Text StrValue; public Text ConValue; public Text DexValue; public Text IntValue; public Text LukValue; public Text PPValue;
    public Text CreateName; public Text AlertText; public InputField intput;
    public bool NameCheck = false;
    public GameObject AlertWindow;
    public GameObject ChangeButton;
    public SkillObject _skill;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            return;
        }

        //DontDestroyOnLoad(gameObject);        
        DataManager.instance.nowPlayer.Str = 5;
        DataManager.instance.nowPlayer.Con = 5;
        DataManager.instance.nowPlayer.Dex = 5;
        DataManager.instance.nowPlayer.Int = 5;
        DataManager.instance.nowPlayer.Luk = 5;
        DataManager.instance.nowPlayer.Pp = 20;
        DataManager.instance.nowPlayer.Level = 0;
        DataManager.instance.nowPlayer.TotalScore = 0;
        DataManager.instance.nowPlayer.monsterKill = 0;
        DataManager.instance.nowPlayer.gold = 0;
        DataManager.instance.nowPlayer.RubbyPoint = 0;
        DataManager.instance.nowPlayer.CrystalPoint = 0;
        DataManager.instance.nowPlayer.SkillPoint = 0;
        DataManager.instance.nowPlayer.itemStr = 0;
        DataManager.instance.nowPlayer.itemCon = 0;
        DataManager.instance.nowPlayer.itemDex = 0;
        DataManager.instance.nowPlayer.itemInt = 0;
        DataManager.instance.nowPlayer.itemLuk = 0;
        DataManager.instance.nowPlayer.itemATK = 0;
        DataManager.instance.nowPlayer.itemAttackSpeed = 0;
        DataManager.instance.nowPlayer.itemCritical = 0;
        DataManager.instance.nowPlayer.itemMoveSpeed = 0;
        DataManager.instance.nowPlayer.itemCriticalDmg = 0;
        DataManager.instance.nowPlayer.itemDEF = 0;
        DataManager.instance.nowPlayer.itemCooltime = 0;
        DataManager.instance.nowPlayer.itemMaxHP = 0;
        DataManager.instance.nowPlayer.itemRecoveryHP = 0;
        DataManager.instance.nowPlayer.itemMaxMP = 0;
        DataManager.instance.nowPlayer.itemRecoveryMP = 0;
        DataManager.instance.nowPlayer.maxExp = 10;

        DataManager.instance.nowPlayer.Crystal10Time = "20231012000000";
        DataManager.instance.nowPlayer.Crystal30Time = "20231012000000";
        DataManager.instance.nowPlayer.Crystal50Time = "20231012000000";
        DataManager.instance.nowPlayer.FreeBoxTime = "20231012000000";
        DataManager.instance.nowPlayer.manaportionTime = "20231012000000";
        DataManager.instance.nowPlayer.gold500RubyTime = "20231012000000";
        DataManager.instance.nowPlayer.gold50CrystalTime = "20231012000000";
        DataManager.instance.nowPlayer.StatTime = "20231012000000";

        StrValue.text = DataManager.instance.nowPlayer.Str.ToString();
        ConValue.text = DataManager.instance.nowPlayer.Con.ToString();
        DexValue.text = DataManager.instance.nowPlayer.Dex.ToString();
        IntValue.text = DataManager.instance.nowPlayer.Int.ToString();
        LukValue.text = DataManager.instance.nowPlayer.Luk.ToString();
        PPValue.text = DataManager.instance.nowPlayer.Pp.ToString();

    }



    public void SecenChange()
    {
        DataManager.instance.nowPlayer.SelectedCharacter = (int)SelectedCharacter;

        if ((int)SelectedCharacter == 0 || (int)SelectedCharacter == 1 || (int)SelectedCharacter == 2)
        {
            if (NameCheck == true && DataManager.instance.nowPlayer.Pp == 0)
            {
                Debug.Log("오류0");
                StartSkill();
                Debug.Log("오류1");
                DataManager.instance.SaveData2();
                Debug.Log("오류2");
                DataManager.instance.OnClickSaveButton();
                Debug.Log("오류3");
                LoadingBar.LoadScene("PlayScene");
            }
            else if (NameCheck == false)
            {
                AlertWindow.SetActive(true);
                AlertText.text = "캐릭터명을 확인해주세요.";

                Debug.Log("아이디 확인");
            }
            else if (DataManager.instance.nowPlayer.Pp != 0)
            {
                AlertWindow.SetActive(true);
                AlertText.text = "남은 포인트가 있습니다.";

                Debug.Log("분배 포인트 확인");
            }

        }
        else
        {
            AlertWindow.SetActive(true);
            AlertText.text = "캐릭터를 선택해 주세요.";

            Debug.Log("캐릭터 선택");
        }
    }

    public void NameCreate()
    {
        if (DataManager.instance.nowPlayer.name == "" || DataManager.instance.nowPlayer.name == " " || DataManager.instance.nowPlayer.name == "  " || DataManager.instance.nowPlayer.name == "   " || DataManager.instance.nowPlayer.name == "    " || DataManager.instance.nowPlayer.name == "     " || DataManager.instance.nowPlayer.name == "      ")
        {
            AlertWindow.SetActive(true);
            AlertText.text = "캐릭터명을 입력해 주세요.";

        }
        else
        {
            if (DataManager.instance.nameChecking == true)
            {
                NameCheck = true;
                AlertWindow.SetActive(true);
                AlertText.text = "사용 가능한 캐릭터명입니다.";
                ChangeButton.SetActive(true);
            }
            else if (DataManager.instance.nameChecking == false)
            {
                AlertWindow.SetActive(true);
                AlertText.text = "사용중인 캐릭터명입니다.";
                DataManager.instance.nowPlayer.name = "";
            }
        }
        //Debug.Log(DataManager.instance.nowPlayer.name);
    }
    public void namechecking()
    {
        DataManager.instance.nowPlayer.name = CreateName.text;
        DataManager.instance.nicknameCheking();

        AlertWindow.SetActive(true);
        AlertText.text = "";
        StartCoroutine("ChangeImage");

        Invoke("NameCreate", 3.0f);
    }
    public void ChangeNickname()
    {
        NameCheck = false;
        DataManager.instance.nameChecking = false;
        ChangeButton.SetActive(false);
        intput.text = null;
        DataManager.instance.nowPlayer.name = "";
    }

    IEnumerator ChangeImage() // 보물상자 열리는 이펙트
    {
        for (int i = 0; i < 3; i++)
        {            
            AlertText.text = (3 - i).ToString();
            yield return new WaitForSeconds(1f);
        }
    }
    public void PlusPointSTR()
    {
        if (DataManager.instance.nowPlayer.Pp > 0) { DataManager.instance.nowPlayer.Str++; DataManager.instance.nowPlayer.Pp--; }
        StrValue.text = DataManager.instance.nowPlayer.Str.ToString();
        PPValue.text = DataManager.instance.nowPlayer.Pp.ToString();
    }
    public void PlusPointCON()
    {
        if (DataManager.instance.nowPlayer.Pp > 0) { DataManager.instance.nowPlayer.Con++; DataManager.instance.nowPlayer.Pp--; }
        ConValue.text = DataManager.instance.nowPlayer.Con.ToString();
        PPValue.text = DataManager.instance.nowPlayer.Pp.ToString();
    }
    public void PlusPointDEX()
    {
        if (DataManager.instance.nowPlayer.Pp > 0) { DataManager.instance.nowPlayer.Dex++; DataManager.instance.nowPlayer.Pp--; }
        DexValue.text = DataManager.instance.nowPlayer.Dex.ToString();
        PPValue.text = DataManager.instance.nowPlayer.Pp.ToString();
    }
    public void PlusPointINT()
    {
        if (DataManager.instance.nowPlayer.Pp > 0) { DataManager.instance.nowPlayer.Int++; DataManager.instance.nowPlayer.Pp--; }
        IntValue.text = DataManager.instance.nowPlayer.Int.ToString();
        PPValue.text = DataManager.instance.nowPlayer.Pp.ToString();
    }
    public void PlusPointLUK()
    {
        if (DataManager.instance.nowPlayer.Pp > 0) { DataManager.instance.nowPlayer.Luk++; DataManager.instance.nowPlayer.Pp--; }
        LukValue.text = DataManager.instance.nowPlayer.Luk.ToString();
        PPValue.text = DataManager.instance.nowPlayer.Pp.ToString();
    }

    public void MinusPointSTR()
    {
        if (DataManager.instance.nowPlayer.Str <= 5) { return; }
        else { DataManager.instance.nowPlayer.Str--; if (DataManager.instance.nowPlayer.Pp < 20) DataManager.instance.nowPlayer.Pp++; }
        StrValue.text = DataManager.instance.nowPlayer.Str.ToString();
        PPValue.text = DataManager.instance.nowPlayer.Pp.ToString();
    }

    public void MinusPointCON()
    {
        if (DataManager.instance.nowPlayer.Con <= 5) { return; }
        else { DataManager.instance.nowPlayer.Con--; if (DataManager.instance.nowPlayer.Pp < 20) DataManager.instance.nowPlayer.Pp++; }
        ConValue.text = DataManager.instance.nowPlayer.Con.ToString();
        PPValue.text = DataManager.instance.nowPlayer.Pp.ToString();
    }

    public void MinusPointDEX()
    {
        if (DataManager.instance.nowPlayer.Dex <= 5) { return; }
        else { DataManager.instance.nowPlayer.Dex--; if (DataManager.instance.nowPlayer.Pp < 20) DataManager.instance.nowPlayer.Pp++; }
        DexValue.text = DataManager.instance.nowPlayer.Dex.ToString();
        PPValue.text = DataManager.instance.nowPlayer.Pp.ToString();
    }

    public void MinusPointINT()
    {
        if (DataManager.instance.nowPlayer.Int <= 5) { return; }
        else { DataManager.instance.nowPlayer.Int--; if (DataManager.instance.nowPlayer.Pp < 20) DataManager.instance.nowPlayer.Pp++; }
        IntValue.text = DataManager.instance.nowPlayer.Int.ToString();
        PPValue.text = DataManager.instance.nowPlayer.Pp.ToString();
    }

    public void MinusPointLUK()
    {
        if (DataManager.instance.nowPlayer.Luk <= 5) { return; }
        else { DataManager.instance.nowPlayer.Luk--; if (DataManager.instance.nowPlayer.Pp < 20) DataManager.instance.nowPlayer.Pp++; }
        LukValue.text = DataManager.instance.nowPlayer.Luk.ToString();
        PPValue.text = DataManager.instance.nowPlayer.Pp.ToString();
    }
    public void CloseAlert()
    {
        AlertWindow.SetActive(false);
    }

    public void StartSkill()
    {
        Debug.Log("오류4");
        DataManager.instance.nowPlayer.SkillPoint = 0;

        DataManager.instance.nowPlayer.MagnetLv = 0;
        DataManager.instance.nowPlayer.MagnetCurExp = 0;
        DataManager.instance.nowPlayer.MagnetMaxExp = 10;

        DataManager.instance.nowPlayer.ViewRadiusLv = 0;
        DataManager.instance.nowPlayer.SkillViewRadius = 3;
        DataManager.instance.nowPlayer.ViewRadiusCurExp = 0;
        DataManager.instance.nowPlayer.ViewRadiusMaxExp = 10;

        DataManager.instance.nowPlayer.AttackSpeedLv = 0;
        DataManager.instance.nowPlayer.SkillAttackSpeed = 0;
        DataManager.instance.nowPlayer.AttackSpeedCurExp = 0;
        DataManager.instance.nowPlayer.AttackSpeedMaxExp = 10;

        DataManager.instance.nowPlayer.AttackLv = 0;
        DataManager.instance.nowPlayer.SkillAttack = 0;
        DataManager.instance.nowPlayer.AttackCurExp = 0;
        DataManager.instance.nowPlayer.AttackMaxExp = 10;

        DataManager.instance.nowPlayer.CriticalLv = 0;
        DataManager.instance.nowPlayer.SkillCritical = 0;
        DataManager.instance.nowPlayer.CriticalCurExp = 0;
        DataManager.instance.nowPlayer.CriticalMaxExp = 10;

        ////////////////////////////   보조 스킬
        Debug.Log("오류5");
        DataManager.instance.nowPlayer.HealLv = 0;
        DataManager.instance.nowPlayer.HealingAmount = 0;
        DataManager.instance.nowPlayer.HealCurExp = 0;
        DataManager.instance.nowPlayer.HealMaxExp = 10;
        DataManager.instance.nowPlayer.HealUseMP = 0;
        DataManager.instance.nowPlayer.HealCooltime = 0;

        DataManager.instance.nowPlayer.MoveSpeedLv = 0;
        DataManager.instance.nowPlayer.SkillMoveSpeed = 0;
        DataManager.instance.nowPlayer.MoveSpeedDuring = 0;
        DataManager.instance.nowPlayer.MoveSpeedCurExp = 0;
        DataManager.instance.nowPlayer.HMoveSpeedMaxExp = 10;
        DataManager.instance.nowPlayer.MoveSpeedUseMP = 0;
        DataManager.instance.nowPlayer.MoveSpeedCooltime = 0;

        DataManager.instance.nowPlayer.AreaSkillLv = 0;
        DataManager.instance.nowPlayer.AreaSkillDamage = 0;
        DataManager.instance.nowPlayer.AreaSkillDuring = 0;
        DataManager.instance.nowPlayer.AreaSkillCurExp = 0;
        DataManager.instance.nowPlayer.AreaSkillMaxExp = 10;
        DataManager.instance.nowPlayer.AreaSkillUseMP = 0;
        DataManager.instance.nowPlayer.AreaSkillCooltime = 0;

        DataManager.instance.nowPlayer.AroundSkillLv = 0;
        DataManager.instance.nowPlayer.AroundSkillDamage = 0;
        DataManager.instance.nowPlayer.AroundSkillDuring = 0;
        DataManager.instance.nowPlayer.AroundSkillCurExp = 0;
        DataManager.instance.nowPlayer.AroundSkillMaxExp = 10;
        DataManager.instance.nowPlayer.AroundSkillUseMP = 0;
        DataManager.instance.nowPlayer.AroundSkillCooltime = 0;

        DataManager.instance.nowPlayer.InvincibilityLv = 0;
        DataManager.instance.nowPlayer.InvincibilityDuring = 0;
        DataManager.instance.nowPlayer.InvincibilityCurExp = 0;
        DataManager.instance.nowPlayer.InvincibilityMaxExp = 10;
        DataManager.instance.nowPlayer.InvincibilityUseMP = 0;
        DataManager.instance.nowPlayer.InvincibilityCooltime = 0;

        ////////////////////////////   공격 스킬
        Debug.Log("오류6");
        DataManager.instance.nowPlayer.MultiShotLv = 0;
        DataManager.instance.nowPlayer.MultiShotDuring = 0;
        DataManager.instance.nowPlayer.MultiShotCurExp = 0;
        DataManager.instance.nowPlayer.MultiShotMaxExp = 10;
        DataManager.instance.nowPlayer.MultiShotUseMP = 0;
        DataManager.instance.nowPlayer.MultiShotCooltime = 0;

        DataManager.instance.nowPlayer.PierceShotLv = 0;
        DataManager.instance.nowPlayer.PierceShotCount = 0;
        DataManager.instance.nowPlayer.PierceShotCurExp = 0;
        DataManager.instance.nowPlayer.PierceShotMaxExp = 10;
        DataManager.instance.nowPlayer.PierceShotUseMP = 0;
        DataManager.instance.nowPlayer.PierceShotCooltime = 0;

        ////////////////////////////////////스킬 오브젝트 초기화
        Debug.Log("오류7");
        _skill.SkillPoint = DataManager.instance.nowPlayer.SkillPoint;

        _skill.MagnetLv = DataManager.instance.nowPlayer.MagnetLv;
        _skill.MagnetCurExp = DataManager.instance.nowPlayer.MagnetCurExp;
        _skill.MagnetMaxExp = DataManager.instance.nowPlayer.MagnetMaxExp;

        _skill.ViewRadiusLv = DataManager.instance.nowPlayer.ViewRadiusLv;
        _skill.SkillViewRadius = DataManager.instance.nowPlayer.SkillViewRadius;
        _skill.ViewRadiusCurExp = DataManager.instance.nowPlayer.ViewRadiusCurExp;
        _skill.ViewRadiusMaxExp = DataManager.instance.nowPlayer.ViewRadiusMaxExp;

        _skill.AttackSpeedLv = DataManager.instance.nowPlayer.AttackSpeedLv;
        _skill.SkillAttackSpeed = DataManager.instance.nowPlayer.SkillAttackSpeed;
        _skill.AttackSpeedCurExp = DataManager.instance.nowPlayer.AttackSpeedCurExp;
        _skill.AttackSpeedMaxExp = DataManager.instance.nowPlayer.AttackSpeedMaxExp;

        _skill.AttackLv = DataManager.instance.nowPlayer.AttackLv;
        _skill.SkillAttack = DataManager.instance.nowPlayer.SkillAttack;
        _skill.AttackCurExp = DataManager.instance.nowPlayer.AttackCurExp;
        _skill.AttackMaxExp = DataManager.instance.nowPlayer.AttackMaxExp;

        _skill.CriticalLv = DataManager.instance.nowPlayer.CriticalLv;
        _skill.SkillCritical = DataManager.instance.nowPlayer.SkillCritical;
        _skill.CriticalCurExp = DataManager.instance.nowPlayer.CriticalCurExp;
        _skill.CriticalMaxExp = DataManager.instance.nowPlayer.CriticalMaxExp;

        ////////////////////////////   보조 스킬
        Debug.Log("오류8");
        _skill.HealLv = DataManager.instance.nowPlayer.HealLv;
        _skill.HealingAmount = DataManager.instance.nowPlayer.HealingAmount;
        _skill.HealCurExp = DataManager.instance.nowPlayer.HealCurExp;
        _skill.HealMaxExp = DataManager.instance.nowPlayer.HealMaxExp;
        _skill.HealUseMP = DataManager.instance.nowPlayer.HealUseMP;
        _skill.HealCooltime = DataManager.instance.nowPlayer.HealCooltime;

        _skill.MoveSpeedLv = DataManager.instance.nowPlayer.MoveSpeedLv;
        _skill.SkillMoveSpeed = DataManager.instance.nowPlayer.SkillMoveSpeed;
        _skill.MoveSpeedDuring = DataManager.instance.nowPlayer.MoveSpeedDuring;
        _skill.MoveSpeedCurExp = DataManager.instance.nowPlayer.MoveSpeedCurExp;
        _skill.HMoveSpeedMaxExp = DataManager.instance.nowPlayer.HMoveSpeedMaxExp;
        _skill.MoveSpeedUseMP = DataManager.instance.nowPlayer.MoveSpeedUseMP;
        _skill.MoveSpeedCooltime = DataManager.instance.nowPlayer.MoveSpeedCooltime;

        _skill.AreaSkillLv = DataManager.instance.nowPlayer.AreaSkillLv;
        _skill.AreaSkillDamage = DataManager.instance.nowPlayer.AreaSkillDamage;
        _skill.AreaSkillDuring = DataManager.instance.nowPlayer.AreaSkillDuring;
        _skill.AreaSkillCurExp = DataManager.instance.nowPlayer.AreaSkillCurExp;
        _skill.AreaSkillMaxExp = DataManager.instance.nowPlayer.AreaSkillMaxExp;
        _skill.AreaSkillUseMP = DataManager.instance.nowPlayer.AreaSkillUseMP;
        _skill.AreaSkillCooltime = DataManager.instance.nowPlayer.AreaSkillCooltime;

        _skill.AroundSkillLv = DataManager.instance.nowPlayer.AroundSkillLv;
        _skill.AroundSkillDamage = DataManager.instance.nowPlayer.AroundSkillDamage;
        _skill.AroundSkillDuring = DataManager.instance.nowPlayer.AroundSkillDuring;
        _skill.AroundSkillCurExp = DataManager.instance.nowPlayer.AroundSkillCurExp;
        _skill.AroundSkillMaxExp = DataManager.instance.nowPlayer.AroundSkillMaxExp;
        _skill.AroundSkillUseMP = DataManager.instance.nowPlayer.AroundSkillUseMP;
        _skill.AroundSkillCooltime = DataManager.instance.nowPlayer.AroundSkillCooltime;

        _skill.InvincibilityLv = DataManager.instance.nowPlayer.InvincibilityLv;
        _skill.InvincibilityDuring = DataManager.instance.nowPlayer.InvincibilityDuring;
        _skill.InvincibilityCurExp = DataManager.instance.nowPlayer.InvincibilityCurExp;
        _skill.InvincibilityMaxExp = DataManager.instance.nowPlayer.InvincibilityMaxExp;
        _skill.InvincibilityUseMP = DataManager.instance.nowPlayer.InvincibilityUseMP;
        _skill.InvincibilityCooltime = DataManager.instance.nowPlayer.InvincibilityCooltime;

        ////////////////////////////   공격 스킬
        Debug.Log("오류9");
        _skill.MultiShotLv = DataManager.instance.nowPlayer.MultiShotLv;
        _skill.MultiShotDuring = DataManager.instance.nowPlayer.MultiShotDuring;
        _skill.MultiShotCurExp = DataManager.instance.nowPlayer.MultiShotCurExp;
        _skill.MultiShotMaxExp = DataManager.instance.nowPlayer.MultiShotMaxExp;
        _skill.MultiShotUseMP = DataManager.instance.nowPlayer.MultiShotUseMP;
        _skill.MultiShotCooltime = DataManager.instance.nowPlayer.MultiShotCooltime;

        _skill.PierceShotLv = DataManager.instance.nowPlayer.PierceShotLv;
        _skill.PierceShotCount = DataManager.instance.nowPlayer.PierceShotCount;
        _skill.PierceShotCurExp = DataManager.instance.nowPlayer.PierceShotCurExp;
        _skill.PierceShotMaxExp = DataManager.instance.nowPlayer.PierceShotMaxExp;
        _skill.PierceShotUseMP = DataManager.instance.nowPlayer.PierceShotUseMP;
        _skill.PierceShotCooltime = DataManager.instance.nowPlayer.PierceShotCooltime;

    }
}

