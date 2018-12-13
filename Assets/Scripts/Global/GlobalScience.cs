using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScience : MonoBehaviour {

    public static double ScienceCount;
    public GameObject ScienceText;

    public double HappyScience;
    public static double TrueScience;
    public double IN_ScienceCount;

	

	void Update () {
        if(GlobalHappiness.HappinessCount >= 0)
        {
            HappyScience = GlobalHappiness.HappinessCount;
        }

        TrueScience = ScienceCount + HappyScience;

        IN_ScienceCount = TrueScience;
        ScienceText.GetComponent<Text>().text = "" + IN_ScienceCount;

		
	}
}
