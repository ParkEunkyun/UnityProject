using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTabButton : MonoBehaviour
{
    public TutorialManager tutorialmanager;
    public GameObject EquipInven;
    public GameObject MetarialInven;
    public GameObject Crafting;
    public GameObject Equipments;
    public GameObject EquipInvenBtn;
    public GameObject metarialInvenBtn;
    public GameObject StatBtn;
    public GameObject SkillBtn;
    public GameObject RecipeBtn;
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
        RecipeBtn.SetActive(false);
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
        TutorialManager tutorialManager = tutorialmanager.GetComponent<TutorialManager>();

        if (DataManager.instance.nowPlayer.Crafttutorial == 0)
        {
            EquipInven.SetActive(false);
            Equipments.SetActive(false);
            MetarialInven.SetActive(true);
            Crafting.SetActive(true);
            StatBtn.SetActive(false);
            SkillBtn.SetActive(false);
            RecipeBtn.SetActive(true);
            //metarialInvenBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,1.0f);
            //EquipInvenBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,0.5f);
            metarialInvenBtn.SetActive(false);
            EquipInvenBtn.SetActive(true);
            tutorialManager.TutorialMask_7.SetActive(true);        
        }
        else
        {
            EquipInven.SetActive(false);
            Equipments.SetActive(false);
            MetarialInven.SetActive(true);
            Crafting.SetActive(true);
            StatBtn.SetActive(false);
            SkillBtn.SetActive(false);
            RecipeBtn.SetActive(true);
            //metarialInvenBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,1.0f);
            //EquipInvenBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,0.5f);
            metarialInvenBtn.SetActive(false);
            EquipInvenBtn.SetActive(true);
        }
    }

    public Text goldtext;
    public Text Rubytext;
    public Text Crystaltext;
    private void Update()
    {
        string goldFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.gold);
        goldtext.text = goldFomat;

        string RubyFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.RubbyPoint);
        Rubytext.text = RubyFomat;

        string CrystalFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.CrystalPoint);
        Crystaltext.text = CrystalFomat;
    }

}
