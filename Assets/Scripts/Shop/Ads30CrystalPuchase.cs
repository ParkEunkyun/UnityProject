using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ads30CrystalPuchase : MonoBehaviour
{
    public Text goldtext;
    public Text Rubytext;
    public Text Crystaltext;    

    public bool isPuchase;
    public GameObject buttonCover; // 버튼을 어둡게 해주는 창
    public string CurrentTimeStr; // 시작시간 문자열
    public string FinishTimeStr; // 종료시간 문자열
    DateTime StartTimeDt;    // 시작시간
    DateTime EndTimeDt;   // 목표시간
    TimeSpan DelayTimeTs;   // 대기 시간
    TimeSpan CountTimeTs;   // 감소 시간
    TimeSpan RemainTimeTs;   // 남은 시간
    public Text TimeText; //화면에 노출되는 텍스트    
        
    public void OnEnable() // 저장한 시간을 불러왔을때 처리해야됨
    {
        CurrentTimeStr = DateTime.Now.ToString("yyyyMMddHHmmss");
        StartTimeDt = DateTime.ParseExact(CurrentTimeStr, "yyyyMMddHHmmss", null);

        FinishTimeStr = DataManager.instance.nowPlayer.Crystal30Time;
        EndTimeDt = DateTime.ParseExact(FinishTimeStr, "yyyyMMddHHmmss", null);

        if (EndTimeDt > DateTime.Now)
        {
            Debug.Log("활성화 함수 실행");
            buttonCover.SetActive(true);
            CountTimeTs = new TimeSpan(0, 0, 1);
            isPuchase = false;
            StartCoroutine("PuchaseCor");
        }
        else
        {
            isPuchase = true;
            buttonCover.SetActive(false);
            TimeText.text = "▶";
        }
    }

    public void Update()
    {
        if (!isPuchase && StartTimeDt >= EndTimeDt)
        {
            Debug.Log("코루틴 종료" + EndTimeDt);
            TimeText.text = "▶";
            StopCoroutine("PuchaseCor");
            buttonCover.SetActive(false);
            isPuchase = true;
        }
        Textudate();
    }
    public void Puchase() // 구매버튼 클릭 시
    {       

        if (isPuchase)
        {
            CurrentTimeStr = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            StartTimeDt = DateTime.ParseExact(CurrentTimeStr, "yyyyMMddHHmmss", null);//CultureInfo.InvariantCulture);

            Debug.Log("현재시간" + StartTimeDt);

            DelayTimeTs = new TimeSpan(0, 5, 0); // 쿨타임
            CountTimeTs = new TimeSpan(0, 0, 1);
            EndTimeDt = StartTimeDt + DelayTimeTs;            

            Debug.Log("목표시간" + EndTimeDt);

            buttonCover.SetActive(true);
            //DataManager.instance.nowPlayer.CrystalPoint += 30;
            isPuchase = false;

            CurrentTimeStr = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            FinishTimeStr = EndTimeDt.ToString("yyyyMMddHHmmss");
            DataManager.instance.nowPlayer.Crystal30Time = FinishTimeStr;            

            StartCoroutine("PuchaseCor");

            Crystal30Admob.instance.ShowAds2();

            Textudate();
        }
        else
        {
            return;
        }
    }
    IEnumerator PuchaseCor()
    {
        while (true)
        {
            StartTimeDt = StartTimeDt + CountTimeTs;
            RemainTimeTs = EndTimeDt - StartTimeDt;
            string timer = string.Format("{0:00}:{1:00}:{2:00}",
            RemainTimeTs.Hours, RemainTimeTs.Minutes, RemainTimeTs.Seconds);
            TimeText.text = timer;
            
           

            Debug.Log("코루틴" + StartTimeDt);
            yield return new WaitForSeconds(1);
        }
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
