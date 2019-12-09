/**************************************************
 * OPEN AND CLOSE DISPLAY SCRIPT SPECIFIC FOR RESEARCH
 * 
 * I CAN'T REMEMBER WHY THIS IS NEEDED AND CAN'T USE
 * THE BASIC ONE
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MAIN
public class ResearchDisplay : MonoBehaviour
{
    //VARIBALES
    public static int ID;
    private int tempID;

    public GameObject Background;
    public AudioSource closeSound;


    public void Start()
    {
        ID = 000;
        tempID = 000;
    }

    public void ButtonClick()   
    {
        if (Background.activeSelf == false)
        {
            Background.SetActive(true);
            tempID = ID;
        }
        else
        {
            if (tempID == ID)
            {
                
                Background.SetActive(false);
                tempID = 000;
            }
            else
            {
                tempID = ID;
            }
            
        }
    }

    public void ButtonClickClose()
    {
        closeSound.Play();
        Background.SetActive(false);
        tempID = 000;
    }

    public void ButtonClickOpen()
    {
        if (Background.activeSelf == false)
        {
            Background.SetActive(true);
        }
        else
        {
            Background.SetActive(false);
        }
    }

}
