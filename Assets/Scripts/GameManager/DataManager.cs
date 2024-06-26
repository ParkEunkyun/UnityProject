using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;
using System.Runtime.ConstrainedExecution;
using static DataManager;

public class PlayerData
{
    public string UID;
    public int howManyPlay;
    public int SelectedCharacter;
    public int PrecurExp; //광고 이어보기 시 복구용

    public int Playtutorial;
    public int statustutorial;
    public int skilltutorial;
    public int itemtutorial;
    public int Crafttutorial;

    #region 스탯
    [Header("Status")]
    public string name;
    public int TotalScore;
    public int monsterKill;
    public int Level;
    public int maxExp;
    public int curExp;
    public int maxHp;
    public int curHP;
    public int maxMp;
    public int curMP;
    public int Str;
    public int Con;
    public int Dex;
    public int Int;
    public int Luk;
    public int Pp;
    public int gold;
    public int RubbyPoint;
    public int CrystalPoint;
    public int itemStr;  // 무기, 갑옷   
    public int itemCon;  // 갑옷, 투구  
    public int itemDex;  // 무기, 장갑  
    public int itemInt;  // 투구, 신발  
    public int itemLuk;  // 장갑, 신발
    public int itemATK; // 무기    
    public int itemAttackSpeed;
    public int itemCritical;
    public int itemMoveSpeed;   // 신발
    public int itemCriticalDmg; // 장갑
    public int itemDEF; //갑옷
    public int itemCooltime;
    public int itemMaxHP;
    public int itemRecoveryHP;  //  투구
    public int itemMaxMP;
    public int itemRecoveryMP;  //  투구
    public int HealthPotion;
    public int ManaPotion;

    #endregion

    #region 장비창
    [Header("Itemstatus")]
    // 배열 순서 0 = helmet, 1 = weapon, 2 = gloves, 3 = armor, 4 = boots
    public int[] EquipItemID;
    public string[] EquipItemName;
    public int[] EquipItemAmount;
    public int[] EquipItemoption0; public int[] EquipItemoptionValue0;
    public int[] EquipItemoption1; public int[] EquipItemoptionValue1;
    public int[] EquipItemoption2; public int[] EquipItemoptionValue2;
    public int[] EquipItemoption3; public int[] EquipItemoptionValue3;
    public int[] EquipItemoption4; public int[] EquipItemoptionValue4;
    public int[] EquipItemoption5; public int[] EquipItemoptionValue5;
    public int[] EquipItemoption6; public int[] EquipItemoptionValue6;
    public int[] EquipItemoption7; public int[] EquipItemoptionValue7;
    public int[] EquipItemoption8; public int[] EquipItemoptionValue8;
    public int[] EquipItemoption9; public int[] EquipItemoptionValue9;
    public int[] EquipItemoption10; public int[] EquipItemoptionValue10;
    public int[] EquipItemoption11; public int[] EquipItemoptionValue11;
    public int[] EquipItemoption12; public int[] EquipItemoptionValue12;
    #endregion

    #region 장비 인벤토리
    [Header("Inventory")]
    public int[] itemId;
    public string[] itemname;
    public int[] amount;
    public int[] option0; public int[] optionValue0;
    public int[] option1; public int[] optionValue1;
    public int[] option2; public int[] optionValue2;
    public int[] option3; public int[] optionValue3;
    public int[] option4; public int[] optionValue4;
    public int[] option5; public int[] optionValue5;
    public int[] option6; public int[] optionValue6;
    public int[] option7; public int[] optionValue7;
    public int[] option8; public int[] optionValue8;
    public int[] option9; public int[] optionValue9;
    public int[] option10; public int[] optionValue10;
    public int[] option11; public int[] optionValue11;
    public int[] option12; public int[] optionValue12;
    #endregion

    #region 기타 인벤토리
    [Header("Inventory")]
    public int[] materialitemId;
    public string[] materialitemname;
    public int[] materialamount;
    public int[] materialoption0; public int[] materialoptionValue0;
    public int[] materialoption1; public int[] materialoptionValue1;
    public int[] materialoption2; public int[] materialoptionValue2;
    public int[] materialoption3; public int[] materialoptionValue3;
    public int[] materialoption4; public int[] materialoptionValue4;
    public int[] materialoption5; public int[] materialoptionValue5;
    public int[] materialoption6; public int[] materialoptionValue6;
    public int[] materialoption7; public int[] materialoptionValue7;
    public int[] materialoption8; public int[] materialoptionValue8;
    public int[] materialoption9; public int[] materialoptionValue9;
    public int[] materialoption10; public int[] materialoptionValue10;
    public int[] materialoption11; public int[] materialoptionValue11;
    public int[] materialoption12; public int[] materialoptionValue12;
    #endregion

    #region 스킬
    public int SkillPoint;

    [Header("자석")]
    public int MagnetLv;
    public int MagnetCurExp;
    public int MagnetMaxExp;

    [Header("사거리")]
    public int ViewRadiusLv;
    public float SkillViewRadius;
    public int ViewRadiusCurExp;
    public int ViewRadiusMaxExp;

    [Header("공속")]
    public int AttackSpeedLv;
    public int SkillAttackSpeed;
    public int AttackSpeedCurExp;
    public int AttackSpeedMaxExp;

    [Header("공격")]
    public int AttackLv;
    public int SkillAttack;
    public int AttackCurExp;
    public int AttackMaxExp;

    [Header("치확")]

    public int CriticalLv;
    public int SkillCritical;
    public int CriticalCurExp;
    public int CriticalMaxExp;

    ////////////////////////////   보조 스킬

    [Header("힐")]

    public int HealLv;
    public int HealingAmount;
    public int HealCurExp;
    public int HealMaxExp;
    public int HealUseMP;
    public float HealCooltime;

    [Header("헤이스트")]

    public int MoveSpeedLv;
    public int SkillMoveSpeed;
    public float MoveSpeedDuring;
    public int MoveSpeedCurExp;
    public int HMoveSpeedMaxExp;
    public int MoveSpeedUseMP;
    public float MoveSpeedCooltime;

    [Header("장판")]
    public int AreaSkillLv;
    public int AreaSkillDamage;
    public float AreaSkillDuring;
    public int AreaSkillCurExp;
    public int AreaSkillMaxExp;
    public int AreaSkillUseMP;
    public float AreaSkillCooltime;

    [Header("주위회전체")]
    public int AroundSkillLv;
    public int AroundSkillDamage;
    public float AroundSkillDuring;
    public int AroundSkillCurExp;
    public int AroundSkillMaxExp;
    public int AroundSkillUseMP;
    public float AroundSkillCooltime;

    [Header("무적")]
    public int InvincibilityLv;
    public float InvincibilityDuring;
    public int InvincibilityCurExp;
    public int InvincibilityMaxExp;
    public int InvincibilityUseMP;
    public float InvincibilityCooltime;

    ////////////////////////////   공격 스킬

    [Header("멀티샷")]
    public int MultiShotLv;
    public float MultiShotDuring;
    public int MultiShotCurExp;
    public int MultiShotMaxExp;
    public int MultiShotUseMP;
    public float MultiShotCooltime;

    [Header("관통샷")]
    public int PierceShotLv;
    public int PierceShotCount;
    public int PierceShotCurExp;
    public int PierceShotMaxExp;
    public int PierceShotUseMP;
    public float PierceShotCooltime;

