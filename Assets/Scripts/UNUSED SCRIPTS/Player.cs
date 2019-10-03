using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour {


    // Battle


    /*------
      PLAYER ---------------------------------------------
     * -----*/
    
    // ATTACK
    public static double PlayerTotalAttack = 0;
    public static double PlayerEquipmentsAttack = 0;

    //HIT-POINTS
    public static double PlayerTotalHP = 0;
    public static double PlayerEquipmentsHP = 0;

    //SPEED
    public static double PlayerTotalSpeed = 0;
    public static double PlayerEquipmentsSpeed = 0;

    //RANGE
    public static double PlayerTotalRange = 0;
    public static double PlayerEquipmentsRange = 0;

    //STEALTH
    public static double TotalStealth = 0;
    public static double EquipmentsStealth = 0;



    // Update is called once per frame
    void Update()
    {
        PlayerTotalAttack = (GlobalSoldiers.SoldierCount * Soldier.UnitAttack) + PlayerEquipmentsAttack;
        PlayerTotalHP = (GlobalSoldiers.SoldierCount * Soldier.UnitHitPoint) + PlayerEquipmentsHP;
        PlayerTotalSpeed = (Soldier.UnitSpeed);
        PlayerTotalRange = (Soldier.UnitRange);
        TotalStealth = (Soldier.UnitStealth);
    }

}
