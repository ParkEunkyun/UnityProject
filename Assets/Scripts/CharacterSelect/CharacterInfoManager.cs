using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CharacterInfoManager : MonoBehaviour
{
    public GameObject CharInfo;
    public GameObject EmptyInfo;

    public GameObject CharacterImage;
    public Sprite[] CharacterSprite;
    public Text NickName;
    public Text Level;
    public Text[] Stat;

    public Text Power;
    public Text KillPoint;


    void Start()
    {
        if(File.Exists(DataManager.instance.PlayerPath + $"{0}") && DataManager.instance.nowPlayer.name != "")
        {
            CharInfo.SetActive(true);
            EmptyInfo.SetActive(false);
            StatLoad();
        }
        else
        {            
            CharInfo.SetActive(false);
            EmptyInfo.SetActive(true);
        }    
        
    }
    public void StatLoad()
    {
        CharacterImage.GetComponent<Image>().sprite = CharacterSprite[DataManager.instance.nowPlayer.SelectedCharacter];
        NickName.text = DataManager.instance.nowPlayer.name;
        Level.text = DataManager.instance.nowPlayer.Level.ToString();
        Power.text = DataManager.instance.nowPlayer.TotalScore.ToString();
        KillPoint.text = DataManager.instance.nowPlayer.monsterKill.ToString();

        //Èû
        Stat[0].text = DataManager.instance.nowPlayer.Str.ToString();
        Stat[1].text = DataManager.instance.nowPlayer.itemStr.ToString();

        //ÄÜ
        Stat[2].text = DataManager.instance.nowPlayer.Con.ToString();
        Stat[3].text = DataManager.instance.nowPlayer.itemCon.ToString();

        //µ¦
        Stat[4].text = DataManager.instance.nowPlayer.Dex.ToString();
        Stat[5].text = DataManager.instance.nowPlayer.itemDex.ToString();

        //ÀÎÆ®
        Stat[6].text = DataManager.instance.nowPlayer.Int.ToString();
        Stat[7].text = DataManager.instance.nowPlayer.itemInt.ToString();

        //·°
        Stat[8].text = DataManager.instance.nowPlayer.Luk.ToString();
        Stat[9].text = DataManager.instance.nowPlayer.itemLuk.ToString();
    }
}
