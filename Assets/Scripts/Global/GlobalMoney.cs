/**************************************************
 * GLOBAL GOLD SCRIPT
 * 
 * TRACK AND WORK EVERYTHING GOLD RELATED
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class GlobalMoney : MonoBehaviour {

    //VARIABLES
    public static int MoneyCount = 100;       //Number of Available Gold

    public GameObject TextObject;           //Top Bar Gold Text Counter



    //UNEEDED AT THE MOMENT!
    public static int GoldIncome;
    public static int Expenses;
    public static int BankCount = 0;
    public static int Meals;
    public static int Employees;
    public GameObject TextObject2;
    public GameObject TextObject3;
    public GameObject TextObject4;
    public GameObject TextObject5;
    public bool reset = true;




    //UPDATE
    void Update()
    {
        TextObject.GetComponent<Text>().text = "" + MoneyCount;     //Update Top Bar Gold Text Counter to the Current Count


        //UNEEDED AT THE MOMENT!
        GoldIncome = 2 * BankCount;
        Meals = 3 * BankCount;
        Employees = 3 * BankCount;
        TextObject2.GetComponent<Text>().text = "" + BankCount;
        TextObject3.GetComponent<Text>().text = "" + GoldIncome + " Gold / Min";
        TextObject4.GetComponent<Text>().text = "" + Meals + " Food / Min";
        TextObject5.GetComponent<Text>().text = "" + Employees + " Manpower";
        //UNEEDED AT THE MOMENT!
        if (reset == true)
        {
            StartCoroutine(GoldIncomeMethod());
            reset = false;
        }
    }
    //UNEEDED AT THE MOMENT!
    IEnumerator GoldIncomeMethod()
    {
        yield return new WaitForSeconds(1);



        MoneyCount += GoldIncome;
        MoneyCount -= Expenses;
        reset = true;
    }
    
}
