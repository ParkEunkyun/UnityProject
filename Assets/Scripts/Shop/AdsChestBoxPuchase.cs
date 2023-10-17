using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZInventory;
using Random = UnityEngine.Random;

public class AdsChestBoxPuchase : MonoBehaviour
{
    public Text goldtext;
    public Text Rubytext;
    public Text Crystaltext;
    public RecipeDataBase recipeData;

    public Sprite[] freeBox;

    public bool isPuchase;
    public GameObject buttonCover; // ��ư�� ��Ӱ� ���ִ� â
    public string CurrentTimeStr; // ���۽ð� ���ڿ�
    public string FinishTimeStr; // ����ð� ���ڿ�
    DateTime StartTimeDt;    // ���۽ð�
    DateTime EndTimeDt;   // ��ǥ�ð�
    TimeSpan DelayTimeTs;   // ��� �ð�
    TimeSpan CountTimeTs;   // ���� �ð�
    TimeSpan RemainTimeTs;   // ���� �ð�
    public Text TimeText; //ȭ�鿡 ����Ǵ� �ؽ�Ʈ    
        
    public void OnEnable() // ������ �ð��� �ҷ������� ó���ؾߵ�
    {
        CurrentTimeStr = DateTime.Now.ToString("yyyyMMddHHmmss");
        StartTimeDt = DateTime.ParseExact(CurrentTimeStr, "yyyyMMddHHmmss", null);

        FinishTimeStr = DataManager.instance.nowPlayer.FreeBoxTime;
        EndTimeDt = DateTime.ParseExact(FinishTimeStr, "yyyyMMddHHmmss", null);

        if (EndTimeDt > DateTime.Now)
        {
            Debug.Log("Ȱ��ȭ �Լ� ����");
            buttonCover.SetActive(true);
            CountTimeTs = new TimeSpan(0, 0, 1);
            isPuchase = false;
            StartCoroutine("PuchaseCor");
        }
        else
        {
            isPuchase = true;
            buttonCover.SetActive(false);
            TimeText.text = "��";
        }
    }

    public void Update()
    {
        if (!isPuchase && StartTimeDt >= EndTimeDt)
        {
            Debug.Log("�ڷ�ƾ ����" + EndTimeDt);
            TimeText.text = "��";
            StopCoroutine("PuchaseCor");
            buttonCover.SetActive(false);
            isPuchase = true;
        }
        Textudate();
    }
    public void Puchase() // ���Ź�ư Ŭ�� ��
    {
        if (isPuchase)
        {
            CurrentTimeStr = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            StartTimeDt = DateTime.ParseExact(CurrentTimeStr, "yyyyMMddHHmmss", null);//CultureInfo.InvariantCulture);

            Debug.Log("����ð�" + StartTimeDt);

            DelayTimeTs = new TimeSpan(0, 5, 0); // ��Ÿ��
            CountTimeTs = new TimeSpan(0, 0, 1);
            EndTimeDt = StartTimeDt + DelayTimeTs;            

            Debug.Log("��ǥ�ð�" + EndTimeDt);

            buttonCover.SetActive(true);

            int ran = Random.Range(0, 2);
            ItemSO item = recipeData.RecipeItem[ran];
            EZInventory.InventoryManager.instance.AddItemToInventory(item, 1);

            isPuchase = false;

            CurrentTimeStr = System.DateTime.Now.ToString("yyyyMMddHHmmss");
            FinishTimeStr = EndTimeDt.ToString("yyyyMMddHHmmss");
            DataManager.instance.nowPlayer.FreeBoxTime = FinishTimeStr;

            Textudate();

            StartCoroutine("PuchaseCor");
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
            
           

            Debug.Log("�ڷ�ƾ" + StartTimeDt);
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
