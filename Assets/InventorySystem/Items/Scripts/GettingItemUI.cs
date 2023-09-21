using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GettingItemUI : MonoBehaviour
{
    public GameObject getPopup;
    public Image getItmeimg;
    public Text ItemName;
    public void GetItems(int i)
    {
        getPopup.SetActive(true);
        //int itemnumber = DataManager.instance.gettingItem;
        getItmeimg.sprite = DataManager.instance.databaseObject.itemObjects[i].icon;
        ItemName.text = DataManager.instance.databaseObject.itemObjects[i].data.name;
        Invoke("DestroyObject", 3.0f);
    }

    public void DestroyObject()
    {
        getPopup.SetActive(false);
    }
}
