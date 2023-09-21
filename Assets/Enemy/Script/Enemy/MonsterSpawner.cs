using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
public GameObject Monster;
public static MonsterSpawner instance;
public Queue<GameObject> m_queue = new Queue<GameObject>();
//public float xPos;
//public float yPos;
//private Vector3 RandomVector;
public int CNT;
public int SCNT;
[SerializeField]
private int monsterCNT;
public Transform[] spawnPoint;

// Start is called before the first frame update
void Awake()
{
    instance = this;
    
    for(int i=0; i<monsterCNT; i++)
    {
        GameObject t_object = Instantiate(Monster, this.gameObject.transform);
        m_queue.Enqueue(t_object);
        t_object.SetActive(false);
    }    
        //StartCoroutine(MonsterSpawn());       
    }
/* private void OnTriggerStay2D(Collider2D other)
{
    if(other.tag.Equals("Player") && CNT == 0)
    {                
        for(int i=0; i<monsterCNT; i++)
        {
            StartCoroutine("MonsterSpawn");
        }
    }
    if(SCNT == monsterCNT)
    {
        CNT = 0;
        SCNT = 0;
    }   
}*/
private void OnTriggerEnter2D(Collider2D other)
{
    StartCoroutine(MonsterSpawn());
}
private void OnTriggerExit2D(Collider2D other)
{
    if(other.tag.Equals("Player"))
    {               
        StopCoroutine("MonsterSpawn");       
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

IEnumerator MonsterSpawn()
{
    spawnPoint = GameObject.Find("Spawner").GetComponentsInChildren<Transform>();
    while (true)
    {
        if(m_queue.Count != 0 )
        {
            //xPos = Random.Range(-9.5f, 9.5f);
            //yPos = Random.Range(-9.5f, 9.5f);
            //RandomVector = new Vector3(xPos, yPos, 0.0f);
            CNT++; 
            GameObject t_object = GetQueue();
            //t_object.transform.position = gameObject.transform.position+ RandomVector;
            t_object.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
            }
            
            yield return new WaitForSeconds(0.1f);                    
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

