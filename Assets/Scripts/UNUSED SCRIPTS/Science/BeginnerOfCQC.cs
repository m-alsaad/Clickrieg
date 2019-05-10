using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BeginnerOfCQC : MonoBehaviour
{

    public Sprite Icon;
    private string Name = "Beginner of CQC";
    private string Quote = "Blah Blah Blah.";
    private int ScienceCost = 50;
    private int GoldCost = 20;
    private int TimeCost = 20;
    private int ID = 003;
    public double x;
    public double y;

    public ResearchDisplay DisplayButton;

    public GameObject self;
    public GameObject ResearchText;
    public GameObject ResearchIcon;
    public GameObject NameText;
    public GameObject QuoteText;
    public GameObject ScienceText;
    public GameObject GoldText;
    public GameObject TimeText;
    public GameObject Button;

    public static List<int> Dependents = new List<int>();




    // Start is called before the first frame update
    void Start()
    {
        x = self.transform.localPosition.x;
        y = self.transform.localPosition.y;

        Dependents.Add(001);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClick()
    {
        ResearchDisplay.ID = ID;
        ResearchButton.ScienceCost = ScienceCost;
        ResearchButton.GoldCost = GoldCost;
        Research.tempID = ID;

        DisplayButton.ButtonClick();
        




        ResearchIcon.GetComponent<Image>().sprite = Icon;
        NameText.GetComponent<Text>().text = Name;
        QuoteText.GetComponent<Text>().text = "\"" + Quote + "\"";

        if (Research.ResearchActive == false && Research.Completed.Contains(ID) == false)
        {
            Research.TimeCost = TimeCost;
            Research.ID = ID;
            Research.x = x;
            Research.y = y;

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
