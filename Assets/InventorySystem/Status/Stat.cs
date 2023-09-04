using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName ="New Status", menuName = "Inventory System/Status")]
public class Stat : ScriptableObject
{
    public string Name;
    public int maxExp;
    public int curExp;

    [Header("PlayerStat")]
    public int Level;    
    public int Str;    
    public int Con;    
    public int Dex;    
    public int Int;    
    public int Luk;    
    public int Pp;
    
    [Header("ItemStat")]     
    public int ItemStr;  // 무기, 갑옷   
    public int ItemCon;  // 갑옷, 투구  
    public int ItemDex;  // 무기, 장갑  
    public int ItemInt;  // 투구, 신발  
    public int ItemLuk;  // 장갑, 신발
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
    
    [Header("Attribute")]
    public int minAtk; // 무기
    public int maxAtk; // 무기
    public int AttackSpeed;
    public int Critical;
    public int MoveSpeed;   // 신발
    public int CriticalDmg; // 장갑
    public int Def; //갑옷
    public int Cooltime;   
    public int maxHP;
    public int curHP;
    public int RecoveryHP;  //  투구
    public int maxMP;
    public int curMP;
    public int RecoveryMP; 
    
}

