using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTabButton : MonoBehaviour
{
    public GameObject EquipInven;
    public GameObject MetarialInven;
    public GameObject Crafting;
    public GameObject Equipments;
    public GameObject EquipInvenBtn;
    public GameObject metarialInvenBtn;
    public GameObject StatBtn;
    public GameObject SkillBtn;
    public bool EquipInvenbool;
    public bool meterialInvenbool;

    public void Start()
    {
        EquipInvenBtn.SetActive(false);
    }
    public void EquipmentsInventoryOn()
    {

        EquipInven.SetActive(true);
        Equipments.SetActive(true);
        StatBtn.SetActive(true);
        SkillBtn.SetActive(true);
        MetarialInven.SetActive(false);
        Crafting.SetActive(false);
        EquipInvenbool = true;
        //EquipInvenBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,1.0f);
        //metarialInvenBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,0.5f);
        metarialInvenBtn.SetActive(true);
        EquipInvenBtn.SetActive(false);


    }

    public void MetarialInventoryOn()
    {
        EquipInven.SetActive(false);
        Equipments.SetActive(false);
        MetarialInven.SetActive(true);
        Crafting.SetActive(true);
        StatBtn.SetActive(false);
        SkillBtn.SetActive(false);
        //metarialInvenBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,1.0f);
        //EquipInvenBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,0.5f);
        metarialInvenBtn.SetActive(false);
        EquipInvenBtn.SetActive(true);
    }

}
