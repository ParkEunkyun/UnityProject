using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject MainUIwindow;
    public GameObject Statuswindow;
    public GameObject Skillwindow;
    public GameObject Activewindow;
    public GameObject Supportwindow;
    public GameObject Passivewindow;
    public GameObject Inventory2;
    public GameObject CraftingInven;
    public GameObject EquipTooltipwindow;
    public GameObject MaterialTooltipwindow;
    public GameObject inventoryTooltipwindow;
    public GameObject UnEquipBtn;
    public GameObject SellingBtn1;
    public GameObject SellingBtn2;
    public GameObject SellingBtn3;
    public GameObject DisassambleBtn1;
    public GameObject DisassambleBtn2;
    public GameObject Alret1;
    public GameObject Alret2;
    public GameObject Alret3;
    public GameObject modifyWindow;
    public GameObject RankingBoard;
    public GameObject Hamberger;
    public GameObject Xbutton;
    public GameObject getitemPop;
    bool Ranking = false;
    public GameObject testObj;
    public GameObject shop;
    public GameObject SkillPassive;
    public GameObject RecipeBook;
    public GameObject settingWindow;

    private void Start()
    {
        MainUIwindow.GetComponent<LoadImage>();
        Inventory2.SetActive(false);
        CraftingInven.SetActive(false);
        MainUIwindow.SetActive(false);
        RankingBoard.SetActive(false);
        SkillPassive.SetActive(false);
        Skillwindow.SetActive(false);
        Xbutton.SetActive(false);
        getitemPop.SetActive(false);
        shop.SetActive(false);
        Shadow();
    }

    public void MainWindowOpen()
    {
        DataManager.instance.audioSource.mute = true;
        MainUIwindow.SetActive(true);
        MainUIwindow.GetComponent<LoadImage>().Loadimage();
        testObj.SetActive(false);
    }

    public void StatusWindowOpen()
    {
        Statuswindow.SetActive(true);
        Statuswindow.GetComponent<StatusManager>().infoupdate();
    }

    public void StatusWindowClose()
    {
        Statuswindow.SetActive(false);
    }

    public void SkillWindowOpen()
    {
        Skillwindow.SetActive(true);
        //Activewindow.SetActive(true);
        //Supportwindow.SetActive(false);
        // Passivewindow.SetActive(false);
    }

    public void SkillWindowClose()
    {
        Skillwindow.SetActive(false);
        Shadow();
    }

    public void CloseAllUI()
    {
        UnEquipBtn.SetActive(false);
        SellingBtn1.SetActive(false);
        DisassambleBtn1.SetActive(false);
        SellingBtn2.SetActive(false);
        DisassambleBtn2.SetActive(false);
        SellingBtn3.SetActive(false);
        MainUIwindow.SetActive(false);
        Statuswindow.SetActive(false);
        Alret1.SetActive(false);
        Alret2.SetActive(false);
        Alret3.SetActive(false);
        EquipTooltipwindow.SetActive(false);
        inventoryTooltipwindow.SetActive(false);
        MaterialTooltipwindow.SetActive(false);
        shop.SetActive(false);
        testObj.SetActive(true);
        RecipeBook.SetActive(false);
        settingWindow.SetActive(false);
        DataManager.instance.audioSource.mute = false;
    }

    public void modifyWindowOpen()
    {
        modifyWindow.SetActive(true);
        Hamberger.SetActive(false);
        Xbutton.SetActive(true);

    }
    public void modifyWindowClose()
    {
        modifyWindow.SetActive(false);
        Xbutton.SetActive(false);
        Hamberger.SetActive(true);
    }
    public void logoutGame()
    {
        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();
        FirebaseManager.Instance.SignOut();
    }
    public void RankWindowOpne()
    {
        RankingBoard.SetActive(true);
        DataManager.instance.OnClickLoadButton();
        Invoke("myRank", 1.0f);

    }

    public Text myRanking;
    public Text myNickName;
    public Text myPower;
    public void myRank()
    {
        myNickName.text = DataManager.instance.nowPlayer.name;
        for (int i = 0; i < DataManager.instance.strRank.Length; i++)
        {
            bool contain = DataManager.instance.strRank[i].Contains(DataManager.instance.nowPlayer.UID);
            if (contain)
            {
                Debug.Log(i);
                Debug.Log(contain);
                myRanking.text = (i + 1).ToString();
                myPower.text = DataManager.instance.Comma[i];
            }

        }
    }
    public void RankWindowClose()
    {
        RankingBoard.SetActive(false);
    }

    public void TestObjOn()
    {
        testObj.SetActive(true);
    }
    public void TestObjOff()
    {
        testObj.SetActive(false);
    }

    public void openShop()
    {
        DataManager.instance.audioSource.mute = true;
        testObj.SetActive(false);
        shop.SetActive(true);
    }
    public void Back()
    {
        DataManager.instance.audioSource.volume = 0.2f;
        LoadingBar.LoadScene("SelectScene");
    }

    public void RecipeBookOpen()
    {
        RecipeBook.SetActive(true);
    }
    public void RecipeBookClose()
    {
        RecipeBook.SetActive(false);
    }

    public GameObject skillshadow1;
    public GameObject skillshadow2;
    public GameObject skillshadow3;
    public GameObject skillshadow4;

    public void Shadow()
    {
        if (DataManager.instance._skill.AreaSkillLv > 0)
        {
            skillshadow3.SetActive(false);
        }
        else
        {
            skillshadow3.SetActive(true);
        }

        if (DataManager.instance._skill.AroundSkillLv > 0)
        {
            skillshadow4.SetActive(false);
        }
        else
        {
            skillshadow4.SetActive(true);
        }

        if (DataManager.instance._skill.PierceShotLv > 0)
        {
            skillshadow2.SetActive(false);
        }
        else
        {
            skillshadow2.SetActive(true);
        }

        if (DataManager.instance._skill.MultiShotLv > 0)
        {
            skillshadow1.SetActive(false);
        }
        else
        {
            skillshadow1.SetActive(true);
        }
    }

    public void settingWindowON()
    {
        settingWindow.SetActive(true);
    }
    public void settingWindowOff()
    {
        settingWindow.SetActive(false);
    }
}
