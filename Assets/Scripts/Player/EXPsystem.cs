using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPsystem : MonoBehaviour
{
    public Slider EXPbar1;   
    public Text EXPtext;
    public Stat _stat;    
    void Start()
    {
        EXPbar1.maxValue = _stat.maxExp;
        EXPbar1.value = DataManager.instance.nowPlayer.curExp;
        EXPtext.text = EXPbar1.value.ToString() + " / " + _stat.maxExp.ToString();
    }

    
}
