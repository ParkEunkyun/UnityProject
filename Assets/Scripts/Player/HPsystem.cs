using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
        if(HPortionAmount != preAmount)
        {
            preAmount = HPortionAmount;
            DataManager.instance.SaveData();
            DataManager.instance.OnClickSaveButton();          
        }
        if(timer >= 5f)
        {
            RecoveryHP();
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
        
    }
    
    
    private void OnTriggerStay2D(Collider2D other)
    {   
        Monster _monster = other.gameObject.GetComponent<Monster>();

         if(other.gameObject.tag.Equals("Enemy"))
        {
            if(HPbar1.value > 0)
            {                
                HPbar1.value = HPbar1.value - Mathf.Round(_monster.Damage-(_monster.Damage*(_stat.Def/100f)));
                Debug.Log(Mathf.Round(_monster.Damage-(_monster.Damage*(_stat.Def/100f))));
                HPbar2.value = HPbar1.value;
                HPtext.text = HPbar1.value.ToString() + " / " + _stat.maxHP.ToString();
                
            }
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
        }
    }
    public void RecoveryHP()
    {
        //if(HPbar1.value < HPbar1.maxValue)
        {
            HPbar1.value = HPbar1.value + _stat.RecoveryHP*1f;
        }
    }
}
