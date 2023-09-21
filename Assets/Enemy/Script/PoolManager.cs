using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] Pools;    

    private void Awake()
    {
        Pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < Pools.Length; index++)
        {
            Pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in Pools[index])  {
            if(!item.activeSelf)    {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(!select) {
            select = Instantiate(prefabs[index], transform);
            Pools[index].Add(select);
        }

        return select;
    }
}
