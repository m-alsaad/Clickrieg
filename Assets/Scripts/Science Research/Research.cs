/**************************************************
 * SCRIPT FOR THE MECHANICS BEHIND RESEARCHING
 * 
 * HERE LIES THE MECHANICS OF HOW RESEARCHING WORKS
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class Research : MonoBehaviour
{

    //VARIABLES
    //---------
    public static int TimeCost;             //Total Time Cost of Research Material
    public static int TimeRemaining;        //How much time remains on current active research
    public static bool ResearchActive;      //Is there an Active Research? (True/False)
    public static int ID;                   //ID of Corrent Open Research
    public static int tempID;               //Temp Variables for the ID (This helps make research panal display correct information)
    public static double x;                 //X Location
    public static double y;                 //Y Location

    //LISTS
    public static List<int> RelayList;                      //The Relay Researches this one has
    public static List<int> DependentList;                  //What this Research depends on
    public static List<GameObject> PathList;                //The Paths connected to this Research

    public static List<int> Completed = new List<int>();    //List of Completed Reseachs (Takes in their ID (int))

    private bool Countdown;
    private bool Unlock;            //Checks if a research can be unlocked.

    //ARRAY that holds all the Research Material Game Objects from Unity's Hierachy.
    private GameObject[] Objs;

    //Game Objects
    public GameObject Button;
    public GameObject Display;
    public GameObject Background;
    public GameObject ResearchText;
    public GameObject FlashingIcon;
    public GameObject Unlockable;
    public GameObject ResearchOverlay;


    //Rewards from completed the Research
    public static int CompleteClickPower;
    public static int CompleteSteelReward;
    public static GameObject RewardUnlock;
    public GameObject RewardSteelObject;




    // Start is called before the first frame update
    void Start()
    {
        //Sets Variables
        ResearchActive = false;
        Countdown = false;
        ID = 000;
        tempID = 000;
        Unlock = false;

        //Sets Flashing Icon's Color
        FlashingIcon.GetComponent<Image>().color = new Color32(255, 255, 225, (byte)0);


        /********************************************************************
         * Gets in all the Research Material Game Objects from Unity's Hierchy.
         * But they need to be active/displayed to be able to collect them,
         * thus, it's automatically activated here, grab the objects into the
         * array, and deactivated them. Fast enough to not even be visible
         ********************************************************************/
        Background.SetActive(true);
        Objs = GameObject.FindGameObjectsWithTag("ResearchMaterial");
        Background.SetActive(false);

        ResearchOverlay.SetActive(true);
        ScienceMaterial.ResearchText = GameObject.Find("Overlays/Research Detail Display/Researching Text");
        ScienceMaterial.ResearchIcon = GameObject.Find("Overlays/Research Detail Display/Research Detail Icon");
        ScienceMaterial.NameText = GameObject.Find("Overlays/Research Detail Display/Research Title");
        ScienceMaterial.QuoteText = GameObject.Find("Overlays/Research Detail Display/Research Quote");
        ScienceMaterial.ScienceText = GameObject.Find("Overlays/Research Detail Display/Research Science Cost");
        ScienceMaterial.GoldText = GameObject.Find("Overlays/Research Detail Display/Research Gold Cost");
        ScienceMaterial.TimeText = GameObject.Find("Overlays/Research Detail Display/Research Time Cost");
        ScienceMaterial.ResearchEffects = GameObject.Find("Overlays/Research Detail Display/Research Effects");
        ScienceMaterial.Button = GameObject.Find("Overlays/Research Detail Display/Research Button");
        ResearchOverlay.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        //This updates the researching progress such as time and flashing icon
        if (ResearchActive == true)
        {
            Button.SetActive(false);
            FlashingIcon.transform.localPosition = new Vector3((int)x, (int)y, 0f);

            if (Countdown == false)
            {
                TimeRemaining = TimeCost;
                Countdown = true;
                Unlock = false;
                StartCoroutine(Researching());
                ResetFlash();
            }
        }

    }

    //Time Method of updating the Research Panel while Researching
    IEnumerator Researching()
    {
        //Updates the Timer within the Research Panel
        for (int i = 0; i < TimeCost; i++)
        {
            if (Display.activeSelf && tempID == ID)
            {
                ResearchText.GetComponent<Text>().text = "RESEARCHING\n" + TimeRemaining;
            }

            yield return new WaitForSeconds(1f);    //Update every second
            TimeRemaining -= 1;
        }

        //Once Research Completes, goes through here
        Countdown = false;
        ResearchActive = false;
        if (Display.activeSelf && tempID == ID)
        {
            ResearchText.GetComponent<Text>().text = "RESEARCHING\nCOMPLETE!";
        }

        if (tempID != ID)
        {
            Button.SetActive(true);
            
        }

        ResetFlash();
        ResearchComplete();

    }

    //Method to start the Time Method for flashing icon and set everything in motion
    public void ResetFlash()
    {
        if (ResearchActive == true)
        {
            StartCoroutine(Flashing());
        }
        else
        {
            FlashingIcon.GetComponent<Image>().color = new Color32(255, 255, 225, (byte)0);
        }
    }

    //Flashing Icon Time Method
    IEnumerator Flashing()
    {
        //Fade In
        for (int i = 100; i < 200; i += 5)
        {
            FlashingIcon.GetComponent<Image>().color = new Color32(255, 255, 225, (byte)i);
            yield return new WaitForSeconds(0.025f);
            if (ResearchActive == false)
            {
                break;
            }
        }

        //Fade Out
        for (int i = 200; i > 100; i -= 5)
        {
            FlashingIcon.GetComponent<Image>().color = new Color32(255, 255, 225, (byte)i);
            yield return new WaitForSeconds(0.025f);
            if (ResearchActive == false)
            {
                break;
            }
        }

        //Repeat
        ResetFlash();

    }


    //Research COMPLETEM Method
    public void ResearchComplete()
    {
        ID = ResearchButton.ID;
        Completed.Add(ID); //Adds current ID into the Complete list
        ResearchButton.ID = 000;

        //For Loop Starts going through the list or Relay Research
        for (int i = 0; i < RelayList.Count; i++)
        {
            //For Loop going through the Research Materials Game Objects
            for (int k = 0; k < Objs.Length; k++)
            {
                Debug.Log("Looking for " + ID);
                //Check if they have the same ID (Relay of Research Material 1 == Dependent of Research Material 2)
                if (RelayList[i] == Objs[k].GetComponent<ScienceMaterial>().ID)
                {
                    Unlockable = Objs[k];
                    DependentList = Unlockable.GetComponent<ScienceMaterial>().Dependents; //Get the list of what this Research Material Depends on

                    for (int j = 0; j < DependentList.Count; j++)
                    {
                        //Checks the Completed List if it's Dependents are inside
                        if (Completed.Contains(DependentList[j]))
                        {
                            Unlock = true;
                        }
                        else
                        {
                            Unlock = false;
                        }
                    }

                    //Unlocks the new Research
                    if (Unlock == true)
                    {
                        Unlockable.GetComponent<Button>().interactable = true;
                    }
                    else //Break Out and don't continue
                    {
                        break;
                    }

                }
            }

        }

        //Turn Paths to Green
        for (int i = 0; i < PathList.Count; i++)
        {
            PathList[i].GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        }

        //Adds Reward
        Click.clickPower += CompleteClickPower;
        RewardSteelObject.GetComponent<Resource>().Add(CompleteSteelReward);
        
        if (RewardUnlock != null)
        {
            RewardUnlock.SetActive(true);
        }

    }

}
