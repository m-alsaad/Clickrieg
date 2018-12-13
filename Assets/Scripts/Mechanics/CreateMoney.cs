using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMoney : MonoBehaviour {

    public GameObject textBox;

    public void ButtonClick()
    {
        if(GlobalFood.FoodCount - 5 >= 0)
        {
            GlobalMoney.MoneyCount += 1;
            GlobalFood.FoodCount -= 5;
        }

    }
}
