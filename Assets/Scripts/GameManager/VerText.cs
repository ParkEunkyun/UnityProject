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
        // �� �Ŵ����� sceneLoaded�� ü���� �Ǵ�.
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
