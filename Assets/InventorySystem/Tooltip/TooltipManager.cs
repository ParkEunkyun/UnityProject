using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{

    public GameObject Tooltip;
    public Text ItemName;
    public Image ItemIcon;
    public InventoryObject Inven;
    public InventoryObject EquipInven;
    public InventoryObject TempInven;
    public Text option1; public Text option2; public Text option3; public Text option4; public Text option5; public Text option6;
    public GameObject Starforce;
    public GameObject Specialforce1; public GameObject Specialforce2; public GameObject Specialforce3;
    public GameObject Specialforce4; public GameObject Specialforce5;
    public int star;
    public int specialstar;
    public int ItemTypeNumber;
    public int id;
    public Stat stat;
    public GameObject UnEquipBtn;
    public GameObject SellingBtn;
    public Text Sellingprice; string sellingFormat; // 판매 가격
    public GameObject DisassambleBtn;
    public Text GetRubbyPoint; string getRubbyFormat; // 분해 시 획득 포인트    
    public Text disassamblePrice; string disassambleFormat;// 분해 비용
    public Text goldinfoamount;  // 소지 골드
    public Text RubbyPoint;  // 소지 포인트
    public Text CrystalPoint; 
    public Text EnhanceRubbypoint; string EnhanceRubbypointFormat;//강화 시 사용 포인트
    public Text Enhancegold; string EnhancegoldFormat;// 강화시 사용 골드
    public GameObject EnhanceBtn;
    public GameObject AlertWindow;
    public Text AlertText;
    public Slider MaterialAmount;
    public Text MaterialAmountText;
    public int materialvalue;
    //WeaponChange _weaponchange;
    //public int PartNum;
    public GameObject QuestionMarkAlert;

    private AudioSource audioSource;
    public void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void slotClick() //인벤토리 슬롯 선택
    {
        id = Inven.Slots[ParentMathod.SlotNumber].item.id;
        if (id != -1)
        {
            Tooltip.SetActive(true);
            //PartNum = Inven.Slots[ParentMathod.SlotNumber].item.partNum;
            star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
            specialstar = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value;
            ItemTypeNumber = ((int)Inven.Slots[ParentMathod.SlotNumber].ItemObject.type);
            ItemName.GetComponent<Text>().text = Inven.Slots[ParentMathod.SlotNumber].ItemObject.data.name;
            ItemIcon.GetComponent<Image>().sprite = Inven.Slots[ParentMathod.SlotNumber].ItemObject.icon;
            ItemIcon.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            optionTostring();
            StarforceReset();
            StarForceActive();
            specialstarAtiveReset();
            specialstarAtive();
        }
    }

    public void EquipslotClick() //장비창 슬롯 선택
    {
        id = Inven.Slots[ParentMathod.SlotNumber].item.id;
        if (id != -1)
        {
            Tooltip.SetActive(true);
            UnEquipBtn.SetActive(true);
            //PartNum = Inven.Slots[ParentMathod.SlotNumber].item.partNum;
            star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
            specialstar = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value;
            ItemTypeNumber = ((int)Inven.Slots[ParentMathod.SlotNumber].ItemObject.type);
            ItemName.GetComponent<Text>().text = Inven.Slots[ParentMathod.SlotNumber].ItemObject.data.name;
            ItemIcon.GetComponent<Image>().sprite = Inven.Slots[ParentMathod.SlotNumber].ItemObject.icon;
            ItemIcon.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            optionTostring();
            StarforceReset();
            StarForceActive();
            specialstarAtiveReset();
            specialstarAtive();
        }
    }
    public void MaterialslotClick() //인벤토리 슬롯 선택
    {
        id = Inven.Slots[ParentMathod.SlotNumber].item.id;
        if (id != -1)
        {
            Tooltip.SetActive(true);
            //PartNum = Inven.Slots[ParentMathod.SlotNumber].item.partNum;
            MaterialAmount.maxValue = Inven.Slots[ParentMathod.SlotNumber].amount;
            ItemTypeNumber = ((int)Inven.Slots[ParentMathod.SlotNumber].ItemObject.type);
            ItemName.GetComponent<Text>().text = Inven.Slots[ParentMathod.SlotNumber].ItemObject.data.name;
            ItemIcon.GetComponent<Image>().sprite = Inven.Slots[ParentMathod.SlotNumber].ItemObject.icon;
            ItemIcon.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            option1.GetComponent<Text>().text = Inven.database.itemObjects[id].description;
        }
    }

    public void Closed() // 툴팁 닫을때
    {
        //DataManager.instance.EXPandHP();
        Tooltip.SetActive(false);
        UnEquipBtn.SetActive(false);
        SellingBtn.SetActive(false);
        AlertWindow.SetActive(false);
        DisassambleBtn.SetActive(false);
        EnhanceBtn.SetActive(false);
        QuestionMarkAlert.SetActive(false);
        ItemIcon.GetComponent<Image>().sprite = null;
        ItemIcon.GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }
    public void optionTostring() //툴팁 옵션 노출
    {
        option1.GetComponent<Text>().text = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].stat.ToString() + " +" + Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value.ToString();
        option2.GetComponent<Text>().text = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].stat.ToString() + " +" + Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value.ToString();
        option3.GetComponent<Text>().text = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].stat.ToString() + " +" + Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value.ToString();
        option4.GetComponent<Text>().text = Inven.Slots[ParentMathod.SlotNumber].item.buffs[8].stat.ToString() + " +" + Inven.Slots[ParentMathod.SlotNumber].item.buffs[8].value.ToString();
        option5.GetComponent<Text>().text = Inven.Slots[ParentMathod.SlotNumber].item.buffs[9].stat.ToString() + " +" + Inven.Slots[ParentMathod.SlotNumber].item.buffs[9].value.ToString();
        option6.GetComponent<Text>().text = Inven.Slots[ParentMathod.SlotNumber].item.buffs[10].stat.ToString() + " +" + Inven.Slots[ParentMathod.SlotNumber].item.buffs[10].value.ToString();

        if ((int)Inven.Slots[ParentMathod.SlotNumber].item.buffs[8].stat == 23)
        {
            option4.GetComponent<Text>().text = "";
        }

        if ((int)Inven.Slots[ParentMathod.SlotNumber].item.buffs[9].stat == 23)
        {
            option5.GetComponent<Text>().text = "";
        }

        if ((int)Inven.Slots[ParentMathod.SlotNumber].item.buffs[10].stat == 23)
        {
            option6.GetComponent<Text>().text = "";
        }
    }    
    public void StarForceActive() //스타포스 활성화
    {

        if (star == 1)
        {
            Starforce.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        if (star == 2)
        {
            Starforce.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            Starforce.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        }
        if (star == 3)
        {
            Starforce.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            Starforce.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            Starforce.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
        }
        if (star == 4)
        {
            Starforce.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            Starforce.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            Starforce.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            Starforce.transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
        }
        if (star == 5)
        {
            Starforce.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            Starforce.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            Starforce.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
            Starforce.transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
            Starforce.transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
        }
    }
    public void StarforceReset() //스타포스 리셋할때
    {
        Starforce.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        Starforce.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        Starforce.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        Starforce.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        Starforce.transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
    }
    public void EuquipButton() // 인벤토리 기준 Iven : 인벤토리 툴팁에서 장착버튼 클릭 할 떄
    {
        //_weaponchange = GameObject.Find("BulletPool").GetComponent<WeaponChange>();
        Item oldItem = EquipInven.Slots[ItemTypeNumber].item;
        TempInven.Slots[ItemTypeNumber].AddItem(oldItem, 1);
        Item newItem = Inven.Slots[ParentMathod.SlotNumber].item;
        EquipInven.Slots[ItemTypeNumber].AddItem(newItem, 1);
        Inven.Slots[ParentMathod.SlotNumber].RemoveItem();
        Item tempItem = TempInven.Slots[ItemTypeNumber].item;
        Inven.Slots[ParentMathod.SlotNumber].AddItem(tempItem, 1);
        EquipStatReset();
        EquipStatPlus();
        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();
        Closed();
    }
    public void UnEuquipButton() // 장비창 기준 Inven : 장비창 툴팁에서 해제버튼 클릭 할 떄
    {
        if (TempInven.EmptySlotCount > 0)
        {
            //_weaponchange = GameObject.Find("BulletPool").GetComponent<WeaponChange>();
            Item EquipItem = Inven.Slots[ParentMathod.SlotNumber].item;
            TempInven.AddItem(EquipItem, 1);
            Inven.Slots[ParentMathod.SlotNumber].RemoveItem();
            //if(ParentMathod.SlotNumber == 1) {_weaponchange.Itemcode50000();}
            EquipStatReset();
            EquipStatPlus2();
            DataManager.instance.SaveData();
            DataManager.instance.OnClickSaveButton();
            Closed();
        }
    }
    public void SellButtonActive() // 툴팁에서 판매버튼 클릭 했을 떄
    {
        SellingBtn.SetActive(true);
        sellingFormat = string.Format("{0:#,0}", (Inven.Slots[ParentMathod.SlotNumber].item.buffs[4].value * (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value + 1)));
        Sellingprice.text = "        +" + sellingFormat;
    }
    public void DisassambleButtonActive() // 툴팁에서 분해버튼 클릭 했을 떄
    {
        DisassambleBtn.SetActive(true);
        getRubbyFormat = string.Format("{0:#,0}", (Inven.Slots[ParentMathod.SlotNumber].item.buffs[6].value * (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value + 1)));
        GetRubbyPoint.text = "         +" + getRubbyFormat;
        disassambleFormat = string.Format("{0:#,0}", (Inven.Slots[ParentMathod.SlotNumber].item.buffs[4].value / 2));
        disassamblePrice.text = "         - " + disassambleFormat;
    }
    public void EnhanceButtonActive()  // 툴팁에서 강화버튼 클릭 했을 떄
    {
        if (Inven.Slots[ParentMathod.SlotNumber].item.id != -1)
        {
            EnhanceBtn.SetActive(true);
            EnhanceRubbypointFormat = string.Format("{0:#,0}", (Inven.Slots[ParentMathod.SlotNumber].item.buffs[5].value * (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value + 1)));
            EnhanceRubbypoint.text = "         - " + EnhanceRubbypointFormat;
            EnhancegoldFormat = string.Format("{0:#,0}", (Inven.Slots[ParentMathod.SlotNumber].item.buffs[4].value / 2));
            Enhancegold.text = "         - " + EnhancegoldFormat;
        }
    }
    public void SellAction()  // 툴팁에서 판매버튼 누르고 최종 판매 할떄
    {

        DataManager.instance.nowPlayer.gold = DataManager.instance.nowPlayer.gold + (Inven.Slots[ParentMathod.SlotNumber].item.buffs[4].value * (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value + 1));
        Textudate();
        Inven.Slots[ParentMathod.SlotNumber].RemoveItem();
        EquipStatReset();
        if ((int)Inven.type == 1) { EquipStatPlus2(); }
        else if ((int)Inven.type == 0) { EquipStatPlus(); }
        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();
        Closed();
    }
    public void disasaambleAction()  //툴팁에서 분해버튼 누르고 최종 분해 할떄
    {
        if (DataManager.instance.nowPlayer.gold > (Inven.Slots[ParentMathod.SlotNumber].item.buffs[4].value / 2))
        {
            DataManager.instance.nowPlayer.RubbyPoint = DataManager.instance.nowPlayer.RubbyPoint + (Inven.Slots[ParentMathod.SlotNumber].item.buffs[6].value * (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value + 1));
            DataManager.instance.nowPlayer.gold = DataManager.instance.nowPlayer.gold - (Inven.Slots[ParentMathod.SlotNumber].item.buffs[4].value / 2);
            Textudate();
            Inven.Slots[ParentMathod.SlotNumber].RemoveItem();
            EquipStatReset();
            if ((int)Inven.type == 1) { EquipStatPlus2(); }
            else if ((int)Inven.type == 0) { EquipStatPlus(); }
            DataManager.instance.SaveData();
            DataManager.instance.OnClickSaveButton();
            Closed();
        }
        else
        {
            AlertWindow.SetActive(true);
            AlertText.text = "골드가 부족합니다.";
        }
    }
    public void EnhanceAction() //툴팁에서 강화버튼 누르고 최종 강화 할떄
    {
        if (DataManager.instance.nowPlayer.RubbyPoint >= (Inven.Slots[ParentMathod.SlotNumber].item.buffs[5].value * (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value + 1))
        && Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value < 5 && DataManager.instance.nowPlayer.gold >= (Inven.Slots[ParentMathod.SlotNumber].item.buffs[4].value / 2))
        {


            EnforceEffect.SetActive(true);

            StartCoroutine("ChangeImage");

            Invoke("EnforceEffectFalse", 2.0f);

            DataManager.instance.nowPlayer.RubbyPoint = DataManager.instance.nowPlayer.RubbyPoint - (Inven.Slots[ParentMathod.SlotNumber].item.buffs[5].value * (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value + 1));
            DataManager.instance.nowPlayer.gold = DataManager.instance.nowPlayer.gold - (Inven.Slots[ParentMathod.SlotNumber].item.buffs[4].value / 2);
            Textudate();

            if (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value < 1)
            {
                int ran = Random.Range(0, 106);
                if (ran < 61)
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value++;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화에 성공하였습니다.";

                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value + 2;
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value + 1;

                    if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value + 10;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value + 1;
                    }
                    optionTostring();
                }
                else if (ran < 96)
                {
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화에 실패하였습니다.";
                    optionTostring();
                }
                else if (ran < 101)
                {
                    Inven.Slots[ParentMathod.SlotNumber].RemoveItem();
                    Closed();
                    AlertWindow.SetActive(true);
                    AlertText.text = "장비가 파괴되었습니다.";
                }
                else // 3%
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value++;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "장비의 특이점을 발견했습니다.";

                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value * 2;
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value * 2;

                    if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value * 2;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value * 2;
                    }
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value + 10000;
                    specialstar = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value;

                    optionTostring();
                }
            }
            else if (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value < 2)
            {
                int ran = Random.Range(0, 106);
                if (ran < 51)
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value++;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화에 성공하였습니다.";

                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value + 2;
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value + 1;

                    if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value + 20;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value + 2;
                    }
                }
                else if (ran < 91)
                {
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화에 실패하였습니다.";
                }
                else if (ran < 101)
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value--;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화가 하락하였습니다.";

                    if ((specialstar % 100000) / 10000 == 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value / 2;
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value / 2;

                        if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value / 2;
                        }
                        else
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value / 2;
                        }
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value - 10000;
                        specialstar = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value - 2;
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value - 1;

                        if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value - 10;
                        }
                        else
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value - 1;
                        }
                    }

                }
                else
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value++;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "장비의 특이점을 발견했습니다.";

                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value * 2;
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value * 2;

                    if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value * 2;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value * 2;
                    }
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value + 1000;
                    specialstar = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value;
                }
                optionTostring();
            }
            else if (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value < 3)
            {
                int ran = Random.Range(0, 106);
                if (ran < 41)
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value++;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화에 성공하였습니다.";

                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value + 2;
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value + 1;

                    if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value + 40;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value + 4;
                    }
                }
                else if (ran < 81)
                {
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화에 실패하였습니다.";
                }
                else if (ran < 101)
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value--;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화가 하락하였습니다.";

                    if ((specialstar % 10000) / 1000 == 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value / 2;
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value / 2;

                        if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value / 2;
                        }
                        else
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value / 2;
                        }
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value - 1000;
                        specialstar = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value - 2;
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value - 1;

                        if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value - 20;
                        }
                        else
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value - 2;
                        }
                    }
                }
                else // 1%
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value++;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "장비의 특이점을 발견했습니다.";

                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value * 2;
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value * 2;

                    if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value * 2;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value * 2;
                    }

                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value + 100;
                    specialstar = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value;
                }
                optionTostring();
            }
            else if (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value < 4)
            {
                int ran = Random.Range(0, 106);
                if (ran < 31)
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value++;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화에 성공하였습니다.";

                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value + 2;
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value + 1;

                    if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value + 80;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value + 8;
                    }
                }
                else if (ran < 71)
                {
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화에 실패하였습니다.";
                }
                else if (ran < 101)
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value--;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화가 하락하였습니다.";

                    if ((specialstar % 1000) / 100 == 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value / 2;
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value / 2;

                        if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value / 2;
                        }
                        else
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value / 2;
                        }
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value - 100;
                        specialstar = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value - 2;
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value - 1;

                        if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value - 40;
                        }
                        else
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value - 4;
                        }
                    }

                }
                else // 1%
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value++;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "장비의 특이점을 발견했습니다.";

                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value * 2;
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value * 2;

                    if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value * 2;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value * 2;
                    }
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value + 10;
                    specialstar = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value;

                }
                optionTostring();
            }

            else if (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value < 5)
            {
                int ran = Random.Range(0, 106);
                if (ran < 21)
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value++;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화에 성공하였습니다.";

                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value * 2;
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value * 2;

                    if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value * 2;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value * 2;
                    }
                }
                else if (ran < 61)
                {
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화에 실패하였습니다.";
                }
                else if (ran < 101)
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value--;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "강화가 하락하였습니다.";

                    if ((specialstar % 100) / 10 == 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value / 2;
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value / 2;

                        if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value / 2;
                        }
                        else
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value / 2;
                        }
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value - 10;
                        specialstar = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value - 2;
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value - 1;

                        if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value - 80;
                        }
                        else
                        {
                            Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value - 8;
                        }
                    }
                }
                else
                {
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value++;
                    star = Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value;
                    AlertWindow.SetActive(true);
                    AlertText.text = "장비의 특이점을 발견했습니다.";

                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[1].value * 3;
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[2].value * 3;

                    if (ItemTypeNumber != 3)//Inven.Slots[ParentMathod.SlotNumber].item.id != 1)
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value * 3;
                    }
                    else
                    {
                        Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[3].value * 3;
                    }
                    Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value + 1;
                    specialstar = Inven.Slots[ParentMathod.SlotNumber].item.buffs[7].value;

                }
                optionTostring();
            }


        }
        else if (DataManager.instance.nowPlayer.gold < (Inven.Slots[ParentMathod.SlotNumber].item.buffs[4].value / 2))
        {

            AlertWindow.SetActive(true);
            AlertText.text = "골드가 부족합니다.";

        }
        else if (DataManager.instance.nowPlayer.RubbyPoint < (Inven.Slots[ParentMathod.SlotNumber].item.buffs[5].value * (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value + 1)))
        {

            AlertWindow.SetActive(true);
            AlertText.text = "포인트가 부족합니다.";

        }
        else if (Inven.Slots[ParentMathod.SlotNumber].item.buffs[0].value >= 5)
        {

            AlertWindow.SetActive(true);
            AlertText.text = "최대 강화 수치입니다.";

        }


        StarforceReset();
        StarForceActive();
        specialstarAtiveReset();
        specialstarAtive();
        EnhanceButtonActive();
        EquipStatReset();
        if ((int)Inven.type == 1) { EquipStatPlus2(); }
        else if ((int)Inven.type == 0) { EquipStatPlus(); }
        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();
        //Closed();
    }
    public void CloseAlert()  //알럿창 닫을 때
    {
        EnhanceBtn.SetActive(false);
        DisassambleBtn.SetActive(false);
        AlertWindow.SetActive(false);
    }
    public void EquipStatPlus() // 인벤토리 기준 장착 할 때 스탯 적용
    {
        if (EquipInven.Slots[1].item.id != -1 && EquipInven.Slots[3].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemStr += EquipInven.Slots[1].item.buffs[1].value + EquipInven.Slots[3].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemATK += EquipInven.Slots[1].item.buffs[3].value + EquipInven.Slots[1].item.buffs[10].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += EquipInven.Slots[1].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCriticalDmg += EquipInven.Slots[1].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemDEF += EquipInven.Slots[3].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemMaxHP += EquipInven.Slots[3].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += EquipInven.Slots[3].item.buffs[9].value;
        }
        else if (EquipInven.Slots[1].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemStr += EquipInven.Slots[1].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemATK += EquipInven.Slots[1].item.buffs[3].value + EquipInven.Slots[1].item.buffs[10].value; ;
            DataManager.instance.nowPlayer.itemAttackSpeed += EquipInven.Slots[1].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCriticalDmg += EquipInven.Slots[1].item.buffs[9].value;
        }
        else if (EquipInven.Slots[3].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemStr += EquipInven.Slots[3].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemDEF += EquipInven.Slots[3].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemMaxHP += EquipInven.Slots[3].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += EquipInven.Slots[3].item.buffs[9].value;
        }

        if (EquipInven.Slots[3].item.id != -1 && EquipInven.Slots[0].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemCon += EquipInven.Slots[3].item.buffs[1].value + EquipInven.Slots[0].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemDEF += EquipInven.Slots[3].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemMaxHP += EquipInven.Slots[3].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += EquipInven.Slots[3].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += EquipInven.Slots[0].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemCooltime += EquipInven.Slots[0].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemMaxMP += EquipInven.Slots[0].item.buffs[8].value;
        }
        else if (EquipInven.Slots[3].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemCon += EquipInven.Slots[3].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemDEF += EquipInven.Slots[3].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemMaxHP += EquipInven.Slots[3].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += EquipInven.Slots[3].item.buffs[9].value;
        }
        else if (EquipInven.Slots[0].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemCon += EquipInven.Slots[0].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += EquipInven.Slots[0].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemCooltime += EquipInven.Slots[0].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemMaxMP += EquipInven.Slots[0].item.buffs[8].value;
        }

        if (EquipInven.Slots[1].item.id != -1 && EquipInven.Slots[2].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemDex += EquipInven.Slots[1].item.buffs[2].value + EquipInven.Slots[2].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemATK += EquipInven.Slots[1].item.buffs[3].value + EquipInven.Slots[2].item.buffs[3].value + EquipInven.Slots[1].item.buffs[10].value; ;
            DataManager.instance.nowPlayer.itemAttackSpeed += EquipInven.Slots[1].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCriticalDmg += EquipInven.Slots[1].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += EquipInven.Slots[2].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCritical += EquipInven.Slots[2].item.buffs[9].value;
        }
        else if (EquipInven.Slots[1].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemDex += EquipInven.Slots[1].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemATK += EquipInven.Slots[1].item.buffs[3].value + EquipInven.Slots[1].item.buffs[10].value; ;
            DataManager.instance.nowPlayer.itemAttackSpeed += EquipInven.Slots[1].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCriticalDmg += EquipInven.Slots[1].item.buffs[9].value;
        }
        else if (EquipInven.Slots[2].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemDex += EquipInven.Slots[2].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemATK += EquipInven.Slots[2].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += EquipInven.Slots[2].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCritical += EquipInven.Slots[2].item.buffs[9].value;
        }

        if (EquipInven.Slots[0].item.id != -1 && EquipInven.Slots[4].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemInt += EquipInven.Slots[0].item.buffs[1].value + EquipInven.Slots[4].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += EquipInven.Slots[0].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemCooltime += EquipInven.Slots[0].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemMaxMP += EquipInven.Slots[0].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemMoveSpeed += EquipInven.Slots[4].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += EquipInven.Slots[4].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemCritical += EquipInven.Slots[4].item.buffs[8].value;
        }
        else if (EquipInven.Slots[0].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemInt += EquipInven.Slots[0].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += EquipInven.Slots[0].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemCooltime += EquipInven.Slots[0].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemMaxMP += EquipInven.Slots[0].item.buffs[8].value;
        }
        else if (EquipInven.Slots[4].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemInt += EquipInven.Slots[4].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemMoveSpeed += EquipInven.Slots[4].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += EquipInven.Slots[4].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemCritical += EquipInven.Slots[4].item.buffs[8].value;
        }

        if (EquipInven.Slots[2].item.id != -1 && EquipInven.Slots[4].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemLuk += EquipInven.Slots[2].item.buffs[2].value + EquipInven.Slots[4].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemATK += EquipInven.Slots[2].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += EquipInven.Slots[2].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCritical += EquipInven.Slots[2].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemMoveSpeed += EquipInven.Slots[4].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += EquipInven.Slots[4].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemCritical += EquipInven.Slots[4].item.buffs[8].value;
        }
        else if (EquipInven.Slots[2].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemLuk += EquipInven.Slots[2].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemATK += EquipInven.Slots[2].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += EquipInven.Slots[2].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCritical += EquipInven.Slots[2].item.buffs[9].value;
        }
        else if (EquipInven.Slots[4].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemLuk += EquipInven.Slots[4].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemMoveSpeed += EquipInven.Slots[4].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += EquipInven.Slots[4].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemCritical += EquipInven.Slots[4].item.buffs[8].value;
        }

        DataManager.instance.nowPlayer.itemATK = DataManager.instance.nowPlayer.itemATK / 2;
        DataManager.instance.nowPlayer.itemMoveSpeed = DataManager.instance.nowPlayer.itemMoveSpeed / 2;
        DataManager.instance.nowPlayer.itemRecoveryHP = DataManager.instance.nowPlayer.itemRecoveryHP / 2;
        DataManager.instance.nowPlayer.itemCriticalDmg = DataManager.instance.nowPlayer.itemCriticalDmg / 2;
        DataManager.instance.nowPlayer.itemDEF = DataManager.instance.nowPlayer.itemDEF / 2;
        DataManager.instance.nowPlayer.itemMaxHP = DataManager.instance.nowPlayer.itemMaxHP / 2;
        DataManager.instance.nowPlayer.itemMaxMP = DataManager.instance.nowPlayer.itemMaxMP / 2;
        DataManager.instance.nowPlayer.itemAttackSpeed = DataManager.instance.nowPlayer.itemAttackSpeed / 2;
        DataManager.instance.nowPlayer.itemCooltime = DataManager.instance.nowPlayer.itemCooltime / 2;
        DataManager.instance.nowPlayer.itemCritical = DataManager.instance.nowPlayer.itemCritical / 2;

        //DataManager.instance.EXPandHP();
        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();

        StatOverWrite();
    }
    public void EquipStatReset()  // 스탯 초기화
    {

        DataManager.instance.nowPlayer.itemStr = 0;
        DataManager.instance.nowPlayer.itemCon = 0;
        DataManager.instance.nowPlayer.itemDex = 0;
        DataManager.instance.nowPlayer.itemInt = 0;
        DataManager.instance.nowPlayer.itemLuk = 0;
        DataManager.instance.nowPlayer.itemATK = 0;
        DataManager.instance.nowPlayer.itemMoveSpeed = 0;
        DataManager.instance.nowPlayer.itemRecoveryHP = 0;
        DataManager.instance.nowPlayer.itemCriticalDmg = 0;
        DataManager.instance.nowPlayer.itemDEF = 0;
        DataManager.instance.nowPlayer.itemMaxHP = 0;
        DataManager.instance.nowPlayer.itemMaxMP = 0;
        DataManager.instance.nowPlayer.itemAttackSpeed = 0;
        DataManager.instance.nowPlayer.itemCooltime = 0;
        DataManager.instance.nowPlayer.itemCritical = 0;

        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();

        StatOverWrite();
    }
    public void EquipStatPlus2() // 장비창 기준 장착 해제 할 때 스탯 적용
    {
        if (Inven.Slots[1].item.id != -1 && Inven.Slots[3].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemStr += Inven.Slots[1].item.buffs[1].value + Inven.Slots[3].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemATK += Inven.Slots[1].item.buffs[3].value + EquipInven.Slots[1].item.buffs[10].value; ;
            DataManager.instance.nowPlayer.itemAttackSpeed += Inven.Slots[1].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCriticalDmg += Inven.Slots[1].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemDEF += Inven.Slots[3].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemMaxHP += Inven.Slots[3].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += Inven.Slots[3].item.buffs[9].value;
        }
        else if (Inven.Slots[1].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemStr += Inven.Slots[1].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemATK += Inven.Slots[1].item.buffs[3].value + EquipInven.Slots[1].item.buffs[10].value; ;
            DataManager.instance.nowPlayer.itemAttackSpeed += Inven.Slots[1].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCriticalDmg += Inven.Slots[1].item.buffs[9].value;
        }
        else if (Inven.Slots[3].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemStr += Inven.Slots[3].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemDEF += Inven.Slots[3].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemMaxHP += Inven.Slots[3].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += Inven.Slots[3].item.buffs[9].value;
        }

        if (Inven.Slots[3].item.id != -1 && Inven.Slots[0].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemCon += Inven.Slots[3].item.buffs[1].value + Inven.Slots[0].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemDEF += Inven.Slots[3].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemMaxHP += Inven.Slots[3].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += Inven.Slots[3].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += Inven.Slots[0].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemCooltime += Inven.Slots[0].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemMaxMP += Inven.Slots[0].item.buffs[8].value;
        }
        else if (Inven.Slots[3].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemCon += Inven.Slots[3].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemDEF += Inven.Slots[3].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemMaxHP += Inven.Slots[3].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += Inven.Slots[3].item.buffs[9].value;
        }
        else if (Inven.Slots[0].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemCon += Inven.Slots[0].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += Inven.Slots[0].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemCooltime += Inven.Slots[0].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemMaxMP += Inven.Slots[0].item.buffs[8].value;
        }

        if (Inven.Slots[1].item.id != -1 && Inven.Slots[2].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemDex += Inven.Slots[1].item.buffs[2].value + Inven.Slots[2].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemATK += Inven.Slots[1].item.buffs[3].value + Inven.Slots[2].item.buffs[3].value + EquipInven.Slots[1].item.buffs[10].value; ;
            DataManager.instance.nowPlayer.itemAttackSpeed += Inven.Slots[1].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCriticalDmg += Inven.Slots[1].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += Inven.Slots[2].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCritical += Inven.Slots[2].item.buffs[9].value;
        }
        else if (Inven.Slots[1].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemDex += Inven.Slots[1].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemATK += Inven.Slots[1].item.buffs[3].value + EquipInven.Slots[1].item.buffs[10].value; ;
            DataManager.instance.nowPlayer.itemAttackSpeed += Inven.Slots[1].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCriticalDmg += Inven.Slots[1].item.buffs[9].value;
        }
        else if (Inven.Slots[2].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemDex += Inven.Slots[2].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemATK += Inven.Slots[2].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += Inven.Slots[2].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCritical += Inven.Slots[2].item.buffs[9].value;
        }

        if (Inven.Slots[0].item.id != -1 && Inven.Slots[4].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemInt += Inven.Slots[0].item.buffs[1].value + Inven.Slots[4].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += Inven.Slots[0].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemCooltime += Inven.Slots[0].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemMaxMP += Inven.Slots[0].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemMoveSpeed += Inven.Slots[4].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += Inven.Slots[4].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemCritical += Inven.Slots[4].item.buffs[8].value;
        }
        else if (Inven.Slots[0].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemInt += Inven.Slots[0].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemRecoveryHP += Inven.Slots[0].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemCooltime += Inven.Slots[0].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemMaxMP += Inven.Slots[0].item.buffs[8].value;
        }
        else if (Inven.Slots[4].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemInt += Inven.Slots[4].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemMoveSpeed += Inven.Slots[4].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += Inven.Slots[4].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemCritical += Inven.Slots[4].item.buffs[8].value;
        }

        if (Inven.Slots[2].item.id != -1 && Inven.Slots[4].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemLuk += Inven.Slots[2].item.buffs[2].value + Inven.Slots[4].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemATK += Inven.Slots[2].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += Inven.Slots[2].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCritical += Inven.Slots[2].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemMoveSpeed += Inven.Slots[4].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += Inven.Slots[4].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemCritical += Inven.Slots[4].item.buffs[8].value;
        }
        else if (Inven.Slots[2].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemLuk += Inven.Slots[2].item.buffs[2].value;
            DataManager.instance.nowPlayer.itemATK += Inven.Slots[2].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += Inven.Slots[2].item.buffs[8].value;
            DataManager.instance.nowPlayer.itemCritical += Inven.Slots[2].item.buffs[9].value;
        }
        else if (Inven.Slots[4].item.id != -1)
        {
            DataManager.instance.nowPlayer.itemLuk += Inven.Slots[4].item.buffs[1].value;
            DataManager.instance.nowPlayer.itemMoveSpeed += Inven.Slots[4].item.buffs[3].value;
            DataManager.instance.nowPlayer.itemAttackSpeed += Inven.Slots[4].item.buffs[9].value;
            DataManager.instance.nowPlayer.itemCritical += Inven.Slots[4].item.buffs[8].value;
        }


        DataManager.instance.nowPlayer.itemATK = DataManager.instance.nowPlayer.itemATK / 2;
        DataManager.instance.nowPlayer.itemMoveSpeed = DataManager.instance.nowPlayer.itemMoveSpeed / 2;
        DataManager.instance.nowPlayer.itemRecoveryHP = DataManager.instance.nowPlayer.itemRecoveryHP / 2;
        DataManager.instance.nowPlayer.itemCriticalDmg = DataManager.instance.nowPlayer.itemCriticalDmg / 2;
        DataManager.instance.nowPlayer.itemDEF = DataManager.instance.nowPlayer.itemDEF / 2;
        DataManager.instance.nowPlayer.itemMaxHP = DataManager.instance.nowPlayer.itemMaxHP / 2;
        DataManager.instance.nowPlayer.itemMaxMP = DataManager.instance.nowPlayer.itemMaxMP / 2;
        DataManager.instance.nowPlayer.itemAttackSpeed = DataManager.instance.nowPlayer.itemAttackSpeed / 2;
        DataManager.instance.nowPlayer.itemCooltime = DataManager.instance.nowPlayer.itemCooltime / 2;
        DataManager.instance.nowPlayer.itemCritical = DataManager.instance.nowPlayer.itemCritical / 2;

        //DataManager.instance.EXPandHP();
        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();

        StatOverWrite();
    }
    public void StatOverWrite()  // 스탯 오브젝트에 반영
    {
        stat.ItemStr = DataManager.instance.nowPlayer.itemStr;
        stat.ItemCon = DataManager.instance.nowPlayer.itemCon;
        stat.ItemDex = DataManager.instance.nowPlayer.itemDex;
        stat.ItemInt = DataManager.instance.nowPlayer.itemInt;
        stat.ItemLuk = DataManager.instance.nowPlayer.itemLuk;
        stat.itemATK = DataManager.instance.nowPlayer.itemATK;
        stat.itemMoveSpeed = DataManager.instance.nowPlayer.itemMoveSpeed;
        stat.itemRecoveryHP = DataManager.instance.nowPlayer.itemRecoveryHP;
        stat.itemCriticalDmg = DataManager.instance.nowPlayer.itemCriticalDmg;
        stat.itemDEF = DataManager.instance.nowPlayer.itemDEF;
        stat.itemMaxHP = DataManager.instance.nowPlayer.itemMaxHP;
        stat.itemMaxMP = DataManager.instance.nowPlayer.itemMaxMP;
        stat.itemAttackSpeed = DataManager.instance.nowPlayer.itemAttackSpeed;
        stat.itemCooltime = DataManager.instance.nowPlayer.itemCooltime;
        stat.itemCritical = DataManager.instance.nowPlayer.itemCritical;

        Calcurate();
    }

    public SkillObject _skill;
    public void Calcurate()
    {
        stat.minAtk = 0;
        stat.maxAtk = 0;
        stat.maxHP = 0;
        stat.maxMP = 0;
        stat.AttackSpeed = 100;
        stat.Critical = 0;
        stat.CriticalDmg = 150;
        stat.MoveSpeed = 300;
        stat.RecoveryHP = 0;
        stat.Def = 0;
        stat.Cooltime = 0;

        stat.minAtk = (stat.Str + stat.ItemStr) * 3 + stat.itemATK + _skill.SkillAttack;
        stat.maxAtk = (stat.Str + stat.ItemStr) * 4 + stat.itemATK + _skill.SkillAttack;
        stat.maxHP = (stat.Con + stat.ItemCon) * 10 + stat.itemMaxHP;
        stat.maxMP = (stat.Int + stat.ItemInt) * 5 + stat.itemMaxMP;
        stat.AttackSpeed = 100 + stat.Dex + stat.ItemDex + stat.itemAttackSpeed + _skill.SkillAttackSpeed;
        stat.Critical = stat.Luk + stat.ItemLuk + stat.itemCritical + _skill.SkillCritical;
        stat.CriticalDmg = 150 + ((stat.Str + stat.ItemStr) / 2) + stat.itemCriticalDmg;
        if (stat.Critical > 500)
        {
            stat.CriticalDmg = stat.CriticalDmg + (stat.Critical - 500);
            stat.Critical = 500;
        }

        stat.MoveSpeed = 300 + stat.itemMoveSpeed;
        if (stat.MoveSpeed > 600)
        {
            stat.AttackSpeed = stat.AttackSpeed + ((stat.itemMoveSpeed - 600) / 10);
            stat.MoveSpeed = 600;
        }
        stat.RecoveryHP = stat.Con + stat.ItemCon + stat.itemRecoveryHP;
        stat.RecoveryMP = stat.Int + stat.ItemInt; // 추후 스킬 추가
        stat.Def = stat.itemDEF;
        if (stat.Def > 98)
        {
            stat.maxHP = stat.maxHP + (stat.itemDEF - 99) * 1000;
            stat.Def = 99;
        }
        stat.Cooltime = ((stat.Int + stat.ItemInt) / 20) + stat.itemCooltime;
        DataManager.instance.nowPlayer.TotalScore = (stat.maxAtk * 2) + stat.maxHP + stat.AttackSpeed + stat.Critical + stat.CriticalDmg + stat.Def + stat.maxMP;

    }
    public void specialstarAtive()
    {
        int a = (specialstar % 100000) / 10000; int b = (specialstar % 10000) / 1000; int c = (specialstar % 1000) / 100;
        int d = (specialstar % 100) / 10; int e = (specialstar % 10);
        if (a == 1) { Starforce.transform.GetChild(0).GetChild(1).gameObject.SetActive(true); }
        else { Starforce.transform.GetChild(0).GetChild(1).gameObject.SetActive(false); }

        if (b == 1) { Starforce.transform.GetChild(1).GetChild(1).gameObject.SetActive(true); }
        else { Starforce.transform.GetChild(1).GetChild(1).gameObject.SetActive(false); }

        if (c == 1) { Starforce.transform.GetChild(2).GetChild(1).gameObject.SetActive(true); }
        else { Starforce.transform.GetChild(2).GetChild(1).gameObject.SetActive(false); }

        if (d == 1) { Starforce.transform.GetChild(3).GetChild(1).gameObject.SetActive(true); }
        else { Starforce.transform.GetChild(3).GetChild(1).gameObject.SetActive(false); }

        if (e == 1) { Starforce.transform.GetChild(4).GetChild(1).gameObject.SetActive(true); }
        else { Starforce.transform.GetChild(4).GetChild(1).gameObject.SetActive(false); }

    }
    public void specialstarAtiveReset()
    {
        Starforce.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        Starforce.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        Starforce.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
        Starforce.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
        Starforce.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
    }
    public void TestItemClear()
    {
        DataManager.instance.ClearInventory();
    }
    public void materialSellButtonActive() // 툴팁에서 판매버튼 클릭 했을 떄
    {
        SellingBtn.SetActive(true);
        sellingFormat = string.Format("{0:#,0}", (Inven.Slots[ParentMathod.SlotNumber].item.buffs[4].value * materialvalue));
        Sellingprice.text = "        +" + sellingFormat;
    }
    public void MaterialSellAction()  // 툴팁에서 판매버튼 누르고 최종 판매 할떄
    {
        DataManager.instance.nowPlayer.gold = DataManager.instance.nowPlayer.gold + (Inven.Slots[ParentMathod.SlotNumber].item.buffs[4].value * materialvalue);
        Textudate();
        Inven.Slots[ParentMathod.SlotNumber].amount = Inven.Slots[ParentMathod.SlotNumber].amount - materialvalue;
        Inven.Slots[ParentMathod.SlotNumber].UpdateSlot(Inven.Slots[ParentMathod.SlotNumber].item, Inven.Slots[ParentMathod.SlotNumber].amount);
        if (Inven.Slots[ParentMathod.SlotNumber].amount == 0)
        {
            Inven.Slots[ParentMathod.SlotNumber].RemoveItem();
        }
        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();
        Closed();
    }
    public void MaterialValueChange()
    {
        materialvalue = ((int)MaterialAmount.value);
        sellingFormat = string.Format("{0:#,0}", (Inven.Slots[ParentMathod.SlotNumber].item.buffs[4].value * materialvalue));
        Sellingprice.text = "        +" + sellingFormat;
        MaterialAmountText.text = materialvalue.ToString();
        Debug.Log(materialvalue);
    }
    public void QuestionMarkOpen()
    {
        QuestionMarkAlert.SetActive(true);
    }
    public void QuestionMarkClose()
    {
        QuestionMarkAlert.SetActive(false);
    }

    public void Textudate()
    {
        string goldFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.gold);
        goldinfoamount.text = goldFomat;

        string RubyFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.RubbyPoint);
        RubbyPoint.text = RubyFomat;

        string CrystalFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.CrystalPoint);
        CrystalPoint.text = CrystalFomat;
    }
    public void Update()
    {
        Textudate();
    }

    public GameObject EnforceEffect;
    public GameObject EnforceEffectimg;
    public Sprite[] Enforcing;

    IEnumerator ChangeImage() //강화중 이펙트
    {
        audioSource.Play();
        for (int i = 0; i < 5; i++)
        {
            EnforceEffectimg.GetComponent<Image>().sprite = Enforcing[i];
            yield return new WaitForSeconds(0.35f);
        }
        audioSource.Stop();
    }
    public void EnforceEffectFalse()
    {
        EnforceEffect.SetActive(false);
    }    
}



