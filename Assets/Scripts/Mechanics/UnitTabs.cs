using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTabs : MonoBehaviour
{
    public GameObject ShowProduction;
    public GameObject HideProduction1, HideProduction2, HideProduction3;

    public AudioSource clickTabSound;


    public void clickButton()
    {
        clickTabSound.Play();

        ShowProduction.transform.localPosition = new Vector3(0, 250, 0);
        HideProduction1.transform.localPosition = new Vector3(-500, 250, 0);
        HideProduction2.transform.localPosition = new Vector3(-1000, 250, 0);
        HideProduction3.transform.localPosition = new Vector3(-1500, 250, 0);
    }
}
