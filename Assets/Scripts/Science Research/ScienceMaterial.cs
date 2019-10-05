/**************************************************
 * SCRIPT FOR SCIENCE RESEARCH MATERIALS
 * 
 * EACH RESEARCH MATERIAL WILL FOLLOW EVERYTHING
 *                  IN THIS SCRIPT
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


//MAIN
public class ScienceMaterial : MonoBehaviour
{

    //VARIABLES
    //---------
    public string Name;         //The Name of the Science Material
    public string Quote;        //The Quote within the Science material
    public int ScienceCost;     //The Cost in Science
    public int GoldCost;        //The Cost in Gold
    public int TimeCost;        //The Cost in Time
    public int ID;              //The ID of the Science Material. Each has a unique ID

    //Coordinates of the Game Object
    private double x;           
    private double y;

    //Rewards
    public int RewardClickPower;
    public int RewardDPSPower;
    public int RewardSteel;
    public GameObject RewardSteelObject;
    public GameObject RewardUnlock;
    

    //Text Area of Rewards
    [TextArea]
    public string Effects;


    //The Background of the Research Tree
    public ResearchDisplay DisplayButton;

    //GameObjects variables
    public static GameObject ResearchText;        //Research Text within the small Research Window
    public static GameObject ResearchIcon;        //Research Icon within the samll Research Window
    public static GameObject NameText;             //Research Name within the small Research Window
    public static GameObject QuoteText;            //Research Quote within the samll Research Window
    public static GameObject ScienceText;          //Research Science Cost within the small Research Window
    public static GameObject GoldText;             //Research Gold Cost within the small Research Window
    public static GameObject TimeText;             //Research Time Cost within the small Research Window
    public static GameObject ResearchEffects;       //Resaearching Effects Text Box within the samll Research Window
    public static GameObject Button;               //The Research Button the starts the Research Itself.
    

    //List of 5 Researchs that this depends on. They take the Research ID (int)
    public  List<int> Dependents = new List<int>();
        public int Dependent1;
        public int Dependent2;
        public int Dependent3;
        public int Dependent4;
        public int Dependent5;

    //List of 5 Researchs that this relays to (helps progress unlock to)
    public static List<int> Relays = new List<int>();
        public int Relay1;
        public int Relay2;
        public int Relay3;
        public int Relay4;
        public int Relay5;

    //List of 5 Paths that this connects to.
    public static List<GameObject> Paths = new List<GameObject>();
        public GameObject Path1;
        public GameObject Path2;
        public GameObject Path3;
        public GameObject Path4;
        public GameObject Path5;



    // Start is called before the first frame update
    void Start()
    {

        //Get self position
        x = this.transform.localPosition.x;
        y = this.transform.localPosition.y;


        //Adding the Dependents into the Dependents List
        if (Dependent1 != 000)
        {
            Dependents.Add(Dependent1);
        }
        if (Dependent2 != 000)
        {
            Dependents.Add(Dependent2);
        }
        if (Dependent3 != 000)
        {
            Dependents.Add(Dependent3);
        }
        if (Dependent4 != 000)
        {
            Dependents.Add(Dependent4);
        }
        if (Dependent5 != 000)
        {
            Dependents.Add(Dependent5);
        }

        //Adding Relays into the Relays List
        if (Relay1 != 000)
        {
            
            Relays.Add(Relay1);
        }
        if (Relay2 != 000)
        {
            Relays.Add(Relay2);
        }
        if (Relay3 != 000)
        {
            Relays.Add(Relay3);
        }
        if (Relay4 != 000)
        {
            Relays.Add(Relay4);
        }
        if (Relay5 != 000)
        {
            Relays.Add(Relay5);
        }



    }

    // Update is called once per frame
    void Update()
    {

    }

    //This opens up the research panel (small window)
    public void ButtonClick()
    {
        //Moves variables to other classes
        ResearchButton.ScienceCost = ScienceCost;
        ResearchButton.GoldCost = GoldCost;
        Research.tempID = ID;
        ResearchDisplay.ID = ID;

        DisplayButton.ButtonClick();

        //Update The Research Window Overlay
        ResearchIcon.GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;
        NameText.GetComponent<Text>().text = Name;
        QuoteText.GetComponent<Text>().text = "\"" + Quote + "\"";
        ResearchEffects.GetComponent<Text>().text = "" + Effects;

        //Sends the Research Material Info to the Research Button class where it'll be sent to Research if it is Researched
        ResearchButton.TimeCost = TimeCost;
        ResearchButton.ID = ID;
        ResearchButton.x = x;
        ResearchButton.y = y;
        ResearchButton.ClickReward = RewardClickPower;
        ResearchButton.DPSReward = RewardDPSPower;
        ResearchButton.SteelReward = RewardSteel;
        ResearchButton.RelayList = Relays;
        
        ResearchButton.RewardUnlock = RewardUnlock;
        
        //Adding the Paths into the Paths List
        if (Path1 != null)
        {
            Paths.Add(Path1);
        }
        if (Path2 != null)
        {
            Paths.Add(Path2);
        }
        if (Path3 != null)
        {
            Paths.Add(Path3);
        }
        if (Path4 != null)
        {
            Paths.Add(Path4);
        }
        if (Path5 != null)
        {
            Paths.Add(Path5);
        }

        //Sending the Paths to the Research Button class Path list
        ResearchButton.PathsConnected = Paths;



        CheckDisplay();




    }

    public void CheckDisplay()
    {


        //Conditions on how the information is displayed depending on specific Conditions
        if (Research.ResearchActive == false && Research.Completed.Contains(ID) == false)
        {
            

            ScienceText.GetComponent<Text>().text = "Sience: " + ScienceCost;
            GoldText.GetComponent<Text>().text = "Gold: " + GoldCost;
            TimeText.GetComponent<Text>().text = "Time: " + TimeCost;
            ResearchText.GetComponent<Text>().text = "";
            Button.SetActive(true);
        }
        else if (Research.ResearchActive == false && Research.Completed.Contains(ID) == true)
        {
            ScienceText.GetComponent<Text>().text = "";
            GoldText.GetComponent<Text>().text = "";
            TimeText.GetComponent<Text>().text = "";
            ResearchText.GetComponent<Text>().text = "RESEARCH\nCOMPLETE!";
            Button.SetActive(false);
        }
        else if (Research.ResearchActive == true && Research.Completed.Contains(ID) == true)
        {
            ScienceText.GetComponent<Text>().text = "";
            GoldText.GetComponent<Text>().text = "";
            TimeText.GetComponent<Text>().text = "";
            ResearchText.GetComponent<Text>().text = "RESEARCH\nCOMPLETE!";
            Button.SetActive(false);
        }
        else if (Research.ResearchActive == true && Research.Completed.Contains(ID) == false && Research.ID != ID)
        {


            ScienceText.GetComponent<Text>().text = "Sience: " + ScienceCost;
            GoldText.GetComponent<Text>().text = "Gold: " + GoldCost;
            TimeText.GetComponent<Text>().text = "Time: " + TimeCost;
            ResearchText.GetComponent<Text>().text = "";
        }
        else if (Research.ResearchActive == true && Research.Completed.Contains(ID) == false && Research.ID == ID)
        {
            ScienceText.GetComponent<Text>().text = "";
            GoldText.GetComponent<Text>().text = "";
            TimeText.GetComponent<Text>().text = "";
            ResearchText.GetComponent<Text>().text = "RESEARCHING\n" + Research.TimeRemaining;
        }
        else
        {
            ScienceText.GetComponent<Text>().text = "";
            GoldText.GetComponent<Text>().text = "";
            TimeText.GetComponent<Text>().text = "";
            ResearchText.GetComponent<Text>().text = "";
        }
    }


}
