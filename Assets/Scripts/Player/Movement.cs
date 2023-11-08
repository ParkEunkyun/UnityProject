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

    public AudioClip walkingSound;
    public AudioSource audioSource;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
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

        transform.position += dir * (_PlayerStat.MoveSpeed / 100) * Time.deltaTime;

        if (js.Horizontal < 0)
        {
            dir = Vector3.left;
            transform.localScale = new Vector3(1f, 1f, 1f);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(walkingSound);
            }

        }
        else if (js.Horizontal > 0)
        {
            dir = Vector3.right;
            transform.localScale = new Vector3(-1f, 1f, 1f);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(walkingSound);
            }

        }
            
    }

    public void AnimateMovement()
    {
        animator.SetFloat("move_L", js.Horizontal * -1f);
        animator.SetFloat("move_R", js.Horizontal * 1f);
    }    
}



