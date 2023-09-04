using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipDropItem : MonoBehaviour
{
    // Start is called before the first frame update

    public int itemnumber;
    public InventoryObject _inventoryObject;
    SpriteRenderer sprites;
    

    ////////////////////////////////////////////////

    private void OnTriggerEnter2D(Collider2D other) // 추후 아이템 획득 로직으로 변경
    {
        sprites = this.gameObject.GetComponent<SpriteRenderer>();
        if(other.tag.Equals("Player") && _inventoryObject.EmptySlotCount > 0)
        {
                
                DataManager.instance.AddNewEquipItem(itemnumber);
                Destroy(this.gameObject);
        }
       /* else if (other.tag.Equals("Player") && _inventoryObject.EmptySlotCount == 0)
        {
            sprites.color = new Color(1,1,1,0);
        }*/
        
    }
}
