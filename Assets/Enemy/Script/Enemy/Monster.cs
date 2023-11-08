using EZInventory;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    //public GoldObjectPool goldPool;

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
        if (timer >= 0.5f)
        {
            AreaSkillUse = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Bullet"))
        {
            _AutoThrowing = GameObject.Find("Char").GetComponent<AutoThrowing>();

            if (enemyHP.value > 0)
            {
                _AutoThrowing.DamageCaculate();
                TakeDmg();
                if (_AutoThrowing.CriDmg == 0)
                {
                    enemyHP.value = enemyHP.value - _AutoThrowing.Dmg;
                }
                else if (_AutoThrowing.Dmg == 0)
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
                //DataManager.instance.LevelUP();
                DataManager.instance.SaveData();
                MonsterSpawner.instance.InsertQueue(gameObject);

            }
        }
        ///////////////회전체 스킬 데미지 : 데미지 루트 변경예정
        if (other.gameObject.tag.Equals("Around"))
        {
            _AutoThrowing = GameObject.Find("Char").GetComponent<AutoThrowing>();

            if (enemyHP.value > 0)
            {
                _AutoThrowing.DamageCaculate();
                TakeDmg();
                if (_AutoThrowing.CriDmg == 0)
                {
                    enemyHP.value = enemyHP.value - _AutoThrowing.Dmg;
                }
                else if (_AutoThrowing.Dmg == 0)
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
                //DataManager.instance.LevelUP();
                DataManager.instance.SaveData();
                MonsterSpawner.instance.InsertQueue(gameObject);

            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        ///////////////장판 스킬 데미지 : 데미지 루트 변경예정
        if (other.gameObject.tag.Equals("Area") && AreaSkillUse == true)
        {
            _AutoThrowing = GameObject.Find("Char").GetComponent<AutoThrowing>();

            if (enemyHP.value > 0)
            {
                _AutoThrowing.DamageCaculate();
                TakeDmg();
                if (_AutoThrowing.CriDmg == 0)
                {
                    enemyHP.value = enemyHP.value - _AutoThrowing.Dmg / 10;
                }
                else if (_AutoThrowing.Dmg == 0)
                {
                    enemyHP.value = enemyHP.value - _AutoThrowing.CriDmg / 10;
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
                //DataManager.instance.LevelUP();
                DataManager.instance.SaveData();
                MonsterSpawner.instance.InsertQueue(gameObject);

            }
            AreaSkillUse = false;
            timer = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("GroundArea"))
        {
            this.gameObject.SetActive(false);
            MonsterSpawner.instance.InsertQueue(gameObject);
        }
    }

    private void OnEnable() // 오브젝트 풀링에의해 다시 활성화될시 정보 초기화
    {
        if (enemyHP != null)
        {
            enemyHP.maxValue = maxHP;
            enemyHP.value = maxHP;
        }
    }
    public int golddrop;

    void dropTheItems()
    {
        int maxItems = 1;
        for (int i = 0; i < maxItems; i++)
        {
            int randomNum = Random.Range(0, 1001);
            if (randomNum < 301) //30%
            {
                return;
            }
            else if (randomNum < 701) // 40%
            {
                for (int ii = 0; ii < golddrop; ii++)
                {
                    GameObject gold = GoldObjectPool.GetObject();
                    gold.transform.position = trans.position;
                }
            }
            else if (randomNum < 726) //2.5%
            {
                GameObject HPortion = HealthPortionObjectPool.GetObject();
                HPortion.transform.position = trans.position;
            }
            else if (randomNum < 751) // 2.5%
            {
                GameObject MPortion = ManaPortionObjectPool.GetObject();
                MPortion.transform.position = trans.position;
            }
            else if (randomNum < 851) // 10%
            {
                DropItems();
                //하급 재료템
            }
            else if (randomNum < 901) //5%
            {
                testDropItems();
                //상급 재료템
            }
            else if (randomNum < 951) // 5%
            {
                Instantiate(items[2], trans.position, Quaternion.identity);
                //스킬조각
            }
            else if (randomNum < 952) // 0.1%
            {
                Instantiate(items[3], trans.position, Quaternion.identity);
                //장비1
            }
            else if (randomNum < 953) // 0.1%
            {
                Instantiate(items[4], trans.position, Quaternion.identity);
                //장비2
            }
            else if (randomNum < 954) // 0.1%
            {
                Instantiate(items[5], trans.position, Quaternion.identity);
                //장비3
            }
            else if (randomNum < 955) // 0.1%
            {
                Instantiate(items[6], trans.position, Quaternion.identity);
                //희귀
            }
            else if (randomNum < 1001) // 4.5%
            {
                return;
            }
        }

    }

    private void TakeDmg()
    {
        if (_AutoThrowing.CriDmg == 0)
        {
            GameObject hudText = DamageObjectPool.GetObject();//Instantiate(hudDamageText);
            hudText.transform.position = hudPos.position;
            hudText.gameObject.layer = 5;
            //hudText.GetComponent<DamageText>().damage = _AutoThrowing.Dmg;
            hudText.GetComponent<TextMeshPro>().text = _AutoThrowing.Dmg.ToString();
        }
        else if (_AutoThrowing.Dmg == 0)
        {
            GameObject hudCriText = CriDamageObjectPool.GetObject(); //Instantiate(hudCriDamageText);
            hudCriText.transform.position = hudPos.position;
            hudCriText.gameObject.layer = 5;
            //hudCriText.GetComponent<DamageText>().damage = _AutoThrowing.CriDmg;
            hudCriText.GetComponent<TextMeshPro>().text = _AutoThrowing.CriDmg.ToString();
        }
    }

    //////////////////////////////////////////////////////////// 새로 받아온 조합 시스템 아이템 드랍
    public ItemSO itemDrop;
    public ItemSO itemDrop2;
    public int dropAmount;

    static GameObject player;

    void DropItems() //노말재료
    {
        for (int i = 0; i < dropAmount; i++)
        {
            //Spawn force and position. Random so they all pop out in different directions
            Vector3 force = new Vector3(Random.Range(-2f, 2f), 2, Random.Range(-2f, 2f));
            ItemPickupable drop = (Instantiate(Resources.Load("Item Pickupable 1"), transform.position + (force / 4f), Quaternion.identity) as GameObject).GetComponent<ItemPickupable>();
            drop.SetUpPickupable(itemDrop, 1);
            drop.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        }
    }
    void testDropItems() // 고급재료
    {
        for (int i = 0; i < dropAmount; i++)
        {
            //Spawn force and position. Random so they all pop out in different directions
            Vector3 force = new Vector3(Random.Range(-2f, 2f), 2, Random.Range(-2f, 2f));
            ItemPickupable drop = (Instantiate(Resources.Load("Item Pickupable 1"), transform.position + (force / 4f), Quaternion.identity) as GameObject).GetComponent<ItemPickupable>();
            drop.SetUpPickupable(itemDrop2, 1);
            drop.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        }
    }
}
