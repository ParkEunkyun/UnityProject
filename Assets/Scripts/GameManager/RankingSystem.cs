using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Firebase.Database;


public class RankingSystem : MonoBehaviour
{
    private void Start() 
    {
        for(int i = 0; i < DataManager.instance.Nick.Length; i++)
        {
            DataManager.instance.Nick[i] = GameObject.Find("Nick" + i.ToString()).GetComponent<Text>();
        }
        for(int i = 0; i < DataManager.instance.Nick.Length; i++)
        {
            DataManager.instance.Score[i] = GameObject.Find("power" + i.ToString()).GetComponent<Text>();
        }
           
    }
}