/**************************************************
 * GLOBAL FOOD SRIPT
 * 
 * TRACK AND WORK EVERYTHING COAL RELATED
 **************************************************/

//IMPORTS
using UnityEngine;
using UnityEngine.UI;
//----------

//MAIN
public class GlobalCoal : MonoBehaviour {

    //VARIABLES
    public static int CoalCount;            //Number of Available Coal

    public GameObject TopBarCoalTextCounter;       //Top Bar Coal Text Counter
    //--------------------

    //UPDATE
    void Update () {
        TopBarCoalTextCounter.GetComponent<Text>().text = "" + CoalCount;
	}
    //--------------------
}
