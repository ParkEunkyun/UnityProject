using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningAction : MonoBehaviour
{
    public GameObject effect;    
    //ChangeButton _changeButton;   
    public GameObject FX; 
    private void Awake()
    {        
       // _changeButton = GameObject.Find("GNB_3").GetComponent<ChangeButton>();
        effect.SetActive(false);
        FX.SetActive(false);         
    }   
    void NomalAttack()
    {
        effect.SetActive(true);
        FX.SetActive(true);
    }
    void EffectOff()
    {
        effect.SetActive(false);
        FX.SetActive(false);       
    }
}
