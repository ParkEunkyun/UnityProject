using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public Character character;    
    SpriteRenderer spriteRender;
    public SelectCharacter[] chars;
    Animator anim;
    private void Start()
    {        
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();      
    }

    private void OnMouseUpAsButton()
    {        
        CharacterDataManager.instance.SelectedCharacter = character;    
        OnSelect();
        for(int i = 0; i < chars.Length; i++)
        {
            if(chars[i] != this)
            {
                chars[i].OnDeselect();
            }
        }
    }

    void OnDeselect()
    {
        anim.SetBool("run", false);
    }

    void OnSelect()
    {
        anim.SetBool("run", true);
    }
}
