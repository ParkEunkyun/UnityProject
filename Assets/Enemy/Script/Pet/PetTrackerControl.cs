using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetTrackerControl : MonoBehaviour
{
        Rigidbody2D rb;
        Transform target;
        Movement _movements;
        
        [Header("추격 속도")]
        [SerializeField] [Range(1f,4f)] float moveSpeed = 3f;

        [Header("근접 거리")]
        [SerializeField] [Range(0f,3f)] float contactDistance = 1f;
        bool follow = false;
        private Animator animator;
              
       

    // Start is called before the first frame update
    void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
       target = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Transform>();
       _movements = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();    
       animator = GetComponentInChildren<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();       
    }

    void FollowTarget()
    {      
        
        if (Vector2.Distance(transform.position, target.position) > contactDistance)
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        else
            rb.velocity = Vector2.zero;

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //follow = true;
            if(Vector2.Distance(transform.position, target.position) > contactDistance + 0.1f)
            {
                animator.SetBool("move", true);
            }
            
            if(Vector2.Distance(transform.position, target.position) <= contactDistance + 0.1f)
            {
                animator.SetBool("move", false);
            }
            
        }              
    }        
}
