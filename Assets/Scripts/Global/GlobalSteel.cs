/**************************************************
 * GLOBAL STEEL SCRIPT
 * 
 * TRACK AND WORK EVERYTHING STEEL RELATED
 **************************************************/ 

//IMPORTS
using UnityEngine;
using UnityEngine.UI;
//----------


//MAIN
public class GlobalSteel : MonoBehaviour {

    //VARIABLES
    public static int SteelCount;       //Number of Available Steel

    public GameObject TopBarSteelTextCounter;       //Top Bar Steel Text Counter
    //--------------------


    //UPDATE
    void Update (){
        TopBarSteelTextCounter.GetComponent<Text>().text = "" + SteelCount;     //Update Top Bar Steel Text Counter to the Current Count
    }
    //--------------------


    //BUTTON: MAKE STEEL
    public void BuySteel(){

        if (GlobalMoney.MoneyCount - 2 >= 0){
            GlobalMoney.MoneyCount -= 2;
            SteelCount += 1;
        }
    }
    //--------------------
}
