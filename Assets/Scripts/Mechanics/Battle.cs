using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Battle : MonoBehaviour {

    public static int CurrentBattle = 1;
    public static int CurrentProgress = 0;
    public static int MaxStage = 1;
    public static string BattleType = "";
    public static int BattleRound = 0;

    public bool Active = false;
    public bool PlayerTurn = true;
    public bool Victory = false;

    public double PlayerFinalStealth;
    public double PlayerHP = Player.PlayerTotalHP;
    public double PlayerMaxHP = Player.PlayerTotalHP;
    public double EnemyHP = Enemy.EnemyTotalHP;
    public double EnemyMaxHP = Enemy.EnemyTotalHP;
    public double Distance = 0;
    public double RunPanalty;
    public double PlayerFinalAttack = 0;
    public double EnemyFinalSpeed = 0;

    public GameObject CurrentBattleNumber;
    public GameObject CurrentBattleProgress;







    void Update () {

        CurrentBattleNumber.GetComponent<Text>().text = "" + CurrentBattle;
        CurrentBattleProgress.GetComponent<Text>().text = "" + CurrentProgress + " | 10";

        if (CurrentBattle == 1)
        {
            BattleType = "Flee";
        }
		
	}





    public void ButtonClick()
    {
        
        Active = true;

        Debug.Log("Player Stealth: " + Player.TotalStealth + " VS. Enemy Alert: " + Enemy.TotalAlert);

        if (Player.TotalStealth > Enemy.TotalAlert)
        {
            Debug.Log("Player Start First");
            PlayerTurn = true;
        }
        else
        {
            Debug.Log("Enemy Start First");
            PlayerTurn = false;
        }

        CommenceBattle(CurrentBattle);
    }





    public void CommenceBattle(int BattleNumber)
    {
        Distance = 0;
        BattleRound = 0;
        RunPanalty = 0;
        EnemyHP = Enemy.EnemyTotalHP;
        EnemyMaxHP = Enemy.EnemyTotalHP;

        Debug.Log("Battle Started!");

        while(Active == true)
        {
            BattleRound += 1;
            Debug.Log("Round " + BattleRound + "!");

            if (PlayerTurn == true)
            {
                Debug.Log("Player's Turn");
                if (Distance > 0)
                {
                    Debug.Log("Enemy is " + Distance + " Units away!");
                    Distance -= Player.PlayerTotalSpeed;
                }

                if (Distance <= 0 && BattleRound > 1)
                {
                    RunPanalty = Distance + Player.PlayerTotalSpeed;
                    Debug.Log("RunPanalty is " + RunPanalty);
                    Distance = 0;
                }

                if (Distance == 0)
                {

                    PlayerFinalAttack = Player.PlayerTotalAttack - (Player.PlayerTotalAttack*(RunPanalty / Player.PlayerTotalSpeed));
                    Debug.Log("Player has dealt " + PlayerFinalAttack + " unit of Attack to Enemy who had " + EnemyHP + " units of Health");
                    EnemyHP -= PlayerFinalAttack;
                    EnemyHP = Math.Round(EnemyHP, 2);
                    RunPanalty = 0;

                    Debug.Log("Enemy Health is " + Math.Round(EnemyHP, 2));
                    if (EnemyHP <= 0)
                    {
                        Debug.Log("You are Victorious!");
                        Victory = true;
                        Active = false;
                        break;
                    }
                }
                PlayerTurn = false;
            }

            else if (PlayerTurn == false)
            {
                Debug.Log("Enemy's Turn");
                if (BattleType == "Flee")
                {
                    Debug.Log("Enemy is trying to flee!");
                    Debug.Log(EnemyHP);
                    Debug.Log(EnemyMaxHP);
                    EnemyFinalSpeed = Enemy.EnemyTotalSpeed * (EnemyHP / EnemyMaxHP);
                    Distance += EnemyFinalSpeed;
                    Debug.Log("Enemy has ran " + EnemyFinalSpeed + " units of Distance and now stands away with a distance of " + Distance + " units away");
                    
                    if (Distance >= Player.PlayerTotalSpeed * 3 || BattleRound == 10)
                    {
                        Debug.Log("Enemy Has Fled!");
                        Debug.Log("DEFEAT!");
                        Victory = false;
                        Active = false;
                        break;
                    }
                }
                PlayerTurn = true;
            }
        }

        if (Victory == true)
        {
            GlobalScience.ScienceCount += 1;
            GlobalFood.FoodCount += 1;

            if (CurrentProgress < 10)
            {
                CurrentProgress += 1;
            }
        }

        Debug.Log("Battle Ended!");




    }
}
