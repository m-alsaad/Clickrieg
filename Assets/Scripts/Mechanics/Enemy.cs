using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour {

    /*------
      ENEMY ---------------------------------------------
     * -----*/

    public string EnemyName;

    //ATTACK
    public static double EnemyTotalAttack = 0;
    public double EnemyEquipmentsAttack = 0;

    //HIT-POINTS
    public static double EnemyTotalHP = 0;
    public double EnemyEquipmentsHP = 0;

    //EVADE
    public static double EnemyTotalEvade = 0;
    public double EnemyEquipmentEvade = 0;

    //SPEED
    public static double EnemyTotalSpeed = 0;
    public double EnemyEquipmentsSpeed = 0;

    //RANGE
    public static double EnemyTotalRange = 0;
    public double EnemyEquipmentsRange = 0;

    //ALERT
    public static double TotalAlert = 0;
    public double EquipmentAlert = 0;




    // Update is called once per frame
    void Update () {
 
        if (Battle.CurrentBattle < 10)
        {
            EnemyName = Rabbit.UnitName;
            EnemyTotalAttack = Rabbit.UnitAttack * Battle.CurrentBattle;
            EnemyTotalHP = Rabbit.UnitHitPoint * Battle.CurrentBattle;
            EnemyTotalEvade = Rabbit.UnitEvade;
            EnemyTotalSpeed = Rabbit.UnitSpeed;
            EnemyTotalRange = Rabbit.UnitRange;
            TotalAlert = Rabbit.UnitAlert;
        }

        

    }
}
