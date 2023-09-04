using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{
    public InventoryObject EquipInven;
    public Image Helmet;
    public Image Weapon;
    public Image Glove;
    public Image Armmor;
    public Image Boots;
    public Text logtest;

    public void Start()
    {
        Helmet = Helmet.GetComponent<Image>();
        Weapon = Weapon.GetComponent<Image>();
        Glove = Glove.GetComponent<Image>();
        Armmor = Armmor.GetComponent<Image>();
        Boots = Boots.GetComponent<Image>();
    }
    public void Loadimage()
    {
        Helmet.sprite = null;
        Weapon.sprite = null;
        Glove.sprite = null;
        Armmor.sprite = null;
        Boots.sprite = null;
        
        if(EquipInven.Slots[0].item.id != -1)
        {        
            
            Helmet.sprite = EquipInven.Slots[0].ItemObject.icon;
            Helmet.color = new Color(1, 1, 1, 1);
            Debug.Log("투구");
        }

        if(EquipInven.Slots[1].item.id != -1)
        {        
            Weapon.sprite = EquipInven.Slots[1].ItemObject.icon;
            Weapon.color = new Color(1, 1, 1, 1);
            Debug.Log("무기");
        
        }

        if(EquipInven.Slots[2].item.id != -1)
        {
            Glove.sprite = EquipInven.Slots[2].ItemObject.icon;
            Glove.color = new Color(1, 1, 1, 1);
            Debug.Log("장갑");
        }
        
        if(EquipInven.Slots[3].item.id != -1)
        {        
            Armmor.sprite = EquipInven.Slots[3].ItemObject.icon;
            Armmor.color = new Color(1, 1, 1, 1);
            Debug.Log("갑옷");
        }
       
        if(EquipInven.Slots[4].item.id != -1)
        {        
            Boots.sprite = EquipInven.Slots[4].ItemObject.icon;
            Boots.color = new Color(1, 1, 1, 1);
            Debug.Log("신발");
        }
        
        //이미지 테스트용
        if(Helmet.sprite != null)
        {
            logtest.text = Glove.sprite.ToString();
        }
        else
        {
            logtest.text = "null";
        }
    }

}
