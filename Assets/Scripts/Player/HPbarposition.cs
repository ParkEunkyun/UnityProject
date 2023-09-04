using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbarposition : MonoBehaviour
{
    public GameObject movement;        
    void Update()
    {
        this.transform.position = movement.transform.position;
    }
}
