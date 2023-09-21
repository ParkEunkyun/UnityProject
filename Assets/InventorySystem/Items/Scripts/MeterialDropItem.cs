using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterialDropItem : MonoBehaviour
{
    // Start is called before the first frame update

    public int itemnumber;
    public InventoryObject _inventoryObject;

    ////////////////////////////////////////////////

     private void OnTriggerEnter2D(Collider2D other) // 추후 아이템 획득 로직으로 변경
    {
        if(other.tag.Equals("Player") && _inventoryObject.EmptySlotCount > 0)
        {
                DataManager.instance.AddNewMaterialItem(itemnumber);
                //this.gameObject.SetActive(false);
                Destroy(this.gameObject);
        }

    }
}

