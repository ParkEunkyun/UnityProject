using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TipText : MonoBehaviour
{
    public Text _Text;
    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {        
        InvokeRepeating("Textupdate", 0.1f, 3.0f);
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void Textupdate()
    {
        int ran = Random.Range(0, 13);
        if (ran < 1)
        {
            _Text.text = "재료아이템을 버리면 종류에 상관없이 개당 5개의 루비를 받습니다.";
        }
        else if (ran < 2)
        {
            _Text.text = "STR 은 공격력, CON은 최대체력, DEX는 공격속도, INT는 최대마나, LUK은 치명타확률을 상승시켜줍니다.";
        }
        else if (ran < 3)
        {
            _Text.text = "제작법의 아이템 리스트는 희귀도 순서로 나열되어 있습니다.";
        }
        else if (ran < 4)
        {
            _Text.text = "각 장비아이템의 기본 능력치는 각각 다릅니다.";
        }
        else if (ran < 5)
        {
            _Text.text = "'포이즌 스모그'는 다수의 적을 상대하기 편합니다. (제작자 강추)";
        }
        else if (ran < 6)
        {
            _Text.text = "'마그넷'스킬은 아이템 획득의 편의성을 상승 시켜줍니다.(제작자 강추)";
        }
        else if (ran < 7)
        {
            _Text.text = "인벤토리와 상점에 들어가면 몬스터가 사라져, 체력과 마나회복에 도움을 줍니다.";
        }
        else if (ran < 8)
        {
            _Text.text = "중요!! 광고 시청은 제작자가 게임을 운영하는데 큰 도움이 됩니다.";
        }
        else if (ran < 9)
        {
            _Text.text = "일반 몬스터는 50 ~ 100골드, 엘리트 몬스터는 5,000골드, 보스 몬스터는 10,000골드를 드롭한다.";
        }
        else if (ran < 10)
        {
            _Text.text = "장비 강화시 특이점을 발견하면 이전 능력치의 2배(5성의 경우 3배)를 상승시켜준다.";
        }
        else if (ran < 11)
        {
            _Text.text = "마지막 강화를 성공하면 이전 능력치의 2배가 상승한다.";
        }
        else
        {
            _Text.text = "중요!! 광고 시청은 제작자가 게임을 운영하는데 큰 도움이 됩니다.";
        }

    }
}
