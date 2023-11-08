using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPoolingActive : MonoBehaviour
{
    public GameObject[] pooling;

    public void Start()
    {
        for(int i = 0; i < pooling.Length; i++)
        {
            pooling[i].SetActive(false);
        }
        pooling[MonsterSelect.monsterPoolIndex].SetActive(true);
    }

    public void OnEnable()
    {
        for (int i = 0; i < pooling.Length; i++)
        {
            pooling[i].SetActive(false);
        }
        pooling[MonsterSelect.monsterPoolIndex].SetActive(true);
    }
}
