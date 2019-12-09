/**************************************************
 * SIMPLE OPEN AND CLOSE DISPLAY SCRIPT
 * 
 * CAN BE USED ON ANY GAME OBJECT. 
 * USE SCRIPT ON THE BUTTON
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MAIN
public class OpenCloseButton : MonoBehaviour
{

    //The Background image that will be manipulated
    public GameObject Background;
    public AudioSource open;
    public AudioSource close;

    private void Start()
    {

    }

    //For Buttons that open and close a display
    public void OpenCloseClick()
    {

        if(Background.activeSelf == false)
        {
            Background.SetActive(true);
            open.Play();
        }
        else
        {
            Background.SetActive(false);
            close.Play();
        }

    }

    //For Buttons that can only close
    public void CloseDisplay()
    {
        Background.SetActive(false);
    }


    //For Buttons that can only open
    public void OpenDisplay()
    {
        Background.SetActive(true);
    }
}
