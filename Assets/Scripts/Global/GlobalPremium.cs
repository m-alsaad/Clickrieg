/**************************************************
 * GLOBAL PREMIUM SCRIPT
 * 
 * TRACK AND WORK EVERYTHING PREMIUM RELATED
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class GlobalPremium : MonoBehaviour
{

    //VARIABLES
    public static int PremiumCount = 0;        //Number of Available Premium

    public GameObject TextObject;               //Top Bar Premium Text Counter


    //UPDATE
    void Update()
    {

        TextObject.GetComponent<Text>().text = "" + PremiumCount;      //Update Top Bar Premium Text Counter to the Current Count

    }
}
