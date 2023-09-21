using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPsystem : MonoBehaviour
{
    public Slider MPbar1;   
    public Text MPtext;
    public Text MPamountText;
    public int MPortionAmount;
    public int preAmount;
    public Stat _stat;
    public float timer;
    private void Start()
    {
        MPbar1.maxValue = _stat.maxMP;
        MPbar1.value = _stat.maxMP;
        MPtext.text = MPbar1.value.ToString() + " / " + _stat.maxMP.ToString();
        MPortionAmount = DataManager.instance.nowPlayer.ManaPotion;
        MPamountText.text = MPortionAmount.ToString();
        timer = 0f;
    }

    private void Update()
    {
        MPbar1.maxValue = _stat.maxMP;
        MPtext.text = MPbar1.value.ToString() + " / " + _stat.maxMP.ToString();
        MPamountText.text = MPortionAmount.ToString();
        MPortionAmount = DataManager.instance.nowPlayer.ManaPotion;
        _stat.curMP = (int)MPbar1.value;
        if(MPortionAmount != preAmount)
        {
            preAmount = MPortionAmount;
            DataManager.instance.SaveData();
            DataManager.instance.OnClickSaveButton();          
        }
        if(timer >= 15f)
        {
            RecoveryMP();
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void UseManaPortion()
    {
        if(MPortionAmount != 0 && MPbar1.value < MPbar1.maxValue)
        {
            MPbar1.value = MPbar1.value + Mathf.Round(MPbar1.maxValue/10);
            DataManager.instance.nowPlayer.ManaPotion--;
            
            if(MPortionAmount != preAmount)
            {
                preAmount = MPortionAmount;
                DataManager.instance.SaveData();
                DataManager.instance.OnClickSaveButton();             
            }
            _stat.curMP = (int)MPbar1.value;
        }
    }

    public void RecoveryMP()
    {        
        {
            MPbar1.value = MPbar1.value + _stat.RecoveryMP*1f;
            _stat.curMP = (int)MPbar1.value;
        }
    }
   
}

