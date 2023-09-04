    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    //NewMoving Char;
    Movement Char;

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
       

        switch (transform.tag)  {
            case "Ground":
            float diffx = playerPos.x - myPos.x;
            float diffy = playerPos.y - myPos.y;
            float dirX = diffx < 0 ? -1 : 1;
            float dirY = diffy < 0 ? -1 : 1;
            diffx = Mathf.Abs(diffx);
            diffy = Mathf.Abs(diffy);

                if(diffx > diffy){
                    transform.Translate(dirX * 80, 0, 0);
                    Debug.Log("좌우diffx" + diffx);
                    Debug.Log("좌우diffy" + diffy);
                }
                else if (diffx < diffy){
                    transform.Translate(0, dirY * 80, 0);
                    Debug.Log("상하diffx" + diffx);
                    Debug.Log("상하diffy" + diffy);
                }
                else
                {
                    transform.Translate(dirX * 80, dirY * 80, 0);
                    Debug.Log("대각diffx" + diffx);
                    Debug.Log("대각diffy" + diffy);
                }
                break;

            case "Enemy":
            
                break;
            }
            Debug.Log("fgjkfshgkjh");
        }
        

    }    
}
