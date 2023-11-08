using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRespawn : MonoBehaviour
{


    public Transform spawnposition;
    public GameObject boss;
    public GameObject button;
    public GameObject Alret;
    public Text AlretText;
    public void Rspawn()
    {
        if (DataManager.instance.nowPlayer.monsterKill > 999)
        {
            DataManager.instance.nowPlayer.monsterKill -= 1000;
            DataManager.instance.SaveData();
            boss.gameObject.SetActive(true);
            boss.transform.position = spawnposition.position;
            button.SetActive(false);
        }
        else
        {
            Alret.SetActive(true);
            AlretText.text = "몬스터 포인트가 부족합니다.";
            Invoke("AlretFalse", 2.0f);
        }
    }

    public void AlretFalse()
    {
        Alret.SetActive(false);
    }

}
