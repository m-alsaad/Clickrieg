using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScienceButton : MonoBehaviour
{

    public GameObject Research_BG;
    public GameObject IncreaseRecruit;
    public GameObject Plus;
    public GameObject Clip;

    bool Active = false;

    public void ButtonClick()
    {
        if(Active == false)
        {
            Research_BG.SetActive(true);
            IncreaseRecruit.SetActive(true);
            Plus.SetActive(true);
            Clip.SetActive(true);

            Active = true;
        }
        else
        {
            Research_BG.SetActive(false);
            IncreaseRecruit.SetActive(false);
            Plus.SetActive(false);
            Clip.SetActive(false);

            Active = false;
        }
    }

}
