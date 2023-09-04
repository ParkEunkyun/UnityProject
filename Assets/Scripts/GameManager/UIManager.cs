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
    bool Ranking = false;

    private void Start()
    {
        MainUIwindow.GetComponent<LoadImage>();
        Inventory2.SetActive(false);
        MainUIwindow.SetActive(false);
        RankingBoard.SetActive(false);
        Skillwindow.SetActive(false);
        Xbutton.SetActive(false);
    }    

    public void MainWindowOpen()
    {
        MainUIwindow.SetActive(true);
        MainUIwindow.GetComponent<LoadImage>().Loadimage();
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

    }
    public void RankWindowClose()
    {
        RankingBoard.SetActive(false);        
    }
}
