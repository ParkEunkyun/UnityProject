using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class Crystal30Admob : MonoBehaviour
{
    public static Crystal30Admob instance;
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

    //광고 초기화 함수
    public void InitAds()
    {
        string adUnitId;

#if UNITY_ANDROID
       //adUnitId = "ca-app-pub-3940256099942544/3347511713";
        adUnitId = "ca-app-pub-2393527128341658/2629970759";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif

        RewardedAd.Load(adUnitId, new AdRequest.Builder().Build(), LoadCallback);
    }

    //로드 콜백 함수
    public void LoadCallback(RewardedAd rewardedAd, LoadAdError loadAdError)
    {
        if (rewardedAd != null)
        {            
            this.rewardedAd = rewardedAd;
            Debug.Log("로드성공");
        }
        else
        {
            Debug.Log(loadAdError.GetMessage());
        }

    }

    //광고 보여주는 함수
    public void ShowAds2()
    {
        if (rewardedAd.CanShowAd())
        {
            rewardedAd.Show(GetReward);
        }
        else
        {
            Debug.Log("광고 재생 실패");
        }
    }
    

    //보상 함수
    public void GetReward(Reward reward)
    {        
        InitAds();        
        messageBox.SetActive(true);
        DataManager.instance.nowPlayer.CrystalPoint += 30;
        DataManager.instance.SaveData();
        gold_txt.text = "크리스탈 : 30";
    }    

    public void messageBoxfalse()
    {
        messageBox.SetActive(false);
         
        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();

    }


}