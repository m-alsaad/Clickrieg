/**************************************************
 * GLOBAL ARMOURED VEHICLES SCRIPT
 * 
 * TRACK AND WORK EVERYTHING ARMOURED VEHICLES RELATED
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class GlobalArmoured : MonoBehaviour {

    //VARIABLES
    public static int ArmouredCount;         //Number of Available Armoured Vehicles

    public GameObject TextObject;           //Top Bar Armoured Vehicles Text Counter


    //UPDATE
    void Update () {
        TextObject.GetComponent<Text>().text = "" + ArmouredCount;      //Update Top Bar Armoured Text Counter to the Current Count
    }
}
