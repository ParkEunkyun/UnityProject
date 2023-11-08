using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{
    //public GameObject creat;	// 플레이어 닉네임 입력UI
    public Text[] slotText;		// 슬롯버튼 아래에 존재하는 Text들
    //public Text newPlayerName;	// 새로 입력된 플레이어의 닉네임

    bool[] savefile = new bool[1];	// 세이브파일 존재유무 저장

    void Start()
    {
        // 슬롯별로 저장된 데이터가 존재하는지 판단.
        //for (int i = 0; i < 1; i++)
        //{
        if (File.Exists(DataManager.instance.PlayerPath + $"{0}") && DataManager.instance.nowPlayer.name != "") // 데이터가 있는 경우
        {
            savefile[0] = true;         // 해당 슬롯 번호의 bool배열 true로 변환
            DataManager.instance.nowSlot = 0;   // 선택한 슬롯 번호 저장
            DataManager.instance.LoadData();    // 해당 슬롯 데이터 불러옴
            slotText[0].text = "시작 하기"; //DataManager.instance.nowPlayer.name;	// 버튼에 닉네임 표시
        }
        else    // 데이터가 없는 경우
        {
            slotText[0].text = "캐릭터 생성";
        }
        //}
        // 불러온 데이터를 초기화시킴.(버튼에 닉네임을 표현하기위함이었기 때문)
        //DataManager.instance.DataClear();
    }

    public void Slot(int number)	// 슬롯의 기능 구현
    {
        DataManager.instance.nowSlot = number;	// 슬롯의 번호를 슬롯번호로 입력함.

        if (savefile[number] && DataManager.instance.nowPlayer.name != "")	// bool 배열에서 현재 슬롯번호가 true라면 = 데이터 존재한다는 뜻
        {
            DataManager.instance.LoadData();	// 데이터를 로드하고
            GoGame();	// 게임씬으로 이동
        }
        else	// bool 배열에서 현재 슬롯번호가 false라면 데이터가 없다는 뜻
        {
            Creat();	// 플레이어 닉네임 입력 UI 활성화
        }
    }

    public void Creat()	// 플레이어 생성하는 메소드
    {
        if (MonsterSelect.monsterPoolIndex < 1)
        {
            LoadingBar.LoadScene("MakeScene"); // Play씬으로 이동
        }
        else if (MonsterSelect.monsterPoolIndex > 1)
        {
            if (DataManager.instance.nowPlayer.monsterKill > 999)
            {
                DataManager.instance.nowPlayer.monsterKill -= 1000;
                DataManager.instance.SaveData();
                LoadingBar.LoadScene("MakeScene");
            }
            else
            {
                Alret.SetActive(true);
                AlretText.text = "'블루슬라임' 에서만 생성 가능합니다.";
                Invoke("AlretFalse", 2.0f);
            }
        }
    }

    public GameObject Alret;
    public Text AlretText;
    public void GoGame()	// 게임씬으로 이동
    {
        if (!savefile[DataManager.instance.nowSlot])	// 현재 슬롯번호의 데이터가 없다면
        {
            //DataManager.instance.nowPlayer.name = newPlayerName.text; // 입력한 이름을 복사해옴
            DataManager.instance.SaveData();
            DataManager.instance.OnClickSaveButton(); // 현재 정보를 저장함.
        }
        if(MonsterSelect.monsterPoolIndex < 8)
        {
            LoadingBar.LoadScene("PlayScene"); // Play씬으로 이동
        }
        else if (MonsterSelect.monsterPoolIndex == 8 )
        {
            if (DataManager.instance.nowPlayer.monsterKill > 999)
            {
                DataManager.instance.nowPlayer.monsterKill -= 1000;
                DataManager.instance.SaveData();
                LoadingBar.LoadScene("PlayScene");
            }
            else
            {
                Alret.SetActive(true);
                AlretText.text = "1000 몬스터 포인트가 필요합니다.";
                Invoke("AlretFalse", 2.0f);
            }
        }
        else if (MonsterSelect.monsterPoolIndex == 9)
        {
            if (DataManager.instance.nowPlayer.monsterKill > 1999)
            {
                DataManager.instance.nowPlayer.monsterKill -= 2000;
                DataManager.instance.SaveData();
                LoadingBar.LoadScene("PlayScene");
            }
            else
            {
                Alret.SetActive(true);
                AlretText.text = "2000 몬스터 포인트가 필요합니다.";
                Invoke("AlretFalse", 2.0f);
            }
        }
    }

    public void AlretFalse()
    {
        Alret.SetActive(false);
    }
}