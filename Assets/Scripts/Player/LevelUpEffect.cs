using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpEffect : MonoBehaviour
{
    public GameObject Effect;
    public GameObject PlayerParent;

    public void ActiveLvUpEffect()
    {
        PlayerParent = GameObject.Find("Char");
        var effects = Instantiate(Effect);
        effects.transform.SetParent(PlayerParent.transform);
        effects.transform.position = PlayerParent.transform.position;
    }
    
}
