/**************************************************
 * GLOBAL ALUMINIUM SCRIPT
 * 
 * TRACK AND WORK EVERYTHING ALUMINIUM RELATED
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class GlobalAluminium : MonoBehaviour {

    //VARIABLES
    public static int AluminiumCount;              //Number of Available Aluminium

    public GameObject TopBarAluminiumTextCounter;  //Top Bar Aluminium Text Counter


    //UPDATE
    void Update () {
        TopBarAluminiumTextCounter.GetComponent<Text>().text = "" + AluminiumCount;     //Update Top Bar Aluminium Text Counter to the Current Count
    }
}
