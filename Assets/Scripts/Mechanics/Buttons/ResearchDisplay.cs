using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchDisplay : MonoBehaviour
{
    public static int ID;
    private int tempID;

    public GameObject Background;


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
