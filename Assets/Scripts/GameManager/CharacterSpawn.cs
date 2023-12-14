using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using EZInventory;

public class CharacterSpawn : MonoBehaviour
{
    public GameObject[] charprefabs;
    public GameObject player;
    public InventoryObject Inven;
    public InventoryObject EquipInven;
    public InventoryObject materialInven;
    public Text gold; public Text RubbyPoint; public Text CrystalPoint; public Text KillPoint; public Text PowerPoint;
    public Stat stat;
    public SkillObject _skill;
    string goldFomat;
    string RubbyFormat;
    string CrystalFormat;
    string KillFomat;
    string PowerPointFomat;
    public GameObject PlayerParent;
    public int preGoldAmount; public int preKillAmount; public int prePowerAmount;



    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        DataManager.instance.audioSource.volume = 0.1f;
        DataManager.instance.LoadData();
        // player = Instantiate(charprefabs[(int)CharacterDataManager.instance.SelectedCharacter]);        
        player = Instantiate(charprefabs[(int)DataManager.instance.nowPlayer.SelectedCharacter]);
        player.transform.SetParent(PlayerParent.transform);
        player.name = "Player";
        player.transform.position = transform.position;
        goldFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.gold);
        gold.text = goldFomat;    //DataManager.instance.nowPlayer.gold.ToString();
        RubbyFormat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.RubbyPoint);
        RubbyPoint.text = RubbyFormat;    //DataManager.instance.nowPlayer.RubbyPoint.ToString();
        CrystalFormat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.CrystalPoint);
        CrystalPoint.text = CrystalFormat;    //DataManager.instance.nowPlayer.CrystalPoint.ToString();
        KillFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.monsterKill);
        KillPoint.text = KillFomat;
        PowerPointFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.TotalScore);
        PowerPoint.text = PowerPointFomat;
        DataManager.instance.nowPlayer.howManyPlay++;
        Statload();
        SkillLoad();
        Calcurate();
        if (DataManager.instance.nowPlayer.Level != 0)
        {
            //DataManager.instance.ClearInventory();
            LoadPlayerData();
        }
        else
        {
            DataManager.instance.ClearInventory();
            DataManager.instance.AddNewEquipItem(0);
            DataManager.instance.AddNewEquipItem(1);
            DataManager.instance.AddNewEquipItem(2);
            DataManager.instance.AddNewEquipItem(3);
            DataManager.instance.AddNewEquipItem(4);
            DataManager.instance.nowPlayer.Level++;
            DataManager.instance.nowPlayer.gold += 100000;
            DataManager.instance.nowPlayer.RubbyPoint += 5000;
            DataManager.instance.nowPlayer.CrystalPoint += 1000;
        }
        //DataManager.instance.EXPandHP();
        stat.curHP = stat.maxHP;
        stat.curMP = stat.maxMP;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
       

    private void Update()
    {
            goldFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.gold);
            gold.text = goldFomat;
            KillFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.monsterKill);
            KillPoint.text = KillFomat;
            PowerPointFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.TotalScore);
            PowerPoint.text = PowerPointFomat;
    }

    void LoadPlayerData()
    {
        for (int i = 0; i < 30; i++)
        {

            {
                Inven.Slots[i].item.id = DataManager.instance.nowPlayer.itemId[i];
                Inven.Slots[i].item.name = DataManager.instance.nowPlayer.itemname[i];
                Inven.Slots[i].amount = DataManager.instance.nowPlayer.amount[i];
            }
        }
        for (int i = 0; i < 5; i++)
        {

            {
                EquipInven.Slots[i].item.id = DataManager.instance.nowPlayer.EquipItemID[i];
                EquipInven.Slots[i].item.name = DataManager.instance.nowPlayer.EquipItemName[i];
                EquipInven.Slots[i].amount = DataManager.instance.nowPlayer.EquipItemAmount[i];
            }
        }
        RecipeInvenLoad();
        optionload();
        optionvalueload();
        Equipoptionload();
        Equipoptionvalueload();      

        Calcurate();
    }

    void optionload()
    {
        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option0[i] == 0) { Inven.Slots[i].item.buffs[0].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option0[i] == 1) { Inven.Slots[i].item.buffs[0].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option0[i] == 2) { Inven.Slots[i].item.buffs[0].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option0[i] == 3) { Inven.Slots[i].item.buffs[0].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option0[i] == 4) { Inven.Slots[i].item.buffs[0].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option0[i] == 5) { Inven.Slots[i].item.buffs[0].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option0[i] == 6) { Inven.Slots[i].item.buffs[0].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option0[i] == 7) { Inven.Slots[i].item.buffs[0].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option0[i] == 8) { Inven.Slots[i].item.buffs[0].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option0[i] == 9) { Inven.Slots[i].item.buffs[0].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option0[i] == 10) { Inven.Slots[i].item.buffs[0].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option0[i] == 11) { Inven.Slots[i].item.buffs[0].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option0[i] == 12) { Inven.Slots[i].item.buffs[0].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option0[i] == 13) { Inven.Slots[i].item.buffs[0].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option0[i] == 14) { Inven.Slots[i].item.buffs[0].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option0[i] == 15) { Inven.Slots[i].item.buffs[0].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option0[i] == 16) { Inven.Slots[i].item.buffs[0].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option0[i] == 17) { Inven.Slots[i].item.buffs[0].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option0[i] == 18) { Inven.Slots[i].item.buffs[0].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option0[i] == 19) { Inven.Slots[i].item.buffs[0].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option0[i] == 20) { Inven.Slots[i].item.buffs[0].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option0[i] == 21) { Inven.Slots[i].item.buffs[0].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option0[i] == 22) { Inven.Slots[i].item.buffs[0].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option0[i] == 23) { Inven.Slots[i].item.buffs[0].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option1[i] == 0) { Inven.Slots[i].item.buffs[1].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option1[i] == 1) { Inven.Slots[i].item.buffs[1].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option1[i] == 2) { Inven.Slots[i].item.buffs[1].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option1[i] == 3) { Inven.Slots[i].item.buffs[1].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option1[i] == 4) { Inven.Slots[i].item.buffs[1].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option1[i] == 5) { Inven.Slots[i].item.buffs[1].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option1[i] == 6) { Inven.Slots[i].item.buffs[1].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option1[i] == 7) { Inven.Slots[i].item.buffs[1].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option1[i] == 8) { Inven.Slots[i].item.buffs[1].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option1[i] == 9) { Inven.Slots[i].item.buffs[1].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option1[i] == 10) { Inven.Slots[i].item.buffs[1].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option1[i] == 11) { Inven.Slots[i].item.buffs[1].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option1[i] == 12) { Inven.Slots[i].item.buffs[1].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option1[i] == 13) { Inven.Slots[i].item.buffs[1].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option1[i] == 14) { Inven.Slots[i].item.buffs[1].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option1[i] == 15) { Inven.Slots[i].item.buffs[1].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option1[i] == 16) { Inven.Slots[i].item.buffs[1].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option1[i] == 17) { Inven.Slots[i].item.buffs[1].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option1[i] == 18) { Inven.Slots[i].item.buffs[1].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option1[i] == 19) { Inven.Slots[i].item.buffs[1].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option1[i] == 20) { Inven.Slots[i].item.buffs[1].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option1[i] == 21) { Inven.Slots[i].item.buffs[1].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option1[i] == 22) { Inven.Slots[i].item.buffs[1].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option1[i] == 23) { Inven.Slots[i].item.buffs[1].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option2[i] == 0) { Inven.Slots[i].item.buffs[2].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option2[i] == 1) { Inven.Slots[i].item.buffs[2].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option2[i] == 2) { Inven.Slots[i].item.buffs[2].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option2[i] == 3) { Inven.Slots[i].item.buffs[2].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option2[i] == 4) { Inven.Slots[i].item.buffs[2].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option2[i] == 5) { Inven.Slots[i].item.buffs[2].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option2[i] == 6) { Inven.Slots[i].item.buffs[2].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option2[i] == 7) { Inven.Slots[i].item.buffs[2].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option2[i] == 8) { Inven.Slots[i].item.buffs[2].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option2[i] == 9) { Inven.Slots[i].item.buffs[2].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option2[i] == 10) { Inven.Slots[i].item.buffs[2].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option2[i] == 11) { Inven.Slots[i].item.buffs[2].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option2[i] == 12) { Inven.Slots[i].item.buffs[2].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option2[i] == 13) { Inven.Slots[i].item.buffs[2].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option2[i] == 14) { Inven.Slots[i].item.buffs[2].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option2[i] == 15) { Inven.Slots[i].item.buffs[2].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option2[i] == 16) { Inven.Slots[i].item.buffs[2].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option2[i] == 17) { Inven.Slots[i].item.buffs[2].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option2[i] == 18) { Inven.Slots[i].item.buffs[2].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option2[i] == 19) { Inven.Slots[i].item.buffs[2].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option2[i] == 20) { Inven.Slots[i].item.buffs[2].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option2[i] == 21) { Inven.Slots[i].item.buffs[2].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option2[i] == 22) { Inven.Slots[i].item.buffs[2].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option2[i] == 23) { Inven.Slots[i].item.buffs[2].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option3[i] == 0) { Inven.Slots[i].item.buffs[3].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option3[i] == 1) { Inven.Slots[i].item.buffs[3].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option3[i] == 2) { Inven.Slots[i].item.buffs[3].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option3[i] == 3) { Inven.Slots[i].item.buffs[3].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option3[i] == 4) { Inven.Slots[i].item.buffs[3].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option3[i] == 5) { Inven.Slots[i].item.buffs[3].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option3[i] == 6) { Inven.Slots[i].item.buffs[3].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option3[i] == 7) { Inven.Slots[i].item.buffs[3].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option3[i] == 8) { Inven.Slots[i].item.buffs[3].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option3[i] == 9) { Inven.Slots[i].item.buffs[3].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option3[i] == 10) { Inven.Slots[i].item.buffs[3].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option3[i] == 11) { Inven.Slots[i].item.buffs[3].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option3[i] == 12) { Inven.Slots[i].item.buffs[3].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option3[i] == 13) { Inven.Slots[i].item.buffs[3].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option3[i] == 14) { Inven.Slots[i].item.buffs[3].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option3[i] == 15) { Inven.Slots[i].item.buffs[3].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option3[i] == 16) { Inven.Slots[i].item.buffs[3].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option3[i] == 17) { Inven.Slots[i].item.buffs[3].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option3[i] == 18) { Inven.Slots[i].item.buffs[3].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option3[i] == 19) { Inven.Slots[i].item.buffs[3].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option3[i] == 20) { Inven.Slots[i].item.buffs[3].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option3[i] == 21) { Inven.Slots[i].item.buffs[3].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option3[i] == 22) { Inven.Slots[i].item.buffs[3].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option3[i] == 23) { Inven.Slots[i].item.buffs[3].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option4[i] == 0) { Inven.Slots[i].item.buffs[4].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option4[i] == 1) { Inven.Slots[i].item.buffs[4].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option4[i] == 2) { Inven.Slots[i].item.buffs[4].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option4[i] == 3) { Inven.Slots[i].item.buffs[4].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option4[i] == 4) { Inven.Slots[i].item.buffs[4].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option4[i] == 5) { Inven.Slots[i].item.buffs[4].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option4[i] == 6) { Inven.Slots[i].item.buffs[4].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option4[i] == 7) { Inven.Slots[i].item.buffs[4].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option4[i] == 8) { Inven.Slots[i].item.buffs[4].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option4[i] == 9) { Inven.Slots[i].item.buffs[4].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option4[i] == 10) { Inven.Slots[i].item.buffs[4].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option4[i] == 11) { Inven.Slots[i].item.buffs[4].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option4[i] == 12) { Inven.Slots[i].item.buffs[4].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option4[i] == 13) { Inven.Slots[i].item.buffs[4].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option4[i] == 14) { Inven.Slots[i].item.buffs[4].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option4[i] == 15) { Inven.Slots[i].item.buffs[4].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option4[i] == 16) { Inven.Slots[i].item.buffs[4].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option4[i] == 17) { Inven.Slots[i].item.buffs[4].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option4[i] == 18) { Inven.Slots[i].item.buffs[4].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option4[i] == 19) { Inven.Slots[i].item.buffs[4].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option4[i] == 20) { Inven.Slots[i].item.buffs[4].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option4[i] == 21) { Inven.Slots[i].item.buffs[4].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option4[i] == 22) { Inven.Slots[i].item.buffs[4].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option4[i] == 23) { Inven.Slots[i].item.buffs[4].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option5[i] == 0) { Inven.Slots[i].item.buffs[5].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option5[i] == 1) { Inven.Slots[i].item.buffs[5].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option5[i] == 2) { Inven.Slots[i].item.buffs[5].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option5[i] == 3) { Inven.Slots[i].item.buffs[5].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option5[i] == 4) { Inven.Slots[i].item.buffs[5].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option5[i] == 5) { Inven.Slots[i].item.buffs[5].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option5[i] == 6) { Inven.Slots[i].item.buffs[5].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option5[i] == 7) { Inven.Slots[i].item.buffs[5].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option5[i] == 8) { Inven.Slots[i].item.buffs[5].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option5[i] == 9) { Inven.Slots[i].item.buffs[5].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option5[i] == 10) { Inven.Slots[i].item.buffs[5].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option5[i] == 11) { Inven.Slots[i].item.buffs[5].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option5[i] == 12) { Inven.Slots[i].item.buffs[5].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option5[i] == 13) { Inven.Slots[i].item.buffs[5].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option5[i] == 14) { Inven.Slots[i].item.buffs[5].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option5[i] == 15) { Inven.Slots[i].item.buffs[5].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option5[i] == 16) { Inven.Slots[i].item.buffs[5].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option5[i] == 17) { Inven.Slots[i].item.buffs[5].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option5[i] == 18) { Inven.Slots[i].item.buffs[5].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option5[i] == 19) { Inven.Slots[i].item.buffs[5].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option5[i] == 20) { Inven.Slots[i].item.buffs[5].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option5[i] == 21) { Inven.Slots[i].item.buffs[5].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option5[i] == 22) { Inven.Slots[i].item.buffs[5].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option5[i] == 23) { Inven.Slots[i].item.buffs[5].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option6[i] == 0) { Inven.Slots[i].item.buffs[6].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option6[i] == 1) { Inven.Slots[i].item.buffs[6].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option6[i] == 2) { Inven.Slots[i].item.buffs[6].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option6[i] == 3) { Inven.Slots[i].item.buffs[6].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option6[i] == 4) { Inven.Slots[i].item.buffs[6].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option6[i] == 5) { Inven.Slots[i].item.buffs[6].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option6[i] == 6) { Inven.Slots[i].item.buffs[6].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option6[i] == 7) { Inven.Slots[i].item.buffs[6].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option6[i] == 8) { Inven.Slots[i].item.buffs[6].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option6[i] == 9) { Inven.Slots[i].item.buffs[6].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option6[i] == 10) { Inven.Slots[i].item.buffs[6].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option6[i] == 11) { Inven.Slots[i].item.buffs[6].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option6[i] == 12) { Inven.Slots[i].item.buffs[6].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option6[i] == 13) { Inven.Slots[i].item.buffs[6].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option6[i] == 14) { Inven.Slots[i].item.buffs[6].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option6[i] == 15) { Inven.Slots[i].item.buffs[6].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option6[i] == 16) { Inven.Slots[i].item.buffs[6].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option6[i] == 17) { Inven.Slots[i].item.buffs[6].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option6[i] == 18) { Inven.Slots[i].item.buffs[6].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option6[i] == 19) { Inven.Slots[i].item.buffs[6].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option6[i] == 20) { Inven.Slots[i].item.buffs[6].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option6[i] == 21) { Inven.Slots[i].item.buffs[6].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option6[i] == 22) { Inven.Slots[i].item.buffs[6].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option6[i] == 23) { Inven.Slots[i].item.buffs[6].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option7[i] == 0) { Inven.Slots[i].item.buffs[7].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option7[i] == 1) { Inven.Slots[i].item.buffs[7].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option7[i] == 2) { Inven.Slots[i].item.buffs[7].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option7[i] == 3) { Inven.Slots[i].item.buffs[7].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option7[i] == 4) { Inven.Slots[i].item.buffs[7].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option7[i] == 5) { Inven.Slots[i].item.buffs[7].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option7[i] == 6) { Inven.Slots[i].item.buffs[7].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option7[i] == 7) { Inven.Slots[i].item.buffs[7].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option7[i] == 8) { Inven.Slots[i].item.buffs[7].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option7[i] == 9) { Inven.Slots[i].item.buffs[7].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option7[i] == 10) { Inven.Slots[i].item.buffs[7].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option7[i] == 11) { Inven.Slots[i].item.buffs[7].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option7[i] == 12) { Inven.Slots[i].item.buffs[7].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option7[i] == 13) { Inven.Slots[i].item.buffs[7].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option7[i] == 14) { Inven.Slots[i].item.buffs[7].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option7[i] == 15) { Inven.Slots[i].item.buffs[7].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option7[i] == 16) { Inven.Slots[i].item.buffs[7].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option7[i] == 17) { Inven.Slots[i].item.buffs[7].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option7[i] == 18) { Inven.Slots[i].item.buffs[7].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option7[i] == 19) { Inven.Slots[i].item.buffs[7].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option7[i] == 20) { Inven.Slots[i].item.buffs[7].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option7[i] == 21) { Inven.Slots[i].item.buffs[7].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option7[i] == 22) { Inven.Slots[i].item.buffs[7].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option7[i] == 23) { Inven.Slots[i].item.buffs[7].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option8[i] == 0) { Inven.Slots[i].item.buffs[8].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option8[i] == 1) { Inven.Slots[i].item.buffs[8].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option8[i] == 2) { Inven.Slots[i].item.buffs[8].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option8[i] == 3) { Inven.Slots[i].item.buffs[8].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option8[i] == 4) { Inven.Slots[i].item.buffs[8].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option8[i] == 5) { Inven.Slots[i].item.buffs[8].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option8[i] == 6) { Inven.Slots[i].item.buffs[8].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option8[i] == 7) { Inven.Slots[i].item.buffs[8].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option8[i] == 8) { Inven.Slots[i].item.buffs[8].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option8[i] == 9) { Inven.Slots[i].item.buffs[8].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option8[i] == 10) { Inven.Slots[i].item.buffs[8].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option8[i] == 11) { Inven.Slots[i].item.buffs[8].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option8[i] == 12) { Inven.Slots[i].item.buffs[8].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option8[i] == 13) { Inven.Slots[i].item.buffs[8].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option8[i] == 14) { Inven.Slots[i].item.buffs[8].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option8[i] == 15) { Inven.Slots[i].item.buffs[8].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option8[i] == 16) { Inven.Slots[i].item.buffs[8].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option8[i] == 17) { Inven.Slots[i].item.buffs[8].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option8[i] == 18) { Inven.Slots[i].item.buffs[8].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option8[i] == 19) { Inven.Slots[i].item.buffs[8].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option8[i] == 20) { Inven.Slots[i].item.buffs[8].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option8[i] == 21) { Inven.Slots[i].item.buffs[8].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option8[i] == 22) { Inven.Slots[i].item.buffs[8].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option8[i] == 23) { Inven.Slots[i].item.buffs[8].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option9[i] == 0) { Inven.Slots[i].item.buffs[9].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option9[i] == 1) { Inven.Slots[i].item.buffs[9].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option9[i] == 2) { Inven.Slots[i].item.buffs[9].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option9[i] == 3) { Inven.Slots[i].item.buffs[9].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option9[i] == 4) { Inven.Slots[i].item.buffs[9].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option9[i] == 5) { Inven.Slots[i].item.buffs[9].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option9[i] == 6) { Inven.Slots[i].item.buffs[9].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option9[i] == 7) { Inven.Slots[i].item.buffs[9].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option9[i] == 8) { Inven.Slots[i].item.buffs[9].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option9[i] == 9) { Inven.Slots[i].item.buffs[9].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option9[i] == 10) { Inven.Slots[i].item.buffs[9].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option9[i] == 11) { Inven.Slots[i].item.buffs[9].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option9[i] == 12) { Inven.Slots[i].item.buffs[9].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option9[i] == 13) { Inven.Slots[i].item.buffs[9].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option9[i] == 14) { Inven.Slots[i].item.buffs[9].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option9[i] == 15) { Inven.Slots[i].item.buffs[9].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option9[i] == 16) { Inven.Slots[i].item.buffs[9].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option9[i] == 17) { Inven.Slots[i].item.buffs[9].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option9[i] == 18) { Inven.Slots[i].item.buffs[9].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option9[i] == 19) { Inven.Slots[i].item.buffs[9].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option9[i] == 20) { Inven.Slots[i].item.buffs[9].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option9[i] == 21) { Inven.Slots[i].item.buffs[9].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option9[i] == 22) { Inven.Slots[i].item.buffs[9].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option9[i] == 23) { Inven.Slots[i].item.buffs[9].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option10[i] == 0) { Inven.Slots[i].item.buffs[10].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option10[i] == 1) { Inven.Slots[i].item.buffs[10].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option10[i] == 2) { Inven.Slots[i].item.buffs[10].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option10[i] == 3) { Inven.Slots[i].item.buffs[10].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option10[i] == 4) { Inven.Slots[i].item.buffs[10].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option10[i] == 5) { Inven.Slots[i].item.buffs[10].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option10[i] == 6) { Inven.Slots[i].item.buffs[10].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option10[i] == 7) { Inven.Slots[i].item.buffs[10].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option10[i] == 8) { Inven.Slots[i].item.buffs[10].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option10[i] == 9) { Inven.Slots[i].item.buffs[10].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option10[i] == 10) { Inven.Slots[i].item.buffs[10].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option10[i] == 11) { Inven.Slots[i].item.buffs[10].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option10[i] == 12) { Inven.Slots[i].item.buffs[10].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option10[i] == 13) { Inven.Slots[i].item.buffs[10].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option10[i] == 14) { Inven.Slots[i].item.buffs[10].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option10[i] == 15) { Inven.Slots[i].item.buffs[10].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option10[i] == 16) { Inven.Slots[i].item.buffs[10].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option10[i] == 17) { Inven.Slots[i].item.buffs[10].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option10[i] == 18) { Inven.Slots[i].item.buffs[10].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option10[i] == 19) { Inven.Slots[i].item.buffs[10].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option10[i] == 20) { Inven.Slots[i].item.buffs[10].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option10[i] == 21) { Inven.Slots[i].item.buffs[10].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option10[i] == 22) { Inven.Slots[i].item.buffs[10].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option10[i] == 23) { Inven.Slots[i].item.buffs[10].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option11[i] == 0) { Inven.Slots[i].item.buffs[11].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option11[i] == 1) { Inven.Slots[i].item.buffs[11].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option11[i] == 2) { Inven.Slots[i].item.buffs[11].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option11[i] == 3) { Inven.Slots[i].item.buffs[11].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option11[i] == 4) { Inven.Slots[i].item.buffs[11].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option11[i] == 5) { Inven.Slots[i].item.buffs[11].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option11[i] == 6) { Inven.Slots[i].item.buffs[11].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option11[i] == 7) { Inven.Slots[i].item.buffs[11].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option11[i] == 8) { Inven.Slots[i].item.buffs[11].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option11[i] == 9) { Inven.Slots[i].item.buffs[11].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option11[i] == 10) { Inven.Slots[i].item.buffs[11].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option11[i] == 11) { Inven.Slots[i].item.buffs[11].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option11[i] == 12) { Inven.Slots[i].item.buffs[11].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option11[i] == 13) { Inven.Slots[i].item.buffs[11].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option11[i] == 14) { Inven.Slots[i].item.buffs[11].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option11[i] == 15) { Inven.Slots[i].item.buffs[11].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option11[i] == 16) { Inven.Slots[i].item.buffs[11].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option11[i] == 17) { Inven.Slots[i].item.buffs[11].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option11[i] == 18) { Inven.Slots[i].item.buffs[11].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option11[i] == 19) { Inven.Slots[i].item.buffs[11].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option11[i] == 20) { Inven.Slots[i].item.buffs[11].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option11[i] == 21) { Inven.Slots[i].item.buffs[11].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option11[i] == 22) { Inven.Slots[i].item.buffs[11].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option11[i] == 23) { Inven.Slots[i].item.buffs[11].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 60; i++)
        {
            if (DataManager.instance.nowPlayer.option12[i] == 0) { Inven.Slots[i].item.buffs[12].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.option12[i] == 1) { Inven.Slots[i].item.buffs[12].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.option12[i] == 2) { Inven.Slots[i].item.buffs[12].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.option12[i] == 3) { Inven.Slots[i].item.buffs[12].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.option12[i] == 4) { Inven.Slots[i].item.buffs[12].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.option12[i] == 5) { Inven.Slots[i].item.buffs[12].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.option12[i] == 6) { Inven.Slots[i].item.buffs[12].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.option12[i] == 7) { Inven.Slots[i].item.buffs[12].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.option12[i] == 8) { Inven.Slots[i].item.buffs[12].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.option12[i] == 9) { Inven.Slots[i].item.buffs[12].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.option12[i] == 10) { Inven.Slots[i].item.buffs[12].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.option12[i] == 11) { Inven.Slots[i].item.buffs[12].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.option12[i] == 12) { Inven.Slots[i].item.buffs[12].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.option12[i] == 13) { Inven.Slots[i].item.buffs[12].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.option12[i] == 14) { Inven.Slots[i].item.buffs[12].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.option12[i] == 15) { Inven.Slots[i].item.buffs[12].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.option12[i] == 16) { Inven.Slots[i].item.buffs[12].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.option12[i] == 17) { Inven.Slots[i].item.buffs[12].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.option12[i] == 18) { Inven.Slots[i].item.buffs[12].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.option12[i] == 19) { Inven.Slots[i].item.buffs[12].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.option12[i] == 20) { Inven.Slots[i].item.buffs[12].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.option12[i] == 21) { Inven.Slots[i].item.buffs[12].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.option12[i] == 22) { Inven.Slots[i].item.buffs[12].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.option12[i] == 23) { Inven.Slots[i].item.buffs[12].stat = Itemoption.Nothing; }
        }
    }
    void optionvalueload()
    {
        for (int i = 0; i < 60; i++)
        {

            Inven.Slots[i].item.buffs[0].value = DataManager.instance.nowPlayer.optionValue0[i];
            Inven.Slots[i].item.buffs[1].value = DataManager.instance.nowPlayer.optionValue1[i];
            Inven.Slots[i].item.buffs[2].value = DataManager.instance.nowPlayer.optionValue2[i];
            Inven.Slots[i].item.buffs[3].value = DataManager.instance.nowPlayer.optionValue3[i];
            Inven.Slots[i].item.buffs[4].value = DataManager.instance.nowPlayer.optionValue4[i];
            Inven.Slots[i].item.buffs[5].value = DataManager.instance.nowPlayer.optionValue5[i];
            Inven.Slots[i].item.buffs[6].value = DataManager.instance.nowPlayer.optionValue6[i];
            Inven.Slots[i].item.buffs[7].value = DataManager.instance.nowPlayer.optionValue7[i];
            Inven.Slots[i].item.buffs[8].value = DataManager.instance.nowPlayer.optionValue8[i];
            Inven.Slots[i].item.buffs[9].value = DataManager.instance.nowPlayer.optionValue9[i];
            Inven.Slots[i].item.buffs[10].value = DataManager.instance.nowPlayer.optionValue10[i];
            Inven.Slots[i].item.buffs[11].value = DataManager.instance.nowPlayer.optionValue11[i];
            Inven.Slots[i].item.buffs[12].value = DataManager.instance.nowPlayer.optionValue12[i];

        }
    }


    void Equipoptionload()
    {
        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 0) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 1) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 2) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 3) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 4) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 5) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 6) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 7) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 8) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 9) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 10) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 11) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 12) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 13) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 14) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 15) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 16) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 17) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 18) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 19) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 20) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 21) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 22) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption0[i] == 23) { EquipInven.Slots[i].item.buffs[0].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 0) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 1) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 2) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 3) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 4) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 5) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 6) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 7) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 8) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 9) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 10) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 11) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 12) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 13) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 14) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 15) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 16) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 17) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 18) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 19) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 20) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 21) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 22) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption1[i] == 23) { EquipInven.Slots[i].item.buffs[1].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 0) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 1) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 2) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 3) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 4) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 5) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 6) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 7) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 8) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 9) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 10) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 11) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 12) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 13) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 14) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 15) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 16) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 17) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 18) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 19) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 20) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 21) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 22) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption2[i] == 23) { EquipInven.Slots[i].item.buffs[2].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 0) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 1) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 2) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 3) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 4) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 5) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 6) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 7) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 8) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 9) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 10) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 11) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 12) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 13) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 14) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 15) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 16) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 17) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 18) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 19) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 20) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 21) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 22) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption3[i] == 23) { EquipInven.Slots[i].item.buffs[3].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 0) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 1) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 2) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 3) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 4) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 5) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 6) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 7) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 8) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 9) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 10) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 11) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 12) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 13) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 14) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 15) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 16) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 17) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 18) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 19) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 20) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 21) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 22) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption4[i] == 23) { EquipInven.Slots[i].item.buffs[4].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 0) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 1) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 2) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 3) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 4) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 5) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 6) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 7) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 8) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 9) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 10) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 11) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 12) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 13) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 14) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 15) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 16) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 17) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 18) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 19) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 20) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 21) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 22) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption5[i] == 23) { EquipInven.Slots[i].item.buffs[5].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 0) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 1) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 2) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 3) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 4) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 5) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 6) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 7) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 8) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 9) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 10) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 11) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 12) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 13) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 14) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 15) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 16) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 17) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 18) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 19) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 20) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 21) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 22) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption6[i] == 23) { EquipInven.Slots[i].item.buffs[6].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 0) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 1) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 2) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 3) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 4) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 5) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 6) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 7) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 8) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 9) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 10) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 11) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 12) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 13) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 14) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 15) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 16) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 17) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 18) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 19) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 20) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 21) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 22) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption7[i] == 23) { EquipInven.Slots[i].item.buffs[7].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 0) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 1) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 2) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 3) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 4) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 5) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 6) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 7) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 8) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 9) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 10) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 11) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 12) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 13) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 14) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 15) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 16) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 17) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 18) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 19) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 20) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 21) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 22) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption8[i] == 23) { EquipInven.Slots[i].item.buffs[8].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 0) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 1) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 2) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 3) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 4) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 5) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 6) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 7) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 8) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 9) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 10) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 11) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 12) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 13) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 14) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 15) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 16) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 17) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 18) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 19) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 20) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 21) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 22) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption9[i] == 23) { EquipInven.Slots[i].item.buffs[9].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 0) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 1) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 2) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 3) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 4) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 5) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 6) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 7) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 8) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 9) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 10) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 11) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 12) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 13) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 14) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 15) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 16) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 17) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 18) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 19) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 20) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 21) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 22) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption10[i] == 23) { EquipInven.Slots[i].item.buffs[10].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 0) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 1) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 2) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 3) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 4) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 5) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 6) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 7) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 8) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 9) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 10) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 11) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 12) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 13) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 14) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 15) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 16) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 17) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 18) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 19) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 20) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 21) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 22) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption11[i] == 23) { EquipInven.Slots[i].item.buffs[11].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 0) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 1) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 2) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 3) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 4) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 5) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 6) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 7) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 8) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 9) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 10) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 11) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 12) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 13) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 14) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 15) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 16) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 17) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 18) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 19) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 20) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 21) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 22) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.EquipItemoption12[i] == 23) { EquipInven.Slots[i].item.buffs[12].stat = Itemoption.Nothing; }
        }
    }
    void Equipoptionvalueload()
    {
        for (int i = 0; i < 5; i++)
        {

            EquipInven.Slots[i].item.buffs[0].value = DataManager.instance.nowPlayer.EquipItemoptionValue0[i];
            EquipInven.Slots[i].item.buffs[1].value = DataManager.instance.nowPlayer.EquipItemoptionValue1[i];
            EquipInven.Slots[i].item.buffs[2].value = DataManager.instance.nowPlayer.EquipItemoptionValue2[i];
            EquipInven.Slots[i].item.buffs[3].value = DataManager.instance.nowPlayer.EquipItemoptionValue3[i];
            EquipInven.Slots[i].item.buffs[4].value = DataManager.instance.nowPlayer.EquipItemoptionValue4[i];
            EquipInven.Slots[i].item.buffs[5].value = DataManager.instance.nowPlayer.EquipItemoptionValue5[i];
            EquipInven.Slots[i].item.buffs[6].value = DataManager.instance.nowPlayer.EquipItemoptionValue6[i];
            EquipInven.Slots[i].item.buffs[7].value = DataManager.instance.nowPlayer.EquipItemoptionValue7[i];
            EquipInven.Slots[i].item.buffs[8].value = DataManager.instance.nowPlayer.EquipItemoptionValue8[i];
            EquipInven.Slots[i].item.buffs[9].value = DataManager.instance.nowPlayer.EquipItemoptionValue9[i];
            EquipInven.Slots[i].item.buffs[10].value = DataManager.instance.nowPlayer.EquipItemoptionValue10[i];
            EquipInven.Slots[i].item.buffs[11].value = DataManager.instance.nowPlayer.EquipItemoptionValue11[i];
            EquipInven.Slots[i].item.buffs[12].value = DataManager.instance.nowPlayer.EquipItemoptionValue12[i];

        }
    }


    void materialoptionload()
    {
        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption0[i] == 0) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 1) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 2) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 3) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 4) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 5) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 6) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 7) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 8) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 9) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 10) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 11) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 12) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 13) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 14) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 15) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 16) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 17) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 18) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 19) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 20) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 21) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 22) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption0[i] == 23) { materialInven.Slots[i].item.buffs[0].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption1[i] == 0) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 1) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 2) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 3) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 4) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 5) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 6) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 7) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 8) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 9) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 10) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 11) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 12) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 13) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 14) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 15) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 16) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 17) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 18) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 19) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 20) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 21) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 22) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption1[i] == 23) { materialInven.Slots[i].item.buffs[1].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption2[i] == 0) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 1) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 2) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 3) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 4) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 5) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 6) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 7) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 8) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 9) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 10) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 11) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 12) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 13) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 14) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 15) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 16) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 17) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 18) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 19) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 20) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 21) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 22) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption2[i] == 23) { materialInven.Slots[i].item.buffs[2].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption3[i] == 0) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 1) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 2) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 3) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 4) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 5) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 6) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 7) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 8) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 9) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 10) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 11) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 12) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 13) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 14) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 15) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 16) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 17) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 18) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 19) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 20) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 21) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 22) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption3[i] == 23) { materialInven.Slots[i].item.buffs[3].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption4[i] == 0) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 1) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 2) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 3) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 4) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 5) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 6) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 7) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 8) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 9) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 10) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 11) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 12) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 13) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 14) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 15) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 16) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 17) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 18) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 19) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 20) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 21) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 22) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption4[i] == 23) { materialInven.Slots[i].item.buffs[4].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption5[i] == 0) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 1) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 2) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 3) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 4) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 5) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 6) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 7) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 8) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 9) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 10) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 11) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 12) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 13) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 14) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 15) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 16) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 17) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 18) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 19) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 20) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 21) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 22) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption5[i] == 23) { materialInven.Slots[i].item.buffs[5].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption6[i] == 0) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 1) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 2) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 3) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 4) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 5) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 6) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 7) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 8) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 9) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 10) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 11) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 12) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 13) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 14) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 15) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 16) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 17) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 18) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 19) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 20) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 21) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 22) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption6[i] == 23) { materialInven.Slots[i].item.buffs[6].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption7[i] == 0) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 1) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 2) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 3) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 4) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 5) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 6) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 7) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 8) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 9) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 10) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 11) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 12) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 13) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 14) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 15) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 16) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 17) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 18) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 19) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 20) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 21) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 22) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption7[i] == 23) { materialInven.Slots[i].item.buffs[7].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption8[i] == 0) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 1) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 2) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 3) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 4) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 5) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 6) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 7) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 8) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 9) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 10) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 11) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 12) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 13) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 14) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 15) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 16) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 17) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 18) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 19) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 20) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 21) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 22) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption8[i] == 23) { materialInven.Slots[i].item.buffs[8].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption9[i] == 0) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 1) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 2) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 3) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 4) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 5) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 6) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 7) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 8) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 9) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 10) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 11) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 12) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 13) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 14) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 15) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 16) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 17) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 18) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 19) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 20) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 21) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 22) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption9[i] == 23) { materialInven.Slots[i].item.buffs[9].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption10[i] == 0) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 1) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 2) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 3) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 4) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 5) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 6) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 7) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 8) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 9) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 10) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 11) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 12) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 13) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 14) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 15) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 16) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 17) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 18) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 19) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 20) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 21) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 22) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption10[i] == 23) { materialInven.Slots[i].item.buffs[10].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption11[i] == 0) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 1) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 2) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 3) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 4) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 5) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 6) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 7) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 8) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 9) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 10) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 11) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 12) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 13) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 14) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 15) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 16) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 17) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 18) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 19) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 20) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 21) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 22) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption11[i] == 23) { materialInven.Slots[i].item.buffs[11].stat = Itemoption.Nothing; }
        }

        for (int i = 0; i < 5; i++)
        {
            if (DataManager.instance.nowPlayer.materialoption12[i] == 0) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.STR; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 1) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.CON; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 2) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.DEX; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 3) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.INT; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 4) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.LUK; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 5) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.ATK; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 6) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.DEF; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 7) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.MoveSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 8) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.SellingPrice; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 9) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.EnhancePoint; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 10) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.StarForce; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 11) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.RubbyPoint; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 12) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.AtteckSpeed; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 13) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.Cooltime; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 14) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.maxHP; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 15) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.Critical; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 16) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.CriticalDmg; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 17) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.RecoveryHP; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 18) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.SpecialStarforce; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 19) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.UpGradePoint; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 20) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.Grade; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 21) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.maxMP; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 22) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.RecoveryMP; }
            else if (DataManager.instance.nowPlayer.materialoption12[i] == 23) { materialInven.Slots[i].item.buffs[12].stat = Itemoption.Nothing; }
        }
    }
    void Materialionvalueload()
    {
        for (int i = 0; i < 5; i++)
        {

            materialInven.Slots[i].item.buffs[0].value = DataManager.instance.nowPlayer.materialoptionValue0[i];
            materialInven.Slots[i].item.buffs[1].value = DataManager.instance.nowPlayer.materialoptionValue1[i];
            materialInven.Slots[i].item.buffs[2].value = DataManager.instance.nowPlayer.materialoptionValue2[i];
            materialInven.Slots[i].item.buffs[3].value = DataManager.instance.nowPlayer.materialoptionValue3[i];
            materialInven.Slots[i].item.buffs[4].value = DataManager.instance.nowPlayer.materialoptionValue4[i];
            materialInven.Slots[i].item.buffs[5].value = DataManager.instance.nowPlayer.materialoptionValue5[i];
            materialInven.Slots[i].item.buffs[6].value = DataManager.instance.nowPlayer.materialoptionValue6[i];
            materialInven.Slots[i].item.buffs[7].value = DataManager.instance.nowPlayer.materialoptionValue7[i];
            materialInven.Slots[i].item.buffs[8].value = DataManager.instance.nowPlayer.materialoptionValue8[i];
            materialInven.Slots[i].item.buffs[9].value = DataManager.instance.nowPlayer.materialoptionValue9[i];
            materialInven.Slots[i].item.buffs[10].value = DataManager.instance.nowPlayer.materialoptionValue10[i];
            materialInven.Slots[i].item.buffs[11].value = DataManager.instance.nowPlayer.materialoptionValue11[i];
            materialInven.Slots[i].item.buffs[12].value = DataManager.instance.nowPlayer.materialoptionValue12[i];

        }
    }




    void Statload()
    {
        stat.curExp = DataManager.instance.nowPlayer.curExp;
        stat.maxExp = DataManager.instance.nowPlayer.maxExp;

        stat.Str = DataManager.instance.nowPlayer.Str;
        stat.Con = DataManager.instance.nowPlayer.Con;
        stat.Dex = DataManager.instance.nowPlayer.Dex;
        stat.Int = DataManager.instance.nowPlayer.Int;
        stat.Luk = DataManager.instance.nowPlayer.Luk;
        stat.Pp = DataManager.instance.nowPlayer.Pp;
        stat.Level = DataManager.instance.nowPlayer.Level;
        stat.ItemStr = DataManager.instance.nowPlayer.itemStr;
        stat.ItemCon = DataManager.instance.nowPlayer.itemCon;
        stat.ItemDex = DataManager.instance.nowPlayer.itemDex;
        stat.ItemInt = DataManager.instance.nowPlayer.itemInt;
        stat.ItemLuk = DataManager.instance.nowPlayer.itemLuk;
        stat.itemATK = DataManager.instance.nowPlayer.itemATK;
        stat.itemAttackSpeed = DataManager.instance.nowPlayer.itemAttackSpeed;
        stat.itemCritical = DataManager.instance.nowPlayer.itemCritical;
        stat.itemMoveSpeed = DataManager.instance.nowPlayer.itemMoveSpeed;
        stat.itemCriticalDmg = DataManager.instance.nowPlayer.itemCriticalDmg;
        stat.itemDEF = DataManager.instance.nowPlayer.itemDEF;
        stat.itemCooltime = DataManager.instance.nowPlayer.itemCooltime;
        stat.itemMaxHP = DataManager.instance.nowPlayer.itemMaxHP;
        stat.itemMaxMP = DataManager.instance.nowPlayer.itemMaxMP;
        stat.itemRecoveryHP = DataManager.instance.nowPlayer.itemRecoveryHP;
        stat.itemRecoveryMP = DataManager.instance.nowPlayer.itemRecoveryMP;

    }

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

        ///////////////////////////////////////////////////////////////
    }
    public void SkillLoad()
    {
        _skill.SkillPoint = DataManager.instance.nowPlayer.SkillPoint;

        _skill.MagnetLv = DataManager.instance.nowPlayer.MagnetLv;
        _skill.MagnetCurExp = DataManager.instance.nowPlayer.MagnetCurExp;
        _skill.MagnetMaxExp = DataManager.instance.nowPlayer.MagnetMaxExp;

        _skill.ViewRadiusLv = DataManager.instance.nowPlayer.ViewRadiusLv;
        _skill.SkillViewRadius = DataManager.instance.nowPlayer.SkillViewRadius;
        _skill.ViewRadiusCurExp = DataManager.instance.nowPlayer.ViewRadiusCurExp;
        _skill.ViewRadiusMaxExp = DataManager.instance.nowPlayer.ViewRadiusMaxExp;

        _skill.AttackSpeedLv = DataManager.instance.nowPlayer.AttackSpeedLv;
        _skill.SkillAttackSpeed = DataManager.instance.nowPlayer.SkillAttackSpeed;
        _skill.AttackSpeedCurExp = DataManager.instance.nowPlayer.AttackSpeedCurExp;
        _skill.AttackSpeedMaxExp = DataManager.instance.nowPlayer.AttackSpeedMaxExp;

        _skill.AttackLv = DataManager.instance.nowPlayer.AttackLv;
        _skill.SkillAttack = DataManager.instance.nowPlayer.SkillAttack;
        _skill.AttackCurExp = DataManager.instance.nowPlayer.AttackCurExp;
        _skill.AttackMaxExp = DataManager.instance.nowPlayer.AttackMaxExp;

        _skill.CriticalLv = DataManager.instance.nowPlayer.CriticalLv;
        _skill.SkillCritical = DataManager.instance.nowPlayer.SkillCritical;
        _skill.CriticalCurExp = DataManager.instance.nowPlayer.CriticalCurExp;
        _skill.CriticalMaxExp = DataManager.instance.nowPlayer.CriticalMaxExp;

        ////////////////////////////   보조 스킬

        _skill.HealLv = DataManager.instance.nowPlayer.HealLv;
        _skill.HealingAmount = DataManager.instance.nowPlayer.HealingAmount;
        _skill.HealCurExp = DataManager.instance.nowPlayer.HealCurExp;
        _skill.HealMaxExp = DataManager.instance.nowPlayer.HealMaxExp;
        _skill.HealUseMP = DataManager.instance.nowPlayer.HealUseMP;
        _skill.HealCooltime = DataManager.instance.nowPlayer.HealCooltime;

        _skill.MoveSpeedLv = DataManager.instance.nowPlayer.MoveSpeedLv;
        _skill.SkillMoveSpeed = DataManager.instance.nowPlayer.SkillMoveSpeed;
        _skill.MoveSpeedDuring = DataManager.instance.nowPlayer.MoveSpeedDuring;
        _skill.MoveSpeedCurExp = DataManager.instance.nowPlayer.MoveSpeedCurExp;
        _skill.HMoveSpeedMaxExp = DataManager.instance.nowPlayer.HMoveSpeedMaxExp;
        _skill.MoveSpeedUseMP = DataManager.instance.nowPlayer.MoveSpeedUseMP;
        _skill.MoveSpeedCooltime = DataManager.instance.nowPlayer.MoveSpeedCooltime;

        _skill.AreaSkillLv = DataManager.instance.nowPlayer.AreaSkillLv;
        _skill.AreaSkillDamage = DataManager.instance.nowPlayer.AreaSkillDamage;
        _skill.AreaSkillDuring = DataManager.instance.nowPlayer.AreaSkillDuring;
        _skill.AreaSkillCurExp = DataManager.instance.nowPlayer.AreaSkillCurExp;
        _skill.AreaSkillMaxExp = DataManager.instance.nowPlayer.AreaSkillMaxExp;
        _skill.AreaSkillUseMP = DataManager.instance.nowPlayer.AreaSkillUseMP;
        _skill.AreaSkillCooltime = DataManager.instance.nowPlayer.AreaSkillCooltime;

        _skill.AroundSkillLv = DataManager.instance.nowPlayer.AroundSkillLv;
        _skill.AroundSkillDamage = DataManager.instance.nowPlayer.AroundSkillDamage;
        _skill.AroundSkillDuring = DataManager.instance.nowPlayer.AroundSkillDuring;
        _skill.AroundSkillCurExp = DataManager.instance.nowPlayer.AroundSkillCurExp;
        _skill.AroundSkillMaxExp = DataManager.instance.nowPlayer.AroundSkillMaxExp;
        _skill.AroundSkillUseMP = DataManager.instance.nowPlayer.AroundSkillUseMP;
        _skill.AroundSkillCooltime = DataManager.instance.nowPlayer.AroundSkillCooltime;

        _skill.InvincibilityLv = DataManager.instance.nowPlayer.InvincibilityLv;
        _skill.InvincibilityDuring = DataManager.instance.nowPlayer.InvincibilityDuring;
        _skill.InvincibilityCurExp = DataManager.instance.nowPlayer.InvincibilityCurExp;
        _skill.InvincibilityMaxExp = DataManager.instance.nowPlayer.InvincibilityMaxExp;
        _skill.InvincibilityUseMP = DataManager.instance.nowPlayer.InvincibilityUseMP;
        _skill.InvincibilityCooltime = DataManager.instance.nowPlayer.InvincibilityCooltime;

        ////////////////////////////   공격 스킬

        _skill.MultiShotLv = DataManager.instance.nowPlayer.MultiShotLv;
        _skill.MultiShotDuring = DataManager.instance.nowPlayer.MultiShotDuring;
        _skill.MultiShotCurExp = DataManager.instance.nowPlayer.MultiShotCurExp;
        _skill.MultiShotMaxExp = DataManager.instance.nowPlayer.MultiShotMaxExp;
        _skill.MultiShotUseMP = DataManager.instance.nowPlayer.MultiShotUseMP;
        _skill.MultiShotCooltime = DataManager.instance.nowPlayer.MultiShotCooltime;

        _skill.PierceShotLv = DataManager.instance.nowPlayer.PierceShotLv;
        _skill.PierceShotCount = DataManager.instance.nowPlayer.PierceShotCount;
        _skill.PierceShotCurExp = DataManager.instance.nowPlayer.PierceShotCurExp;
        _skill.PierceShotMaxExp = DataManager.instance.nowPlayer.PierceShotMaxExp;
        _skill.PierceShotUseMP = DataManager.instance.nowPlayer.PierceShotUseMP;
        _skill.PierceShotCooltime = DataManager.instance.nowPlayer.PierceShotCooltime;

    }

    public void RecipeInvenLoad()
    {
        for (int i = 0; i < InventoryManager.instance.slots.Count; i++)
        {
            int itemData = DataManager.instance.nowPlayer.RecipeitemId[i];
            if (itemData > 0)
            {
                itemData -= 1000;
                ItemSO item = InventoryManager.instance._recipeDataBase.RecipeItem[itemData];
                InventoryManager.instance.AddItemToInventory(item, DataManager.instance.nowPlayer.Recipeitemamount[i]);
            }
        }
    }


    public void Continue()
    {
        LoadingBar.LoadScene("SelectScene");
    }

    public void ContinueAds()
    {
        TestAdmob.instance.ShowAds4();
    }
}
