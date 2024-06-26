using Cainos.PixelArtPlatformer_VillageProps;
using EZInventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemPuchase : MonoBehaviour
{
    public Text goldtext;
    public Text Rubytext;
    public Text Crystaltext;
    public bool isPuchase;

    public GameObject Alert;
    public Text AlertText;
    public GameObject[] buybutton;
    public GameObject protector;

    private void OnEnable()
    {
        isPuchase = true;
    }

    public void portionButtonActive()
    {
        buybutton[0].SetActive(true);
    }
    public void RubyButtonActive()
    {
        buybutton[1].SetActive(true);
    }
    public void CrystalButtonActive()
    {
        buybutton[2].SetActive(true);
    }

    public void puchasePortion()
    {
        protector.SetActive(true);
        if (isPuchase)
        {
            isPuchase = false;
            if (DataManager.instance.nowPlayer.gold >= 2000)
            {
                Alert.SetActive(true);
                AlertText.text = "구매 완료";
                DataManager.instance.nowPlayer.gold -= 2000;
                DataManager.instance.nowPlayer.ManaPotion += 5;
                DataManager.instance.nowPlayer.HealthPotion += 5;
                Textudate();
            }
            else
            {
                Alert.SetActive(true);
                AlertText.text = "골드가 부족합니다.";
            }
        }
        Invoke("isPuchasetrue", 1.0f);
        DataManager.instance.SaveData();
    }

    public void puchaseRuby()
    {
        protector.SetActive(true);
        if (isPuchase)
        {
            isPuchase = false;
            if (DataManager.instance.nowPlayer.gold >= 50000)
            {
                Alert.SetActive(true);
                AlertText.text = "구매 완료";
                DataManager.instance.nowPlayer.gold -= 50000;
                DataManager.instance.nowPlayer.RubbyPoint += 500;
                Textudate();
            }
            else
            {
                Alert.SetActive(true);
                AlertText.text = "골드가 부족합니다.";
            }
        }
        Invoke("isPuchasetrue", 1.0f);
        DataManager.instance.SaveData();

    }

    public void puchaseCrystal()
    {
        protector.SetActive(true);
        if (isPuchase)
        {
            isPuchase = false;
            if (DataManager.instance.nowPlayer.gold >= 500000)
            {
                Alert.SetActive(true);
                AlertText.text = "구매 완료";
                DataManager.instance.nowPlayer.gold -= 500000;
                DataManager.instance.nowPlayer.CrystalPoint += 50;
                Textudate();
            }
            else
            {
                Alert.SetActive(true);
                AlertText.text = "골드가 부족합니다.";
            }
        }
        Invoke("isPuchasetrue", 1.0f);
        DataManager.instance.SaveData();

    }


    public void isPuchasetrue()
    {
        isPuchase = true;
        Alert.SetActive(false);
        buybutton[0].SetActive(false);
        buybutton[1].SetActive(false);
        buybutton[2].SetActive(false);
        protector.SetActive(false);
         
        DataManager.instance.SaveData();
    }

    public void OnDisable()
    {
        Alert.SetActive(false);
        buybutton[0].SetActive(false);
        buybutton[1].SetActive(false);
        buybutton[2].SetActive(false);
        protector.SetActive(false);
         
        DataManager.instance.SaveData();
    }

    public void Textudate()
    {
        string goldFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.gold);
        goldtext.text = goldFomat;

        string RubyFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.RubbyPoint);
        Rubytext.text = RubyFomat;

        string CrystalFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.CrystalPoint);
        Crystaltext.text = CrystalFomat;
    }
}
