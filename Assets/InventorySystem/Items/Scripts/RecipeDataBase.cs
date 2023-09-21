using EZInventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Crafting System/Item/Database")]
public class RecipeDataBase : ScriptableObject
{
    
    public ItemSO[] RecipeItem;

    public void OnValidate()
    {
        for (int i = 0; i < RecipeItem.Length; ++i)
        {
            RecipeItem[i].id = i;
        }
    }
}
