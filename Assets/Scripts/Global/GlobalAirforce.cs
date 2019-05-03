/**************************************************
 * GLOBAL AIRFORCE SCRIPT
 * 
 * TRACK AND WORK EVERYTHING AIRFORCE RELATED
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class GlobalAirforce : MonoBehaviour {

    //VARIABLES
    public static int AirforceCount;        //Number of Available Airforce

    public GameObject TextObject;           //Top Bar Airforce Text Counter


    //UPDATE
    void Update () {
        TextObject.GetComponent<Text>().text = "" + AirforceCount;      //Update Top Bar Airforce Text Counter to the Current Count
    }
}
