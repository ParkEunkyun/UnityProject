using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    public Slider playerHP;
    //public float maxHP;
    public GameObject player;
    public Stat _playerstat;
    Monster _monster;
    private void start()
    {
        //_playerstat = GameObject.Find("Player").GetComponent<PlayerStat>();
        playerHP.maxValue = _playerstat.maxHP;
        //playerHP.value = _playerstat.;
    }
    private void Update()
    {
        //playerHP.maxValue = _playerstat.MaxHp;
    }
    public void OnTriggerEnter2D(Collider2D other) 
    {
        Monster _monster = other.gameObject.GetComponent<Monster>();   
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.gameObject.tag.Equals("Enemy"))
        {               
            if(playerHP.value > 0)
            { 
                
                playerHP.value = playerHP.value - _monster.Damage;
                //ObjectPool.ReturnObject();
                //Destroy(other.gameObject);
                //Debug.Log("데미지" + .Dmg);
            }
            
            if (playerHP.value <= 0)
            {                
                //Vector2 v = new Vector2(0f, 0f);
                //animator = GameObject.Find("EnemyUnitRoot").GetComponent<Animator>();
                //animator.SetTrigger("Death");                
                //Destroy(other.gameObject);
                //Destroy(transform.parent.gameObject);
                //SpawnManager.EnemyCnt--;              
                //trans.position = this.transform.position;
                player.gameObject.SetActive(false);
                //MonsterSpawner.instance.InsertQueue(gameObject); 
                
                //StartCoroutine("dropTheItems");
                          
            }
        }
    }
}
