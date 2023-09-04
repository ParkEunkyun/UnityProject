using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject targetObj;
    //public GameObject petObj;
    public GameObject toObj;
    //public GameObject toPet;
    public float Timer;
    private void Start()
    {
        Timer = 2.5f;
    }
    /*

    private void Update()
    {
        if(Timer > 0)
        {   
            Timer =  Timer - Time.deltaTime;
        }
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Key") && collision.tag.Equals("Player") && Timer <= 0)
        {
            targetObj = collision.gameObject;
            //petObj = collision.gameObject;  
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag.Equals("Key") && Timer > 0)
        {   
            Timer =  Timer - Time.deltaTime;
        }
        if(collision.tag.Equals("Key") &&  Timer <= 0 )
        {
            StartCoroutine(TeleportRoutine());
        }
    }
    
    /*
     void TeleportRoutine()
    {
        
        targetObj.transform.position = toObj.transform.position;         

    }
    */
    
    IEnumerator TeleportRoutine()
    {
        if(Timer <= 0)
        { yield return null;
        targetObj.transform.position = toObj.transform.position;
        //petObj.transform.position = toPet.transform.position;
        Timer = 2.5f; 
        }
    }
    
}
