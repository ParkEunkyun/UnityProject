using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HPsystem : MonoBehaviour
{
    public Slider HPbar1;
    public Slider HPbar2;
    public Text HPtext; 
    public Text HPamountText;
    public int HPortionAmount;
    public int preAmount;
    public Stat _stat;
    Monster _monster;
    public float timer;
    public float Monstertimer;
    public bool MonsterDmg;
    public GameObject _char;
    public GameObject _ContinueWindow;
    public GameObject _monsterPool;

    public void Start()
    {
        
        HPbar1.maxValue = _stat.maxHP;
        HPbar1.value = _stat.maxHP;
        HPbar2.maxValue = HPbar1.maxValue;
        HPbar2.value = HPbar1.value;
        HPtext.text = HPbar1.value.ToString() + " / " + _stat.maxHP.ToString();
        HPortionAmount = DataManager.instance.nowPlayer.HealthPotion;
        HPamountText.text = HPortionAmount.ToString();
        timer = 0f;
    }
    private void Update()
    {
        HPbar1.maxValue = _stat.maxHP;
        HPbar2.maxValue = HPbar1.maxValue;
        HPbar2.value = HPbar1.value;
        HPtext.text = HPbar1.value.ToString() + " / " + _stat.maxHP.ToString();        
        HPamountText.text = HPortionAmount.ToString();
        HPortionAmount = DataManager.instance.nowPlayer.HealthPotion;
        _stat.curHP = (int)HPbar1.value;
        if(HPortionAmount != preAmount)
        {
            preAmount = HPortionAmount;
             
            DataManager.instance.SaveData();
            DataManager.instance.OnClickSaveButton();          
        }
        if(timer >= 10f)
        {
            RecoveryHP();
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

        Monstertimer += Time.deltaTime;
        if(Monstertimer >= 1f)
        {
            MonsterDmg = true;
        }
        
    }
    
    
    private void OnTriggerStay2D(Collider2D other)
    {   
        Monster _monster = other.gameObject.GetComponent<Monster>();
        BossMob _Boss = other.gameObject.GetComponent<BossMob>();
        RealBossMob _RealBoss = other.gameObject.GetComponent<RealBossMob>();

        if (other.gameObject.tag.Equals("Enemy") && MonsterDmg == true)
        {
            if (HPbar1.value > 0)
            {
                HPbar1.value = HPbar1.value - Mathf.Round(_monster.Damage - (_monster.Damage * (_stat.Def / 100f)));
                Debug.Log(Mathf.Round(_monster.Damage - (_monster.Damage * (_stat.Def / 100f))));
                HPbar2.value = HPbar1.value;
                HPtext.text = HPbar1.value.ToString() + " / " + _stat.maxHP.ToString();

            }
            else if (HPbar1.value <= 0)
            {
                DataManager.instance.nowPlayer.PrecurExp = _stat.curExp;
                DataManager.instance.nowPlayer.curExp = DataManager.instance.nowPlayer.curExp - (DataManager.instance.nowPlayer.curExp / 4);
                DataManager.instance.SaveData();
                
                _monsterPool.SetActive(false);
                _char.SetActive(false);
                _ContinueWindow.SetActive(true);
            }

            if (HPbar1.value <= 0)
            {
                DataManager.instance.nowPlayer.PrecurExp = _stat.curExp;
                DataManager.instance.nowPlayer.curExp = DataManager.instance.nowPlayer.curExp - (DataManager.instance.nowPlayer.curExp / 4);
                DataManager.instance.SaveData();

                _monsterPool.SetActive(false);
                _char.SetActive(false);
                _ContinueWindow.SetActive(true);
            }

            MonsterDmg = false;
            Monstertimer = 0;
        }

        else if (other.gameObject.tag.Equals("Boss") && MonsterDmg == true)
        {
            if (HPbar1.value > 0)
            {
                HPbar1.value = HPbar1.value - Mathf.Round(_Boss.Damage - (_Boss.Damage * (_stat.Def / 100f)));
                Debug.Log(Mathf.Round(_Boss.Damage - (_Boss.Damage * (_stat.Def / 100f))));
                HPbar2.value = HPbar1.value;
                HPtext.text = HPbar1.value.ToString() + " / " + _stat.maxHP.ToString();

            }
            else if (HPbar1.value <= 0)
            {
                DataManager.instance.nowPlayer.PrecurExp = _stat.curExp;
                DataManager.instance.nowPlayer.curExp = DataManager.instance.nowPlayer.curExp - (DataManager.instance.nowPlayer.curExp / 4);
                DataManager.instance.SaveData();

                _monsterPool.SetActive(false);
                _char.SetActive(false);
                _ContinueWindow.SetActive(true);
            }

            if (HPbar1.value <= 0)
            {
                DataManager.instance.nowPlayer.PrecurExp = _stat.curExp;
                DataManager.instance.nowPlayer.curExp = DataManager.instance.nowPlayer.curExp - (DataManager.instance.nowPlayer.curExp / 4);
                DataManager.instance.SaveData();

                _monsterPool.SetActive(false);
                _char.SetActive(false);
                _ContinueWindow.SetActive(true);
            }

            MonsterDmg = false;
            Monstertimer = 0;
        }
        else if (other.gameObject.tag.Equals("RealBoss") && MonsterDmg == true)
        {
            if (HPbar1.value > 0)
            {
                HPbar1.value = HPbar1.value - Mathf.Round(_RealBoss.Damage - (_RealBoss.Damage * (_stat.Def / 100f)));
                Debug.Log(Mathf.Round(_RealBoss.Damage - (_RealBoss.Damage * (_stat.Def / 100f))));
                HPbar2.value = HPbar1.value;
                HPtext.text = HPbar1.value.ToString() + " / " + _stat.maxHP.ToString();

            }
            else if (HPbar1.value <= 0)
            {
                DataManager.instance.nowPlayer.PrecurExp = _stat.curExp;
                DataManager.instance.nowPlayer.curExp = DataManager.instance.nowPlayer.curExp - (DataManager.instance.nowPlayer.curExp / 4);
                DataManager.instance.SaveData();

                _monsterPool.SetActive(false);
                _char.SetActive(false);
                _ContinueWindow.SetActive(true);
            }

            if (HPbar1.value <= 0)
            {
                DataManager.instance.nowPlayer.PrecurExp = _stat.curExp;
                DataManager.instance.nowPlayer.curExp = DataManager.instance.nowPlayer.curExp - (DataManager.instance.nowPlayer.curExp / 4);
                DataManager.instance.SaveData();

                _monsterPool.SetActive(false);
                _char.SetActive(false);
                _ContinueWindow.SetActive(true);
            }

            MonsterDmg = false;
            Monstertimer = 0;
        }
    }

    public void UseHealthPortion()
    {
        if(HPortionAmount != 0 && HPbar1.value < HPbar1.maxValue)
        {
            HPbar1.value = HPbar1.value + Mathf.Round(HPbar1.maxValue/10);
            DataManager.instance.nowPlayer.HealthPotion--;
            
            if(HPortionAmount != preAmount)
            {
                preAmount = HPortionAmount;
                 
                DataManager.instance.SaveData();
                DataManager.instance.OnClickSaveButton();             
            }       
            _stat.curHP = (int)HPbar1.value;     
        }
    }
    public void RecoveryHP()
    {
        //if(HPbar1.value < HPbar1.maxValue)
        {
            HPbar1.value = HPbar1.value + _stat.RecoveryHP*1f;
            _stat.curHP = (int)HPbar1.value;        
        }
    }
    
}
