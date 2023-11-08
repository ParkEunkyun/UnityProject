using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public void SecenChange()
    {
        DataManager.instance.audioSource.volume = 0.2f;
        LoadingBar.LoadScene("SelectScene");
    }
    
}
