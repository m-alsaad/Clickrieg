/**************************************************
 * GLOBAL FUEL SCRIPT
 * 
 * TRACK AND WORK EVERYTHING FUEL RELATED
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class GlobalFuel : MonoBehaviour {

    //VARIABLES
    public static int FuelCount;                        //Number of Available Fuel

    public GameObject TopBarFuelTextCounter;           //Top Bar Fuel Text Counter

    
    //UPDATE
    void Update () {
        TopBarFuelTextCounter.GetComponent<Text>().text = "" + FuelCount;      //Update Top Bar Fuel Text Counter to the Current Count
    }
}
