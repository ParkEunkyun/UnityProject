using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
public GameObject MineRock;
public static MineSpawner instance;
public Queue<GameObject> m_queue = new Queue<GameObject>();
public float xPos;
public float yPos;
private Vector3 RandomVector;
public int CNT;
public int SCNT;

// Start is called before the first frame update
void Awake()
{
    instance = this;
    
    for(int i=0; i<101; i++)
    {
        GameObject t_object = Instantiate(MineRock, this.gameObject.transform);
        m_queue.Enqueue(t_object);
        t_object.SetActive(false);
    }    
    //StartCoroutine(MonsterSpawn());       
}
private void OnTriggerStay2D(Collider2D other)
{
    if(other.tag.Equals("Key") && CNT == 0)
    {                
        for(int i=0; i<101; i++)
        {
            StartCoroutine("MineSpawn");
        }
    }
    if(SCNT == 101)
    {
        CNT = 0;
        SCNT = 0;
    }   
}
private void OnTriggerExit2D(Collider2D other)
{
    if(other.tag.Equals("Key"))
    {               
        StopCoroutine("MineSpawn");       
    }    
}
public void InsertQueue(GameObject p_object)
{
    SCNT++;
    m_queue.Enqueue(p_object);
    p_object.SetActive(false);
}

public GameObject GetQueue()
{      
    GameObject t_object = m_queue.Dequeue();
    t_object.SetActive(true);
    
    return t_object;
}

IEnumerator MineSpawn()
{
    //while (true)
    {
        if(m_queue.Count != 0 )
        {
            xPos = Random.Range(-6, 6);
            yPos = Random.Range(-6, 6);
            RandomVector = new Vector3(xPos, yPos, 0.0f);
            CNT++; 
            GameObject t_object = GetQueue();
            t_object.transform.position = gameObject.transform.position+ RandomVector;           
        }
        yield return new WaitForSeconds(1.0f);                    
    }     
}
/*
IEnumerator MonsterSpawn()
{
    while (true)
    {
        if(m_queue.Count !=0)
        {
            xPos = Random.Range(-8, 8);
            yPos = Random.Range(-8, 8);
            RandomVector = new Vector3(xPos, yPos, 0.0f);
            GameObject t_object = GetQueue();
            t_object.transform.position = gameObject.transform.position+ RandomVector;           
        }
        yield return new WaitForSeconds(1.0f);                    
    }     
}
/* private void OnEnable()
{
    if (hpBar!=null)
    {
        hpBar.SetActive(true);
        HP = (int)MaxHp;
        hpSlider.value = 1.0f;
    }
}*/
}

