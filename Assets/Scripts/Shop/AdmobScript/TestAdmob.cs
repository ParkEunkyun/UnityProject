using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class TestAdmob : MonoBehaviour
{
    public static TestAdmob instance;
    private RewardedAd rewardedAd;
        
    public Text gold_txt;
    public GameObject messageBox;

    public int exp;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }       
    }

    public void Start()
    {
        InitAds();
    }

    //���� �ʱ�ȭ �Լ�
    public void InitAds()
    {
        string adUnitId;

#if UNITY_ANDROID
        //adUnitId = "ca-app-pub-3940256099942544/5224354917";
        adUnitId = "ca-app-pub-2393527128341658/6257915496";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

        RewardedAd.Load(adUnitId, new AdRequest.Builder().Build(), LoadCallback);
    }

    //�ε� �ݹ� �Լ�
    public void LoadCallback(RewardedAd rewardedAd, LoadAdError loadAdError)
    {
        if (rewardedAd != null)
        {            
            this.rewardedAd = rewardedAd;
            Debug.Log("�ε强��");
        }
        else
        {
            Debug.Log(loadAdError.GetMessage());
        }

    }

    //���� �����ִ� �Լ�
    public void ShowAds()
    {
        if (rewardedAd.CanShowAd())
        {
            rewardedAd.Show(GetReward);
        }
        else
        {
            Debug.Log("���� ��� ����");
        }
    }
    public void ShowAdss()
    {
        if (rewardedAd.CanShowAd())
        {
            rewardedAd.Show(GetRewardd);
        }
        else
        {
            Debug.Log("���� ��� ����");
        }
    }

    public void ShowAds2()
    {
        if (rewardedAd.CanShowAd())
        {
            rewardedAd.Show(GetReward2);
        }
        else
        {
            Debug.Log("���� ��� ����");
        }
    }

    public void ShowAds3()
    {
        if (rewardedAd.CanShowAd())
        {
            rewardedAd.Show(GetReward3);
        }
        else
        {
            Debug.Log("���� ��� ����");
        }
    }
    public void ShowAds4()
    {
        if (rewardedAd.CanShowAd())
        {
            rewardedAd.Show(GetReward4);
        }
        else
        {
            Debug.Log("���� ��� ����");
        }
    }

    //���� �Լ�
    public void GetReward(Reward reward)
    {        
        InitAds();        
        messageBox.SetActive(true);
        DataManager.instance.nowPlayer.CrystalPoint += 30;
        DataManager.instance.SaveData();
        gold_txt.text = "ũ����Ż : 30";
    }
    public void GetRewardd(Reward reward)
    {
        InitAds();
        messageBox.SetActive(true);
        DataManager.instance.nowPlayer.CrystalPoint += 50;
        DataManager.instance.SaveData();
        gold_txt.text = "ũ����Ż : 50";
    }
    public void GetReward2(Reward reward)
    {        
        InitAds();
    }

    public void GetReward3(Reward reward)
    {
        
        InitAds();
        messageBox.SetActive(true);
        gold_txt.text = " �й谡���� ���� 1�� ȹ�� ";
    }

    public void GetReward4(Reward reward)
    {
        DataManager.instance.nowPlayer.curExp = DataManager.instance.nowPlayer.PrecurExp;
        DataManager.instance.SaveData();
        InitAds();

        LoadingBar.LoadScene("SelectScene");
    }

    public void messageBoxfalse()
    {
        messageBox.SetActive(false);
         
        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();

    }


}