/**************************************************
 * GLOBAL FOOD SCRIPT
 * 
 * TRACK AND WORK EVERYTHING FOOD RELATED
 **************************************************/

//IMPORTS
using UnityEngine;
using UnityEngine.UI;
//----------


//MAIN
public class GlobalFood : MonoBehaviour {

    //VARIABLES
    public static int FoodCount = 5;        //Number of Available Food
    public static int FoodIncome;           //Number of Food Income
    public static int FarmCount = 0;        //Number of Built Farms

    public GameObject TopBarFoodTextCounter;    //Top Bar Food Text Counter
    public GameObject FarmTextCounter;          //Farm Text Counter
    public GameObject IncomeTextCounter;        //Food Income Text Counter
    //--------------------


    //UPDATE
    void Update () {

        FoodIncome = 3 * FarmCount;         //Food Income from Farms

        TopBarFoodTextCounter.GetComponent<Text>().text = "" + FoodCount;               //Update Top Bar Food Text Counter to the Current Count
        FarmTextCounter.GetComponent<Text>().text = "" + FarmCount;                     //Update Farm Text Counter to the Current Count 
        IncomeTextCounter.GetComponent<Text>().text = "" + FoodIncome + " Food / Min";  //Update Food Income Text Counter to the Current Count
	}
    //--------------------


}
