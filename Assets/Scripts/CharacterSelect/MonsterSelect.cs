using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSelect : MonoBehaviour
{
    public GameObject[] monster;
    public int PoolIndex;
    public static int monsterPoolIndex;

    private void Start()
    {
        monsterPoolIndex = 0;
    }

    public void ArrowMonsterIndexPlus()
    {
        if(monsterPoolIndex < monster.Length-1)
        {
            for(int i = 0;i < monster.Length; i++)
            {
                monster[i].SetActive(false);
            }
            monsterPoolIndex++;
            PoolIndex = monsterPoolIndex;
            monster[monsterPoolIndex].SetActive(true);
        }
        else
        {
            for (int i = 0; i < monster.Length; i++)
            {
                monster[i].SetActive(false);
            }
            monsterPoolIndex = 0;
            PoolIndex = monsterPoolIndex;
            monster[monsterPoolIndex].SetActive(true);
        }        
    }

    public void ArrowMonsterIndexMinus()
    {
        if (monsterPoolIndex != 0)
        {
            for (int i = 0; i < monster.Length; i++)
            {
                monster[i].SetActive(false);
            }
            monsterPoolIndex--;
            PoolIndex = monsterPoolIndex;
            monster[monsterPoolIndex].SetActive(true);
        }
        else if(monsterPoolIndex == 0)
        {
            for (int i = 0; i < monster.Length; i++)
            {
                monster[i].SetActive(false);
            }
            monsterPoolIndex = monster.Length - 1;
            PoolIndex = monsterPoolIndex;
            monster[monsterPoolIndex].SetActive(true);
        }

    }
}
