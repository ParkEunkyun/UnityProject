using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public Slider enemyHP;
    public float Damage;
    public int maxHP;    
    public GameObject[] items = new GameObject[4];
    public GameObject hudDamageText;
    public GameObject hudCriDamageText;
    Transform trans;
    public Transform hudPos; 
    //private Animator animator;
    AutoThrowing _AutoThrowing;
    public Stat stat;
    public SkillObject _skill;
    public bool AreaSkillUse;
    
    [SerializeField]
    private int EXP;
    public float timer;
    void Start()
    {
        
        trans = GetComponent<Transform>();
        //obj = GetComponent<GameObject>();
        enemyHP.maxValue = maxHP;
        enemyHP.value = maxHP;
        
    }
    private void Update() 
    {        
        timer += Time.deltaTime;
        if(timer >= 0.5f)
        {
            AreaSkillUse = true;
        }
    } 
    private void OnTriggerEnter2D(Collider2D other)
    {       
                
        if(other.gameObject.tag.Equals("Bullet"))
        {   
            _AutoThrowing = GameObject.Find("Char").GetComponent<AutoThrowing>();           

            if(enemyHP.value > 0)
            { 
                _AutoThrowing.DamageCaculate();
                TakeDmg();
                if(_AutoThrowing.CriDmg == 0)
                {
                    enemyHP.value = enemyHP.value - _AutoThrowing.Dmg;
                }
                else if(_AutoThrowing.Dmg == 0)
                {
                    enemyHP.value = enemyHP.value - _AutoThrowing.CriDmg;
                }                
                Debug.Log("데미지" + _AutoThrowing.Dmg);
                Debug.Log("데미지" + _AutoThrowing.CriDmg);
            }
            
            if (enemyHP.value <= 0)
            {                
                Vector2 v = new Vector2(0f, 0f);                
                trans.position = this.transform.position;
                this.gameObject.SetActive(false);
                dropTheItems();
                DataManager.instance.nowPlayer.monsterKill++;
                DataManager.instance.nowPlayer.curExp = DataManager.instance.nowPlayer.curExp + EXP;               
                DataManager.instance.LevelUP();
                DataManager.instance.SaveData();   
                MonsterSpawner.instance.InsertQueue(gameObject);
                
            }
        }
///////////////회전체 스킬 데미지 : 데미지 루트 변경예정
        if(other.gameObject.tag.Equals("Around"))
        {
            _AutoThrowing = GameObject.Find("Char").GetComponent<AutoThrowing>();

            if(enemyHP.value > 0)
            { 
                _AutoThrowing.DamageCaculate();
                TakeDmg();
                if(_AutoThrowing.CriDmg == 0)
                {
                    enemyHP.value = enemyHP.value - _AutoThrowing.Dmg;
                }
                else if(_AutoThrowing.Dmg == 0)
                {
                    enemyHP.value = enemyHP.value - _AutoThrowing.CriDmg;
                }                
                Debug.Log("데미지" + _AutoThrowing.Dmg);
                Debug.Log("데미지" + _AutoThrowing.CriDmg);
            }
            
            if (enemyHP.value <= 0)
            {                
                Vector2 v = new Vector2(0f, 0f);                
                trans.position = this.transform.position;
                this.gameObject.SetActive(false);
                dropTheItems();
                DataManager.instance.nowPlayer.monsterKill++;
                DataManager.instance.nowPlayer.curExp = DataManager.instance.nowPlayer.curExp + EXP;               
                DataManager.instance.LevelUP();
                DataManager.instance.SaveData();   
                MonsterSpawner.instance.InsertQueue(gameObject);
                
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {        
        ///////////////장판 스킬 데미지 : 데미지 루트 변경예정
        if(other.gameObject.tag.Equals("Area") && AreaSkillUse == true)
        {
            _AutoThrowing = GameObject.Find("Char").GetComponent<AutoThrowing>();

            if(enemyHP.value > 0)
            { 
                _AutoThrowing.DamageCaculate();
                TakeDmg();
                if(_AutoThrowing.CriDmg == 0)
                {
                    enemyHP.value = enemyHP.value - _AutoThrowing.Dmg;
                }
                else if(_AutoThrowing.Dmg == 0)
                {
                    enemyHP.value = enemyHP.value - _AutoThrowing.CriDmg;
                }           
                Debug.Log("데미지" + _AutoThrowing.Dmg);
                Debug.Log("데미지" + _AutoThrowing.CriDmg);
            }
            
            if (enemyHP.value <= 0)
            {                
                Vector2 v = new Vector2(0f, 0f);                
                trans.position = this.transform.position;
                this.gameObject.SetActive(false);
                dropTheItems();
                DataManager.instance.nowPlayer.monsterKill++;
                DataManager.instance.nowPlayer.curExp = DataManager.instance.nowPlayer.curExp + EXP;               
                DataManager.instance.LevelUP();
                DataManager.instance.SaveData();
                MonsterSpawner.instance.InsertQueue(gameObject);
                
            }
            AreaSkillUse = false;
            timer = 0;
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
            int randomNum = Random.Range(0,1002);
            if(randomNum < 801)
            {
                Instantiate(items[0], trans.position, Quaternion.identity);
                Debug.Log("아이템 1" + randomNum);            
            }
            else if(randomNum < 901)
            {
                Instantiate(items[1], trans.position, Quaternion.identity);
                Debug.Log("아이템 2" + randomNum);            
            }
            else if(randomNum < 1001)
            {
                Instantiate(items[2], trans.position, Quaternion.identity);
                Debug.Log("아이템 3" + randomNum);            
            }
            else if(randomNum < 1002)
            {
                Instantiate(items[3], trans.position, Quaternion.identity);
                Debug.Log("아이템 4" + randomNum);            
            }

            if(randomNum < 1001)
            {
                Instantiate(items[4], trans.position, Quaternion.identity);
                Debug.Log("기타아이템 " + randomNum);            
            }
            //Instantiate(items[3], trans.position, Quaternion.identity);
        }        
        
    }
    
    private void TakeDmg()
    {
        if(_AutoThrowing.CriDmg == 0)
        {
        GameObject hudText = Instantiate(hudDamageText);
        hudText.transform.position = hudPos.position;
        hudText.gameObject.layer = 5;
        hudText.GetComponent<DamageText>().damage = _AutoThrowing.Dmg;
        }
        else if (_AutoThrowing.Dmg == 0)
        {
        GameObject hudCriText = Instantiate(hudCriDamageText);
        hudCriText.transform.position = hudPos.position;
        hudCriText.gameObject.layer = 5;
        hudCriText.GetComponent<DamageText>().damage = _AutoThrowing.CriDmg;
        }
    }

}
