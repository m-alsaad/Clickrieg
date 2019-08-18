using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchButton : MonoBehaviour
{
    public static int ScienceCost;
    public static int GoldCost;
    public static int TimeCost;
    public static int ID;

    public static int ClickReward;
    public static int SteelReward;

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
        if(Science.GetComponent<Resource>().GetCount() >= ScienceCost && Gold.GetComponent<Resource>().GetCount() >= GoldCost)
        {
            Science.GetComponent<Resource>().Subtract(ScienceCost);
            Gold.GetComponent<Resource>().Subtract(GoldCost);

            ScienceText.GetComponent<Text>().text = "";
            GoldText.GetComponent<Text>().text = "";
            TimeText.GetComponent<Text>().text = "";
            ID = Research.ID;
            ClickReward = Research.CompleteClickPower;
            SteelReward = Research.CompleteSteelReward;
            Research.ResearchActive = true;
            

        }
    }

}
