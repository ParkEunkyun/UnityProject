using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Database : MonoBehaviour
{   
    

    public void OnClickSaveButton()
    {
        DataManager.instance.OnClickSaveButton();
    }
    
    public void OnClickLoadButton()
    {
        DataManager.instance.OnClickLoadButton();
    }
}