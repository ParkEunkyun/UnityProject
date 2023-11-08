using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EZInventory;
using UnityEngine.UI;

public class CraftingBook : MonoBehaviour
{

    public GameObject[] craftingSlot;
    public List<RecipeGrid> recipes;
    public Text itemName;


    public void OnEnable()
    {
        itemName.text = "";
        craftingSlot[0].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        craftingSlot[1].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        craftingSlot[2].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        craftingSlot[3].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        craftingSlot[4].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        craftingSlot[5].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        craftingSlot[6].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        craftingSlot[7].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        craftingSlot[8].GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }
    public void LoadRecipeImage(int slotNumber)
    {
        itemName.text = recipes[slotNumber].output.tooltip;
        if (recipes[slotNumber].topLeft != null)
        {
            craftingSlot[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            craftingSlot[0].GetComponent<Image>().sprite = recipes[slotNumber].topLeft.itemSlotSprite;
        }
        else
        {
            craftingSlot[0].GetComponent<Image>().color = new Color(0,0,0,0);
        }

        if (recipes[slotNumber].topMiddle != null)
        {
            craftingSlot[1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            craftingSlot[1].GetComponent<Image>().sprite = recipes[slotNumber].topMiddle.itemSlotSprite;
        }
        else
        {
            craftingSlot[1].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        if (recipes[slotNumber].topRight != null)
        {
            craftingSlot[2].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            craftingSlot[2].GetComponent<Image>().sprite = recipes[slotNumber].topRight.itemSlotSprite;
        }
        else
        {
            craftingSlot[2].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        if (recipes[slotNumber].middleLeft != null)
        {
            craftingSlot[3].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            craftingSlot[3].GetComponent<Image>().sprite = recipes[slotNumber].middleLeft.itemSlotSprite;
        }
        else
        {
            craftingSlot[3].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        if (recipes[slotNumber].middle != null)
        {
            craftingSlot[4].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            craftingSlot[4].GetComponent<Image>().sprite = recipes[slotNumber].middle.itemSlotSprite;
        }
        else
        {
            craftingSlot[4].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        if (recipes[slotNumber].middleRight != null)
        {
            craftingSlot[5].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            craftingSlot[5].GetComponent<Image>().sprite = recipes[slotNumber].middleRight.itemSlotSprite;
        }
        else
        {
            craftingSlot[5].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        if (recipes[slotNumber].bottomLeft != null)
        {
            craftingSlot[6].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            craftingSlot[6].GetComponent<Image>().sprite = recipes[slotNumber].bottomLeft.itemSlotSprite;
        }
        else
        {
            craftingSlot[6].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        if (recipes[slotNumber].bottomMiddle != null)
        {
            craftingSlot[7].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            craftingSlot[7].GetComponent<Image>().sprite = recipes[slotNumber].bottomMiddle.itemSlotSprite;
        }
        else
        {
            craftingSlot[7].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }

        if (recipes[slotNumber].bottomRight != null)
        {
            craftingSlot[8].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            craftingSlot[8].GetComponent<Image>().sprite = recipes[slotNumber].bottomRight.itemSlotSprite;
        }
        else
        {
            craftingSlot[8].GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
    }
}

