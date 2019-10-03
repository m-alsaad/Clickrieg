using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour {

    /*------
      ENEMY ---------------------------------------------
     * -----*/

    public static string EnemyName;
    public static double EnemyHP;
    public static int EnemyArmor;
    public static int EnemyAir;
    public static int EnemyNavy;
    public static int EnemyBuilding;
    public GameObject EnemyImageObject;




    // Update is called once per frame
    void Update () {
 
        if (Battle.CurrentBattle < 11)
        {
            
            EnemyImageObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Enemies/Bandit");

            EnemyName = Bandit.Name;
            EnemyHP = Bandit.HP * Battle.CurrentBattle;
        }
        else if (Battle.CurrentBattle < 21)
        {
            EnemyImageObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Enemies/BanditSquad");

            EnemyName = Bandit.Name + "Squad";
            EnemyHP = Bandit.HP * Battle.CurrentBattle * 5;
        }

        

    }
}
