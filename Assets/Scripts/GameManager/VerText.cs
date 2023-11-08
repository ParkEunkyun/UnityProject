using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VerText : MonoBehaviour
{
    public Text _Text;
    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _Text.text = "v" + Application.version;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
   
}
