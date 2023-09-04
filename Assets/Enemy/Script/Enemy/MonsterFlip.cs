using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFlip : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Char");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = transform.position - player.transform.position;
        dir.Normalize();        
        if(dir.x < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        else if(dir.x > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);       
    }   
}
