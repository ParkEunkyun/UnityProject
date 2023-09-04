using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundSkill : MonoBehaviour
{    
    public float rotSpeed = 300f;  // 원하는 속도    
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
    }

}
