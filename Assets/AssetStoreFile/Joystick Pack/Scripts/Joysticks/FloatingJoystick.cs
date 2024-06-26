using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    protected override void Start()
    {
        base.Start();
        //background.gameObject.SetActive(false);
        
        
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
        
    }

    public override void OnPointerUp(PointerEventData eventData)
    {

        //background.gameObject.SetActive(false);
        background.anchoredPosition = new Vector3(540.0f, 330.0f, 0.0f);
        base.OnPointerUp(eventData);     
    }
}