using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itemoption : int
{
    STR = 0,
    CON = 1,
    DEX = 2,
    INT = 3,
    LUK = 4,
    ATK = 5,
    DEF = 6,
    MoveSpeed = 7,
    SellingPrice = 8,
    EnhancePoint= 9,
    StarForce = 10,
    RubbyPoint = 11,
    AtteckSpeed = 12,
    Cooltime = 13,
    maxHP = 14,
    Critical = 15,
    CriticalDmg = 16,
    RecoveryHP = 17,
    SpecialStarforce = 18,
    UpGradePoint = 19,
    Grade = 20,
    maxMP = 21,
    RecoveryMP = 22,
    Nothing = 23
}
[Serializable]
public class ItemBuff
{
   public Itemoption stat;
   public int value;

   [SerializeField]
   private int min;
   
   [SerializeField]
   private int max;

   public int Min => min;
   public int Max => max;
   
   public ItemBuff(int min, int max)
   {
        this.min = min;
        this.max = max;
        
        GenerateValue();
   }

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }

    public void AddValue(ref int v)
    {
        v += value;
    }
}
