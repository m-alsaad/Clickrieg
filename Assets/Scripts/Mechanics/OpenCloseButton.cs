using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseButton : MonoBehaviour
{

    //The Background image that will be manipulated
    public GameObject Background;


    //For Buttons that open and close a display
    public void OpenCloseClick()
    {

        if(Background.activeSelf == false)
        {
            Background.SetActive(true);
        }
        else
        {
            Background.SetActive(false);
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
