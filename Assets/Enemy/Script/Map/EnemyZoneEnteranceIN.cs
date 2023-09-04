using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZoneEnteranceIN : MonoBehaviour
{
    
    public GameObject EnemyZone;
    private void Start()
    {
        EnemyZone.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {        
        if(other.tag.Equals("Key") && EnemyZone.activeSelf == false)
        {
            EnemyZone.SetActive(true);
        }
    }
}
