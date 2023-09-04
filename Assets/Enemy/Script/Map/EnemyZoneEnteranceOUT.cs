using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZoneEnteranceOUT : MonoBehaviour
{
    
    public GameObject EnemyZone;
    private void Start()
    {
        EnemyZone.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if(other.tag.Equals("Key") && EnemyZone.activeSelf == true)
        {
            EnemyZone.SetActive(false);    
        }
               
    }
}
