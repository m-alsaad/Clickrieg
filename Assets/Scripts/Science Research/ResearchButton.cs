using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchButton : MonoBehaviour
{

    //Research Material Information to pass on when Research is activated
    public static int ScienceCost;
    public static int GoldCost;
    public static int TimeCost;
    public static int ID;
    public static double x;
    public static double y;
    public static int ClickReward;
    public static double ClickPercentageReward;
    public static double ProductDPSPercentageReward;
    public static int DPSReward;
    public static int SteelReward;

    public static List<int> RelayList;                      //The Relay Researches this one has
    public static List<int> DependentList;                  //What this Research depends on
    public static List<GameObject> PathsConnected;          //The Paths connected to this Research

    public static GameObject RewardUnlock;
    public static GameObject RewardProduct;


    public GameObject Science;
    public GameObject Gold;

    public GameObject ScienceText;
    public GameObject GoldText;
    public GameObject TimeText;
    public GameObject ResearchText;



    // Start is called before the first frame update
    void Start()
    {
        ID = 000;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClick()
    {
        //Checks if player has enough Science and Gold
        if(Science.GetComponent<Resource>().GetCount() >= ScienceCost && Gold.GetComponent<Resource>().GetCount() >= GoldCost)
        {

            //Subtract Science and Gold
            Science.GetComponent<Resource>().Subtract(ScienceCost);
            Gold.GetComponent<Resource>().Subtract(GoldCost);

            //Removes text from Science Material Display
            ScienceText.GetComponent<Text>().text = "";
            GoldText.GetComponent<Text>().text = "";
            TimeText.GetComponent<Text>().text = "";

            

            //Sends the information of what is being Researched to the main Research Class
            Research.TimeCost = TimeCost;
            Research.ID = ID;
            Research.x = x;
            Research.y = y;
            Research.CompleteClickPower = ClickReward;
            Research.CompleteClickPowerPercentage = ClickPercentageReward;
            Research.CompleteProductDPSPercentage = ProductDPSPercentageReward;
            Research.CompleteDPSPower = DPSReward;
            Research.CompleteSteelReward = SteelReward;
            Research.RelayList = RelayList;
            Research.RewardUnlock = RewardUnlock;
            Research.Product = RewardProduct;
            Research.ResearchPathsConnected = PathsConnected;
            Research.ResearchActive = true;





        }
    }


}
