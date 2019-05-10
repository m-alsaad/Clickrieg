/**************************************************
 * SCRIPT FOR THE MECHANICS BEHIND CONSTRUCTION
 * 
 * HERE LIES THE MECHANICS OF HOW CONSTRUCTION HAPPENS
 **************************************************/

 //IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class Building : MonoBehaviour
{

    //VARIABLES
    public static int InLine;                   //How many buildings to be constructed
    public static double TimeCost;              //How long it takes to construct
    public static double TimeRemaining;         //How long left
    private bool BuildingActive;                //Is there construction active?

    public ConstructionUnit ConstructionUnit;   //Script from Construction Units

    public GameObject InLineText;               //Text for InLine
    public GameObject TimeRemainingText;        //Text for Time Remining
    public GameObject Excivating;               //Object of the process of Excivating

    public Image TimeCircleGreener;             //The Time Image



    // Start is called before the first frame update
    void Start()
    {
        BuildingActive = false;
    }


    //Function to Start Building
    public void StartBuilding()
    {

        //Update that we have new construction In Line
        InLineText.GetComponent<Text>().text = "" + InLine;


        //Goes here if this is the first In Line Construction
        if (BuildingActive == false)
        {
            //Update some Variables
            BuildingActive = true;
            TimeRemaining = TimeCost;
            TimeRemainingText.GetComponent<Text>().text = TimeRemaining + "s";
            TimeCircleGreener.fillAmount = 0;


            //Start the Timer of Construction
            StartCoroutine(BuildingProcess());
        }

        
    }

    IEnumerator BuildingProcess()
    {
        while (BuildingActive == true)
        {
            yield return new WaitForSeconds(1);

            //Update Time
            TimeRemaining -= 1;
            TimeRemainingText.GetComponent<Text>().text = TimeRemaining + "s";
            TimeCircleGreener.fillAmount = (float)(1 - (float)(TimeRemaining / TimeCost));

            //Once Construction is complete
            if (TimeRemaining == 0)
            {

                InLine -= 1;    //One Construction Done
                InLineText.GetComponent<Text>().text = "" + InLine;

                ConstructionUnit.AddCount(1);   //Add Count to ConstructionUnit **MAY CHANGE WHEN MORE CONSTRUCTION UNITS ARE BUILT!**
                
                //Update Excivator Units
                Excivating.GetComponent<Excivating>().AddExcivator();

                //If no more construction in line
                if (InLine == 0)
                {
                    //End Construction
                    BuildingActive = false;
                }
                //Reset The Proccess
                else
                {
                    TimeRemaining = TimeCost;
                    TimeRemainingText.GetComponent<Text>().text = TimeRemaining + "s";
                    TimeCircleGreener.fillAmount = 0;

                }

            }
        }

    }
}
