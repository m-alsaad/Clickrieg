/**************************************************
 * GLOBAL PASSIVE BATTLE SCRIPT
 * 
 * TRACK AND WORK EVERYTHING PASSIVE BATTLE RELATED
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


//MAIN
public class Battle : MonoBehaviour {

    //VARIABLES
    public static int CurrentBattle = 1;            //# of Stage
    public static int CurrentProgress = 1;          //# of times a Stage is Cleared out of 10
    public static int MaxStage = 1;                 //# of Highest Stage Reached

    public string EnemyName;                        //Current Enemy's Name
    private double EnemyHP;                         //Enemy's Current HP
    private double EnemyMaxHP;                      //Enemy's Max HP
    public int clickPower = Click.clickPower;       //Power of Player's Current Click

    public double PercentageHP = 100;               //The Percentage of Current HP
    public double BarLength = 280;                  //Constant Scale of HP Bar
    private double RemainingBarLength = 0;          //Scale of Black Bar

    

    public GameObject CurrentBattleNumber;          //# of Stage Text Counter
    public GameObject CurrentBattleProgress;        //# of times a Stage is Cleared Text Counter
    public GameObject EnemyNameText;                //Current Enemy's Name Text Object
    public GameObject EnemyPicture;                 //The Object for the Enemy's Picture
    public GameObject HealthBar;                    //It's Actually the Dark Bar
    public GameObject ClickButton;                  //The Clickable area of the Enemy
    public GameObject HealthBarText;



    //UPDATE
    void Update ()
    {
        CurrentBattleNumber.GetComponent<Text>().text = "" + CurrentBattle;                 //Updates the number of the Stage that is being played
        EnemyNameText.GetComponent<Text>().text = EnemyName;                                //Update the Current Enemy's Name Text
        HealthBarText.GetComponent<Text>().text = "" + EnemyHP;

        if(CurrentBattle == MaxStage)
        {
            CurrentBattleProgress.GetComponent<Text>().text = "" + CurrentProgress + " | 10";   //Updated the number of times a Stage is cleared out of 10
            CurrentBattleProgress.GetComponent<Text>().fontSize = 20;
        }
        else
        {
            CurrentBattleProgress.GetComponent<Text>().text = "COMPLETE!";
            CurrentBattleProgress.GetComponent<Text>().fontSize = 15;
        }
    }

    private void Start()
    {
        StartCoroutine(EnemyReset());
    }


    //CLICKING THE ENEMY FUNCTION
    public void ButtonClick()
    {
        
        StartCoroutine(ShakeEnemyImage());      //Shake the Enemy when Clicked
        HealthBar.transform.localScale += new Vector3((int)RemainingBarLength, 0f, 0f);     //Return Black Bar to 0 in the begining of each click
        EnemyHP -= Click.clickPower;                  //Updates new Enemy HP based on Click Power

        

        PercentageHP = (EnemyHP * 100) / EnemyMaxHP;    //The new Precentage of Enemy's HP
        
        //If Enemy is Dead
        if (EnemyHP <= 0)
        {
            GlobalMoney.MoneyCount += 1 * CurrentBattle;        //Earn Gold
            GlobalScience.ScienceCount += 1 * CurrentBattle; ;  //Earn Science
           //GlobalSteel.steel.Add(1);
                

            //Turn the HP bar completely Black. This makes sure the Black Bar doesn't overlap the HP bar
            HealthBar.transform.localScale -= new Vector3((int)RemainingBarLength + ((int)BarLength - (int)RemainingBarLength), 0f, 0f);
            StartCoroutine(EnemyDefeated());    //Enemy Defeated Effect and Delay Function

            //Updates the number of times a stage is cleared variable counter
            if (CurrentProgress < 10 && CurrentBattle == MaxStage)
            {
                CurrentProgress += 1;
            }
            else if (CurrentProgress == 10 && CurrentBattle == MaxStage)
            {
                MaxStage += 1;
                CurrentProgress = 0;
            }
        }
        else //Enemy did not die
        {
            
            RemainingBarLength = BarLength - BarLength * (PercentageHP / 100);  //Calculate the length of the Black Bar based on the Enemy's percentage HP
            HealthBar.transform.localScale -= new Vector3((int)RemainingBarLength, 0f, 0f); //Adds in the Black Bar on top of the HP bar
        }
    }


    //Shaking the Enemy Function
    IEnumerator ShakeEnemyImage()
    {
        //Center point of the Enemy's Picture relative to the world's coordinates and not relative to it's container
        int x = (int)EnemyPicture.transform.localPosition.x;
        int y = (int)EnemyPicture.transform.localPosition.y; ;

        //Number of Shakes is i
        for (int i = 0; i < 4; i++)
        {
            //Shake to the Right
            EnemyPicture.transform.localPosition = new Vector3(x + 10, y, transform.position.z);
            yield return new WaitForSeconds(0.03f); //Wait 0.03 S

            //Shake to the Left
            EnemyPicture.transform.localPosition = new Vector3(x - 10, y, transform.position.z);
            yield return new WaitForSeconds(0.03f); //Wait 0.03S
        }
        
        EnemyPicture.transform.localPosition = new Vector3(x, y, transform.position.z);  //Return picture to the center
    }


    //Enemy Defeated Effects and Delay Function
    IEnumerator EnemyDefeated()
    {
        
        ClickButton.GetComponent<Button>().interactable = false;    //Disable Clicking on the Enemy

        //Fade Out the Enemy's picture
        for (int i = 100; i > 0; i-=5)
        {
            EnemyPicture.GetComponent<Image>().color = new Color32(255, 255, 225, (byte)i);
            yield return new WaitForSeconds(0.01f);
        }
        
        yield return new WaitForSeconds(.3f);   //The Delay before Enemy respawn and Clicking is Enabled again
        HealthBar.transform.localScale += new Vector3(280f, 0f, 0f);    //Refill HP bar
        EnemyPicture.GetComponent<Image>().color = new Color32(255, 255, 225, 255); //Bring Picture back from Fade Out 
        ClickButton.GetComponent<Button>().interactable = true; //Re-Enable Clicking on the Enemy
        RemainingBarLength = 0; //Reset Variable
        StartCoroutine(EnemyReset());
    }

    IEnumerator EnemyReset()
    {
        yield return new WaitForSeconds(0.01f);
        EnemyName = Enemy.EnemyName;     
        EnemyHP = Enemy.EnemyHP;         
        EnemyMaxHP = Enemy.EnemyHP;
    }


    //Next Battle Click
    public void RightClick()
    {
        if(CurrentBattle < MaxStage)
        {
            Battle.CurrentBattle += 1;
            HealthBar.transform.localScale += new Vector3((int)RemainingBarLength, 0f, 0f);
            RemainingBarLength = 0;
            StartCoroutine(EnemyReset());
        }
        
    }

    //Previous Battle Click
    public void LeftClick()
    {
        if(Battle.CurrentBattle > 1)
        {
            Battle.CurrentBattle -= 1;
            StartCoroutine(EnemyReset());
        }      
    }









    ////////////////////////////////////////////////////////////////////////////////////////////


    //public void ButtonClick()
    //{

    //    Active = true;

    //    Debug.Log("Player Stealth: " + Player.TotalStealth + " VS. Enemy Alert: " + Enemy.TotalAlert);

    //    if (Player.TotalStealth > Enemy.TotalAlert)
    //    {
    //        Debug.Log("Player Start First");
    //        PlayerTurn = true;
    //    }
    //    else
    //    {
    //        Debug.Log("Enemy Start First");
    //        PlayerTurn = false;
    //    }

    //    CommenceBattle(CurrentBattle);
    //}





    //public void CommenceBattle(int BattleNumber)
    //{
    //    Distance = 0;
    //    BattleRound = 0;
    //    RunPanalty = 0;
    //    EnemyHP = Enemy.EnemyTotalHP;
    //    EnemyMaxHP = Enemy.EnemyTotalHP;

    //    Debug.Log("Battle Started!");

    //    while(Active == true)
    //    {
    //        BattleRound += 1;
    //        Debug.Log("Round " + BattleRound + "!");

    //        if (PlayerTurn == true)
    //        {
    //            Debug.Log("Player's Turn");
    //            if (Distance > 0)
    //            {
    //                Debug.Log("Enemy is " + Distance + " Units away!");
    //                Distance -= Player.PlayerTotalSpeed;
    //            }

    //            if (Distance <= 0 && BattleRound > 1)
    //            {
    //                RunPanalty = Distance + Player.PlayerTotalSpeed;
    //                Debug.Log("RunPanalty is " + RunPanalty);
    //                Distance = 0;
    //            }

    //            if (Distance == 0)
    //            {

    //                PlayerFinalAttack = Player.PlayerTotalAttack - (Player.PlayerTotalAttack*(RunPanalty / Player.PlayerTotalSpeed));
    //                Debug.Log("Player has dealt " + PlayerFinalAttack + " unit of Attack to Enemy who had " + EnemyHP + " units of Health");
    //                EnemyHP -= PlayerFinalAttack;
    //                EnemyHP = Math.Round(EnemyHP, 2);
    //                RunPanalty = 0;

    //                Debug.Log("Enemy Health is " + Math.Round(EnemyHP, 2));
    //                if (EnemyHP <= 0)
    //                {
    //                    Debug.Log("You are Victorious!");
    //                    Victory = true;
    //                    Active = false;
    //                    break;
    //                }
    //            }
    //            PlayerTurn = false;
    //        }

    //        else if (PlayerTurn == false)
    //        {
    //            Debug.Log("Enemy's Turn");
    //            if (BattleType == "Flee")
    //            {
    //                Debug.Log("Enemy is trying to flee!");
    //                Debug.Log(EnemyHP);
    //                Debug.Log(EnemyMaxHP);
    //                EnemyFinalSpeed = Enemy.EnemyTotalSpeed * (EnemyHP / EnemyMaxHP);
    //                Distance += EnemyFinalSpeed;
    //                Debug.Log("Enemy has ran " + EnemyFinalSpeed + " units of Distance and now stands away with a distance of " + Distance + " units away");

    //                if (Distance >= Player.PlayerTotalSpeed * 3 || BattleRound == 10)
    //                {
    //                    Debug.Log("Enemy Has Fled!");
    //                    Debug.Log("DEFEAT!");
    //                    Victory = false;
    //                    Active = false;
    //                    break;
    //                }
    //            }
    //            PlayerTurn = true;
    //        }
    //    }

    //    if (Victory == true)
    //    {
    //        GlobalScience.ScienceCount += 1;
    //        GlobalFood.FoodCount += 1;

    //        if (CurrentProgress < 10)
    //        {
    //            CurrentProgress += 1;
    //        }
    //    }

    //    Debug.Log("Battle Ended!");




    //}
}
