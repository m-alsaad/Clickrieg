/**************************************************
 * GLOBAL MANPOWER SCRIPT
 * 
 * TRACK AND WORK EVERYTHING MANPOWER RELATED
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class GlobalManpower : MonoBehaviour {

    //VARIABLES
    public static int ManpowerCount = 0;        //Number of Available Manpower

    public GameObject TextObject;               //Top Bar Manpower Text Counter


    //UPDATE
    void Update () {

        TextObject.GetComponent<Text>().text = "" + ManpowerCount;      //Update Top Bar Manpower Text Counter to the Current Count

    }
}
