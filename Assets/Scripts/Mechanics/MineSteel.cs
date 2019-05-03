using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSteel : MonoBehaviour {

    public void ButtonClick()
    {
        if(GlobalMoney.MoneyCount - 2 >= 0)
        {
            GlobalMoney.MoneyCount -= 2;
            
        }
    }
}
