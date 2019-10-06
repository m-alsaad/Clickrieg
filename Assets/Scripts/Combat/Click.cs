/**************************************************
 * GLOBAL PLAYER DAMAGE SCRIPT
 * 
 * SCRIPT NAME SHOULD BE PLAYER DAMAGE INSTEAD OF CLICK
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//MAIN
public class Click : MonoBehaviour
{
    //VARIABLES
    public static int clickPower;
    public static double clickPowerPercentage;
    public static int DPS;

    //Starting Power
    private void Start()
    {
        clickPower = 10;
        DPS = 0;
        clickPowerPercentage = 0.0;
    }

    //Add Click Power
    public void addClickPower(int num)
    {
        clickPower += num;
    }
    public int getClickPower()
    {
        return clickPower;
    }

    //Add DPS
    public void addDPS(int num)
    {
        DPS += num;
    }
    public int getDPS()
    {
        return DPS;
    }
}
