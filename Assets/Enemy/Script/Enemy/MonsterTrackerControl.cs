using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterTrackerControl : MonoBehaviour
{
        Rigidbody2D rb;
        Transform target;
        
        [Header("추격 속도")]
        [SerializeField] [Range(1f,6f)] float moveSpeed = 3f;

        [Header("근접 거리")]
        [SerializeField] [Range(0f,3f)] float contactDistance = 1f;
        bool follow = false;
        
              
       

    // Start is called before the first frame update
    void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
       target = GameObject.Find("Char").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();       
    }

    void FollowTarget()
    {      
        if (Vector2.Distance(transform.position, target.position) > contactDistance )
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        else
            rb.velocity = Vector2.zero;
    }       
}
