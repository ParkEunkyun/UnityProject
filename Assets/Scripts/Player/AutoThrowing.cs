using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AutoThrowing : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    //있어야함, 왜냐면 타겟 사이에 다른 오브젝트가 있는데 그 오브젝트를 투과해서 뒤의 타겟오브젝트를 볼 수 있음
    public GameObject targeting;
    public float shortDis;
    public GameObject firePoint;
    public GameObject Bullet;
    public float attackSpeed;
    public float BulletSpeed;
    public int Dmg;
    public int CriDmg;
    private Animator animator;

    public List<GameObject> visibleTargets = new List<GameObject>();
    public Stat _playerStat;
    public SkillObject _Skill;
    public float FireTime;
    public float Criper;

    public GameObject Aim;

    public AudioClip ThrowSound;
    public AudioSource audioSource;

    public SpriteRenderer Circle;

    //public GameObject targetingUI;
    void Start()
    {
        //attackSpeed = _playerStat.AttackSpeed;
        BulletSpeed = 7f;
        animator = GetComponentInChildren<Animator>();

    }
    void Update()
    {
        //attackSpeed = _playerStat.AttackSpeed/100;            
        viewRadius = _Skill.SkillViewRadius;
        Aiming();
        FindTargets();
        FireTime = FireTime + (_playerStat.AttackSpeed * Time.deltaTime);
        if (FireTime > 300)
        {
            //FindTargets();
            FireTime = FireTime - 300;
            Throwbullet();
        }
        Circle.transform.localScale = new Vector3(viewRadius*2, viewRadius*2, 1);
    }
    private void OnDrawGizmos()
    {
        Vector3 myPos = transform.position;
        Gizmos.DrawWireSphere(myPos, viewRadius);
    }

    void FindTargets()
    {
        visibleTargets.Clear();
        Collider2D[] targetInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetInViewRadius.Length; i++) //ViewRadius 안에 있는 타겟의 개수 = 배열의 개수보다 i가 작을 때 for 실행
        {
            Transform target = targetInViewRadius[i].transform; //타겟[i]의 위치
            Vector2 dirToTarget = (target.position - transform.position).normalized; //vector3타입의 타겟의 방향 변수 선언 = 타겟의 방향벡터, 타겟의 position - 이 게임오브젝트의 position) normalized = 벡터 크기 정규화 = 단위벡터화
            if (Vector2.Angle(transform.forward, dirToTarget) < viewAngle / 2) // 전방 벡터와 타겟방향벡터의 크기가 시야각의 1/2이면 = 시야각 안에 타겟 존재
            {
                float dstToTarget = Vector2.Distance(transform.position, target.position); //타겟과의 거리를 계산
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)) //레이캐스트를 쐇는데 obstacleMask가 아닐 때 참이고 아래를 실행함
                {
                    visibleTargets.Add(target.transform.gameObject); //게임오브젝트가 리스트에 들어가긴 함,
                    //Debug.DrawRay(transform.position, dirToTarget * 10f, Color.red, 5f);
                    
                    //print("raycast hit!");
                }
            }
        }

        if (visibleTargets.Count != 0) //범위 안에 있는 게임오브젝트 리스트 존재 시, 거리 계산 시작
        {
            targeting = visibleTargets[0];
            shortDis = Vector2.Distance(transform.position, visibleTargets[0].transform.position); //visibleTargets 리스트의 첫번째와의 거리를 기준으로 잡기
                                                                                                   //리스트에서 가장 가까운 거리의 게임 오브젝트 찾기
            foreach (GameObject found in visibleTargets)
            {
                float distance = Vector2.Distance(transform.position, found.transform.position);
                if (distance < shortDis)
                {
                    targeting = found;
                    shortDis = distance;
                }
            }
            
        }
        else
        {
            targeting = null;
        }
    }
    public void Throwbullet()
    {
        if (targeting != null)
        {
            if(targeting.CompareTag("Enemy") || targeting.CompareTag("Boss") || targeting.CompareTag("RealBoss"))
            {
                AnimateAttack();
                var newBullet = BulletObjectPool.GetObject(); // 수정
                                                              //newBullet.transform.SetParent(transform.Find("BulletPool"));        
                newBullet.GetComponent<Rigidbody2D>().velocity = (targeting.transform.position - transform.position).normalized * BulletSpeed;                
            }
        }
    }
    public void AnimateAttack()
    {
        animator.SetTrigger("Attack");
        
            audioSource.PlayOneShot(ThrowSound);
        
    }
    public void DamageCaculate()
    {
        int Crinum = Random.Range(0, 501);
        if (Crinum < _playerStat.Critical + 1)
        {
            Dmg = 0;
            CriDmg = Random.Range(_playerStat.minAtk, _playerStat.maxAtk + 1);
            Criper = CriDmg * (_playerStat.CriticalDmg / 100f);
            //CriDmg = Random.Range(_playerStat.minAtk, _playerStat.maxAtk +1);
            CriDmg = Mathf.RoundToInt(Criper);
        }
        else
        {
            CriDmg = 0;
            Dmg = Random.Range(_playerStat.minAtk, _playerStat.maxAtk + 1);
        }
    }

    public void Aiming()
    {
        if (targeting != null)
        {
            Aim.SetActive(true);
            Aim.transform.position = targeting.transform.position;
        }
        else
        {
            Aim.transform.position = this.transform.position;
            Aim.SetActive(false);
        }
    }
}

