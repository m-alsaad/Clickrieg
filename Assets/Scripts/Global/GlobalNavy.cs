/**************************************************
 * GLOBAL NAVY SCRIPT
 * 
 * TRACK AND WORK EVERYTHING NAVY RELATED
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class GlobalNavy : MonoBehaviour {

    //VARIABLES
    public static int NavyCount;            //Number of Available Navy

    public GameObject TextObject;           //Top Bar Navy Text Counter


    //UPDATE
    void Update () {
        TextObject.GetComponent<Text>().text = "" + NavyCount;      //Update Top Bar Navy Text Counter to the Current Count
    }
}
