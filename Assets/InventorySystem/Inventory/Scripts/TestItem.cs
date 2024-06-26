using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : MonoBehaviour
{    
    public InventoryObject equipmentObject;
    public InventoryObject tempObject;
    public InventoryObject inventoryObject;
    public ItemObjectDataBase databaseObject;

   
    public void AddNewItem()
    {
        if (databaseObject.itemObjects.Length > 0)
        {
            ItemObject newItemObject = databaseObject.itemObjects[Random.Range(0, databaseObject.itemObjects.Length)];
            Item newItem = new Item(newItemObject);
            inventoryObject.AddItem(newItem, 1);
            invenSave();
            tests0();
            tests1();                     
            DataManager.instance.SaveData();
            //Debug.Log(op_0);
            //Debug.Log((int)inventoryObject.Slots[0].item.buffs[0].stat);
        }
    }

    public void ClearInventory()
    {
        equipmentObject?.Clear();
        inventoryObject?.Clear();
        tempObject?.Clear();
    }

    public void invenSave()
    {
        DataManager.instance.nowPlayer.itemId = new int[] {
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
                                                                inventoryObject.Slots[29].item.id
                                                                };

        DataManager.instance.nowPlayer.itemname = new string[]  {
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

                                                                };
                                                                
        DataManager.instance.nowPlayer.amount = new int[]  {
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

                                                                };
                                                                
    }
    private void tests0()
    {
        #region 옵션0

        int op0_0,op0_1,op0_2,op0_3,op0_4,op0_5,op0_6,op0_7,op0_8,op0_9,op0_10,op0_11,op0_12,op0_13,op0_14,op0_15,op0_16,op0_17,op0_18,op0_19,op0_20,op0_21,op0_22,op0_23,op0_24,op0_25,op0_26,op0_27,op0_28,op0_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op0_0 = (int)inventoryObject.Slots[0].item.buffs[0].stat; } else { op0_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op0_1 = (int)inventoryObject.Slots[1].item.buffs[0].stat; } else { op0_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op0_2 = (int)inventoryObject.Slots[2].item.buffs[0].stat; } else { op0_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op0_3 = (int)inventoryObject.Slots[3].item.buffs[0].stat; } else { op0_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op0_4 = (int)inventoryObject.Slots[4].item.buffs[0].stat; } else { op0_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op0_5 = (int)inventoryObject.Slots[5].item.buffs[0].stat; } else { op0_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op0_6 = (int)inventoryObject.Slots[6].item.buffs[0].stat; } else { op0_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op0_7 = (int)inventoryObject.Slots[7].item.buffs[0].stat; } else { op0_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op0_8 = (int)inventoryObject.Slots[8].item.buffs[0].stat; } else { op0_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op0_9 = (int)inventoryObject.Slots[9].item.buffs[0].stat; } else { op0_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op0_10 = (int)inventoryObject.Slots[10].item.buffs[0].stat; } else { op0_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op0_11 = (int)inventoryObject.Slots[11].item.buffs[0].stat; } else { op0_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op0_12 = (int)inventoryObject.Slots[12].item.buffs[0].stat; } else { op0_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op0_13 = (int)inventoryObject.Slots[13].item.buffs[0].stat; } else { op0_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op0_14 = (int)inventoryObject.Slots[14].item.buffs[0].stat; } else { op0_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op0_15 = (int)inventoryObject.Slots[15].item.buffs[0].stat; } else { op0_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op0_16 = (int)inventoryObject.Slots[16].item.buffs[0].stat; } else { op0_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op0_17 = (int)inventoryObject.Slots[17].item.buffs[0].stat; } else { op0_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op0_18 = (int)inventoryObject.Slots[18].item.buffs[0].stat; } else { op0_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op0_19 = (int)inventoryObject.Slots[19].item.buffs[0].stat; } else { op0_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op0_20 = (int)inventoryObject.Slots[20].item.buffs[0].stat; } else { op0_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op0_21 = (int)inventoryObject.Slots[21].item.buffs[0].stat; } else { op0_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op0_22 = (int)inventoryObject.Slots[22].item.buffs[0].stat; } else { op0_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op0_23 = (int)inventoryObject.Slots[23].item.buffs[0].stat; } else { op0_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op0_24 = (int)inventoryObject.Slots[24].item.buffs[0].stat; } else { op0_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op0_25 = (int)inventoryObject.Slots[25].item.buffs[0].stat; } else { op0_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op0_26 = (int)inventoryObject.Slots[26].item.buffs[0].stat; } else { op0_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op0_27 = (int)inventoryObject.Slots[27].item.buffs[0].stat; } else { op0_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op0_28 = (int)inventoryObject.Slots[28].item.buffs[0].stat; } else { op0_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op0_29 = (int)inventoryObject.Slots[29].item.buffs[0].stat; } else { op0_29 = -1; }
               
        DataManager.instance.nowPlayer.option0 = new int[] {op0_0,op0_1,op0_2,op0_3,op0_4,op0_5,op0_6,op0_7,op0_8,op0_9,op0_10,op0_11,op0_12,op0_13,op0_14,op0_15,op0_16,op0_17,op0_18,op0_19,op0_20,op0_21,op0_22,op0_23,op0_24,op0_25,op0_26,op0_27,op0_28,op0_29};
        #endregion
    
        #region 옵션1

        int op1_0,op1_1,op1_2,op1_3,op1_4,op1_5,op1_6,op1_7,op1_8,op1_9,op1_10,op1_11,op1_12,op1_13,op1_14,op1_15,op1_16,op1_17,op1_18,op1_19,op1_20,op1_21,op1_22,op1_23,op1_24,op1_25,op1_26,op1_27,op1_28,op1_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op1_0 = (int)inventoryObject.Slots[0].item.buffs[1].stat; } else { op1_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op1_1 = (int)inventoryObject.Slots[1].item.buffs[1].stat; } else { op1_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op1_2 = (int)inventoryObject.Slots[2].item.buffs[1].stat; } else { op1_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op1_3 = (int)inventoryObject.Slots[3].item.buffs[1].stat; } else { op1_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op1_4 = (int)inventoryObject.Slots[4].item.buffs[1].stat; } else { op1_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op1_5 = (int)inventoryObject.Slots[5].item.buffs[1].stat; } else { op1_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op1_6 = (int)inventoryObject.Slots[6].item.buffs[1].stat; } else { op1_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op1_7 = (int)inventoryObject.Slots[7].item.buffs[1].stat; } else { op1_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op1_8 = (int)inventoryObject.Slots[8].item.buffs[1].stat; } else { op1_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op1_9 = (int)inventoryObject.Slots[9].item.buffs[1].stat; } else { op1_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op1_10 = (int)inventoryObject.Slots[10].item.buffs[1].stat; } else { op1_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op1_11 = (int)inventoryObject.Slots[11].item.buffs[1].stat; } else { op1_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op1_12 = (int)inventoryObject.Slots[12].item.buffs[1].stat; } else { op1_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op1_13 = (int)inventoryObject.Slots[13].item.buffs[1].stat; } else { op1_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op1_14 = (int)inventoryObject.Slots[14].item.buffs[1].stat; } else { op1_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op1_15 = (int)inventoryObject.Slots[15].item.buffs[1].stat; } else { op1_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op1_16 = (int)inventoryObject.Slots[16].item.buffs[1].stat; } else { op1_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op1_17 = (int)inventoryObject.Slots[17].item.buffs[1].stat; } else { op1_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op1_18 = (int)inventoryObject.Slots[18].item.buffs[1].stat; } else { op1_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op1_19 = (int)inventoryObject.Slots[19].item.buffs[1].stat; } else { op1_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op1_20 = (int)inventoryObject.Slots[20].item.buffs[1].stat; } else { op1_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op1_21 = (int)inventoryObject.Slots[21].item.buffs[1].stat; } else { op1_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op1_22 = (int)inventoryObject.Slots[22].item.buffs[1].stat; } else { op1_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op1_23 = (int)inventoryObject.Slots[23].item.buffs[1].stat; } else { op1_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op1_24 = (int)inventoryObject.Slots[24].item.buffs[1].stat; } else { op1_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op1_25 = (int)inventoryObject.Slots[25].item.buffs[1].stat; } else { op1_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op1_26 = (int)inventoryObject.Slots[26].item.buffs[1].stat; } else { op1_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op1_27 = (int)inventoryObject.Slots[27].item.buffs[1].stat; } else { op1_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op1_28 = (int)inventoryObject.Slots[28].item.buffs[1].stat; } else { op1_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op1_29 = (int)inventoryObject.Slots[29].item.buffs[1].stat; } else { op1_29 = -1; }
               
        DataManager.instance.nowPlayer.option1 = new int[] {op1_0,op1_1,op1_2,op1_3,op1_4,op1_5,op1_6,op1_7,op1_8,op1_9,op1_10,op1_11,op1_12,op1_13,op1_14,op1_15,op1_16,op1_17,op1_18,op1_19,op1_20,op1_21,op1_22,op1_23,op1_24,op1_25,op1_26,op1_27,op1_28,op1_29};
        #endregion
    
        #region 옵션2

        int op2_0,op2_1,op2_2,op2_3,op2_4,op2_5,op2_6,op2_7,op2_8,op2_9,op2_10,op2_11,op2_12,op2_13,op2_14,op2_15,op2_16,op2_17,op2_18,op2_19,op2_20,op2_21,op2_22,op2_23,op2_24,op2_25,op2_26,op2_27,op2_28,op2_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op2_0 = (int)inventoryObject.Slots[0].item.buffs[2].stat; } else { op2_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op2_1 = (int)inventoryObject.Slots[1].item.buffs[2].stat; } else { op2_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op2_2 = (int)inventoryObject.Slots[2].item.buffs[2].stat; } else { op2_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op2_3 = (int)inventoryObject.Slots[3].item.buffs[2].stat; } else { op2_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op2_4 = (int)inventoryObject.Slots[4].item.buffs[2].stat; } else { op2_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op2_5 = (int)inventoryObject.Slots[5].item.buffs[2].stat; } else { op2_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op2_6 = (int)inventoryObject.Slots[6].item.buffs[2].stat; } else { op2_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op2_7 = (int)inventoryObject.Slots[7].item.buffs[2].stat; } else { op2_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op2_8 = (int)inventoryObject.Slots[8].item.buffs[2].stat; } else { op2_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op2_9 = (int)inventoryObject.Slots[9].item.buffs[2].stat; } else { op2_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op2_10 = (int)inventoryObject.Slots[10].item.buffs[2].stat; } else { op2_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op2_11 = (int)inventoryObject.Slots[11].item.buffs[2].stat; } else { op2_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op2_12 = (int)inventoryObject.Slots[12].item.buffs[2].stat; } else { op2_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op2_13 = (int)inventoryObject.Slots[13].item.buffs[2].stat; } else { op2_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op2_14 = (int)inventoryObject.Slots[14].item.buffs[2].stat; } else { op2_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op2_15 = (int)inventoryObject.Slots[15].item.buffs[2].stat; } else { op2_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op2_16 = (int)inventoryObject.Slots[16].item.buffs[2].stat; } else { op2_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op2_17 = (int)inventoryObject.Slots[17].item.buffs[2].stat; } else { op2_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op2_18 = (int)inventoryObject.Slots[18].item.buffs[2].stat; } else { op2_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op2_19 = (int)inventoryObject.Slots[19].item.buffs[2].stat; } else { op2_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op2_20 = (int)inventoryObject.Slots[20].item.buffs[2].stat; } else { op2_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op2_21 = (int)inventoryObject.Slots[21].item.buffs[2].stat; } else { op2_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op2_22 = (int)inventoryObject.Slots[22].item.buffs[2].stat; } else { op2_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op2_23 = (int)inventoryObject.Slots[23].item.buffs[2].stat; } else { op2_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op2_24 = (int)inventoryObject.Slots[24].item.buffs[2].stat; } else { op2_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op2_25 = (int)inventoryObject.Slots[25].item.buffs[2].stat; } else { op2_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op2_26 = (int)inventoryObject.Slots[26].item.buffs[2].stat; } else { op2_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op2_27 = (int)inventoryObject.Slots[27].item.buffs[2].stat; } else { op2_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op2_28 = (int)inventoryObject.Slots[28].item.buffs[2].stat; } else { op2_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op2_29 = (int)inventoryObject.Slots[29].item.buffs[2].stat; } else { op2_29 = -1; }
               
        DataManager.instance.nowPlayer.option2 = new int[] {op2_0,op2_1,op2_2,op2_3,op2_4,op2_5,op2_6,op2_7,op2_8,op2_9,op2_10,op2_11,op2_12,op2_13,op2_14,op2_15,op2_16,op2_17,op2_18,op2_19,op2_20,op2_21,op2_22,op2_23,op2_24,op2_25,op2_26,op2_27,op2_28,op2_29};
        #endregion
    
        #region 옵션3

        int op3_0,op3_1,op3_2,op3_3,op3_4,op3_5,op3_6,op3_7,op3_8,op3_9,op3_10,op3_11,op3_12,op3_13,op3_14,op3_15,op3_16,op3_17,op3_18,op3_19,op3_20,op3_21,op3_22,op3_23,op3_24,op3_25,op3_26,op3_27,op3_28,op3_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op3_0 = (int)inventoryObject.Slots[0].item.buffs[3].stat; } else { op3_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op3_1 = (int)inventoryObject.Slots[1].item.buffs[3].stat; } else { op3_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op3_2 = (int)inventoryObject.Slots[2].item.buffs[3].stat; } else { op3_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op3_3 = (int)inventoryObject.Slots[3].item.buffs[3].stat; } else { op3_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op3_4 = (int)inventoryObject.Slots[4].item.buffs[3].stat; } else { op3_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op3_5 = (int)inventoryObject.Slots[5].item.buffs[3].stat; } else { op3_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op3_6 = (int)inventoryObject.Slots[6].item.buffs[3].stat; } else { op3_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op3_7 = (int)inventoryObject.Slots[7].item.buffs[3].stat; } else { op3_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op3_8 = (int)inventoryObject.Slots[8].item.buffs[3].stat; } else { op3_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op3_9 = (int)inventoryObject.Slots[9].item.buffs[3].stat; } else { op3_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op3_10 = (int)inventoryObject.Slots[10].item.buffs[3].stat; } else { op3_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op3_11 = (int)inventoryObject.Slots[11].item.buffs[3].stat; } else { op3_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op3_12 = (int)inventoryObject.Slots[12].item.buffs[3].stat; } else { op3_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op3_13 = (int)inventoryObject.Slots[13].item.buffs[3].stat; } else { op3_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op3_14 = (int)inventoryObject.Slots[14].item.buffs[3].stat; } else { op3_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op3_15 = (int)inventoryObject.Slots[15].item.buffs[3].stat; } else { op3_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op3_16 = (int)inventoryObject.Slots[16].item.buffs[3].stat; } else { op3_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op3_17 = (int)inventoryObject.Slots[17].item.buffs[3].stat; } else { op3_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op3_18 = (int)inventoryObject.Slots[18].item.buffs[3].stat; } else { op3_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op3_19 = (int)inventoryObject.Slots[19].item.buffs[3].stat; } else { op3_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op3_20 = (int)inventoryObject.Slots[20].item.buffs[3].stat; } else { op3_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op3_21 = (int)inventoryObject.Slots[21].item.buffs[3].stat; } else { op3_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op3_22 = (int)inventoryObject.Slots[22].item.buffs[3].stat; } else { op3_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op3_23 = (int)inventoryObject.Slots[23].item.buffs[3].stat; } else { op3_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op3_24 = (int)inventoryObject.Slots[24].item.buffs[3].stat; } else { op3_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op3_25 = (int)inventoryObject.Slots[25].item.buffs[3].stat; } else { op3_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op3_26 = (int)inventoryObject.Slots[26].item.buffs[3].stat; } else { op3_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op3_27 = (int)inventoryObject.Slots[27].item.buffs[3].stat; } else { op3_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op3_28 = (int)inventoryObject.Slots[28].item.buffs[3].stat; } else { op3_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op3_29 = (int)inventoryObject.Slots[29].item.buffs[3].stat; } else { op3_29 = -1; }
               
        DataManager.instance.nowPlayer.option3 = new int[] {op3_0,op3_1,op3_2,op3_3,op3_4,op3_5,op3_6,op3_7,op3_8,op3_9,op3_10,op3_11,op3_12,op3_13,op3_14,op3_15,op3_16,op3_17,op3_18,op3_19,op3_20,op3_21,op3_22,op3_23,op3_24,op3_25,op3_26,op3_27,op3_28,op3_29};
        #endregion
    
        #region 옵션4

        int op4_0,op4_1,op4_2,op4_3,op4_4,op4_5,op4_6,op4_7,op4_8,op4_9,op4_10,op4_11,op4_12,op4_13,op4_14,op4_15,op4_16,op4_17,op4_18,op4_19,op4_20,op4_21,op4_22,op4_23,op4_24,op4_25,op4_26,op4_27,op4_28,op4_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op4_0 = (int)inventoryObject.Slots[0].item.buffs[4].stat; } else { op4_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op4_1 = (int)inventoryObject.Slots[1].item.buffs[4].stat; } else { op4_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op4_2 = (int)inventoryObject.Slots[2].item.buffs[4].stat; } else { op4_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op4_3 = (int)inventoryObject.Slots[3].item.buffs[4].stat; } else { op4_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op4_4 = (int)inventoryObject.Slots[4].item.buffs[4].stat; } else { op4_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op4_5 = (int)inventoryObject.Slots[5].item.buffs[4].stat; } else { op4_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op4_6 = (int)inventoryObject.Slots[6].item.buffs[4].stat; } else { op4_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op4_7 = (int)inventoryObject.Slots[7].item.buffs[4].stat; } else { op4_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op4_8 = (int)inventoryObject.Slots[8].item.buffs[4].stat; } else { op4_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op4_9 = (int)inventoryObject.Slots[9].item.buffs[4].stat; } else { op4_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op4_10 = (int)inventoryObject.Slots[10].item.buffs[4].stat; } else { op4_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op4_11 = (int)inventoryObject.Slots[11].item.buffs[4].stat; } else { op4_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op4_12 = (int)inventoryObject.Slots[12].item.buffs[4].stat; } else { op4_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op4_13 = (int)inventoryObject.Slots[13].item.buffs[4].stat; } else { op4_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op4_14 = (int)inventoryObject.Slots[14].item.buffs[4].stat; } else { op4_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op4_15 = (int)inventoryObject.Slots[15].item.buffs[4].stat; } else { op4_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op4_16 = (int)inventoryObject.Slots[16].item.buffs[4].stat; } else { op4_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op4_17 = (int)inventoryObject.Slots[17].item.buffs[4].stat; } else { op4_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op4_18 = (int)inventoryObject.Slots[18].item.buffs[4].stat; } else { op4_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op4_19 = (int)inventoryObject.Slots[19].item.buffs[4].stat; } else { op4_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op4_20 = (int)inventoryObject.Slots[20].item.buffs[4].stat; } else { op4_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op4_21 = (int)inventoryObject.Slots[21].item.buffs[4].stat; } else { op4_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op4_22 = (int)inventoryObject.Slots[22].item.buffs[4].stat; } else { op4_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op4_23 = (int)inventoryObject.Slots[23].item.buffs[4].stat; } else { op4_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op4_24 = (int)inventoryObject.Slots[24].item.buffs[4].stat; } else { op4_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op4_25 = (int)inventoryObject.Slots[25].item.buffs[4].stat; } else { op4_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op4_26 = (int)inventoryObject.Slots[26].item.buffs[4].stat; } else { op4_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op4_27 = (int)inventoryObject.Slots[27].item.buffs[4].stat; } else { op4_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op4_28 = (int)inventoryObject.Slots[28].item.buffs[4].stat; } else { op4_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op4_29 = (int)inventoryObject.Slots[29].item.buffs[4].stat; } else { op4_29 = -1; }
               
        DataManager.instance.nowPlayer.option4 = new int[] {op4_0,op4_1,op4_2,op4_3,op4_4,op4_5,op4_6,op4_7,op4_8,op4_9,op4_10,op4_11,op4_12,op4_13,op4_14,op4_15,op4_16,op4_17,op4_18,op4_19,op4_20,op4_21,op4_22,op4_23,op4_24,op4_25,op4_26,op4_27,op4_28,op4_29};
        #endregion
    
        #region 옵션5

        int op5_0,op5_1,op5_2,op5_3,op5_4,op5_5,op5_6,op5_7,op5_8,op5_9,op5_10,op5_11,op5_12,op5_13,op5_14,op5_15,op5_16,op5_17,op5_18,op5_19,op5_20,op5_21,op5_22,op5_23,op5_24,op5_25,op5_26,op5_27,op5_28,op5_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op5_0 = (int)inventoryObject.Slots[0].item.buffs[5].stat; } else { op5_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op5_1 = (int)inventoryObject.Slots[1].item.buffs[5].stat; } else { op5_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op5_2 = (int)inventoryObject.Slots[2].item.buffs[5].stat; } else { op5_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op5_3 = (int)inventoryObject.Slots[3].item.buffs[5].stat; } else { op5_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op5_4 = (int)inventoryObject.Slots[4].item.buffs[5].stat; } else { op5_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op5_5 = (int)inventoryObject.Slots[5].item.buffs[5].stat; } else { op5_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op5_6 = (int)inventoryObject.Slots[6].item.buffs[5].stat; } else { op5_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op5_7 = (int)inventoryObject.Slots[7].item.buffs[5].stat; } else { op5_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op5_8 = (int)inventoryObject.Slots[8].item.buffs[5].stat; } else { op5_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op5_9 = (int)inventoryObject.Slots[9].item.buffs[5].stat; } else { op5_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op5_10 = (int)inventoryObject.Slots[10].item.buffs[5].stat; } else { op5_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op5_11 = (int)inventoryObject.Slots[11].item.buffs[5].stat; } else { op5_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op5_12 = (int)inventoryObject.Slots[12].item.buffs[5].stat; } else { op5_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op5_13 = (int)inventoryObject.Slots[13].item.buffs[5].stat; } else { op5_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op5_14 = (int)inventoryObject.Slots[14].item.buffs[5].stat; } else { op5_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op5_15 = (int)inventoryObject.Slots[15].item.buffs[5].stat; } else { op5_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op5_16 = (int)inventoryObject.Slots[16].item.buffs[5].stat; } else { op5_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op5_17 = (int)inventoryObject.Slots[17].item.buffs[5].stat; } else { op5_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op5_18 = (int)inventoryObject.Slots[18].item.buffs[5].stat; } else { op5_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op5_19 = (int)inventoryObject.Slots[19].item.buffs[5].stat; } else { op5_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op5_20 = (int)inventoryObject.Slots[20].item.buffs[5].stat; } else { op5_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op5_21 = (int)inventoryObject.Slots[21].item.buffs[5].stat; } else { op5_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op5_22 = (int)inventoryObject.Slots[22].item.buffs[5].stat; } else { op5_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op5_23 = (int)inventoryObject.Slots[23].item.buffs[5].stat; } else { op5_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op5_24 = (int)inventoryObject.Slots[24].item.buffs[5].stat; } else { op5_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op5_25 = (int)inventoryObject.Slots[25].item.buffs[5].stat; } else { op5_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op5_26 = (int)inventoryObject.Slots[26].item.buffs[5].stat; } else { op5_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op5_27 = (int)inventoryObject.Slots[27].item.buffs[5].stat; } else { op5_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op5_28 = (int)inventoryObject.Slots[28].item.buffs[5].stat; } else { op5_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op5_29 = (int)inventoryObject.Slots[29].item.buffs[5].stat; } else { op5_29 = -1; }
               
        DataManager.instance.nowPlayer.option5 = new int[] {op5_0,op5_1,op5_2,op5_3,op5_4,op5_5,op5_6,op5_7,op5_8,op5_9,op5_10,op5_11,op5_12,op5_13,op5_14,op5_15,op5_16,op5_17,op5_18,op5_19,op5_20,op5_21,op5_22,op5_23,op5_24,op5_25,op5_26,op5_27,op5_28,op5_29};
        #endregion
  
        #region 옵션6

        int op6_0,op6_1,op6_2,op6_3,op6_4,op6_5,op6_6,op6_7,op6_8,op6_9,op6_10,op6_11,op6_12,op6_13,op6_14,op6_15,op6_16,op6_17,op6_18,op6_19,op6_20,op6_21,op6_22,op6_23,op6_24,op6_25,op6_26,op6_27,op6_28,op6_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op6_0 = (int)inventoryObject.Slots[0].item.buffs[6].stat; } else { op6_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op6_1 = (int)inventoryObject.Slots[1].item.buffs[6].stat; } else { op6_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op6_2 = (int)inventoryObject.Slots[2].item.buffs[6].stat; } else { op6_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op6_3 = (int)inventoryObject.Slots[3].item.buffs[6].stat; } else { op6_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op6_4 = (int)inventoryObject.Slots[4].item.buffs[6].stat; } else { op6_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op6_5 = (int)inventoryObject.Slots[5].item.buffs[6].stat; } else { op6_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op6_6 = (int)inventoryObject.Slots[6].item.buffs[6].stat; } else { op6_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op6_7 = (int)inventoryObject.Slots[7].item.buffs[6].stat; } else { op6_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op6_8 = (int)inventoryObject.Slots[8].item.buffs[6].stat; } else { op6_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op6_9 = (int)inventoryObject.Slots[9].item.buffs[6].stat; } else { op6_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op6_10 = (int)inventoryObject.Slots[10].item.buffs[6].stat; } else { op6_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op6_11 = (int)inventoryObject.Slots[11].item.buffs[6].stat; } else { op6_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op6_12 = (int)inventoryObject.Slots[12].item.buffs[6].stat; } else { op6_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op6_13 = (int)inventoryObject.Slots[13].item.buffs[6].stat; } else { op6_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op6_14 = (int)inventoryObject.Slots[14].item.buffs[6].stat; } else { op6_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op6_15 = (int)inventoryObject.Slots[15].item.buffs[6].stat; } else { op6_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op6_16 = (int)inventoryObject.Slots[16].item.buffs[6].stat; } else { op6_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op6_17 = (int)inventoryObject.Slots[17].item.buffs[6].stat; } else { op6_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op6_18 = (int)inventoryObject.Slots[18].item.buffs[6].stat; } else { op6_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op6_19 = (int)inventoryObject.Slots[19].item.buffs[6].stat; } else { op6_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op6_20 = (int)inventoryObject.Slots[20].item.buffs[6].stat; } else { op6_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op6_21 = (int)inventoryObject.Slots[21].item.buffs[6].stat; } else { op6_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op6_22 = (int)inventoryObject.Slots[22].item.buffs[6].stat; } else { op6_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op6_23 = (int)inventoryObject.Slots[23].item.buffs[6].stat; } else { op6_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op6_24 = (int)inventoryObject.Slots[24].item.buffs[6].stat; } else { op6_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op6_25 = (int)inventoryObject.Slots[25].item.buffs[6].stat; } else { op6_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op6_26 = (int)inventoryObject.Slots[26].item.buffs[6].stat; } else { op6_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op6_27 = (int)inventoryObject.Slots[27].item.buffs[6].stat; } else { op6_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op6_28 = (int)inventoryObject.Slots[28].item.buffs[6].stat; } else { op6_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op6_29 = (int)inventoryObject.Slots[29].item.buffs[6].stat; } else { op6_29 = -1; }
               
        DataManager.instance.nowPlayer.option6 = new int[] {op6_0,op6_1,op6_2,op6_3,op6_4,op6_5,op6_6,op6_7,op6_8,op6_9,op6_10,op6_11,op6_12,op6_13,op6_14,op6_15,op6_16,op6_17,op6_18,op6_19,op6_20,op6_21,op6_22,op6_23,op6_24,op6_25,op6_26,op6_27,op6_28,op6_29};
        #endregion

        #region 옵션7

        int op7_0,op7_1,op7_2,op7_3,op7_4,op7_5,op7_6,op7_7,op7_8,op7_9,op7_10,op7_11,op7_12,op7_13,op7_14,op7_15,op7_16,op7_17,op7_18,op7_19,op7_20,op7_21,op7_22,op7_23,op7_24,op7_25,op7_26,op7_27,op7_28,op7_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op7_0 = (int)inventoryObject.Slots[0].item.buffs[7].stat; } else { op7_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op7_1 = (int)inventoryObject.Slots[1].item.buffs[7].stat; } else { op7_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op7_2 = (int)inventoryObject.Slots[2].item.buffs[7].stat; } else { op7_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op7_3 = (int)inventoryObject.Slots[3].item.buffs[7].stat; } else { op7_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op7_4 = (int)inventoryObject.Slots[4].item.buffs[7].stat; } else { op7_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op7_5 = (int)inventoryObject.Slots[5].item.buffs[7].stat; } else { op7_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op7_6 = (int)inventoryObject.Slots[6].item.buffs[7].stat; } else { op7_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op7_7 = (int)inventoryObject.Slots[7].item.buffs[7].stat; } else { op7_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op7_8 = (int)inventoryObject.Slots[8].item.buffs[7].stat; } else { op7_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op7_9 = (int)inventoryObject.Slots[9].item.buffs[7].stat; } else { op7_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op7_10 = (int)inventoryObject.Slots[10].item.buffs[7].stat; } else { op7_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op7_11 = (int)inventoryObject.Slots[11].item.buffs[7].stat; } else { op7_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op7_12 = (int)inventoryObject.Slots[12].item.buffs[7].stat; } else { op7_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op7_13 = (int)inventoryObject.Slots[13].item.buffs[7].stat; } else { op7_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op7_14 = (int)inventoryObject.Slots[14].item.buffs[7].stat; } else { op7_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op7_15 = (int)inventoryObject.Slots[15].item.buffs[7].stat; } else { op7_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op7_16 = (int)inventoryObject.Slots[16].item.buffs[7].stat; } else { op7_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op7_17 = (int)inventoryObject.Slots[17].item.buffs[7].stat; } else { op7_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op7_18 = (int)inventoryObject.Slots[18].item.buffs[7].stat; } else { op7_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op7_19 = (int)inventoryObject.Slots[19].item.buffs[7].stat; } else { op7_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op7_20 = (int)inventoryObject.Slots[20].item.buffs[7].stat; } else { op7_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op7_21 = (int)inventoryObject.Slots[21].item.buffs[7].stat; } else { op7_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op7_22 = (int)inventoryObject.Slots[22].item.buffs[7].stat; } else { op7_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op7_23 = (int)inventoryObject.Slots[23].item.buffs[7].stat; } else { op7_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op7_24 = (int)inventoryObject.Slots[24].item.buffs[7].stat; } else { op7_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op7_25 = (int)inventoryObject.Slots[25].item.buffs[7].stat; } else { op7_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op7_26 = (int)inventoryObject.Slots[26].item.buffs[7].stat; } else { op7_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op7_27 = (int)inventoryObject.Slots[27].item.buffs[7].stat; } else { op7_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op7_28 = (int)inventoryObject.Slots[28].item.buffs[7].stat; } else { op7_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op7_29 = (int)inventoryObject.Slots[29].item.buffs[7].stat; } else { op7_29 = -1; }
               
        DataManager.instance.nowPlayer.option7 = new int[] {op7_0,op7_1,op7_2,op7_3,op7_4,op7_5,op7_6,op7_7,op7_8,op7_9,op7_10,op7_11,op7_12,op7_13,op7_14,op7_15,op7_16,op7_17,op7_18,op7_19,op7_20,op7_21,op7_22,op7_23,op7_24,op7_25,op7_26,op7_27,op7_28,op7_29};
        #endregion

        #region 옵션8

        int op8_0,op8_1,op8_2,op8_3,op8_4,op8_5,op8_6,op8_7,op8_8,op8_9,op8_10,op8_11,op8_12,op8_13,op8_14,op8_15,op8_16,op8_17,op8_18,op8_19,op8_20,op8_21,op8_22,op8_23,op8_24,op8_25,op8_26,op8_27,op8_28,op8_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op8_0 = (int)inventoryObject.Slots[0].item.buffs[8].stat; } else { op8_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op8_1 = (int)inventoryObject.Slots[1].item.buffs[8].stat; } else { op8_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op8_2 = (int)inventoryObject.Slots[2].item.buffs[8].stat; } else { op8_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op8_3 = (int)inventoryObject.Slots[3].item.buffs[8].stat; } else { op8_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op8_4 = (int)inventoryObject.Slots[4].item.buffs[8].stat; } else { op8_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op8_5 = (int)inventoryObject.Slots[5].item.buffs[8].stat; } else { op8_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op8_6 = (int)inventoryObject.Slots[6].item.buffs[8].stat; } else { op8_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op8_7 = (int)inventoryObject.Slots[7].item.buffs[8].stat; } else { op8_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op8_8 = (int)inventoryObject.Slots[8].item.buffs[8].stat; } else { op8_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op8_9 = (int)inventoryObject.Slots[9].item.buffs[8].stat; } else { op8_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op8_10 = (int)inventoryObject.Slots[10].item.buffs[8].stat; } else { op8_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op8_11 = (int)inventoryObject.Slots[11].item.buffs[8].stat; } else { op8_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op8_12 = (int)inventoryObject.Slots[12].item.buffs[8].stat; } else { op8_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op8_13 = (int)inventoryObject.Slots[13].item.buffs[8].stat; } else { op8_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op8_14 = (int)inventoryObject.Slots[14].item.buffs[8].stat; } else { op8_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op8_15 = (int)inventoryObject.Slots[15].item.buffs[8].stat; } else { op8_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op8_16 = (int)inventoryObject.Slots[16].item.buffs[8].stat; } else { op8_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op8_17 = (int)inventoryObject.Slots[17].item.buffs[8].stat; } else { op8_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op8_18 = (int)inventoryObject.Slots[18].item.buffs[8].stat; } else { op8_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op8_19 = (int)inventoryObject.Slots[19].item.buffs[8].stat; } else { op8_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op8_20 = (int)inventoryObject.Slots[20].item.buffs[8].stat; } else { op8_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op8_21 = (int)inventoryObject.Slots[21].item.buffs[8].stat; } else { op8_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op8_22 = (int)inventoryObject.Slots[22].item.buffs[8].stat; } else { op8_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op8_23 = (int)inventoryObject.Slots[23].item.buffs[8].stat; } else { op8_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op8_24 = (int)inventoryObject.Slots[24].item.buffs[8].stat; } else { op8_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op8_25 = (int)inventoryObject.Slots[25].item.buffs[8].stat; } else { op8_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op8_26 = (int)inventoryObject.Slots[26].item.buffs[8].stat; } else { op8_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op8_27 = (int)inventoryObject.Slots[27].item.buffs[8].stat; } else { op8_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op8_28 = (int)inventoryObject.Slots[28].item.buffs[8].stat; } else { op8_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op8_29 = (int)inventoryObject.Slots[29].item.buffs[8].stat; } else { op8_29 = -1; }
               
        DataManager.instance.nowPlayer.option8 = new int[] {op8_0,op8_1,op8_2,op8_3,op8_4,op8_5,op8_6,op8_7,op8_8,op8_9,op8_10,op8_11,op8_12,op8_13,op8_14,op8_15,op8_16,op8_17,op8_18,op8_19,op8_20,op8_21,op8_22,op8_23,op8_24,op8_25,op8_26,op8_27,op8_28,op8_29};
        #endregion

        #region 옵션9

        int op9_0,op9_1,op9_2,op9_3,op9_4,op9_5,op9_6,op9_7,op9_8,op9_9,op9_10,op9_11,op9_12,op9_13,op9_14,op9_15,op9_16,op9_17,op9_18,op9_19,op9_20,op9_21,op9_22,op9_23,op9_24,op9_25,op9_26,op9_27,op9_28,op9_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op9_0 = (int)inventoryObject.Slots[0].item.buffs[9].stat; } else { op9_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op9_1 = (int)inventoryObject.Slots[1].item.buffs[9].stat; } else { op9_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op9_2 = (int)inventoryObject.Slots[2].item.buffs[9].stat; } else { op9_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op9_3 = (int)inventoryObject.Slots[3].item.buffs[9].stat; } else { op9_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op9_4 = (int)inventoryObject.Slots[4].item.buffs[9].stat; } else { op9_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op9_5 = (int)inventoryObject.Slots[5].item.buffs[9].stat; } else { op9_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op9_6 = (int)inventoryObject.Slots[6].item.buffs[9].stat; } else { op9_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op9_7 = (int)inventoryObject.Slots[7].item.buffs[9].stat; } else { op9_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op9_8 = (int)inventoryObject.Slots[8].item.buffs[9].stat; } else { op9_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op9_9 = (int)inventoryObject.Slots[9].item.buffs[9].stat; } else { op9_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op9_10 = (int)inventoryObject.Slots[10].item.buffs[9].stat; } else { op9_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op9_11 = (int)inventoryObject.Slots[11].item.buffs[9].stat; } else { op9_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op9_12 = (int)inventoryObject.Slots[12].item.buffs[9].stat; } else { op9_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op9_13 = (int)inventoryObject.Slots[13].item.buffs[9].stat; } else { op9_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op9_14 = (int)inventoryObject.Slots[14].item.buffs[9].stat; } else { op9_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op9_15 = (int)inventoryObject.Slots[15].item.buffs[9].stat; } else { op9_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op9_16 = (int)inventoryObject.Slots[16].item.buffs[9].stat; } else { op9_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op9_17 = (int)inventoryObject.Slots[17].item.buffs[9].stat; } else { op9_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op9_18 = (int)inventoryObject.Slots[18].item.buffs[9].stat; } else { op9_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op9_19 = (int)inventoryObject.Slots[19].item.buffs[9].stat; } else { op9_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op9_20 = (int)inventoryObject.Slots[20].item.buffs[9].stat; } else { op9_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op9_21 = (int)inventoryObject.Slots[21].item.buffs[9].stat; } else { op9_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op9_22 = (int)inventoryObject.Slots[22].item.buffs[9].stat; } else { op9_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op9_23 = (int)inventoryObject.Slots[23].item.buffs[9].stat; } else { op9_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op9_24 = (int)inventoryObject.Slots[24].item.buffs[9].stat; } else { op9_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op9_25 = (int)inventoryObject.Slots[25].item.buffs[9].stat; } else { op9_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op9_26 = (int)inventoryObject.Slots[26].item.buffs[9].stat; } else { op9_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op9_27 = (int)inventoryObject.Slots[27].item.buffs[9].stat; } else { op9_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op9_28 = (int)inventoryObject.Slots[28].item.buffs[9].stat; } else { op9_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op9_29 = (int)inventoryObject.Slots[29].item.buffs[9].stat; } else { op9_29 = -1; }
               
        DataManager.instance.nowPlayer.option9 = new int[] {op9_0,op9_1,op9_2,op9_3,op9_4,op9_5,op9_6,op9_7,op9_8,op9_9,op9_10,op9_11,op9_12,op9_13,op9_14,op9_15,op9_16,op9_17,op9_18,op9_19,op9_20,op9_21,op9_22,op9_23,op9_24,op9_25,op9_26,op9_27,op9_28,op9_29};
        #endregion

        #region 옵션10

        int op10_0,op10_1,op10_2,op10_3,op10_4,op10_5,op10_6,op10_7,op10_8,op10_9,op10_10,op10_11,op10_12,op10_13,op10_14,op10_15,op10_16,op10_17,op10_18,op10_19,op10_20,op10_21,op10_22,op10_23,op10_24,op10_25,op10_26,op10_27,op10_28,op10_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op10_0 = (int)inventoryObject.Slots[0].item.buffs[9].stat; } else { op10_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op10_1 = (int)inventoryObject.Slots[1].item.buffs[9].stat; } else { op10_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op10_2 = (int)inventoryObject.Slots[2].item.buffs[9].stat; } else { op10_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op10_3 = (int)inventoryObject.Slots[3].item.buffs[9].stat; } else { op10_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op10_4 = (int)inventoryObject.Slots[4].item.buffs[9].stat; } else { op10_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op10_5 = (int)inventoryObject.Slots[5].item.buffs[9].stat; } else { op10_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op10_6 = (int)inventoryObject.Slots[6].item.buffs[9].stat; } else { op10_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op10_7 = (int)inventoryObject.Slots[7].item.buffs[9].stat; } else { op10_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op10_8 = (int)inventoryObject.Slots[8].item.buffs[9].stat; } else { op10_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op10_9 = (int)inventoryObject.Slots[9].item.buffs[9].stat; } else { op10_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op10_10 = (int)inventoryObject.Slots[10].item.buffs[9].stat; } else { op10_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op10_11 = (int)inventoryObject.Slots[11].item.buffs[9].stat; } else { op10_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op10_12 = (int)inventoryObject.Slots[12].item.buffs[9].stat; } else { op10_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op10_13 = (int)inventoryObject.Slots[13].item.buffs[9].stat; } else { op10_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op10_14 = (int)inventoryObject.Slots[14].item.buffs[9].stat; } else { op10_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op10_15 = (int)inventoryObject.Slots[15].item.buffs[9].stat; } else { op10_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op10_16 = (int)inventoryObject.Slots[16].item.buffs[9].stat; } else { op10_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op10_17 = (int)inventoryObject.Slots[17].item.buffs[9].stat; } else { op10_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op10_18 = (int)inventoryObject.Slots[18].item.buffs[9].stat; } else { op10_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op10_19 = (int)inventoryObject.Slots[19].item.buffs[9].stat; } else { op10_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op10_20 = (int)inventoryObject.Slots[20].item.buffs[9].stat; } else { op10_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op10_21 = (int)inventoryObject.Slots[21].item.buffs[9].stat; } else { op10_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op10_22 = (int)inventoryObject.Slots[22].item.buffs[9].stat; } else { op10_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op10_23 = (int)inventoryObject.Slots[23].item.buffs[9].stat; } else { op10_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op10_24 = (int)inventoryObject.Slots[24].item.buffs[9].stat; } else { op10_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op10_25 = (int)inventoryObject.Slots[25].item.buffs[9].stat; } else { op10_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op10_26 = (int)inventoryObject.Slots[26].item.buffs[9].stat; } else { op10_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op10_27 = (int)inventoryObject.Slots[27].item.buffs[9].stat; } else { op10_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op10_28 = (int)inventoryObject.Slots[28].item.buffs[9].stat; } else { op10_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op10_29 = (int)inventoryObject.Slots[29].item.buffs[9].stat; } else { op10_29 = -1; }
               
        DataManager.instance.nowPlayer.option10 = new int[] {op10_0,op10_1,op10_2,op10_3,op10_4,op10_5,op10_6,op10_7,op10_8,op10_9,op10_10,op10_11,op10_12,op10_13,op10_14,op10_15,op10_16,op10_17,op10_18,op10_19,op10_20,op10_21,op10_22,op10_23,op10_24,op10_25,op10_26,op10_27,op10_28,op10_29};
        #endregion

        #region 옵션11

        int op11_0,op11_1,op11_2,op11_3,op11_4,op11_5,op11_6,op11_7,op11_8,op11_9,op11_10,op11_11,op11_12,op11_13,op11_14,op11_15,op11_16,op11_17,op11_18,op11_19,op11_20,op11_21,op11_22,op11_23,op11_24,op11_25,op11_26,op11_27,op11_28,op11_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op11_0 = (int)inventoryObject.Slots[0].item.buffs[9].stat; } else { op11_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op11_1 = (int)inventoryObject.Slots[1].item.buffs[9].stat; } else { op11_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op11_2 = (int)inventoryObject.Slots[2].item.buffs[9].stat; } else { op11_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op11_3 = (int)inventoryObject.Slots[3].item.buffs[9].stat; } else { op11_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op11_4 = (int)inventoryObject.Slots[4].item.buffs[9].stat; } else { op11_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op11_5 = (int)inventoryObject.Slots[5].item.buffs[9].stat; } else { op11_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op11_6 = (int)inventoryObject.Slots[6].item.buffs[9].stat; } else { op11_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op11_7 = (int)inventoryObject.Slots[7].item.buffs[9].stat; } else { op11_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op11_8 = (int)inventoryObject.Slots[8].item.buffs[9].stat; } else { op11_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op11_9 = (int)inventoryObject.Slots[9].item.buffs[9].stat; } else { op11_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op11_10 = (int)inventoryObject.Slots[10].item.buffs[9].stat; } else { op11_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op11_11 = (int)inventoryObject.Slots[11].item.buffs[9].stat; } else { op11_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op11_12 = (int)inventoryObject.Slots[12].item.buffs[9].stat; } else { op11_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op11_13 = (int)inventoryObject.Slots[13].item.buffs[9].stat; } else { op11_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op11_14 = (int)inventoryObject.Slots[14].item.buffs[9].stat; } else { op11_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op11_15 = (int)inventoryObject.Slots[15].item.buffs[9].stat; } else { op11_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op11_16 = (int)inventoryObject.Slots[16].item.buffs[9].stat; } else { op11_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op11_17 = (int)inventoryObject.Slots[17].item.buffs[9].stat; } else { op11_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op11_18 = (int)inventoryObject.Slots[18].item.buffs[9].stat; } else { op11_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op11_19 = (int)inventoryObject.Slots[19].item.buffs[9].stat; } else { op11_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op11_20 = (int)inventoryObject.Slots[20].item.buffs[9].stat; } else { op11_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op11_21 = (int)inventoryObject.Slots[21].item.buffs[9].stat; } else { op11_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op11_22 = (int)inventoryObject.Slots[22].item.buffs[9].stat; } else { op11_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op11_23 = (int)inventoryObject.Slots[23].item.buffs[9].stat; } else { op11_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op11_24 = (int)inventoryObject.Slots[24].item.buffs[9].stat; } else { op11_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op11_25 = (int)inventoryObject.Slots[25].item.buffs[9].stat; } else { op11_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op11_26 = (int)inventoryObject.Slots[26].item.buffs[9].stat; } else { op11_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op11_27 = (int)inventoryObject.Slots[27].item.buffs[9].stat; } else { op11_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op11_28 = (int)inventoryObject.Slots[28].item.buffs[9].stat; } else { op11_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op11_29 = (int)inventoryObject.Slots[29].item.buffs[9].stat; } else { op11_29 = -1; }
               
        DataManager.instance.nowPlayer.option11 = new int[] {op11_0,op11_1,op11_2,op11_3,op11_4,op11_5,op11_6,op11_7,op11_8,op11_9,op11_10,op11_11,op11_12,op11_13,op11_14,op11_15,op11_16,op11_17,op11_18,op11_19,op11_20,op11_21,op11_22,op11_23,op11_24,op11_25,op11_26,op11_27,op11_28,op11_29};
        #endregion

    }

    private void tests1()
    {
        #region 옵션0 값

        int op0_0,op0_1,op0_2,op0_3,op0_4,op0_5,op0_6,op0_7,op0_8,op0_9,op0_10,op0_11,op0_12,op0_13,op0_14,op0_15,op0_16,op0_17,op0_18,op0_19,op0_20,op0_21,op0_22,op0_23,op0_24,op0_25,op0_26,op0_27,op0_28,op0_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op0_0 = inventoryObject.Slots[0].item.buffs[0].value; } else { op0_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op0_1 = inventoryObject.Slots[1].item.buffs[0].value; } else { op0_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op0_2 = inventoryObject.Slots[2].item.buffs[0].value; } else { op0_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op0_3 = inventoryObject.Slots[3].item.buffs[0].value; } else { op0_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op0_4 = inventoryObject.Slots[4].item.buffs[0].value; } else { op0_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op0_5 = inventoryObject.Slots[5].item.buffs[0].value; } else { op0_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op0_6 = inventoryObject.Slots[6].item.buffs[0].value; } else { op0_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op0_7 = inventoryObject.Slots[7].item.buffs[0].value; } else { op0_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op0_8 = inventoryObject.Slots[8].item.buffs[0].value; } else { op0_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op0_9 = inventoryObject.Slots[9].item.buffs[0].value; } else { op0_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op0_10 = inventoryObject.Slots[10].item.buffs[0].value; } else { op0_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op0_11 = inventoryObject.Slots[11].item.buffs[0].value; } else { op0_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op0_12 = inventoryObject.Slots[12].item.buffs[0].value; } else { op0_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op0_13 = inventoryObject.Slots[13].item.buffs[0].value; } else { op0_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op0_14 = inventoryObject.Slots[14].item.buffs[0].value; } else { op0_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op0_15 = inventoryObject.Slots[15].item.buffs[0].value; } else { op0_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op0_16 = inventoryObject.Slots[16].item.buffs[0].value; } else { op0_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op0_17 = inventoryObject.Slots[17].item.buffs[0].value; } else { op0_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op0_18 = inventoryObject.Slots[18].item.buffs[0].value; } else { op0_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op0_19 = inventoryObject.Slots[19].item.buffs[0].value; } else { op0_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op0_20 = inventoryObject.Slots[20].item.buffs[0].value; } else { op0_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op0_21 = inventoryObject.Slots[21].item.buffs[0].value; } else { op0_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op0_22 = inventoryObject.Slots[22].item.buffs[0].value; } else { op0_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op0_23 = inventoryObject.Slots[23].item.buffs[0].value; } else { op0_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op0_24 = inventoryObject.Slots[24].item.buffs[0].value; } else { op0_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op0_25 = inventoryObject.Slots[25].item.buffs[0].value; } else { op0_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op0_26 = inventoryObject.Slots[26].item.buffs[0].value; } else { op0_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op0_27 = inventoryObject.Slots[27].item.buffs[0].value; } else { op0_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op0_28 = inventoryObject.Slots[28].item.buffs[0].value; } else { op0_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op0_29 = inventoryObject.Slots[29].item.buffs[0].value; } else { op0_29 = -1; }
               
        DataManager.instance.nowPlayer.optionValue0 = new int[] {op0_0,op0_1,op0_2,op0_3,op0_4,op0_5,op0_6,op0_7,op0_8,op0_9,op0_10,op0_11,op0_12,op0_13,op0_14,op0_15,op0_16,op0_17,op0_18,op0_19,op0_20,op0_21,op0_22,op0_23,op0_24,op0_25,op0_26,op0_27,op0_28,op0_29};
        #endregion
    
        #region 옵션1 값 

        int op1_0,op1_1,op1_2,op1_3,op1_4,op1_5,op1_6,op1_7,op1_8,op1_9,op1_10,op1_11,op1_12,op1_13,op1_14,op1_15,op1_16,op1_17,op1_18,op1_19,op1_20,op1_21,op1_22,op1_23,op1_24,op1_25,op1_26,op1_27,op1_28,op1_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op1_0 = inventoryObject.Slots[0].item.buffs[1].value; } else { op1_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op1_1 = inventoryObject.Slots[1].item.buffs[1].value; } else { op1_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op1_2 = inventoryObject.Slots[2].item.buffs[1].value; } else { op1_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op1_3 = inventoryObject.Slots[3].item.buffs[1].value; } else { op1_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op1_4 = inventoryObject.Slots[4].item.buffs[1].value; } else { op1_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op1_5 = inventoryObject.Slots[5].item.buffs[1].value; } else { op1_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op1_6 = inventoryObject.Slots[6].item.buffs[1].value; } else { op1_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op1_7 = inventoryObject.Slots[7].item.buffs[1].value; } else { op1_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op1_8 = inventoryObject.Slots[8].item.buffs[1].value; } else { op1_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op1_9 = inventoryObject.Slots[9].item.buffs[1].value; } else { op1_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op1_10 = inventoryObject.Slots[10].item.buffs[1].value; } else { op1_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op1_11 = inventoryObject.Slots[11].item.buffs[1].value; } else { op1_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op1_12 = inventoryObject.Slots[12].item.buffs[1].value; } else { op1_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op1_13 = inventoryObject.Slots[13].item.buffs[1].value; } else { op1_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op1_14 = inventoryObject.Slots[14].item.buffs[1].value; } else { op1_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op1_15 = inventoryObject.Slots[15].item.buffs[1].value; } else { op1_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op1_16 = inventoryObject.Slots[16].item.buffs[1].value; } else { op1_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op1_17 = inventoryObject.Slots[17].item.buffs[1].value; } else { op1_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op1_18 = inventoryObject.Slots[18].item.buffs[1].value; } else { op1_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op1_19 = inventoryObject.Slots[19].item.buffs[1].value; } else { op1_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op1_20 = inventoryObject.Slots[20].item.buffs[1].value; } else { op1_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op1_21 = inventoryObject.Slots[21].item.buffs[1].value; } else { op1_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op1_22 = inventoryObject.Slots[22].item.buffs[1].value; } else { op1_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op1_23 = inventoryObject.Slots[23].item.buffs[1].value; } else { op1_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op1_24 = inventoryObject.Slots[24].item.buffs[1].value; } else { op1_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op1_25 = inventoryObject.Slots[25].item.buffs[1].value; } else { op1_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op1_26 = inventoryObject.Slots[26].item.buffs[1].value; } else { op1_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op1_27 = inventoryObject.Slots[27].item.buffs[1].value; } else { op1_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op1_28 = inventoryObject.Slots[28].item.buffs[1].value; } else { op1_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op1_29 = inventoryObject.Slots[29].item.buffs[1].value; } else { op1_29 = -1; }
               
        DataManager.instance.nowPlayer.optionValue1 = new int[] {op1_0,op1_1,op1_2,op1_3,op1_4,op1_5,op1_6,op1_7,op1_8,op1_9,op1_10,op1_11,op1_12,op1_13,op1_14,op1_15,op1_16,op1_17,op1_18,op1_19,op1_20,op1_21,op1_22,op1_23,op1_24,op1_25,op1_26,op1_27,op1_28,op1_29};
        #endregion
    
        #region 옵션2 값

        int op2_0,op2_1,op2_2,op2_3,op2_4,op2_5,op2_6,op2_7,op2_8,op2_9,op2_10,op2_11,op2_12,op2_13,op2_14,op2_15,op2_16,op2_17,op2_18,op2_19,op2_20,op2_21,op2_22,op2_23,op2_24,op2_25,op2_26,op2_27,op2_28,op2_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op2_0 = inventoryObject.Slots[0].item.buffs[2].value; } else { op2_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op2_1 = inventoryObject.Slots[1].item.buffs[2].value; } else { op2_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op2_2 = inventoryObject.Slots[2].item.buffs[2].value; } else { op2_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op2_3 = inventoryObject.Slots[3].item.buffs[2].value; } else { op2_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op2_4 = inventoryObject.Slots[4].item.buffs[2].value; } else { op2_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op2_5 = inventoryObject.Slots[5].item.buffs[2].value; } else { op2_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op2_6 = inventoryObject.Slots[6].item.buffs[2].value; } else { op2_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op2_7 = inventoryObject.Slots[7].item.buffs[2].value; } else { op2_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op2_8 = inventoryObject.Slots[8].item.buffs[2].value; } else { op2_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op2_9 = inventoryObject.Slots[9].item.buffs[2].value; } else { op2_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op2_10 = inventoryObject.Slots[10].item.buffs[2].value; } else { op2_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op2_11 = inventoryObject.Slots[11].item.buffs[2].value; } else { op2_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op2_12 = inventoryObject.Slots[12].item.buffs[2].value; } else { op2_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op2_13 = inventoryObject.Slots[13].item.buffs[2].value; } else { op2_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op2_14 = inventoryObject.Slots[14].item.buffs[2].value; } else { op2_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op2_15 = inventoryObject.Slots[15].item.buffs[2].value; } else { op2_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op2_16 = inventoryObject.Slots[16].item.buffs[2].value; } else { op2_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op2_17 = inventoryObject.Slots[17].item.buffs[2].value; } else { op2_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op2_18 = inventoryObject.Slots[18].item.buffs[2].value; } else { op2_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op2_19 = inventoryObject.Slots[19].item.buffs[2].value; } else { op2_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op2_20 = inventoryObject.Slots[20].item.buffs[2].value; } else { op2_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op2_21 = inventoryObject.Slots[21].item.buffs[2].value; } else { op2_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op2_22 = inventoryObject.Slots[22].item.buffs[2].value; } else { op2_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op2_23 = inventoryObject.Slots[23].item.buffs[2].value; } else { op2_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op2_24 = inventoryObject.Slots[24].item.buffs[2].value; } else { op2_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op2_25 = inventoryObject.Slots[25].item.buffs[2].value; } else { op2_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op2_26 = inventoryObject.Slots[26].item.buffs[2].value; } else { op2_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op2_27 = inventoryObject.Slots[27].item.buffs[2].value; } else { op2_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op2_28 = inventoryObject.Slots[28].item.buffs[2].value; } else { op2_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op2_29 = inventoryObject.Slots[29].item.buffs[2].value; } else { op2_29 = -1; }
               
        DataManager.instance.nowPlayer.optionValue2 = new int[] {op2_0,op2_1,op2_2,op2_3,op2_4,op2_5,op2_6,op2_7,op2_8,op2_9,op2_10,op2_11,op2_12,op2_13,op2_14,op2_15,op2_16,op2_17,op2_18,op2_19,op2_20,op2_21,op2_22,op2_23,op2_24,op2_25,op2_26,op2_27,op2_28,op2_29};
        #endregion
    
        #region 옵션3 값

        int op3_0,op3_1,op3_2,op3_3,op3_4,op3_5,op3_6,op3_7,op3_8,op3_9,op3_10,op3_11,op3_12,op3_13,op3_14,op3_15,op3_16,op3_17,op3_18,op3_19,op3_20,op3_21,op3_22,op3_23,op3_24,op3_25,op3_26,op3_27,op3_28,op3_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op3_0 = inventoryObject.Slots[0].item.buffs[3].value; } else { op3_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op3_1 = inventoryObject.Slots[1].item.buffs[3].value; } else { op3_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op3_2 = inventoryObject.Slots[2].item.buffs[3].value; } else { op3_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op3_3 = inventoryObject.Slots[3].item.buffs[3].value; } else { op3_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op3_4 = inventoryObject.Slots[4].item.buffs[3].value; } else { op3_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op3_5 = inventoryObject.Slots[5].item.buffs[3].value; } else { op3_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op3_6 = inventoryObject.Slots[6].item.buffs[3].value; } else { op3_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op3_7 = inventoryObject.Slots[7].item.buffs[3].value; } else { op3_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op3_8 = inventoryObject.Slots[8].item.buffs[3].value; } else { op3_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op3_9 = inventoryObject.Slots[9].item.buffs[3].value; } else { op3_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op3_10 = inventoryObject.Slots[10].item.buffs[3].value; } else { op3_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op3_11 = inventoryObject.Slots[11].item.buffs[3].value; } else { op3_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op3_12 = inventoryObject.Slots[12].item.buffs[3].value; } else { op3_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op3_13 = inventoryObject.Slots[13].item.buffs[3].value; } else { op3_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op3_14 = inventoryObject.Slots[14].item.buffs[3].value; } else { op3_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op3_15 = inventoryObject.Slots[15].item.buffs[3].value; } else { op3_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op3_16 = inventoryObject.Slots[16].item.buffs[3].value; } else { op3_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op3_17 = inventoryObject.Slots[17].item.buffs[3].value; } else { op3_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op3_18 = inventoryObject.Slots[18].item.buffs[3].value; } else { op3_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op3_19 = inventoryObject.Slots[19].item.buffs[3].value; } else { op3_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op3_20 = inventoryObject.Slots[20].item.buffs[3].value; } else { op3_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op3_21 = inventoryObject.Slots[21].item.buffs[3].value; } else { op3_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op3_22 = inventoryObject.Slots[22].item.buffs[3].value; } else { op3_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op3_23 = inventoryObject.Slots[23].item.buffs[3].value; } else { op3_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op3_24 = inventoryObject.Slots[24].item.buffs[3].value; } else { op3_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op3_25 = inventoryObject.Slots[25].item.buffs[3].value; } else { op3_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op3_26 = inventoryObject.Slots[26].item.buffs[3].value; } else { op3_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op3_27 = inventoryObject.Slots[27].item.buffs[3].value; } else { op3_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op3_28 = inventoryObject.Slots[28].item.buffs[3].value; } else { op3_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op3_29 = inventoryObject.Slots[29].item.buffs[3].value; } else { op3_29 = -1; }
               
        DataManager.instance.nowPlayer.optionValue3 = new int[] {op3_0,op3_1,op3_2,op3_3,op3_4,op3_5,op3_6,op3_7,op3_8,op3_9,op3_10,op3_11,op3_12,op3_13,op3_14,op3_15,op3_16,op3_17,op3_18,op3_19,op3_20,op3_21,op3_22,op3_23,op3_24,op3_25,op3_26,op3_27,op3_28,op3_29};
        #endregion
    
        #region 옵션4 값

        int op4_0,op4_1,op4_2,op4_3,op4_4,op4_5,op4_6,op4_7,op4_8,op4_9,op4_10,op4_11,op4_12,op4_13,op4_14,op4_15,op4_16,op4_17,op4_18,op4_19,op4_20,op4_21,op4_22,op4_23,op4_24,op4_25,op4_26,op4_27,op4_28,op4_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op4_0 = inventoryObject.Slots[0].item.buffs[4].value; } else { op4_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op4_1 = inventoryObject.Slots[1].item.buffs[4].value; } else { op4_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op4_2 = inventoryObject.Slots[2].item.buffs[4].value; } else { op4_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op4_3 = inventoryObject.Slots[3].item.buffs[4].value; } else { op4_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op4_4 = inventoryObject.Slots[4].item.buffs[4].value; } else { op4_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op4_5 = inventoryObject.Slots[5].item.buffs[4].value; } else { op4_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op4_6 = inventoryObject.Slots[6].item.buffs[4].value; } else { op4_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op4_7 = inventoryObject.Slots[7].item.buffs[4].value; } else { op4_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op4_8 = inventoryObject.Slots[8].item.buffs[4].value; } else { op4_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op4_9 = inventoryObject.Slots[9].item.buffs[4].value; } else { op4_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op4_10 = inventoryObject.Slots[10].item.buffs[4].value; } else { op4_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op4_11 = inventoryObject.Slots[11].item.buffs[4].value; } else { op4_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op4_12 = inventoryObject.Slots[12].item.buffs[4].value; } else { op4_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op4_13 = inventoryObject.Slots[13].item.buffs[4].value; } else { op4_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op4_14 = inventoryObject.Slots[14].item.buffs[4].value; } else { op4_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op4_15 = inventoryObject.Slots[15].item.buffs[4].value; } else { op4_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op4_16 = inventoryObject.Slots[16].item.buffs[4].value; } else { op4_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op4_17 = inventoryObject.Slots[17].item.buffs[4].value; } else { op4_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op4_18 = inventoryObject.Slots[18].item.buffs[4].value; } else { op4_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op4_19 = inventoryObject.Slots[19].item.buffs[4].value; } else { op4_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op4_20 = inventoryObject.Slots[20].item.buffs[4].value; } else { op4_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op4_21 = inventoryObject.Slots[21].item.buffs[4].value; } else { op4_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op4_22 = inventoryObject.Slots[22].item.buffs[4].value; } else { op4_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op4_23 = inventoryObject.Slots[23].item.buffs[4].value; } else { op4_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op4_24 = inventoryObject.Slots[24].item.buffs[4].value; } else { op4_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op4_25 = inventoryObject.Slots[25].item.buffs[4].value; } else { op4_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op4_26 = inventoryObject.Slots[26].item.buffs[4].value; } else { op4_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op4_27 = inventoryObject.Slots[27].item.buffs[4].value; } else { op4_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op4_28 = inventoryObject.Slots[28].item.buffs[4].value; } else { op4_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op4_29 = inventoryObject.Slots[29].item.buffs[4].value; } else { op4_29 = -1; }
               
        DataManager.instance.nowPlayer.optionValue4 = new int[] {op4_0,op4_1,op4_2,op4_3,op4_4,op4_5,op4_6,op4_7,op4_8,op4_9,op4_10,op4_11,op4_12,op4_13,op4_14,op4_15,op4_16,op4_17,op4_18,op4_19,op4_20,op4_21,op4_22,op4_23,op4_24,op4_25,op4_26,op4_27,op4_28,op4_29};
        #endregion
    
        #region 옵션5 값

        int op5_0,op5_1,op5_2,op5_3,op5_4,op5_5,op5_6,op5_7,op5_8,op5_9,op5_10,op5_11,op5_12,op5_13,op5_14,op5_15,op5_16,op5_17,op5_18,op5_19,op5_20,op5_21,op5_22,op5_23,op5_24,op5_25,op5_26,op5_27,op5_28,op5_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op5_0 = inventoryObject.Slots[0].item.buffs[5].value; } else { op5_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op5_1 = inventoryObject.Slots[1].item.buffs[5].value; } else { op5_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op5_2 = inventoryObject.Slots[2].item.buffs[5].value; } else { op5_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op5_3 = inventoryObject.Slots[3].item.buffs[5].value; } else { op5_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op5_4 = inventoryObject.Slots[4].item.buffs[5].value; } else { op5_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op5_5 = inventoryObject.Slots[5].item.buffs[5].value; } else { op5_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op5_6 = inventoryObject.Slots[6].item.buffs[5].value; } else { op5_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op5_7 = inventoryObject.Slots[7].item.buffs[5].value; } else { op5_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op5_8 = inventoryObject.Slots[8].item.buffs[5].value; } else { op5_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op5_9 = inventoryObject.Slots[9].item.buffs[5].value; } else { op5_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op5_10 = inventoryObject.Slots[10].item.buffs[5].value; } else { op5_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op5_11 = inventoryObject.Slots[11].item.buffs[5].value; } else { op5_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op5_12 = inventoryObject.Slots[12].item.buffs[5].value; } else { op5_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op5_13 = inventoryObject.Slots[13].item.buffs[5].value; } else { op5_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op5_14 = inventoryObject.Slots[14].item.buffs[5].value; } else { op5_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op5_15 = inventoryObject.Slots[15].item.buffs[5].value; } else { op5_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op5_16 = inventoryObject.Slots[16].item.buffs[5].value; } else { op5_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op5_17 = inventoryObject.Slots[17].item.buffs[5].value; } else { op5_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op5_18 = inventoryObject.Slots[18].item.buffs[5].value; } else { op5_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op5_19 = inventoryObject.Slots[19].item.buffs[5].value; } else { op5_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op5_20 = inventoryObject.Slots[20].item.buffs[5].value; } else { op5_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op5_21 = inventoryObject.Slots[21].item.buffs[5].value; } else { op5_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op5_22 = inventoryObject.Slots[22].item.buffs[5].value; } else { op5_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op5_23 = inventoryObject.Slots[23].item.buffs[5].value; } else { op5_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op5_24 = inventoryObject.Slots[24].item.buffs[5].value; } else { op5_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op5_25 = inventoryObject.Slots[25].item.buffs[5].value; } else { op5_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op5_26 = inventoryObject.Slots[26].item.buffs[5].value; } else { op5_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op5_27 = inventoryObject.Slots[27].item.buffs[5].value; } else { op5_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op5_28 = inventoryObject.Slots[28].item.buffs[5].value; } else { op5_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op5_29 = inventoryObject.Slots[29].item.buffs[5].value; } else { op5_29 = -1; }
               
        DataManager.instance.nowPlayer.optionValue5 = new int[] {op5_0,op5_1,op5_2,op5_3,op5_4,op5_5,op5_6,op5_7,op5_8,op5_9,op5_10,op5_11,op5_12,op5_13,op5_14,op5_15,op5_16,op5_17,op5_18,op5_19,op5_20,op5_21,op5_22,op5_23,op5_24,op5_25,op5_26,op5_27,op5_28,op5_29};
        #endregion
  
        #region 옵션6 값

        int op6_0,op6_1,op6_2,op6_3,op6_4,op6_5,op6_6,op6_7,op6_8,op6_9,op6_10,op6_11,op6_12,op6_13,op6_14,op6_15,op6_16,op6_17,op6_18,op6_19,op6_20,op6_21,op6_22,op6_23,op6_24,op6_25,op6_26,op6_27,op6_28,op6_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op6_0 = inventoryObject.Slots[0].item.buffs[6].value; } else { op6_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op6_1 = inventoryObject.Slots[1].item.buffs[6].value; } else { op6_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op6_2 = inventoryObject.Slots[2].item.buffs[6].value; } else { op6_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op6_3 = inventoryObject.Slots[3].item.buffs[6].value; } else { op6_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op6_4 = inventoryObject.Slots[4].item.buffs[6].value; } else { op6_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op6_5 = inventoryObject.Slots[5].item.buffs[6].value; } else { op6_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op6_6 = inventoryObject.Slots[6].item.buffs[6].value; } else { op6_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op6_7 = inventoryObject.Slots[7].item.buffs[6].value; } else { op6_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op6_8 = inventoryObject.Slots[8].item.buffs[6].value; } else { op6_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op6_9 = inventoryObject.Slots[9].item.buffs[6].value; } else { op6_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op6_10 = inventoryObject.Slots[10].item.buffs[6].value; } else { op6_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op6_11 = inventoryObject.Slots[11].item.buffs[6].value; } else { op6_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op6_12 = inventoryObject.Slots[12].item.buffs[6].value; } else { op6_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op6_13 = inventoryObject.Slots[13].item.buffs[6].value; } else { op6_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op6_14 = inventoryObject.Slots[14].item.buffs[6].value; } else { op6_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op6_15 = inventoryObject.Slots[15].item.buffs[6].value; } else { op6_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op6_16 = inventoryObject.Slots[16].item.buffs[6].value; } else { op6_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op6_17 = inventoryObject.Slots[17].item.buffs[6].value; } else { op6_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op6_18 = inventoryObject.Slots[18].item.buffs[6].value; } else { op6_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op6_19 = inventoryObject.Slots[19].item.buffs[6].value; } else { op6_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op6_20 = inventoryObject.Slots[20].item.buffs[6].value; } else { op6_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op6_21 = inventoryObject.Slots[21].item.buffs[6].value; } else { op6_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op6_22 = inventoryObject.Slots[22].item.buffs[6].value; } else { op6_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op6_23 = inventoryObject.Slots[23].item.buffs[6].value; } else { op6_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op6_24 = inventoryObject.Slots[24].item.buffs[6].value; } else { op6_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op6_25 = inventoryObject.Slots[25].item.buffs[6].value; } else { op6_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op6_26 = inventoryObject.Slots[26].item.buffs[6].value; } else { op6_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op6_27 = inventoryObject.Slots[27].item.buffs[6].value; } else { op6_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op6_28 = inventoryObject.Slots[28].item.buffs[6].value; } else { op6_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op6_29 = inventoryObject.Slots[29].item.buffs[6].value; } else { op6_29 = -1; }
               
        DataManager.instance.nowPlayer.optionValue6 = new int[] {op6_0,op6_1,op6_2,op6_3,op6_4,op6_5,op6_6,op6_7,op6_8,op6_9,op6_10,op6_11,op6_12,op6_13,op6_14,op6_15,op6_16,op6_17,op6_18,op6_19,op6_20,op6_21,op6_22,op6_23,op6_24,op6_25,op6_26,op6_27,op6_28,op6_29};
        #endregion

        #region 옵션7 값

        int op7_0,op7_1,op7_2,op7_3,op7_4,op7_5,op7_6,op7_7,op7_8,op7_9,op7_10,op7_11,op7_12,op7_13,op7_14,op7_15,op7_16,op7_17,op7_18,op7_19,op7_20,op7_21,op7_22,op7_23,op7_24,op7_25,op7_26,op7_27,op7_28,op7_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op7_0 = inventoryObject.Slots[0].item.buffs[7].value; } else { op7_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op7_1 = inventoryObject.Slots[1].item.buffs[7].value; } else { op7_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op7_2 = inventoryObject.Slots[2].item.buffs[7].value; } else { op7_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op7_3 = inventoryObject.Slots[3].item.buffs[7].value; } else { op7_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op7_4 = inventoryObject.Slots[4].item.buffs[7].value; } else { op7_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op7_5 = inventoryObject.Slots[5].item.buffs[7].value; } else { op7_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op7_6 = inventoryObject.Slots[6].item.buffs[7].value; } else { op7_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op7_7 = inventoryObject.Slots[7].item.buffs[7].value; } else { op7_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op7_8 = inventoryObject.Slots[8].item.buffs[7].value; } else { op7_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op7_9 = inventoryObject.Slots[9].item.buffs[7].value; } else { op7_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op7_10 = inventoryObject.Slots[10].item.buffs[7].value; } else { op7_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op7_11 = inventoryObject.Slots[11].item.buffs[7].value; } else { op7_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op7_12 = inventoryObject.Slots[12].item.buffs[7].value; } else { op7_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op7_13 = inventoryObject.Slots[13].item.buffs[7].value; } else { op7_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op7_14 = inventoryObject.Slots[14].item.buffs[7].value; } else { op7_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op7_15 = inventoryObject.Slots[15].item.buffs[7].value; } else { op7_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op7_16 = inventoryObject.Slots[16].item.buffs[7].value; } else { op7_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op7_17 = inventoryObject.Slots[17].item.buffs[7].value; } else { op7_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op7_18 = inventoryObject.Slots[18].item.buffs[7].value; } else { op7_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op7_19 = inventoryObject.Slots[19].item.buffs[7].value; } else { op7_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op7_20 = inventoryObject.Slots[20].item.buffs[7].value; } else { op7_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op7_21 = inventoryObject.Slots[21].item.buffs[7].value; } else { op7_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op7_22 = inventoryObject.Slots[22].item.buffs[7].value; } else { op7_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op7_23 = inventoryObject.Slots[23].item.buffs[7].value; } else { op7_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op7_24 = inventoryObject.Slots[24].item.buffs[7].value; } else { op7_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op7_25 = inventoryObject.Slots[25].item.buffs[7].value; } else { op7_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op7_26 = inventoryObject.Slots[26].item.buffs[7].value; } else { op7_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op7_27 = inventoryObject.Slots[27].item.buffs[7].value; } else { op7_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op7_28 = inventoryObject.Slots[28].item.buffs[7].value; } else { op7_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op7_29 = inventoryObject.Slots[29].item.buffs[7].value; } else { op7_29 = -1; }
               
        DataManager.instance.nowPlayer.optionValue7 = new int[] {op7_0,op7_1,op7_2,op7_3,op7_4,op7_5,op7_6,op7_7,op7_8,op7_9,op7_10,op7_11,op7_12,op7_13,op7_14,op7_15,op7_16,op7_17,op7_18,op7_19,op7_20,op7_21,op7_22,op7_23,op7_24,op7_25,op7_26,op7_27,op7_28,op7_29};
        #endregion

        #region 옵션8 값

        int op8_0,op8_1,op8_2,op8_3,op8_4,op8_5,op8_6,op8_7,op8_8,op8_9,op8_10,op8_11,op8_12,op8_13,op8_14,op8_15,op8_16,op8_17,op8_18,op8_19,op8_20,op8_21,op8_22,op8_23,op8_24,op8_25,op8_26,op8_27,op8_28,op8_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op8_0 = inventoryObject.Slots[0].item.buffs[8].value; } else { op8_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op8_1 = inventoryObject.Slots[1].item.buffs[8].value; } else { op8_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op8_2 = inventoryObject.Slots[2].item.buffs[8].value; } else { op8_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op8_3 = inventoryObject.Slots[3].item.buffs[8].value; } else { op8_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op8_4 = inventoryObject.Slots[4].item.buffs[8].value; } else { op8_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op8_5 = inventoryObject.Slots[5].item.buffs[8].value; } else { op8_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op8_6 = inventoryObject.Slots[6].item.buffs[8].value; } else { op8_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op8_7 = inventoryObject.Slots[7].item.buffs[8].value; } else { op8_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op8_8 = inventoryObject.Slots[8].item.buffs[8].value; } else { op8_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op8_9 = inventoryObject.Slots[9].item.buffs[8].value; } else { op8_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op8_10 = inventoryObject.Slots[10].item.buffs[8].value; } else { op8_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op8_11 = inventoryObject.Slots[11].item.buffs[8].value; } else { op8_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op8_12 = inventoryObject.Slots[12].item.buffs[8].value; } else { op8_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op8_13 = inventoryObject.Slots[13].item.buffs[8].value; } else { op8_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op8_14 = inventoryObject.Slots[14].item.buffs[8].value; } else { op8_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op8_15 = inventoryObject.Slots[15].item.buffs[8].value; } else { op8_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op8_16 = inventoryObject.Slots[16].item.buffs[8].value; } else { op8_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op8_17 = inventoryObject.Slots[17].item.buffs[8].value; } else { op8_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op8_18 = inventoryObject.Slots[18].item.buffs[8].value; } else { op8_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op8_19 = inventoryObject.Slots[19].item.buffs[8].value; } else { op8_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op8_20 = inventoryObject.Slots[20].item.buffs[8].value; } else { op8_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op8_21 = inventoryObject.Slots[21].item.buffs[8].value; } else { op8_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op8_22 = inventoryObject.Slots[22].item.buffs[8].value; } else { op8_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op8_23 = inventoryObject.Slots[23].item.buffs[8].value; } else { op8_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op8_24 = inventoryObject.Slots[24].item.buffs[8].value; } else { op8_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op8_25 = inventoryObject.Slots[25].item.buffs[8].value; } else { op8_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op8_26 = inventoryObject.Slots[26].item.buffs[8].value; } else { op8_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op8_27 = inventoryObject.Slots[27].item.buffs[8].value; } else { op8_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op8_28 = inventoryObject.Slots[28].item.buffs[8].value; } else { op8_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op8_29 = inventoryObject.Slots[29].item.buffs[8].value; } else { op8_29 = -1; }
               
        DataManager.instance.nowPlayer.optionValue8 = new int[] {op8_0,op8_1,op8_2,op8_3,op8_4,op8_5,op8_6,op8_7,op8_8,op8_9,op8_10,op8_11,op8_12,op8_13,op8_14,op8_15,op8_16,op8_17,op8_18,op8_19,op8_20,op8_21,op8_22,op8_23,op8_24,op8_25,op8_26,op8_27,op8_28,op8_29};
        #endregion

        #region 옵션9 값

        int op9_0,op9_1,op9_2,op9_3,op9_4,op9_5,op9_6,op9_7,op9_8,op9_9,op9_10,op9_11,op9_12,op9_13,op9_14,op9_15,op9_16,op9_17,op9_18,op9_19,op9_20,op9_21,op9_22,op9_23,op9_24,op9_25,op9_26,op9_27,op9_28,op9_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op9_0 = inventoryObject.Slots[0].item.buffs[9].value; } else { op9_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op9_1 = inventoryObject.Slots[1].item.buffs[9].value; } else { op9_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op9_2 = inventoryObject.Slots[2].item.buffs[9].value; } else { op9_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op9_3 = inventoryObject.Slots[3].item.buffs[9].value; } else { op9_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op9_4 = inventoryObject.Slots[4].item.buffs[9].value; } else { op9_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op9_5 = inventoryObject.Slots[5].item.buffs[9].value; } else { op9_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op9_6 = inventoryObject.Slots[6].item.buffs[9].value; } else { op9_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op9_7 = inventoryObject.Slots[7].item.buffs[9].value; } else { op9_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op9_8 = inventoryObject.Slots[8].item.buffs[9].value; } else { op9_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op9_9 = inventoryObject.Slots[9].item.buffs[9].value; } else { op9_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op9_10 = inventoryObject.Slots[10].item.buffs[9].value; } else { op9_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op9_11 = inventoryObject.Slots[11].item.buffs[9].value; } else { op9_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op9_12 = inventoryObject.Slots[12].item.buffs[9].value; } else { op9_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op9_13 = inventoryObject.Slots[13].item.buffs[9].value; } else { op9_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op9_14 = inventoryObject.Slots[14].item.buffs[9].value; } else { op9_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op9_15 = inventoryObject.Slots[15].item.buffs[9].value; } else { op9_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op9_16 = inventoryObject.Slots[16].item.buffs[9].value; } else { op9_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op9_17 = inventoryObject.Slots[17].item.buffs[9].value; } else { op9_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op9_18 = inventoryObject.Slots[18].item.buffs[9].value; } else { op9_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op9_19 = inventoryObject.Slots[19].item.buffs[9].value; } else { op9_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op9_20 = inventoryObject.Slots[20].item.buffs[9].value; } else { op9_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op9_21 = inventoryObject.Slots[21].item.buffs[9].value; } else { op9_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op9_22 = inventoryObject.Slots[22].item.buffs[9].value; } else { op9_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op9_23 = inventoryObject.Slots[23].item.buffs[9].value; } else { op9_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op9_24 = inventoryObject.Slots[24].item.buffs[9].value; } else { op9_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op9_25 = inventoryObject.Slots[25].item.buffs[9].value; } else { op9_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op9_26 = inventoryObject.Slots[26].item.buffs[9].value; } else { op9_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op9_27 = inventoryObject.Slots[27].item.buffs[9].value; } else { op9_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op9_28 = inventoryObject.Slots[28].item.buffs[9].value; } else { op9_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op9_29 = inventoryObject.Slots[29].item.buffs[9].value; } else { op9_29 = -1; }
               
        DataManager.instance.nowPlayer.optionValue9 = new int[] {op9_0,op9_1,op9_2,op9_3,op9_4,op9_5,op9_6,op9_7,op9_8,op9_9,op9_10,op9_11,op9_12,op9_13,op9_14,op9_15,op9_16,op9_17,op9_18,op9_19,op9_20,op9_21,op9_22,op9_23,op9_24,op9_25,op9_26,op9_27,op9_28,op9_29};
        #endregion

        #region 옵션10 값

        int op10_0,op10_1,op10_2,op10_3,op10_4,op10_5,op10_6,op10_7,op10_8,op10_9,op10_10,op10_11,op10_12,op10_13,op10_14,op10_15,op10_16,op10_17,op10_18,op10_19,op10_20,op10_21,op10_22,op10_23,op10_24,op10_25,op10_26,op10_27,op10_28,op10_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op10_0 = inventoryObject.Slots[0].item.buffs[9].value; } else { op10_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op10_1 = inventoryObject.Slots[1].item.buffs[9].value; } else { op10_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op10_2 = inventoryObject.Slots[2].item.buffs[9].value; } else { op10_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op10_3 = inventoryObject.Slots[3].item.buffs[9].value; } else { op10_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op10_4 = inventoryObject.Slots[4].item.buffs[9].value; } else { op10_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op10_5 = inventoryObject.Slots[5].item.buffs[9].value; } else { op10_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op10_6 = inventoryObject.Slots[6].item.buffs[9].value; } else { op10_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op10_7 = inventoryObject.Slots[7].item.buffs[9].value; } else { op10_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op10_8 = inventoryObject.Slots[8].item.buffs[9].value; } else { op10_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op10_9 = inventoryObject.Slots[9].item.buffs[9].value; } else { op10_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op10_10 = inventoryObject.Slots[10].item.buffs[9].value; } else { op10_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op10_11 = inventoryObject.Slots[11].item.buffs[9].value; } else { op10_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op10_12 = inventoryObject.Slots[12].item.buffs[9].value; } else { op10_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op10_13 = inventoryObject.Slots[13].item.buffs[9].value; } else { op10_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op10_14 = inventoryObject.Slots[14].item.buffs[9].value; } else { op10_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op10_15 = inventoryObject.Slots[15].item.buffs[9].value; } else { op10_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op10_16 = inventoryObject.Slots[16].item.buffs[9].value; } else { op10_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op10_17 = inventoryObject.Slots[17].item.buffs[9].value; } else { op10_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op10_18 = inventoryObject.Slots[18].item.buffs[9].value; } else { op10_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op10_19 = inventoryObject.Slots[19].item.buffs[9].value; } else { op10_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op10_20 = inventoryObject.Slots[20].item.buffs[9].value; } else { op10_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op10_21 = inventoryObject.Slots[21].item.buffs[9].value; } else { op10_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op10_22 = inventoryObject.Slots[22].item.buffs[9].value; } else { op10_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op10_23 = inventoryObject.Slots[23].item.buffs[9].value; } else { op10_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op10_24 = inventoryObject.Slots[24].item.buffs[9].value; } else { op10_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op10_25 = inventoryObject.Slots[25].item.buffs[9].value; } else { op10_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op10_26 = inventoryObject.Slots[26].item.buffs[9].value; } else { op10_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op10_27 = inventoryObject.Slots[27].item.buffs[9].value; } else { op10_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op10_28 = inventoryObject.Slots[28].item.buffs[9].value; } else { op10_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op10_29 = inventoryObject.Slots[29].item.buffs[9].value; } else { op10_29 = -1; }
               
        DataManager.instance.nowPlayer.optionValue10 = new int[] {op10_0,op10_1,op10_2,op10_3,op10_4,op10_5,op10_6,op10_7,op10_8,op10_9,op10_10,op10_11,op10_12,op10_13,op10_14,op10_15,op10_16,op10_17,op10_18,op10_19,op10_20,op10_21,op10_22,op10_23,op10_24,op10_25,op10_26,op10_27,op10_28,op10_29};
        #endregion

        #region 옵션11 값

        int op11_0,op11_1,op11_2,op11_3,op11_4,op11_5,op11_6,op11_7,op11_8,op11_9,op11_10,op11_11,op11_12,op11_13,op11_14,op11_15,op11_16,op11_17,op11_18,op11_19,op11_20,op11_21,op11_22,op11_23,op11_24,op11_25,op11_26,op11_27,op11_28,op11_29;
    
        if(inventoryObject.Slots[0].item.id != -1) { op11_0 = inventoryObject.Slots[0].item.buffs[9].value; } else { op11_0 = -1; }
        if(inventoryObject.Slots[1].item.id != -1) { op11_1 = inventoryObject.Slots[1].item.buffs[9].value; } else { op11_1 = -1; }
        if(inventoryObject.Slots[2].item.id != -1) { op11_2 = inventoryObject.Slots[2].item.buffs[9].value; } else { op11_2 = -1; }
        if(inventoryObject.Slots[3].item.id != -1) { op11_3 = inventoryObject.Slots[3].item.buffs[9].value; } else { op11_3 = -1; }
        if(inventoryObject.Slots[4].item.id != -1) { op11_4 = inventoryObject.Slots[4].item.buffs[9].value; } else { op11_4 = -1; }
        if(inventoryObject.Slots[5].item.id != -1) { op11_5 = inventoryObject.Slots[5].item.buffs[9].value; } else { op11_5 = -1; }
        if(inventoryObject.Slots[6].item.id != -1) { op11_6 = inventoryObject.Slots[6].item.buffs[9].value; } else { op11_6 = -1; }
        if(inventoryObject.Slots[7].item.id != -1) { op11_7 = inventoryObject.Slots[7].item.buffs[9].value; } else { op11_7 = -1; }
        if(inventoryObject.Slots[8].item.id != -1) { op11_8 = inventoryObject.Slots[8].item.buffs[9].value; } else { op11_8 = -1; }
        if(inventoryObject.Slots[9].item.id != -1) { op11_9 = inventoryObject.Slots[9].item.buffs[9].value; } else { op11_9 = -1; }
        if(inventoryObject.Slots[10].item.id != -1) { op11_10 = inventoryObject.Slots[10].item.buffs[9].value; } else { op11_10 = -1; }
        if(inventoryObject.Slots[11].item.id != -1) { op11_11 = inventoryObject.Slots[11].item.buffs[9].value; } else { op11_11 = -1; }
        if(inventoryObject.Slots[12].item.id != -1) { op11_12 = inventoryObject.Slots[12].item.buffs[9].value; } else { op11_12 = -1; }
        if(inventoryObject.Slots[13].item.id != -1) { op11_13 = inventoryObject.Slots[13].item.buffs[9].value; } else { op11_13 = -1; }
        if(inventoryObject.Slots[14].item.id != -1) { op11_14 = inventoryObject.Slots[14].item.buffs[9].value; } else { op11_14 = -1; }
        if(inventoryObject.Slots[15].item.id != -1) { op11_15 = inventoryObject.Slots[15].item.buffs[9].value; } else { op11_15 = -1; }
        if(inventoryObject.Slots[16].item.id != -1) { op11_16 = inventoryObject.Slots[16].item.buffs[9].value; } else { op11_16 = -1; }
        if(inventoryObject.Slots[17].item.id != -1) { op11_17 = inventoryObject.Slots[17].item.buffs[9].value; } else { op11_17 = -1; }
        if(inventoryObject.Slots[18].item.id != -1) { op11_18 = inventoryObject.Slots[18].item.buffs[9].value; } else { op11_18 = -1; }
        if(inventoryObject.Slots[19].item.id != -1) { op11_19 = inventoryObject.Slots[19].item.buffs[9].value; } else { op11_19 = -1; }
        if(inventoryObject.Slots[20].item.id != -1) { op11_20 = inventoryObject.Slots[20].item.buffs[9].value; } else { op11_20 = -1; }
        if(inventoryObject.Slots[21].item.id != -1) { op11_21 = inventoryObject.Slots[21].item.buffs[9].value; } else { op11_21 = -1; }
        if(inventoryObject.Slots[22].item.id != -1) { op11_22 = inventoryObject.Slots[22].item.buffs[9].value; } else { op11_22 = -1; }
        if(inventoryObject.Slots[23].item.id != -1) { op11_23 = inventoryObject.Slots[23].item.buffs[9].value; } else { op11_23 = -1; }
        if(inventoryObject.Slots[24].item.id != -1) { op11_24 = inventoryObject.Slots[24].item.buffs[9].value; } else { op11_24 = -1; }
        if(inventoryObject.Slots[25].item.id != -1) { op11_25 = inventoryObject.Slots[25].item.buffs[9].value; } else { op11_25 = -1; }
        if(inventoryObject.Slots[26].item.id != -1) { op11_26 = inventoryObject.Slots[26].item.buffs[9].value; } else { op11_26 = -1; }
        if(inventoryObject.Slots[27].item.id != -1) { op11_27 = inventoryObject.Slots[27].item.buffs[9].value; } else { op11_27 = -1; }
        if(inventoryObject.Slots[28].item.id != -1) { op11_28 = inventoryObject.Slots[28].item.buffs[9].value; } else { op11_28 = -1; }
        if(inventoryObject.Slots[29].item.id != -1) { op11_29 = inventoryObject.Slots[29].item.buffs[9].value; } else { op11_29 = -1; }
               
        DataManager.instance.nowPlayer.optionValue11 = new int[] {op11_0,op11_1,op11_2,op11_3,op11_4,op11_5,op11_6,op11_7,op11_8,op11_9,op11_10,op11_11,op11_12,op11_13,op11_14,op11_15,op11_16,op11_17,op11_18,op11_19,op11_20,op11_21,op11_22,op11_23,op11_24,op11_25,op11_26,op11_27,op11_28,op11_29};
        #endregion

        
    }
}
