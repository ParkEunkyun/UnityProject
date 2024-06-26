using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject TutorialMask_1;
    public GameObject TutorialMask_2;
    public GameObject TutorialMask_3;
    public GameObject TutorialMask_4;
    public GameObject TutorialMask_5;
    public GameObject TutorialMask_6;
    public GameObject TutorialMask_7;
    public GameObject TutorialMask_8;
    public GameObject TutorialMask_9;
    public GameObject TutorialMask_10;
    public GameObject TutorialMask_11;
    public GameObject TutorialMask_12;
    public GameObject TutorialMask_13;
    public GameObject TutorialMask_14;
    public GameObject TutorialMask_15;
    public GameObject TutorialMask_16;
    public GameObject TutorialMask_17;


    public GameObject MonsterPool;
    public GameObject joystick;

    public void Start()
    {
        if (DataManager.instance.nowPlayer.Playtutorial == 0)
        {
            TutorialMask_1.SetActive(true);
            MonsterPool.SetActive(false);
            joystick.SetActive(false);
        }
        else 
        {
            return;
        }
    }

    public void NextTutorial(int tutorialNumber)
    {
        if (tutorialNumber == 1)
        {
            TutorialMask_1.SetActive(false);
            TutorialMask_2.SetActive(true);
            TutorialMask_3.SetActive(false);
            TutorialMask_4.SetActive(false);
            TutorialMask_5.SetActive(false);
            TutorialMask_6.SetActive(false);
        }
        else if (tutorialNumber == 2)
        {
            TutorialMask_1.SetActive(false);
            TutorialMask_2.SetActive(false);
            TutorialMask_3.SetActive(true);
            TutorialMask_4.SetActive(false);
            TutorialMask_5.SetActive(false);
            TutorialMask_6.SetActive(false);
        }
        else if (tutorialNumber == 3)
        {
            TutorialMask_1.SetActive(false);
            TutorialMask_2.SetActive(false);
            TutorialMask_3.SetActive(false);
            TutorialMask_4.SetActive(true);
            TutorialMask_5.SetActive(false);
            TutorialMask_6.SetActive(false);
        }
        else if (tutorialNumber == 4)
        {
            TutorialMask_1.SetActive(false);
            TutorialMask_2.SetActive(false);
            TutorialMask_3.SetActive(false);
            TutorialMask_4.SetActive(false);
            TutorialMask_5.SetActive(true);
            TutorialMask_6.SetActive(false);
        }
        else if (tutorialNumber == 5)
        {
            TutorialMask_1.SetActive(false);
            TutorialMask_2.SetActive(false);
            TutorialMask_3.SetActive(false);
            TutorialMask_4.SetActive(false);
            TutorialMask_5.SetActive(false);
            TutorialMask_6.SetActive(true);
        }
        else if (tutorialNumber == 6)
        {
            TutorialMask_1.SetActive(false);
            TutorialMask_2.SetActive(false);
            TutorialMask_3.SetActive(false);
            TutorialMask_4.SetActive(false);
            TutorialMask_5.SetActive(false);
            TutorialMask_6.SetActive(false);
            MonsterPool.SetActive(true);
            joystick.SetActive(true);
            DataManager.instance.nowPlayer.Playtutorial = 1;
        }
        else if (tutorialNumber == 7)
        {
            TutorialMask_7.SetActive(false);
            TutorialMask_8.SetActive(true);
            TutorialMask_9.SetActive(false);
            TutorialMask_10.SetActive(false);
            TutorialMask_11.SetActive(false);
        }
        else if (tutorialNumber == 8)
        {
            TutorialMask_7.SetActive(false);
            TutorialMask_8.SetActive(false);
            TutorialMask_9.SetActive(true);
            TutorialMask_10.SetActive(false);
            TutorialMask_11.SetActive(false);
        }
        else if (tutorialNumber == 9)
        {
            TutorialMask_7.SetActive(false);
            TutorialMask_8.SetActive(false);
            TutorialMask_9.SetActive(false);
            TutorialMask_10.SetActive(true);
            TutorialMask_11.SetActive(false);
        }
        else if (tutorialNumber == 10)
        {
            TutorialMask_7.SetActive(false);
            TutorialMask_8.SetActive(false);
            TutorialMask_9.SetActive(false);
            TutorialMask_10.SetActive(false);
            TutorialMask_11.SetActive(true);
        }
        else if (tutorialNumber == 11)
        {
            TutorialMask_7.SetActive(false);
            TutorialMask_8.SetActive(false);
            TutorialMask_9.SetActive(false);
            TutorialMask_10.SetActive(false);
            TutorialMask_11.SetActive(false);
            DataManager.instance.nowPlayer.Crafttutorial = 1;
        }
        else if (tutorialNumber == 12)
        {
            TutorialMask_12.SetActive(false);
            TutorialMask_13.SetActive(true);
            TutorialMask_14.SetActive(false);
            TutorialMask_15.SetActive(false);
            TutorialMask_16.SetActive(false);
            TutorialMask_17.SetActive(false);
        }
        else if (tutorialNumber == 13)
        {
            TutorialMask_12.SetActive(false);
            TutorialMask_13.SetActive(false);
            TutorialMask_14.SetActive(true);
            TutorialMask_15.SetActive(false);
            TutorialMask_16.SetActive(false);
            TutorialMask_17.SetActive(false);
        }
        else if (tutorialNumber == 14)
        {
            TutorialMask_12.SetActive(false);
            TutorialMask_13.SetActive(false);
            TutorialMask_14.SetActive(false);
            TutorialMask_15.SetActive(true);
            TutorialMask_16.SetActive(false);
            TutorialMask_17.SetActive(false);
        }
        else if (tutorialNumber == 15)
        {
            TutorialMask_12.SetActive(false);
            TutorialMask_13.SetActive(false);
            TutorialMask_14.SetActive(false);
            TutorialMask_15.SetActive(false);
            TutorialMask_16.SetActive(true);
            TutorialMask_17.SetActive(false);
        }
        else if (tutorialNumber == 16)
        {
            TutorialMask_12.SetActive(false);
            TutorialMask_13.SetActive(false);
            TutorialMask_14.SetActive(false);
            TutorialMask_15.SetActive(false);
            TutorialMask_16.SetActive(false);
            TutorialMask_17.SetActive(true);
        }
        else if (tutorialNumber == 17)
        {
            TutorialMask_12.SetActive(false);
            TutorialMask_13.SetActive(false);
            TutorialMask_14.SetActive(false);
            TutorialMask_15.SetActive(false);
            TutorialMask_16.SetActive(false);
            TutorialMask_17.SetActive(false);
            DataManager.instance.nowPlayer.statustutorial = 1;
        }
    }
}
