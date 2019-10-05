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

    int x;                                          //Enemy's Picture X coordinate
    int y;                                          //Enemy's Picture Y coordinate

    private string EnemyName;                       //Current Enemy's Name
    private double EnemyHP;                         //Enemy's Current HP
    private double EnemyMaxHP;                      //Enemy's Max HP
    private int clickPower;                         //Power of Player's Current Click
    private int DPSPower;                           //Power of Player's Current Damage per Second
    private bool DPSActive;
    private bool EnemyAlive;
    

    public GameObject CurrentBattleNumber;          //# of Stage Text Counter
    public GameObject CurrentBattleProgress;        //# of times a Stage is Cleared Text Counter
    public GameObject EnemyNameText;                //Current Enemy's Name Text Object
    public GameObject EnemyPicture;                 //The Object for the Enemy's Picture
    public GameObject ClickButton;                  //The Clickable area of the Enemy
    public GameObject Gold;                         //Gold Object from the Hierarchy
    public GameObject Science;                      //Science Object from the Hierarchy
    public GameObject HealthBarText;                //The Text of Enemy's HP
    public GameObject AutoProgressToggle;           //The Checkbox of AutoProgress
    public Image HealthBarImage;                    //The Red HP Bar Image



    //UPDATE
    void Update ()
    {
        CurrentBattleNumber.GetComponent<Text>().text = "" + CurrentBattle;                 //Updates the number of the Stage that is being played
        EnemyNameText.GetComponent<Text>().text = EnemyName;                                //Update the Current Enemy's Name Text

        //Update Enemy's HP text and make sure it doesn't show negative numbers
        if (EnemyHP >= 0)
        {
            HealthBarText.GetComponent<Text>().text = "" + Math.Round(EnemyHP,0);
        }
        else
        {
            HealthBarText.GetComponent<Text>().text = "0";
        }
        
        //Update the text of Battle number and Stage number
        if(CurrentBattle == MaxStage) //If stage is not completed yet
        {
            CurrentBattleProgress.GetComponent<Text>().text = "" + CurrentProgress + " | 10";   //Updated the number of times a Stage is cleared out of 10
            CurrentBattleProgress.GetComponent<Text>().fontSize = 20;
        }
        else //If stage is completed
        {
            CurrentBattleProgress.GetComponent<Text>().text = "COMPLETE!";
            CurrentBattleProgress.GetComponent<Text>().fontSize = 15;
        }
    }

    private void Start()
    {
        DPSActive = true;
        EnemyAlive = true;
        StartCoroutine(EnemyReset());
        StartCoroutine(DPSAttack());

        //Starting Player's power
        clickPower = Click.clickPower;
        DPSPower = Click.DPS;

        //Center point of the Enemy's Picture relative to the world's coordinates and not relative to it's container
        x = (int)EnemyPicture.transform.localPosition.x;
        y = (int)EnemyPicture.transform.localPosition.y;
    }


    //CLICKING THE ENEMY FUNCTION
    public void ButtonClick()
    {

        StartCoroutine(ShakeEnemyImage());      //Shake the Enemy when Clicked

        clickPower = Click.clickPower;

        EnemyHP -= clickPower;                  //Updates new Enemy HP based on Click Power

        

        
        
        //If Enemy is Dead
        if (EnemyHP <= 0)
        {
            StartCoroutine(EnemyDefeated());    //Enemy Defeated Effect and Delay Function

        }
        else //Enemy did not die
        {
            //Remaining Health Bar
            HealthBarImage.fillAmount = (float)(EnemyHP/EnemyMaxHP);       
        }
    }


    //Shaking the Enemy Function
    IEnumerator ShakeEnemyImage()
    {
        

        //Number of Shakes is i
        for (int i = 0; i < 4; i++)
        {
            //Shake to the Right
            EnemyPicture.transform.localPosition = new Vector3(x + 10, y, transform.position.z);
            yield return new WaitForSeconds(0.03f); //Wait 0.03S

            //Shake to the Left
            EnemyPicture.transform.localPosition = new Vector3(x - 10, y, transform.position.z);
            yield return new WaitForSeconds(0.03f); //Wait 0.03S
        }
        
        EnemyPicture.transform.localPosition = new Vector3(x, y, transform.position.z);  //Return picture to the center
    }


    //Enemy Defeated Effects and Delay Function
    IEnumerator EnemyDefeated()
    {
        if(EnemyAlive == true)
        {
            EnemyAlive = false;
            HealthBarImage.fillAmount = (float)(0);     //Empty's the Health Bar
            Gold.GetComponent<Resource>().Add((int)(1.5 * CurrentBattle));     //Earn Gold
            Science.GetComponent<Resource>().Add(1 * CurrentBattle);  //Earn Science

            ClickButton.GetComponent<Button>().interactable = false;    //Disable Clicking on the Enemy

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

            //Fade Out the Enemy's picture
            for (int i = 100; i > 0; i -= 5)
            {
                EnemyPicture.GetComponent<Image>().color = new Color32(255, 255, 225, (byte)i);
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(.3f);   //The Delay before Enemy respawn and Clicking is Enabled again

            HealthBarImage.fillAmount = (float)(1);     //Returning Health Bar to Full
            EnemyPicture.GetComponent<Image>().color = new Color32(255, 255, 225, 255); //Bring Picture back from Fade Out 
            StartCoroutine(EnemyReset());
            yield return new WaitForSeconds(0.01f);     //Makes sures enemy is brought back with full HP before Click is enabled
            ClickButton.GetComponent<Button>().interactable = true; //Re-Enable Clicking on the Enemy

            //If Auto Progress is On, go to next Stage automatically (GOOD FOR IDLE PLAY!)
            if(AutoProgressToggle.GetComponent<Toggle>().isOn == true && CurrentProgress <= 10 && CurrentBattle < MaxStage)
            {
                RightClick();
            }
        }

    }

    IEnumerator EnemyReset()
    {
        
        yield return new WaitForSeconds(0.01f);
        EnemyName = Enemy.EnemyName;     
        EnemyHP = Enemy.EnemyHP;         
        EnemyMaxHP = Enemy.EnemyHP;
        EnemyAlive = true;
    }


    //Next Battle Click
    public void RightClick()
    {
        if(CurrentBattle < MaxStage)
        {
            Battle.CurrentBattle += 1;
            HealthBarImage.fillAmount = (float)(1);
            StartCoroutine(EnemyReset());
        }
        
    }

    //Previous Battle Click
    public void LeftClick()
    {
        if(Battle.CurrentBattle > 1)
        {
            Battle.CurrentBattle -= 1;
            HealthBarImage.fillAmount = (float)(1);
            StartCoroutine(EnemyReset());
        }      
    }

    IEnumerator DPSAttack()
    {
        while(DPSActive == true)
        {
            yield return new WaitForSeconds(0.016f);
            DPSPower = Click.DPS;
            EnemyHP -= (double)(0.016 * DPSPower);

            //If Enemy is Dead
            if (EnemyHP <= 0)
            {
                
                StartCoroutine(EnemyDefeated());    //Enemy Defeated Effect and Delay Function

            }
            else //Enemy did not die
            {
                //Remaining Health Bar
                HealthBarImage.fillAmount = (float)(EnemyHP / EnemyMaxHP);
            }
        }


    }
        

}
