using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Sprites;

public class ResearchGun : MonoBehaviour {

    public double ResearchPoint;

    public bool Active = false;
    public bool Reset = true;
    public Animator anim;

    void Start()
    {
        
    }




    public void ClickButton()
    {
        if(Active == false)
        {
            Active = true;
            anim.SetBool("ResearchActive", true);
  

        }
        else
        {
            Active = false;
            anim.SetBool("ResearchActive", false);
        }
    }




	void Update () {

        if (Active == true)
        {
            if (Reset == true)
            {
                StartCoroutine(Researching());
                Reset = false;
            }
        }
		
	}


    IEnumerator Researching()
    {
        yield return new WaitForSeconds(1);
        
        if (GlobalScience.TrueScience - 0.01 >= 0)
        {
            Debug.Log("YES");
            ResearchPoint += 0.01;
            GlobalScience.ScienceCount -= 1;
        }
        Reset = true;

    }
}
