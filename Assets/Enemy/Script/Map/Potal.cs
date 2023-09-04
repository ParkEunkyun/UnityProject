using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    public GameObject targetObj;    
    public GameObject toObj;
    SpriteRenderer sprite;
        
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Key")&&collision.CompareTag("Player"))
        {
            targetObj = collision.gameObject;            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Key"))
        {
            sprite = this.gameObject.GetComponent<SpriteRenderer>();
            sprite.color = new Color(1,1,1,0.3f);           
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {        
        if(collision.CompareTag("Key"))
        {
            sprite = this.gameObject.GetComponent<SpriteRenderer>();
            sprite.color = new Color(1,1,1,1);
            StartCoroutine(TeleportRoutine());            
        }
    }    
    
    IEnumerator TeleportRoutine()
    {
        yield return new WaitForSeconds(2f);        
        targetObj.transform.position = toObj.transform.position;
        
    }
    
}
