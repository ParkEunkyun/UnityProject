using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItemMagnet : MonoBehaviour
{
        Rigidbody2D rb;
        Transform target;
        
        [Header("추격 속도")]
        [SerializeField] [Range(1f,4f)] float moveSpeed = 3f;

        [Header("근접 거리")]
        [SerializeField] [Range(0f,3f)] float contactDistance = 1f;
        bool follow = false;
        
              
       

    // Start is called before the first frame update
    void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
       target = GameObject.Find("Magnet").GetComponent<Transform>();
    }

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag.Equals("Magnet"))
        {
            StartCoroutine("FollowTarget");// FollowTarget();
        }
             
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            StopCoroutine("FollowTarget");
        }
             
    }

    void FollowTarget()
    {      
        if (Vector2.Distance(transform.position, target.position) > contactDistance )
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        else
            rb.velocity = Vector2.zero;
    }       
}
