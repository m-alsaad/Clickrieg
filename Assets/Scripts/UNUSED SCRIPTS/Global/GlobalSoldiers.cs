/**************************************************
 * GLOBAL SOLDIERS SCRIPT
 * 
 * TRACK AND WORK EVERYTHING TOTAL SOLDIERS RELATED
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class GlobalSoldiers : MonoBehaviour {

    //VARIABLES
    public static int SoldierCount = 0;      //Number of Available Soldiers

    public GameObject TextObject;           //Top Bar Soldier Text Counter


    //UPDATE
    void Update () {
        TextObject.GetComponent<Text>().text = "" + SoldierCount;       //Update Top Bar Soldier Text Counter to the Current Count
    }
}
