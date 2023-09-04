using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonDamage : MonoBehaviour
{
    public Slider enemyHP;
    public float maxHP;    
    public GameObject[] items = new GameObject[4];
    Transform trans;
    GameObject obj;
    //private Animator animator;
    AutoThrowing _AutoThrowing;
    public Stat _PlayerStat;    
    [SerializeField]
    private float EXP;
    void Start()
    {
        
        trans = GetComponent<Transform>();
        obj = GetComponent<GameObject>();
        enemyHP.maxValue = maxHP;
        enemyHP.value = maxHP;
        
    }    
    private void OnTriggerEnter2D(Collider2D other)
    {       
                
        if(other.gameObject.tag.Equals("Bullet"))
        {   
            _AutoThrowing = GameObject.Find("Player").GetComponent<AutoThrowing>();

            if(enemyHP.value > 0)
            { 
                
                enemyHP.value = enemyHP.value - _AutoThrowing.Dmg;
                //ObjectPool.ReturnObject();
                //Destroy(other.gameObject);
                Debug.Log("데미지" + _AutoThrowing.Dmg);
            }
            
            if (enemyHP.value <= 0)
            {                
                Vector2 v = new Vector2(0f, 0f);
                //animator = GameObject.Find("EnemyUnitRoot").GetComponent<Animator>();
                //animator.SetTrigger("Death");                
                //Destroy(other.gameObject);
                //Destroy(transform.parent.gameObject);
                //SpawnManager.EnemyCnt--;              
                trans.position = this.transform.position;
                this.gameObject.SetActive(false);
                FieldSpawner.instance.InsertQueue(gameObject);
                dropTheItems();               
            }
        }
    }
    private void OnEnable() // 오브젝트 풀링에의해 다시 활성화될시 정보 초기화
    {
        if (enemyHP!= null)
        {       
            enemyHP.maxValue = maxHP;
            enemyHP.value = maxHP;
        }
    }
    
    void dropTheItems()
    {
        int maxItems = 1;        
        for (int i = 0; i < maxItems; i++)
        {
            int randomNum = Random.Range(0,101);
            if(randomNum < 31)
            {
               return;           
            }
            else if(randomNum < 81)
            {
                Instantiate(items[0], trans.position, Quaternion.identity);
                Debug.Log("아이템 1" + randomNum);            
            }
            else if(randomNum < 99)
            {
                Instantiate(items[1], trans.position, Quaternion.identity);
                Debug.Log("아이템 1" + randomNum);            
            }
            else if(randomNum < 101)
            {
                Instantiate(items[2], trans.position, Quaternion.identity);
                Debug.Log("아이템 1" + randomNum);            
            }
            Instantiate(items[3], trans.position, Quaternion.identity);
        }
    }
    
}
