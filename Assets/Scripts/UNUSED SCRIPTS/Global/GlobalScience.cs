/**************************************************
 * GLOBAL SCIENCE SCRIPT
 * 
 * TRACK AND WORK EVERYTHING SCIENCE RELATED
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class GlobalScience : MonoBehaviour {

    //VARIABLES
    public static double ScienceCount = 50;      //Number of Available Science

    public GameObject ScienceText;          //Top Bar Science Text Counter



    //UNEEDED AT THE MOMENT!
    public double HappyScience;
    public static double TrueScience;
    public double IN_ScienceCount;

	
    //UPDATE
	void Update () {

        ScienceText.GetComponent<Text>().text = "" + ScienceCount;      //Update Top Bar Science Text Counter to the Current Count


        //UNEEDED AT THE MOMENT!
        TrueScience = ScienceCount + HappyScience;
        IN_ScienceCount = TrueScience;
        

		
	}
}
