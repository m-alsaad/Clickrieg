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
        if(GlobalScience.ScienceCount >= ScienceCost && GlobalMoney.MoneyCount >= GoldCost)
        {
            GlobalScience.ScienceCount -= ScienceCost;
            GlobalMoney.MoneyCount -= GoldCost;

            ScienceText.GetComponent<Text>().text = "";
            GoldText.GetComponent<Text>().text = "";
            TimeText.GetComponent<Text>().text = "";

            Research.ResearchActive = true;
            

        }
    }

}
