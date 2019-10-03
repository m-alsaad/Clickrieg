using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionButton : MonoBehaviour
{

    public GameObject Background;
    bool Active = true;



    public void ButtonClick ()
    {
        if(Active == false)
        {
            Background.SetActive(true);
            Active = true;
        }
        else
        {
            Background.SetActive(false);
            Active = false;
        }
    }

}

