using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[9];
    int childCnt;
    public InventoryObject Inven;
    public void Start()
    {
        childCnt = this.transform.childCount;
        if(Inven.Slots[1].item.id == 20) {Itemcode50001();}
        else if(Inven.Slots[1].item.id == 21) {Itemcode50002();}
        else if(Inven.Slots[1].item.id == 22) {Itemcode50003();}
        else if(Inven.Slots[1].item.id == 23) {Itemcode50004();}
        else if(Inven.Slots[1].item.id == 24) {Itemcode50005();}
        else if(Inven.Slots[1].item.id == 25) {Itemcode50006();}
        else if(Inven.Slots[1].item.id == 26) {Itemcode50007();}
        else if(Inven.Slots[1].item.id == 27) {Itemcode50008();}
        else if(Inven.Slots[1].item.id == 28) {Itemcode50009();}

    }
     public void Itemcode50000()
    {
        childCnt = this.transform.childCount;   
        for(int i = 0; i < childCnt;  i++)
        {
            SpriteRenderer weaponimg = this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            weaponimg.sprite = sprites[0];
        }
    }
    public void Itemcode50001()
    {
        childCnt = this.transform.childCount;   
        for(int i = 0; i < childCnt;  i++)
        {
            SpriteRenderer weaponimg = this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            weaponimg.sprite = sprites[1];
        }
    }
    public void Itemcode50002()
    {
        childCnt = this.transform.childCount;   
        for(int i = 0; i < childCnt;  i++)
        {
            SpriteRenderer weaponimg = this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            weaponimg.sprite = sprites[2];
        }
    }
    public void Itemcode50003()
    {
        childCnt = this.transform.childCount;   
        for(int i = 0; i < childCnt;  i++)
        {
            SpriteRenderer weaponimg = this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            weaponimg.sprite = sprites[3];
        }
    }
    public void Itemcode50004()
    {
        childCnt = this.transform.childCount;   
        for(int i = 0; i < childCnt;  i++)
        {
            SpriteRenderer weaponimg = this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            weaponimg.sprite = sprites[4];
        }
    }
    public void Itemcode50005()
    {
        childCnt = this.transform.childCount;   
        for(int i = 0; i < childCnt;  i++)
        {
            SpriteRenderer weaponimg = this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            weaponimg.sprite = sprites[5];
        }
    }
    public void Itemcode50006()
    {
        childCnt = this.transform.childCount;   
        for(int i = 0; i < childCnt;  i++)
        {
            SpriteRenderer weaponimg = this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            weaponimg.sprite = sprites[6];
        }
    }
    public void Itemcode50007()
    {
        childCnt = this.transform.childCount;   
        for(int i = 0; i < childCnt;  i++)
        {
            SpriteRenderer weaponimg = this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            weaponimg.sprite = sprites[7];
        }
    }
    public void Itemcode50008()
    {
        childCnt = this.transform.childCount;   
        for(int i = 0; i < childCnt;  i++)
        {
            SpriteRenderer weaponimg = this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            weaponimg.sprite = sprites[8];
        }
    }

    public void Itemcode50009()
    {
        childCnt = this.transform.childCount;   
        for(int i = 0; i < childCnt;  i++)
        {
            SpriteRenderer weaponimg = this.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            weaponimg.sprite = sprites[9];
        }
    }
        
}