    #endregion

    #region 레시피 인벤토리
    [Header("Inventory")]
    public int[] RecipeitemId;
    public int[] Recipeitemamount;
    public int Currentitemid;
    public int Currentitemidamount;

    #endregion

    #region 상점 이용 시간
    [Header("Inventory")]

    public string Crystal10Time;
    public string Crystal30Time;
    public string Crystal50Time;
    public string FreeBoxTime;
    public string manaportionTime;
    public string gold500RubyTime;
    public string gold50CrystalTime;
    public string StatTime;

    #endregion


}


public class DataManager : MonoBehaviour
{
    public static DataManager instance; // 싱글톤패턴    
    public PlayerData nowPlayer = new PlayerData(); // 플레이어 데이터 생성
                                                    // public InventoryData nowInven = new InventoryData();
    public string PlayerPath; // 경로
    //public string InvenPath; 
    public int nowSlot; // 현재 슬롯번호    
    bool bPaused = false;

    public int PlayGame;

    public AudioSource audioSource;

    private void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        audioSource = GetComponent<AudioSource>();
        PlayerPath = Application.persistentDataPath + "/player";
        //InvenPath = Application.persistentDataPath + "/inven";    // 경로 지정
        try
        {
            LoadData();
        }
        catch (FileNotFoundException fn)
        {
            return;
        }
    }

    public void SaveData() // 데이터 저장
    {
        invenSave();
        EquipinvenSave();
        materialinvenSave();
        SkillSave();
        string pdata = JsonUtility.ToJson(nowPlayer);
        //pdata = Crypto.AESEncrypt128(pdata);
        File.WriteAllText(PlayerPath + nowSlot.ToString(), pdata);
        Debug.Log("세이브됨");
    }
    public void SaveData2() // 데이터 저장
    {
        invenSave();
        EquipinvenSave();
        materialinvenSave();
        firstRecipeinvenSave();
        SkillSave();
        string pdata = JsonUtility.ToJson(nowPlayer);
        //pdata = Crypto.AESEncrypt128(pdata);
        File.WriteAllText(PlayerPath + nowSlot.ToString(), pdata);
        Debug.Log("세이브2됨");
    }

    public void LoadData()// 데이터 로드
    {
        string pdata = File.ReadAllText(PlayerPath + nowSlot.ToString());
        //pdata = Crypto.AESDecrypt128(pdata);
        nowPlayer = JsonUtility.FromJson<PlayerData>(pdata);
        Debug.Log("로드됨");
    }

    public void DataClear() // 데이터 삭제
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            bPaused = true;
            RecipeinvenSave();
            SaveData();
            OnClickSaveButton();
        }
        else
        {
            if (bPaused)
            {
                bPaused = false;
                LoadData();
            }
        }
    }
    private void OnApplicationQuit()
    {
        RecipeinvenSave();
        SaveData();
        OnClickSaveButton();
    }

    //아이템 획득 및 옵션 저장 및 로드
    ///////////////////////////////////////////////
    public InventoryObject equipmentObject;
    public InventoryObject tempObject;
    public InventoryObject inventoryObject;
    public InventoryObject MaterialinventoryObject;
    public InventoryObject recipeinventoryObject;
    public RecipeDataBase recipeDataBase;
    public ItemObjectDataBase databaseObject;
    public ItemObjectDataBase MaterialdatabaseObject;
    public SkillObject _skill;

    ////////////////////////////////////////////////

    public void AddNewEquipItem(int i) // 추후 아이템 획득 로직으로 변경
    {
        if (databaseObject.itemObjects.Length > 0)
        {
            ItemObject newItemObject = databaseObject.itemObjects[i];
            Item newItem = new Item(newItemObject);
            inventoryObject.AddItem(newItem, 1);
            SaveData();
            //Debug.Log(op_0);
            //Debug.Log((int)inventoryObject.Slots[0].item.buffs[0].stat);
        }
    }

    public void AddNewMaterialItem(int i) // 추후 아이템 획득 로직으로 변경
    {
        if (MaterialdatabaseObject.itemObjects.Length > 0)
        {
            ItemObject newItemObject = MaterialdatabaseObject.itemObjects[i];
            Item newItem = new Item(newItemObject);
            MaterialinventoryObject.AddItem(newItem, 1);
            SaveData();
            //Debug.Log(op_0);
            //Debug.Log((int)inventoryObject.Slots[0].item.buffs[0].stat);
        }
    }

    public void ClearInventory() // 추후 삭제
    {
        equipmentObject?.Clear();
        inventoryObject?.Clear();
        MaterialinventoryObject?.Clear();
        tempObject?.Clear();
    }

    /////////////////////인벤토리 저장//////////////////////////////
    public void invenSave()
    {
        nowPlayer.itemId = new int[] {
                                                                inventoryObject.Slots[0].item.id,
                                                                inventoryObject.Slots[1].item.id,
                                                                inventoryObject.Slots[2].item.id,
                                                                inventoryObject.Slots[3].item.id,
                                                                inventoryObject.Slots[4].item.id,
                                                                inventoryObject.Slots[5].item.id,
                                                                inventoryObject.Slots[6].item.id,
                                                                inventoryObject.Slots[7].item.id,
                                                                inventoryObject.Slots[8].item.id,
                                                                inventoryObject.Slots[9].item.id,
                                                                inventoryObject.Slots[10].item.id,
                                                                inventoryObject.Slots[11].item.id,
                                                                inventoryObject.Slots[12].item.id,
                                                                inventoryObject.Slots[13].item.id,
                                                                inventoryObject.Slots[14].item.id,
                                                                inventoryObject.Slots[15].item.id,
                                                                inventoryObject.Slots[16].item.id,
                                                                inventoryObject.Slots[17].item.id,
                                                                inventoryObject.Slots[18].item.id,
                                                                inventoryObject.Slots[19].item.id,
                                                                inventoryObject.Slots[20].item.id,
                                                                inventoryObject.Slots[21].item.id,
                                                                inventoryObject.Slots[22].item.id,
                                                                inventoryObject.Slots[23].item.id,
                                                                inventoryObject.Slots[24].item.id,
                                                                inventoryObject.Slots[25].item.id,
                                                                inventoryObject.Slots[26].item.id,
                                                                inventoryObject.Slots[27].item.id,
                                                                inventoryObject.Slots[28].item.id,
                                                                inventoryObject.Slots[29].item.id,
                                                                inventoryObject.Slots[30].item.id,
                                                                inventoryObject.Slots[31].item.id,
                                                                inventoryObject.Slots[32].item.id,
                                                                inventoryObject.Slots[33].item.id,
                                                                inventoryObject.Slots[34].item.id,
                                                                inventoryObject.Slots[35].item.id,
                                                                inventoryObject.Slots[36].item.id,
                                                                inventoryObject.Slots[37].item.id,
                                                                inventoryObject.Slots[38].item.id,
                                                                inventoryObject.Slots[39].item.id,
                                                                inventoryObject.Slots[40].item.id,
                                                                inventoryObject.Slots[41].item.id,
                                                                inventoryObject.Slots[42].item.id,
                                                                inventoryObject.Slots[43].item.id,
                                                                inventoryObject.Slots[44].item.id,
                                                                inventoryObject.Slots[45].item.id,
                                                                inventoryObject.Slots[46].item.id,
                                                                inventoryObject.Slots[47].item.id,
                                                                inventoryObject.Slots[48].item.id,
                                                                inventoryObject.Slots[49].item.id,
                                                                inventoryObject.Slots[50].item.id,
                                                                inventoryObject.Slots[51].item.id,
                                                                inventoryObject.Slots[52].item.id,
                                                                inventoryObject.Slots[53].item.id,
                                                                inventoryObject.Slots[54].item.id,
                                                                inventoryObject.Slots[55].item.id,
                                                                inventoryObject.Slots[56].item.id,
                                                                inventoryObject.Slots[57].item.id,
                                                                inventoryObject.Slots[58].item.id,
                                                                inventoryObject.Slots[59].item.id
                                                                };
        nowPlayer.itemname = new string[]  {
                                                                    inventoryObject.Slots[0].item.name,
                                                                    inventoryObject.Slots[1].item.name,
                                                                    inventoryObject.Slots[2].item.name,
                                                                    inventoryObject.Slots[3].item.name,
                                                                    inventoryObject.Slots[4].item.name,
                                                                    inventoryObject.Slots[5].item.name,
                                                                    inventoryObject.Slots[6].item.name,
                                                                    inventoryObject.Slots[7].item.name,
                                                                    inventoryObject.Slots[8].item.name,
                                                                    inventoryObject.Slots[9].item.name,
                                                                    inventoryObject.Slots[10].item.name,
                                                                    inventoryObject.Slots[11].item.name,
                                                                    inventoryObject.Slots[12].item.name,
                                                                    inventoryObject.Slots[13].item.name,
                                                                    inventoryObject.Slots[14].item.name,
                                                                    inventoryObject.Slots[15].item.name,
                                                                    inventoryObject.Slots[16].item.name,
                                                                    inventoryObject.Slots[17].item.name,
                                                                    inventoryObject.Slots[18].item.name,
                                                                    inventoryObject.Slots[19].item.name,
                                                                    inventoryObject.Slots[20].item.name,
                                                                    inventoryObject.Slots[21].item.name,
                                                                    inventoryObject.Slots[22].item.name,
                                                                    inventoryObject.Slots[23].item.name,
                                                                    inventoryObject.Slots[24].item.name,
                                                                    inventoryObject.Slots[25].item.name,
                                                                    inventoryObject.Slots[26].item.name,
                                                                    inventoryObject.Slots[27].item.name,
                                                                    inventoryObject.Slots[28].item.name,
                                                                    inventoryObject.Slots[29].item.name,
                                                                    inventoryObject.Slots[30].item.name,
                                                                    inventoryObject.Slots[31].item.name,
                                                                    inventoryObject.Slots[32].item.name,
                                                                    inventoryObject.Slots[33].item.name,
                                                                    inventoryObject.Slots[34].item.name,
                                                                    inventoryObject.Slots[35].item.name,
                                                                    inventoryObject.Slots[36].item.name,
                                                                    inventoryObject.Slots[37].item.name,
                                                                    inventoryObject.Slots[38].item.name,
                                                                    inventoryObject.Slots[39].item.name,
                                                                    inventoryObject.Slots[40].item.name,
                                                                    inventoryObject.Slots[41].item.name,
                                                                    inventoryObject.Slots[42].item.name,
                                                                    inventoryObject.Slots[43].item.name,
                                                                    inventoryObject.Slots[44].item.name,
                                                                    inventoryObject.Slots[45].item.name,
                                                                    inventoryObject.Slots[46].item.name,
                                                                    inventoryObject.Slots[47].item.name,
                                                                    inventoryObject.Slots[48].item.name,
                                                                    inventoryObject.Slots[49].item.name,
                                                                    inventoryObject.Slots[50].item.name,
                                                                    inventoryObject.Slots[51].item.name,
                                                                    inventoryObject.Slots[52].item.name,
                                                                    inventoryObject.Slots[53].item.name,
                                                                    inventoryObject.Slots[54].item.name,
                                                                    inventoryObject.Slots[55].item.name,
                                                                    inventoryObject.Slots[56].item.name,
                                                                    inventoryObject.Slots[57].item.name,
                                                                    inventoryObject.Slots[58].item.name,
                                                                    inventoryObject.Slots[59].item.name
                                                                };
        nowPlayer.amount = new int[]  {
                                                                    inventoryObject.Slots[0].amount,
                                                                    inventoryObject.Slots[1].amount,
                                                                    inventoryObject.Slots[2].amount,
                                                                    inventoryObject.Slots[3].amount,
                                                                    inventoryObject.Slots[4].amount,
                                                                    inventoryObject.Slots[5].amount,
                                                                    inventoryObject.Slots[6].amount,
                                                                    inventoryObject.Slots[7].amount,
                                                                    inventoryObject.Slots[8].amount,
                                                                    inventoryObject.Slots[9].amount,
                                                                    inventoryObject.Slots[10].amount,
                                                                    inventoryObject.Slots[11].amount,
                                                                    inventoryObject.Slots[12].amount,
                                                                    inventoryObject.Slots[13].amount,
                                                                    inventoryObject.Slots[14].amount,
                                                                    inventoryObject.Slots[15].amount,
                                                                    inventoryObject.Slots[16].amount,
                                                                    inventoryObject.Slots[17].amount,
                                                                    inventoryObject.Slots[18].amount,
                                                                    inventoryObject.Slots[19].amount,
                                                                    inventoryObject.Slots[20].amount,
                                                                    inventoryObject.Slots[21].amount,
                                                                    inventoryObject.Slots[22].amount,
                                                                    inventoryObject.Slots[23].amount,
                                                                    inventoryObject.Slots[24].amount,
                                                                    inventoryObject.Slots[25].amount,
                                                                    inventoryObject.Slots[26].amount,
                                                                    inventoryObject.Slots[27].amount,
                                                                    inventoryObject.Slots[28].amount,
                                                                    inventoryObject.Slots[29].amount,
                                                                    inventoryObject.Slots[30].amount,
                                                                    inventoryObject.Slots[31].amount,
                                                                    inventoryObject.Slots[32].amount,
                                                                    inventoryObject.Slots[33].amount,
                                                                    inventoryObject.Slots[34].amount,
                                                                    inventoryObject.Slots[35].amount,
                                                                    inventoryObject.Slots[36].amount,
                                                                    inventoryObject.Slots[37].amount,
                                                                    inventoryObject.Slots[38].amount,
                                                                    inventoryObject.Slots[39].amount,
                                                                    inventoryObject.Slots[40].amount,
                                                                    inventoryObject.Slots[41].amount,
                                                                    inventoryObject.Slots[42].amount,
                                                                    inventoryObject.Slots[43].amount,
                                                                    inventoryObject.Slots[44].amount,
                                                                    inventoryObject.Slots[45].amount,
                                                                    inventoryObject.Slots[46].amount,
                                                                    inventoryObject.Slots[47].amount,
                                                                    inventoryObject.Slots[48].amount,
                                                                    inventoryObject.Slots[49].amount,
                                                                    inventoryObject.Slots[50].amount,
                                                                    inventoryObject.Slots[51].amount,
                                                                    inventoryObject.Slots[52].amount,
                                                                    inventoryObject.Slots[53].amount,
                                                                    inventoryObject.Slots[54].amount,
                                                                    inventoryObject.Slots[55].amount,
                                                                    inventoryObject.Slots[56].amount,
                                                                    inventoryObject.Slots[57].amount,
                                                                    inventoryObject.Slots[58].amount,
                                                                    inventoryObject.Slots[59].amount

                                                                };
        tests0();
        tests1();
    }
    private void tests0()
    {
        int[] op0 = new int[60];
        int[] op1 = new int[60];
        int[] op2 = new int[60];
        int[] op3 = new int[60];
        int[] op4 = new int[60];
        int[] op5 = new int[60];
        int[] op6 = new int[60];
        int[] op7 = new int[60];
        int[] op8 = new int[60];
        int[] op9 = new int[60];
        int[] op10 = new int[60];
        int[] op11 = new int[60];
        int[] op12 = new int[60];

        for (int i = 0; i < 60; i++)
        {
            op0[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[0].stat : -1);
            op1[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[1].stat : -1);
            op2[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[2].stat : -1);
            op3[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[3].stat : -1);
            op4[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[4].stat : -1);
            op5[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[5].stat : -1);
            op6[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[6].stat : -1);
            op7[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[7].stat : -1);
            op8[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[8].stat : -1);
            op9[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[9].stat : -1);
            op10[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[10].stat : -1);
            op11[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[11].stat : -1);
            op12[i] = ((inventoryObject.Slots[i].item.id != -1) ? (int)inventoryObject.Slots[i].item.buffs[12].stat : -1);
        }

        nowPlayer.option0 = op0;
        nowPlayer.option1 = op1;
        nowPlayer.option2 = op2;
        nowPlayer.option3 = op3;
        nowPlayer.option4 = op4;
        nowPlayer.option5 = op5;
        nowPlayer.option6 = op6;
        nowPlayer.option7 = op7;
        nowPlayer.option8 = op8;
        nowPlayer.option9 = op9;
        nowPlayer.option10 = op10;
        nowPlayer.option11 = op11;
        nowPlayer.option12 = op12;
    }
    private void tests1()
    {
        int[] opv0 = new int[60];
        int[] opv1 = new int[60];
        int[] opv2 = new int[60];
        int[] opv3 = new int[60];
        int[] opv4 = new int[60];
        int[] opv5 = new int[60];
        int[] opv6 = new int[60];
        int[] opv7 = new int[60];
        int[] opv8 = new int[60];
        int[] opv9 = new int[60];
        int[] opv10 = new int[60];
        int[] opv11 = new int[60];
        int[] opv12 = new int[60];

        for (int i = 0; i < 60; i++)
        {
            opv0[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[0].value : 0);
            opv1[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[1].value : 0);
            opv2[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[2].value : 0);
            opv3[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[3].value : 0);
            opv4[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[4].value : 0);
            opv5[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[5].value : 0);
            opv6[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[6].value : 0);
            opv7[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[7].value : 0);
            opv8[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[8].value : 0);
            opv9[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[9].value : 0);
            opv10[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[10].value : 0);
            opv11[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[11].value : 0);
            opv12[i] = ((inventoryObject.Slots[i].item.id != -1) ? inventoryObject.Slots[i].item.buffs[12].value : 0);
        }

        nowPlayer.optionValue0 = opv0;
        nowPlayer.optionValue1 = opv1;
        nowPlayer.optionValue2 = opv2;
        nowPlayer.optionValue3 = opv3;
        nowPlayer.optionValue4 = opv4;
        nowPlayer.optionValue5 = opv5;
        nowPlayer.optionValue6 = opv6;
        nowPlayer.optionValue7 = opv7;
        nowPlayer.optionValue8 = opv8;
        nowPlayer.optionValue9 = opv9;
        nowPlayer.optionValue10 = opv10;
        nowPlayer.optionValue11 = opv11;
        nowPlayer.optionValue12 = opv12;
    }


    /////////////////////장비창 저장//////////////////////////////

    public void EquipinvenSave()
    {
        nowPlayer.EquipItemID = new int[] {
                                                                equipmentObject.Slots[0].item.id,
                                                                equipmentObject.Slots[1].item.id,
                                                                equipmentObject.Slots[2].item.id,
                                                                equipmentObject.Slots[3].item.id,
                                                                equipmentObject.Slots[4].item.id,
                                                                };
        nowPlayer.EquipItemName = new string[]  {
                                                                    equipmentObject.Slots[0].item.name,
                                                                    equipmentObject.Slots[1].item.name,
                                                                    equipmentObject.Slots[2].item.name,
                                                                    equipmentObject.Slots[3].item.name,
                                                                    equipmentObject.Slots[4].item.name,
                                                                };
        nowPlayer.EquipItemAmount = new int[]  {
                                                                    equipmentObject.Slots[0].amount,
                                                                    equipmentObject.Slots[1].amount,
                                                                    equipmentObject.Slots[2].amount,
                                                                    equipmentObject.Slots[3].amount,
                                                                    equipmentObject.Slots[4].amount,
                                                                };
        Equiptests0();
        Equiptests1();
    }
    private void Equiptests0()
    {
        int[] eop0 = new int[30];
        int[] eop1 = new int[30];
        int[] eop2 = new int[30];
        int[] eop3 = new int[30];
        int[] eop4 = new int[30];
        int[] eop5 = new int[30];
        int[] eop6 = new int[30];
        int[] eop7 = new int[30];
        int[] eop8 = new int[30];
        int[] eop9 = new int[30];
        int[] eop10 = new int[30];
        int[] eop11 = new int[30];
        int[] eop12 = new int[30];

        for (int i = 0; i < 5; i++)
        {
            eop0[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[0].stat : -1);
            eop1[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[1].stat : -1);
            eop2[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[2].stat : -1);
            eop3[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[3].stat : -1);
            eop4[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[4].stat : -1);
            eop5[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[5].stat : -1);
            eop6[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[6].stat : -1);
            eop7[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[7].stat : -1);
            eop8[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[8].stat : -1);
            eop9[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[9].stat : -1);
            eop10[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[10].stat : -1);
            eop11[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[11].stat : -1);
            eop12[i] = ((equipmentObject.Slots[i].item.id != -1) ? (int)equipmentObject.Slots[i].item.buffs[12].stat : -1);
        }

        nowPlayer.EquipItemoption0 = eop0;
        nowPlayer.EquipItemoption1 = eop1;
        nowPlayer.EquipItemoption2 = eop2;
        nowPlayer.EquipItemoption3 = eop3;
        nowPlayer.EquipItemoption4 = eop4;
        nowPlayer.EquipItemoption5 = eop5;
        nowPlayer.EquipItemoption6 = eop6;
        nowPlayer.EquipItemoption7 = eop7;
        nowPlayer.EquipItemoption8 = eop8;
        nowPlayer.EquipItemoption9 = eop9;
        nowPlayer.EquipItemoption10 = eop10;
        nowPlayer.EquipItemoption11 = eop11;
        nowPlayer.EquipItemoption12 = eop12;
    }
    private void Equiptests1()
    {
        int[] eopv0 = new int[30];
        int[] eopv1 = new int[30];
        int[] eopv2 = new int[30];
        int[] eopv3 = new int[30];
        int[] eopv4 = new int[30];
        int[] eopv5 = new int[30];
        int[] eopv6 = new int[30];
        int[] eopv7 = new int[30];
        int[] eopv8 = new int[30];
        int[] eopv9 = new int[30];
        int[] eopv10 = new int[30];
        int[] eopv11 = new int[30];
        int[] eopv12 = new int[30];

        for (int i = 0; i < 5; i++)
        {
            eopv0[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[0].value : 0);
            eopv1[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[1].value : 0);
            eopv2[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[2].value : 0);
            eopv3[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[3].value : 0);
            eopv4[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[4].value : 0);
            eopv5[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[5].value : 0);
            eopv6[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[6].value : 0);
            eopv7[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[7].value : 0);
            eopv8[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[8].value : 0);
            eopv9[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[9].value : 0);
            eopv10[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[10].value : 0);
            eopv11[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[11].value : 0);
            eopv12[i] = ((equipmentObject.Slots[i].item.id != -1) ? equipmentObject.Slots[i].item.buffs[12].value : 0);
        }

        nowPlayer.EquipItemoptionValue0 = eopv0;
        nowPlayer.EquipItemoptionValue1 = eopv1;
        nowPlayer.EquipItemoptionValue2 = eopv2;
        nowPlayer.EquipItemoptionValue3 = eopv3;
        nowPlayer.EquipItemoptionValue4 = eopv4;
        nowPlayer.EquipItemoptionValue5 = eopv5;
        nowPlayer.EquipItemoptionValue6 = eopv6;
        nowPlayer.EquipItemoptionValue7 = eopv7;
        nowPlayer.EquipItemoptionValue8 = eopv8;
        nowPlayer.EquipItemoptionValue9 = eopv9;
        nowPlayer.EquipItemoptionValue10 = eopv10;
        nowPlayer.EquipItemoptionValue11 = eopv11;
        nowPlayer.EquipItemoptionValue12 = eopv12;
    }

    ////////////////////////기타창 저장///////////////////////////
    public void materialinvenSave()
    {
        nowPlayer.materialitemId = new int[] {
                                                                MaterialinventoryObject.Slots[0].item.id,
                                                                MaterialinventoryObject.Slots[1].item.id,
                                                                MaterialinventoryObject.Slots[2].item.id,
                                                                MaterialinventoryObject.Slots[3].item.id,
                                                                MaterialinventoryObject.Slots[4].item.id,
                                                                MaterialinventoryObject.Slots[5].item.id,
                                                                MaterialinventoryObject.Slots[6].item.id,
                                                                MaterialinventoryObject.Slots[7].item.id,
                                                                MaterialinventoryObject.Slots[8].item.id,
                                                                MaterialinventoryObject.Slots[9].item.id,
                                                                MaterialinventoryObject.Slots[10].item.id,
                                                                MaterialinventoryObject.Slots[11].item.id,
                                                                MaterialinventoryObject.Slots[12].item.id,
                                                                MaterialinventoryObject.Slots[13].item.id,
                                                                MaterialinventoryObject.Slots[14].item.id,
                                                                MaterialinventoryObject.Slots[15].item.id,
                                                                MaterialinventoryObject.Slots[16].item.id,
                                                                MaterialinventoryObject.Slots[17].item.id,
                                                                MaterialinventoryObject.Slots[18].item.id,
                                                                MaterialinventoryObject.Slots[19].item.id,
                                                                MaterialinventoryObject.Slots[20].item.id,
                                                                MaterialinventoryObject.Slots[21].item.id,
                                                                MaterialinventoryObject.Slots[22].item.id,
                                                                MaterialinventoryObject.Slots[23].item.id,
                                                                MaterialinventoryObject.Slots[24].item.id,
                                                                MaterialinventoryObject.Slots[25].item.id,
                                                                MaterialinventoryObject.Slots[26].item.id,
                                                                MaterialinventoryObject.Slots[27].item.id,
                                                                MaterialinventoryObject.Slots[28].item.id,
                                                                MaterialinventoryObject.Slots[29].item.id
                                                                };
        nowPlayer.materialitemname = new string[]  {
                                                                    MaterialinventoryObject.Slots[0].item.name,
                                                                    MaterialinventoryObject.Slots[1].item.name,
                                                                    MaterialinventoryObject.Slots[2].item.name,
                                                                    MaterialinventoryObject.Slots[3].item.name,
                                                                    MaterialinventoryObject.Slots[4].item.name,
                                                                    MaterialinventoryObject.Slots[5].item.name,
                                                                    MaterialinventoryObject.Slots[6].item.name,
                                                                    MaterialinventoryObject.Slots[7].item.name,
                                                                    MaterialinventoryObject.Slots[8].item.name,
                                                                    MaterialinventoryObject.Slots[9].item.name,
                                                                    MaterialinventoryObject.Slots[10].item.name,
                                                                    MaterialinventoryObject.Slots[11].item.name,
                                                                    MaterialinventoryObject.Slots[12].item.name,
                                                                    MaterialinventoryObject.Slots[13].item.name,
                                                                    MaterialinventoryObject.Slots[14].item.name,
                                                                    MaterialinventoryObject.Slots[15].item.name,
                                                                    MaterialinventoryObject.Slots[16].item.name,
                                                                    MaterialinventoryObject.Slots[17].item.name,
                                                                    MaterialinventoryObject.Slots[18].item.name,
                                                                    MaterialinventoryObject.Slots[19].item.name,
                                                                    MaterialinventoryObject.Slots[20].item.name,
                                                                    MaterialinventoryObject.Slots[21].item.name,
                                                                    MaterialinventoryObject.Slots[22].item.name,
                                                                    MaterialinventoryObject.Slots[23].item.name,
                                                                    MaterialinventoryObject.Slots[24].item.name,
                                                                    MaterialinventoryObject.Slots[25].item.name,
                                                                    MaterialinventoryObject.Slots[26].item.name,
                                                                    MaterialinventoryObject.Slots[27].item.name,
                                                                    MaterialinventoryObject.Slots[28].item.name,
                                                                    MaterialinventoryObject.Slots[29].item.name,

                                                                };
        nowPlayer.materialamount = new int[]  {
                                                                    MaterialinventoryObject.Slots[0].amount,
                                                                    MaterialinventoryObject.Slots[1].amount,
                                                                    MaterialinventoryObject.Slots[2].amount,
                                                                    MaterialinventoryObject.Slots[3].amount,
                                                                    MaterialinventoryObject.Slots[4].amount,
                                                                    MaterialinventoryObject.Slots[5].amount,
                                                                    MaterialinventoryObject.Slots[6].amount,
                                                                    MaterialinventoryObject.Slots[7].amount,
                                                                    MaterialinventoryObject.Slots[8].amount,
                                                                    MaterialinventoryObject.Slots[9].amount,
                                                                    MaterialinventoryObject.Slots[10].amount,
                                                                    MaterialinventoryObject.Slots[11].amount,
                                                                    MaterialinventoryObject.Slots[12].amount,
                                                                    MaterialinventoryObject.Slots[13].amount,
                                                                    MaterialinventoryObject.Slots[14].amount,
                                                                    MaterialinventoryObject.Slots[15].amount,
                                                                    MaterialinventoryObject.Slots[16].amount,
                                                                    MaterialinventoryObject.Slots[17].amount,
                                                                    MaterialinventoryObject.Slots[18].amount,
                                                                    MaterialinventoryObject.Slots[19].amount,
                                                                    MaterialinventoryObject.Slots[20].amount,
                                                                    MaterialinventoryObject.Slots[21].amount,
                                                                    MaterialinventoryObject.Slots[22].amount,
                                                                    MaterialinventoryObject.Slots[23].amount,
                                                                    MaterialinventoryObject.Slots[24].amount,
                                                                    MaterialinventoryObject.Slots[25].amount,
                                                                    MaterialinventoryObject.Slots[26].amount,
                                                                    MaterialinventoryObject.Slots[27].amount,
                                                                    MaterialinventoryObject.Slots[28].amount,
                                                                    MaterialinventoryObject.Slots[29].amount,

                                                                };
        materialtests0();
        materialtests1();
    }
    private void materialtests0()
    {
        int[] op0 = new int[30];
        int[] op1 = new int[30];
        int[] op2 = new int[30];
        int[] op3 = new int[30];
        int[] op4 = new int[30];
        int[] op5 = new int[30];
        int[] op6 = new int[30];
        int[] op7 = new int[30];
        int[] op8 = new int[30];
        int[] op9 = new int[30];
        int[] op10 = new int[30];
        int[] op11 = new int[30];
        int[] op12 = new int[30];

        for (int i = 0; i < 30; i++)
        {
            op0[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[0].stat : -1);
            op1[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[1].stat : -1);
            op2[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[2].stat : -1);
            op3[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[3].stat : -1);
            op4[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[4].stat : -1);
            op5[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[5].stat : -1);
            op6[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[6].stat : -1);
            op7[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[7].stat : -1);
            op8[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[8].stat : -1);
            op9[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[9].stat : -1);
            op10[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[10].stat : -1);
            op11[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[11].stat : -1);
            op12[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? (int)MaterialinventoryObject.Slots[i].item.buffs[12].stat : -1);
        }

        nowPlayer.materialoption0 = op0;
        nowPlayer.materialoption1 = op1;
        nowPlayer.materialoption2 = op2;
        nowPlayer.materialoption3 = op3;
        nowPlayer.materialoption4 = op4;
        nowPlayer.materialoption5 = op5;
        nowPlayer.materialoption6 = op6;
        nowPlayer.materialoption7 = op7;
        nowPlayer.materialoption8 = op8;
        nowPlayer.materialoption9 = op9;
        nowPlayer.materialoption10 = op10;
        nowPlayer.materialoption11 = op11;
        nowPlayer.materialoption12 = op12;
    }
    private void materialtests1()
    {
        int[] opv0 = new int[30];
        int[] opv1 = new int[30];
        int[] opv2 = new int[30];
        int[] opv3 = new int[30];
        int[] opv4 = new int[30];
        int[] opv5 = new int[30];
        int[] opv6 = new int[30];
        int[] opv7 = new int[30];
        int[] opv8 = new int[30];
        int[] opv9 = new int[30];
        int[] opv10 = new int[30];
        int[] opv11 = new int[30];
        int[] opv12 = new int[30];

        for (int i = 0; i < 30; i++)
        {
            opv0[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[0].value : 0);
            opv1[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[1].value : 0);
            opv2[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[2].value : 0);
            opv3[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[3].value : 0);
            opv4[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[4].value : 0);
            opv5[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[5].value : 0);
            opv6[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[6].value : 0);
            opv7[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[7].value : 0);
            opv8[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[8].value : 0);
            opv9[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[9].value : 0);
            opv10[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[10].value : 0);
            opv11[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[11].value : 0);
            opv12[i] = ((MaterialinventoryObject.Slots[i].item.id != -1) ? MaterialinventoryObject.Slots[i].item.buffs[12].value : 0);
        }

        nowPlayer.materialoptionValue0 = opv0;
        nowPlayer.materialoptionValue1 = opv1;
        nowPlayer.materialoptionValue2 = opv2;
        nowPlayer.materialoptionValue3 = opv3;
        nowPlayer.materialoptionValue4 = opv4;
        nowPlayer.materialoptionValue5 = opv5;
        nowPlayer.materialoptionValue6 = opv6;
        nowPlayer.materialoptionValue7 = opv7;
        nowPlayer.materialoptionValue8 = opv8;
        nowPlayer.materialoptionValue9 = opv9;
        nowPlayer.materialoptionValue10 = opv10;
        nowPlayer.materialoptionValue11 = opv11;
        nowPlayer.materialoptionValue12 = opv12;
    }

    ////////////////////////기타창 저장///////////////////////////
    public void RecipeinvenSave()
    {
        nowPlayer.RecipeitemId = new int[] {
                                                                EZInventory.InventoryManager.instance.slots[0].Id,
                                                                EZInventory.InventoryManager.instance.slots[1].Id,
                                                                EZInventory.InventoryManager.instance.slots[2].Id,
                                                                EZInventory.InventoryManager.instance.slots[3].Id,
                                                                EZInventory.InventoryManager.instance.slots[4].Id,
                                                                EZInventory.InventoryManager.instance.slots[5].Id,
                                                                EZInventory.InventoryManager.instance.slots[6].Id,
                                                                EZInventory.InventoryManager.instance.slots[7].Id,
                                                                EZInventory.InventoryManager.instance.slots[8].Id,
                                                                EZInventory.InventoryManager.instance.slots[9].Id,
                                                                EZInventory.InventoryManager.instance.slots[10].Id,
                                                                EZInventory.InventoryManager.instance.slots[11].Id,
                                                                EZInventory.InventoryManager.instance.slots[12].Id,
                                                                EZInventory.InventoryManager.instance.slots[13].Id,
                                                                EZInventory.InventoryManager.instance.slots[14].Id,
                                                                EZInventory.InventoryManager.instance.slots[15].Id,
                                                                EZInventory.InventoryManager.instance.slots[16].Id,
                                                                EZInventory.InventoryManager.instance.slots[17].Id,
                                                                EZInventory.InventoryManager.instance.slots[18].Id,
                                                                EZInventory.InventoryManager.instance.slots[19].Id,
                                                                EZInventory.InventoryManager.instance.slots[20].Id,
                                                                EZInventory.InventoryManager.instance.slots[21].Id,
                                                                EZInventory.InventoryManager.instance.slots[22].Id,
                                                                EZInventory.InventoryManager.instance.slots[23].Id,
                                                                EZInventory.InventoryManager.instance.slots[24].Id,
                                                                EZInventory.InventoryManager.instance.slots[25].Id,
                                                                EZInventory.InventoryManager.instance.slots[26].Id,
                                                                EZInventory.InventoryManager.instance.slots[27].Id,
                                                                EZInventory.InventoryManager.instance.slots[28].Id,
                                                                EZInventory.InventoryManager.instance.slots[29].Id,


                                                                };
        nowPlayer.Recipeitemamount = new int[]  {
                                                                    EZInventory.InventoryManager.instance.slots[0].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[1].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[2].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[3].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[4].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[5].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[6].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[7].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[8].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[9].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[10].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[11].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[12].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[13].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[14].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[15].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[16].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[17].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[18].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[19].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[20].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[21].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[22].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[23].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[24].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[25].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[26].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[27].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[28].currentItemAmount,
                                                                    EZInventory.InventoryManager.instance.slots[29].currentItemAmount,

                                                                };
        Debug.Log("레시피 인벤 세이브됨");
    }

    public void firstRecipeinvenSave()
    {
        nowPlayer.RecipeitemId = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        nowPlayer.Recipeitemamount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
        Debug.Log("레시피 인벤 최초 세이브됨");
    }







    ////////////////////////스킬 저장//////////////////////////////////

    public void SkillSave()
    {
        nowPlayer.SkillPoint = _skill.SkillPoint;

        nowPlayer.MagnetLv = _skill.MagnetLv;
        nowPlayer.MagnetCurExp = _skill.MagnetCurExp;
        nowPlayer.MagnetMaxExp = _skill.MagnetMaxExp;

        nowPlayer.ViewRadiusLv = _skill.ViewRadiusLv;
        nowPlayer.SkillViewRadius = _skill.SkillViewRadius;
        nowPlayer.ViewRadiusCurExp = _skill.ViewRadiusCurExp;
        nowPlayer.ViewRadiusMaxExp = _skill.ViewRadiusMaxExp;

        nowPlayer.AttackSpeedLv = _skill.AttackSpeedLv;
        nowPlayer.SkillAttackSpeed = _skill.SkillAttackSpeed;
        nowPlayer.AttackSpeedCurExp = _skill.AttackSpeedCurExp;
        nowPlayer.AttackSpeedMaxExp = _skill.AttackSpeedMaxExp;

        nowPlayer.AttackLv = _skill.AttackLv;
        nowPlayer.SkillAttack = _skill.SkillAttack;
        nowPlayer.AttackCurExp = _skill.AttackCurExp;
        nowPlayer.AttackMaxExp = _skill.AttackMaxExp;

        nowPlayer.CriticalLv = _skill.CriticalLv;
        nowPlayer.SkillCritical = _skill.SkillCritical;
        nowPlayer.CriticalCurExp = _skill.CriticalCurExp;
        nowPlayer.CriticalMaxExp = _skill.CriticalMaxExp;

        ////////////////////////////   보조 스킬

        nowPlayer.HealLv = _skill.HealLv;
        nowPlayer.HealingAmount = _skill.HealingAmount;
        nowPlayer.HealCurExp = _skill.HealCurExp;
        nowPlayer.HealMaxExp = _skill.HealMaxExp;
        nowPlayer.HealUseMP = _skill.HealUseMP;
        nowPlayer.HealCooltime = _skill.HealCooltime;

        nowPlayer.MoveSpeedLv = _skill.MoveSpeedLv;
        nowPlayer.SkillMoveSpeed = _skill.SkillMoveSpeed;
        nowPlayer.MoveSpeedDuring = _skill.MoveSpeedDuring;
        nowPlayer.MoveSpeedCurExp = _skill.MoveSpeedCurExp;
        nowPlayer.HMoveSpeedMaxExp = _skill.HMoveSpeedMaxExp;
        nowPlayer.MoveSpeedUseMP = _skill.MoveSpeedUseMP;
        nowPlayer.MoveSpeedCooltime = _skill.MoveSpeedCooltime;

        nowPlayer.AreaSkillLv = _skill.AreaSkillLv;
        nowPlayer.AreaSkillDamage = _skill.AreaSkillDamage;
        nowPlayer.AreaSkillDuring = _skill.AreaSkillDuring;
        nowPlayer.AreaSkillCurExp = _skill.AreaSkillCurExp;
        nowPlayer.AreaSkillMaxExp = _skill.AreaSkillMaxExp;
        nowPlayer.AreaSkillUseMP = _skill.AreaSkillUseMP;
        nowPlayer.AreaSkillCooltime = _skill.AreaSkillCooltime;

        nowPlayer.AroundSkillLv = _skill.AroundSkillLv;
        nowPlayer.AroundSkillDamage = _skill.AroundSkillDamage;
        nowPlayer.AroundSkillDuring = _skill.AroundSkillDuring;
        nowPlayer.AroundSkillCurExp = _skill.AroundSkillCurExp;
        nowPlayer.AroundSkillMaxExp = _skill.AroundSkillMaxExp;
        nowPlayer.AroundSkillUseMP = _skill.AroundSkillUseMP;
        nowPlayer.AroundSkillCooltime = _skill.AroundSkillCooltime;

        nowPlayer.InvincibilityLv = _skill.InvincibilityLv;
        nowPlayer.InvincibilityDuring = _skill.InvincibilityDuring;
        nowPlayer.InvincibilityCurExp = _skill.InvincibilityCurExp;
        nowPlayer.InvincibilityMaxExp = _skill.InvincibilityMaxExp;
        nowPlayer.InvincibilityUseMP = _skill.InvincibilityUseMP;
        nowPlayer.InvincibilityCooltime = _skill.InvincibilityCooltime;

        ////////////////////////////   공격 스킬

        nowPlayer.MultiShotLv = _skill.MultiShotLv;
        nowPlayer.MultiShotDuring = _skill.MultiShotDuring;
        nowPlayer.MultiShotCurExp = _skill.MultiShotCurExp;
        nowPlayer.MultiShotMaxExp = _skill.MultiShotMaxExp;
        nowPlayer.MultiShotUseMP = _skill.MultiShotUseMP;
        nowPlayer.MultiShotCooltime = _skill.MultiShotCooltime;

        nowPlayer.PierceShotLv = _skill.PierceShotLv;
        nowPlayer.PierceShotCount = _skill.PierceShotCount;
        nowPlayer.PierceShotCurExp = _skill.PierceShotCurExp;
        nowPlayer.PierceShotMaxExp = _skill.PierceShotMaxExp;
        nowPlayer.PierceShotUseMP = _skill.PierceShotUseMP;
        nowPlayer.PierceShotCooltime = _skill.PierceShotCooltime;

    }

    /*
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Slider ExpBar1; public Text EXP1;
    public Text LvUI;
    public Stat _stat;
    public LevelUpEffect effect;

    public Text myRanking;
    public Text myNickName;
    public Text myPower;

    public void EXPandHP()
    {
        ExpBar1 = GameObject.Find("PlayerExpUI").GetComponent<Slider>();
        ExpBar1.maxValue = nowPlayer.maxExp;
        ExpBar1.value = nowPlayer.curExp;
        EXP1 = GameObject.Find("PlayerExpTEXT").GetComponent<Text>();
        EXP1.text = nowPlayer.curExp.ToString() + " / " + nowPlayer.maxExp.ToString();
        LvUI = GameObject.Find("LvUITEXT").GetComponent<Text>();
        LvUI.text = nowPlayer.Level.ToString();
        effect = GameObject.Find("Char").GetComponent<LevelUpEffect>();

        myRanking = GameObject.Find("myRangking").GetComponent<Text>();
        myNickName = GameObject.Find("myNick").GetComponent<Text>();
        myPower = GameObject.Find("myPower").GetComponent<Text>();

    }
    public void LevelUP()
    {

        while (nowPlayer.curExp >= ExpBar1.maxValue)
        {
            nowPlayer.Level++;
            nowPlayer.curExp = nowPlayer.curExp - nowPlayer.maxExp;
            nowPlayer.Pp = nowPlayer.Pp + 5;
            _skill.SkillPoint = _skill.SkillPoint + 2;
            LvUI.text = nowPlayer.Level.ToString();
            effect.ActiveLvUpEffect();

            if (nowPlayer.Level < 30)
            {
                nowPlayer.maxExp = nowPlayer.maxExp + 10;
            }
            else if (nowPlayer.Level < 50)
            {
                nowPlayer.maxExp = nowPlayer.maxExp + 100;
            }
            else if (nowPlayer.Level < 100)
            {
                nowPlayer.maxExp = nowPlayer.maxExp + 1000;
            }

            if (nowPlayer.curExp < nowPlayer.maxExp)
            {
                break;
            }

        }

        //ExpBar2.maxValue = nowPlayer.maxExp;
        //ExpBar2.value = nowPlayer.curExp;
        ExpBar1.maxValue = nowPlayer.maxExp;
        ExpBar1.value = nowPlayer.curExp;
        EXP1.text = nowPlayer.curExp.ToString() + " / " + nowPlayer.maxExp.ToString();
        _stat.curExp = nowPlayer.curExp;
        _stat.maxExp = nowPlayer.maxExp;
        SaveData();
        OnClickSaveButton();
    }
    */


    //DB 정보 저장//////////////////////////////////////////////////////////////////////////////////////

    public string userid;
    public string nickName;
    public string TotalScore;
    public string KillScore;
    public string Gold;
    public string CrystalPt;
    public string GameVersion;
    //public string[] itemoption0;

    public class User
    {
        public string userid;
        public string nickName;
        public string TotalScore;
        public string KillScore;
        public string Gold;
        public string CrystalPt;
        public string GameVersion;
        //public string[] itemoption0;

        public User(string userid, string nickName, string TotalScore, string KillScore, string Gold, string CrystalPt, string GameVersion/* , string[] itemoption0*/)
        {
            this.nickName = nickName;
            this.TotalScore = TotalScore;
            this.KillScore = KillScore;
            this.Gold = Gold;
            this.CrystalPt = CrystalPt;
            this.userid = FirebaseManager.Instance.UserId;
            this.GameVersion = Application.version;
            //this.itemoption0 = itemoption0;
        }
    }
    DatabaseReference databaseReference;
    public Text[] Nick = new Text[30];
    public Text[] Score = new Text[30];
    public string[] strRank;
    //public string[] strUserid;
    public long strLen;
    public bool textLoadBool = false;
    public bool nameChecking = false;
    //public RankingObject rank;
    public string[] scoreComma;
    public string[] Comma;
    public int[] intScore;
    private void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update()
    {
        if (textLoadBool)
        {
            TextLoad();
        }

    }

    public void OnClickSaveButton()
    {
        writeNewUser(userid, nickName, TotalScore, KillScore, Gold, CrystalPt, GameVersion);
    }

    public void writeNewUser(string userid, string nickName, string TotalScore, string KillScore, string Gold, string CrystalPt, string GameVersion)
    {
        userid = nowPlayer.UID;
        //userid = FirebaseManager.Instance.UserId;
        //nowPlayer.UID = userid;
        nickName = nowPlayer.name;
        //string TotalScoreFomat = string.Format("{0:#,0}", nowPlayer.TotalScore);
        //TotalScore = TotalScoreFomat;
        TotalScore = nowPlayer.TotalScore.ToString();
        KillScore = nowPlayer.monsterKill.ToString();
        Gold = nowPlayer.gold.ToString();
        CrystalPt = nowPlayer.CrystalPoint.ToString();
        GameVersion = Application.version;
        //itemoption0 = nowPlayer.option0.Select(i => i.ToString()).ToArray();   배열 저장법

        User user = new User(userid, nickName, TotalScore, KillScore, Gold, CrystalPt, GameVersion/*, itemoption0*/);
        string jsonData = JsonUtility.ToJson(user);

        databaseReference.Child("Users").Child(userid).SetRawJsonValueAsync(jsonData);

        //text.text = "저장";
    }

    public void OnClickLoadButton()
    {
        readUser(userid);
    }

    public void readUser(string userid)
    {
        //userid = FirebaseManager.Instance.UserId;

        databaseReference.Child("Users").Child(userid).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("로드 취소");
            }
            else if (task.IsFaulted)
            {
                Debug.Log("로드 실패");
            }
            else
            {
                DataSnapshot dataSnapshot = task.Result;

                int count = 0;
                strLen = dataSnapshot.ChildrenCount;
                strRank = new string[strLen];
                //strUserid = new string[strLen];

                Debug.Log(dataSnapshot.ChildrenCount);

                //string dataString = "";
                foreach (DataSnapshot data in dataSnapshot.Children)
                {
                    IDictionary personInfo = (IDictionary)data.Value;
                    //dataString += data.Key + " " + data.Value + "\n";
                    strRank[count] = personInfo["nickName"].ToString() + " . " + personInfo["userid"].ToString() + " | " + string.Format("{0:N2}", personInfo["TotalScore"]);
                    //strUserid[count] = personInfo["userid"].ToString() + "_";
                    //Debug.Log("nickName: " + personInfo["nickName"] + ", TotalScore: " + personInfo["TotalScore"] + ", Userid: " + personInfo["userid"]);
                    count++;
                }
                textLoadBool = true;
                //Debug.Log(dataString);    

            }
        });
    }
    void TextLoad()
    {
        textLoadBool = false;
        try
        {
            //받아온 데이터 정렬 = > 위에서부터 아래로
            /*
            Array.Sort(strRank, (x, y) => string.Compare(
            y.Substring(y.Length - 5, 5).ToString() + x.Substring(x.Length - 5, 5).ToString(),
            x.Substring(x.Length - 5, 5).ToString() + y.Substring(y.Length - 5, 5).ToString()));
            */
            Array.Sort(strRank, (x, y) =>
            {
                int xNum = int.Parse(x.Substring(x.IndexOf('|') + 2));
                int yNum = int.Parse(y.Substring(y.IndexOf('|') + 2));
                return xNum.CompareTo(yNum);
            });

            Array.Reverse(strRank);
        }
        catch (NullReferenceException e)
        {
            return;
        }

        for (int i = 0; i < Nick.Length; i++)
        {
            //Text UI 에 현재 가지고있는 str 길이 까지만 보여주기 위함.
            if (strLen <= i) return;
            //Nick[i].text = strRank[i];

            //rank.Slots[i].UserId = strUserid[i].Substring(0, strUserid[i].LastIndexOf('_'));
            //rank.Slots[i].rank.name = strRank[i].Substring(0, strRank[i].LastIndexOf('_'));
            Nick[i].text = strRank[i].Substring(0, strRank[i].LastIndexOf('.') - 1);
            //Nick[i].text = strRank[i].Substring(strRank[i].LastIndexOf('.')+2, 28);
            //rank.Slots[i].rank.Score = strRank[i].Substring(strRank[i].IndexOf('_')+1);
            scoreComma[i] = strRank[i].Substring(strRank[i].IndexOf('|') + 2);
            intScore[i] = int.Parse(scoreComma[i]);
            Comma[i] = string.Format("{0:#,0}", intScore[i]);
            Score[i].text = Comma[i];
            //Score[i].text = strRank[i].Substring(strRank[i].IndexOf('|')+2);
        }
    }
    // 닉네임 중복 체크

    public void nicknameCheking()
    {
        FirebaseDatabase.DefaultInstance.GetReference(userid).Child("Users").OrderByChild("nickName").EqualTo(DataManager.instance.nowPlayer.name).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // 에러 처리
                Debug.Log("에러남");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    // 중복된 데이터가 존재함
                    Debug.Log("중복됨");
                    nameChecking = false;
                }
                else
                {
                    // 중복된 데이터가 없음
                    Debug.Log("중복 안됨");
                    nameChecking = true;
                }
            }
        });

    }

    public string ver;

    public void VersionChecking()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Version").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("실패");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log(snapshot.Value);
                ver = snapshot.Value.ToString();
            }
        });
    }
}
///////////////////////////////////////////////////////////////////////////////////////////
