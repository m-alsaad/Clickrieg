using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalMoney : MonoBehaviour {

    public static int MoneyCount = 100;
    public static int GoldIncome;
    public static int Expenses;
    public static int BankCount = 0;
    public static int Meals;
    public static int Employees;

    public GameObject TextObject;
    public GameObject TextObject2;
    public GameObject TextObject3;
    public GameObject TextObject4;
    public GameObject TextObject5;

    public bool reset = true;





    void Update()
    {
        GoldIncome = 2 * BankCount;
        Meals = 3 * BankCount;
        Employees = 3 * BankCount;

        TextObject.GetComponent<Text>().text = "" + MoneyCount;
        TextObject2.GetComponent<Text>().text = "" + BankCount;
        TextObject3.GetComponent<Text>().text = "" + GoldIncome + " Gold / Min";
        TextObject4.GetComponent<Text>().text = "" + Meals + " Food / Min";
        TextObject5.GetComponent<Text>().text = "" + Employees + " Manpower";

        if (reset == true)
        {
            StartCoroutine(GoldIncomeMethod());
            reset = false;
        }
    }

    IEnumerator GoldIncomeMethod()
    {
        yield return new WaitForSeconds(1);

        MoneyCount += GoldIncome;
        MoneyCount -= Expenses;
        reset = true;
    }
    
}
