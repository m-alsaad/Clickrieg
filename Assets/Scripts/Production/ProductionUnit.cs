﻿/**************************************************
 * Production Unit Class
 * 
 * This is the Script for all Production Units
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//MAIN
public class ProductionUnit : MonoBehaviour
{
    //VARIABLES
    public string Name;             //Name of Product
    public int Count;               //Number of how many we have
    public int SteelCost;           //Cost of Steel to produce 1 click
    public int AluminiumCost;       //Cost of Aluminium to produce 1 click
    public int GoldCost;            //Cost of Gold to produce 1 click
    public int Clicks;              //How many clicks to build
    public double Multiplier;       //Multipier how much the cost increases per built unit
    private int ClicksInProgress;   //Clicks in Progress to Build a unit

    public int ClickDamage;         //How much Click Damage this Unit adds
    public int DPS;                 //How much DPS this Unit adds

    private float x;                //X position of Time Text Object
    private float y;                //Y postion of Time Text Object

    public int ScienceCost;         //Cost of Science to Research Unit
    public double TimeCost;         //How long the Research the Unit
    private double TimeRemaining;   //How much time left to Research the Unit

    private bool ResearchActive;    //Check if Research is happening

    public GameObject ProductName;          //Name of Unit
    public GameObject CostInSteel;          //Text of Steel Cost
    public GameObject CostInAluminium;      //Text of Aluminium Cost
    public GameObject CostInGold;           //Text of Gold Cost
    public GameObject CostInScience;        //Text of Science Cost
    public GameObject CostInTime;           //Text of Time Cost
    public GameObject ResearchButton;       //The Button that starts the Research
    public GameObject BuildButton;          //This button is the entire image. Each click adds 1 click to build
    public GameObject CountText;            //Text of how many we have of this unit
    public GameObject ClicksTitle;          //Displays where the clicks are
    public GameObject ClicksText;           //Text of how many clicks are required to build
    public GameObject ClicksInProgressText; //Text of how many clicks in progress

    public Image ProductImage;              //Image of the Unit
    public Animator ResearchAnimation;      //Animation of Researching

    public GameObject Steel;                //Steel Object that contains the script that keeps track of this resource
    public GameObject Aluminium;            //Aluminium Object that contains the script that keeps track of this resource
    public GameObject Gold;                 //Gold Object that contains the script that keeps track of this resource
    public GameObject Science;              //Sience Object that contains the script that keeps track of this resource





    // Start is called before the first frame update
    void Start()
    {
        ClicksInProgress = 0;

        ProductName.GetComponent<Text>().text = "" + Name;
        CostInSteel.GetComponent<Text>().text = "" + SteelCost;
        CostInAluminium.GetComponent<Text>().text = "" + AluminiumCost;
        CostInGold.GetComponent<Text>().text = "" + GoldCost;
        CostInScience.GetComponent<Text>().text = "" + ScienceCost;
        CostInTime.GetComponent<Text>().text = "" + TimeCost + "s";
        CountText.GetComponent<Text>().text = "" + Count;
        ClicksTitle.GetComponent<Text>().text = "Clicks\n" + Clicks;
        ClicksText.GetComponent<Text>().text = "" + Clicks;
        ClicksInProgressText.GetComponent<Text>().text = "" + ClicksInProgress;
        

        TimeRemaining = TimeCost;

        ResearchActive = false;

        BuildButton.GetComponent<Button>().interactable = false;

        x = CostInTime.transform.localPosition.x;
        y = CostInTime.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    //Button of Research
    public void StartResearch()
    {
        //Checks if we have enough Science to research
        if(Science.GetComponent<Resource>().GetCount() >= ScienceCost)
        {
            Science.GetComponent<Resource>().Subtract(ScienceCost);                             //Subtract the cost of Science from Science Resource Script
            CostInScience.SetActive(false);                                                     //Removes the Text that shows how much Science is required to research
            CostInTime.GetComponent<RectTransform>().localPosition = new Vector3(x-17, y, 0);   //Moves the Cost in Time to center the container
            ResearchAnimation.SetBool("ResearchActive", true);                                  //Begin Research Animation
            ResearchButton.SetActive(false);                                                    //Disable the Research Button
            ResearchActive = true;                                                              //Set Research is active to True
            StartCoroutine(Researching());                                                      //Starts IEnumerator of Research the Unit
        }
        
    }


    //Unit Research Enumerator
    IEnumerator Researching()
    {
        //Research is still active
        while(ResearchActive == true)
        {
            yield return new WaitForSeconds(1);     //Update every 1 second

            TimeRemaining -= 1;                                                 //Reduce time remaining by 1
            CostInTime.GetComponent<Text>().text = "" + TimeRemaining + "s";    //Update the Text of Time to reflect on time remaining

            //Research is complete
            if(TimeRemaining <= 0)
            {
                ClicksTitle.GetComponent<Text>().text = "Clicks\n|";                            //Updates Click Text to Have a seperator
                ClicksText.SetActive(true);                                                     //Display the Click Requirement text
                ClicksInProgressText.SetActive(true);                                           //Display the Clicks in Progress text
                CostInTime.SetActive(false);                                                    //Removes Time text
                CountText.SetActive(true);                                                      //Display the counter of how many we built
                ResearchAnimation.SetBool("ResearchComplete", true);                            //End Research Animation and turn image to final resualt
                ProductImage.GetComponent<Image>().color = new Color32(255, 255, 255, 255);     //Turn Unit Image to colors
                //CostInScience.SetActive(false);                                                 
                BuildButton.GetComponent<Button>().interactable = true;                         //Enable clicking on image to start producing
                ResearchActive = false;                                                         //Research has ended
            }
        }
        

    }


    //Click of Producing
    public void Produce()
    {
        //Checks if we have enough Stee, Aluminium and Gold
        if((Steel.GetComponent<Resource>().GetCount() >= SteelCost) &&
           (Aluminium.GetComponent<Resource>().GetCount() >= AluminiumCost) &&
           (Gold.GetComponent<Resource>().GetCount() >= GoldCost))
        {

            //Subtract the used resources from their scripts
            Steel.GetComponent<Resource>().Subtract(SteelCost);
            Aluminium.GetComponent<Resource>().Subtract(AluminiumCost);
            Gold.GetComponent<Resource>().Subtract(GoldCost);

            //Adds Clicks in Progress and Updates the Text
            ClicksInProgress += 1;
            ClicksInProgressText.GetComponent<Text>().text = "" + ClicksInProgress;

            //Once we reach the required Text
            if(ClicksInProgress >= Clicks)
            {
                //Update the new cost of Gold
                GoldCost = (int)(GoldCost * Multiplier);                
                CostInGold.GetComponent<Text>().text = "" + GoldCost;

                //Add to count
                Count += 1;
                CountText.GetComponent<Text>().text = "" + Count;

                //Reset the Clicks in Progress
                ClicksInProgress = 0;
                ClicksInProgressText.GetComponent<Text>().text = "" + ClicksInProgress;

                //Adds damage reward
                Click.clickPower += ClickDamage;
                Click.DPS += DPS;
            }

        }
    }

}
