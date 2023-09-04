using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType: int
{
    Helmet = 0,
    Weapon = 1,
    Gloves = 2,
    Armor = 3,  
    Boots = 4,    
    Material,
    Portion,
    Etc,
    Default
}

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory System/Item/New Item")]
public class ItemObject : ScriptableObject
{
    public ItemType type;
    public bool stackable;
    public Sprite icon;
    public GameObject ItemPrefab;
    public Item data = new Item();
    public List<string> partsName = new List<string>();
    
    [TextArea (15,20)]
    public string description;

    /*
    public void OnValidate()
    {
        partsName.Clear();

        if(ItemPrefab == null || ItemPrefab.GetComponent<SpriteRenderer>() == null)
        {
            return;
        }

    }
    */
    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}
