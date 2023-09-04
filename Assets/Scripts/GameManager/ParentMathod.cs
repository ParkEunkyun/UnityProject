using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMathod : MonoBehaviour
{
    public static int SlotNumber;       

    public void parentMathod()
    {
        SlotNumber = this.transform.GetSiblingIndex();
        Debug.Log(SlotNumber);
        this.GetComponentInParent<TooltipManager>().slotClick();
        
    }
    
    public void parentMathod2()
    {
        if(this.gameObject.name == "Helmet") { SlotNumber = 0; }
        else if(this.gameObject.name == "Weapon") { SlotNumber = 1; }
        else if(this.gameObject.name == "Gloves") { SlotNumber = 2; }
        else if(this.gameObject.name == "Armor") { SlotNumber = 3; }
        else if(this.gameObject.name == "Boots") { SlotNumber = 4; }
        Debug.Log(SlotNumber);
        this.GetComponentInParent<TooltipManager>().EquipslotClick();

    }

    public void parentMathod3()
    {
        SlotNumber = this.transform.GetSiblingIndex();
        Debug.Log(SlotNumber);
        this.GetComponentInParent<TooltipManager>().MaterialslotClick();
        
    }
    
}
