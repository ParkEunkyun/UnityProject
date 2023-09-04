using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiningDamage : MonoBehaviour
{
    public Slider miningHP;
    public float maxHP;    
    public GameObject[] items = new GameObject[6];
    Transform trans;
    GameObject obj;    
    public Stat _PlayerStat;
    AutoThrowing _AutoThrowing;
    void Start()
    {
        
        trans = GetComponent<Transform>();
        obj = GetComponent<GameObject>();
        miningHP.maxValue = maxHP;
        miningHP.value = maxHP;
        
    }    
    private void OnTriggerEnter2D(Collider2D other)
    {       
                
        if(other.gameObject.tag.Equals("Effect"))
        {   
            
            _PlayerStat = GameObject.Find("Player").GetComponent<Stat>();
            _AutoThrowing = GameObject.Find("Player").GetComponent<AutoThrowing>();         

            if(miningHP.value > 0)
            { 
                
                miningHP.value = miningHP.value - _AutoThrowing.Dmg;               
                Debug.Log("데미지");
            }
            
            if (miningHP.value <= 0)
            {                
                Vector2 v = new Vector2(0f, 0f);                          
                trans.position = this.transform.position;
                this.gameObject.SetActive(false);
                MineSpawner.instance.InsertQueue(gameObject);
                dropTheItems();
               // MineManager.MineKill++;
            }
        }
    }
    private void OnEnable() // 오브젝트 풀링에의해 다시 활성화될시 정보 초기화
    {
        if (miningHP!= null)
        {       
            miningHP.maxValue = maxHP;
            miningHP.value = maxHP;
        }
    }
    
     void dropTheItems()
    {
        int maxItems = 1;        
        for (int i = 0; i < maxItems; i++)
        {
            int rand1 = Random.Range(0,6);
            Instantiate(items[rand1], trans.position, Quaternion.identity);
            Debug.Log("아이템 1" + rand1);            
        }        
        
    }
    
}
