using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnforceText : MonoBehaviour
{   
    public InventoryObject _inventory;
    public TMP_Text[] _text;

    private void Update()
    {
        for (int i = 0; i < _inventory.Slots.Length; i++)
        {
            if (_inventory.Slots[i].item.id != -1 && _inventory.Slots[i].item.buffs[0].value > 0)
            {
                _text[i].text = "+" + _inventory.Slots[i].item.buffs[0].value.ToString();
                
                if (_inventory.Slots[i].item.buffs[7].value > 0)
                {
                    _text[i].color = Color.red;
                }
                else
                {
                    _text[i].color = Color.white;
                }
            }
            else
            {
                _text[i].text = "";
            }
        }        
    }
}
