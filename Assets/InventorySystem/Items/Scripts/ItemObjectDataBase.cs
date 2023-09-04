using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory System/Item/Database")]
public class ItemObjectDataBase : ScriptableObject
{
    
    public ItemObject[] itemObjects;

    public void OnValidate()
    {
        for (int i = 0; i < itemObjects.Length; ++i)
        {
            itemObjects[i].data.id = i;
        }
    }
}
