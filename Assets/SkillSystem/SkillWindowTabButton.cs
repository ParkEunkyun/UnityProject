using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillWindowTabButton : MonoBehaviour
{
    public GameObject Active;
    public GameObject Support;
    public GameObject Passive;
    public GameObject ActiveBtn;
    public GameObject SupportBtn;
    public GameObject PassiveBtn;

    public void ActiveWindowOn()
    {
        Active.SetActive(true);
        Support.SetActive(false);
        Passive.SetActive(false);
        ActiveBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,1.0f);
        SupportBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,0.5f);
        PassiveBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,0.5f);
    }

    public void SupportWindowOn()
    {
        Active.SetActive(false);
        Support.SetActive(true);
        Passive.SetActive(false);
        ActiveBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,0.5f);
        SupportBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,1.0f);
        PassiveBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,0.5f);
    }

    public void PassiveWindowOn()
    {
        Active.SetActive(false);
        Support.SetActive(false);
        Passive.SetActive(true);
        ActiveBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,0.5f);
        SupportBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,0.5f);
        PassiveBtn.GetComponentInChildren<Image>().color = new Color(1.0f,1.0f,1.0f,1.0f);
    }

}
