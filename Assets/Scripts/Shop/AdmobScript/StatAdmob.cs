using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class StatAdmob : MonoBehaviour
{
    public static StatAdmob instance;
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
       //adUnitId = "ca-app-pub-3940256099942544/3347511713";
        adUnitId = "ca-app-pub-2393527128341658/9924338548";
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


    //���� �Լ�
    public void GetReward(Reward reward)
    {
        InitAds();
        messageBox.SetActive(true);
        gold_txt.text = " �й谡���� ���� 1�� ȹ�� ";
    }

    public void messageBoxfalse()
    {
        messageBox.SetActive(false);
         
        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();

    }


}