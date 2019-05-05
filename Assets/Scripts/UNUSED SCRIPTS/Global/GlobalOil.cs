/**************************************************
 * GLOBAL OIL SCRIPT
 * 
 * TRACK AND WORK EVERYTHING OIL RELATED
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class GlobalOil : MonoBehaviour {

    //VARIABLES
    public static int OilCount;                    //Number of Available Oil

    public GameObject TopBarOilTextCounter;        //Top Bar Oil Text Counter


    //UPDATE
    void Update () {
        TopBarOilTextCounter.GetComponent<Text>().text = "" + OilCount;       //Update Top Bar Oil Text Counter to the Current Count
    }
}
