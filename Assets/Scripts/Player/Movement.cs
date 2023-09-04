using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Movement : MonoBehaviour
{
    public FloatingJoystick js;    
    private Animator animator;    
    public Stat _PlayerStat;
    public Vector3 dir;
    //ChangeButton _changeButton;
    MiningAction _miningAction;
    void Start()
    {
      animator = GetComponentInChildren<Animator>();       
      //_PlayerStat = GetComponent<PlayerStat>();
      //_changeButton = GameObject.Find("GNB_3").GetComponent<ChangeButton>();
      //_miningAction = GameObject.Find("Player").GetComponentInChildren<MiningAction>();
      
    }
     public void Update()
     {
       move();
       AnimateMovement();
     }   
    
    public void move()
    {
        
       dir = new Vector3(js.Horizontal, js.Vertical, 0);
       
       dir.Normalize();        
        
       transform.position += dir * (_PlayerStat.MoveSpeed/100) * Time.deltaTime; 
              
        if(js.Horizontal < 0)
        {
          dir = Vector3.left;
          transform.localScale = new Vector3(1f, 1f, 1f);
        
        }
        else if(js.Horizontal > 0)
        {
          dir = Vector3.right;
          transform.localScale = new Vector3(-1f, 1f, 1f);
              
        }           
    }
    
    public void AnimateMovement()
    {
       animator.SetFloat("move_L", js.Horizontal * -1f);
       animator.SetFloat("move_R", js.Horizontal * 1f);          
    }
    /*
    public void AnimateAttack()
    {
       animator.SetBool("Attack", true);              
    }
     public void AnimateNonAttack()
    {
       animator.SetBool("Attack", false);              
    }   
     private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag.Equals("Mine") && !_changeButton.changed)
        {
          AnimateAttack();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag.Equals("Mine") && !_changeButton.changed)
        {
          AnimateNonAttack();
          _miningAction.FX.SetActive(false);
          _miningAction.effect.SetActive(false);
        }
    }
    */
}
   
      

