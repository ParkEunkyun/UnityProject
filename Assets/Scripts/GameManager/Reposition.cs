    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    //NewMoving Char;
    Movement Char;
    Collider2D coll;
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    public void Start() 
    {
        //Char = GameObject.Find("Char").GetComponent<NewMoving>();
        Char = GameObject.Find("Char").GetComponent<Movement>();
    }
    

    public void OnTriggerExit2D(Collider2D other)
    {
        if(!other.CompareTag("GroundArea"))
        {
            Debug.Log("ㅌㅌㅌㅌㅌ");
        return;
        }
        else
        {
        Vector3 playerPos = Char.transform.position;
        Vector3 myPos = transform.position;
        

        //Vector3 PlayerDir = Char.inputVec;
        //Vector3 PlayerDir = new Vector3(Char.js.Horizontal, Char.js.Vertical, 0);
            float diffx = playerPos.x - myPos.x;
            float diffy = playerPos.y - myPos.y;
            float dirX = diffx < 0 ? -1 : 1;
            float dirY = diffy < 0 ? -1 : 1;
            diffx = Mathf.Abs(diffx);
            diffy = Mathf.Abs(diffy);

        switch (transform.tag)  {
            case "Enemy":
                if(coll.enabled)
                {
                    Vector3 dist = playerPos - myPos;
                    Vector3 ran = new Vector3(Random.Range(-3,3), Random.Range(-3,3), 0);
                    transform.Translate(ran + dist*2);
                }
                break;
            }
            Debug.Log("fgjkfshgkjh");
        }

    }    
}
