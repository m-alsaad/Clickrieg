using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BasicsOfCQC : MonoBehaviour
{

    public Sprite Icon;
    public string Name = "BASICS OF CQC";
    public string Quote = "Remember some of the basics of CQC";
    public int ScienceCost = 10;
    public int GoldCost = 0;
    public int TimeCost = 1;
    public int ID = 001;
    public double x;
    public double y;

    public BackgroundDisplay DisplayButton;

    public GameObject self;
    public GameObject ResearchText;
    public GameObject ResearchIcon;
    public GameObject NameText;
    public GameObject QuoteText;
    public GameObject ScienceText;
    public GameObject GoldText;
    public GameObject TimeText;
    public GameObject Button;

    public List<int> Dependents = new List<int>();

    public GameObject Path1;
    public GameObject Path2;
    public GameObject Path3;
    public GameObject Path4;
    public GameObject Path5;
    public static List<GameObject> Paths = new List<GameObject>();




    // Start is called before the first frame update
    void Start()
    {
        x = self.transform.localPosition.x;
        y = self.transform.localPosition.y;

        Paths.Add(Path1);
        Paths.Add(Path2);
        Paths.Add(Path3);
        Paths.Add(Path4);
        Paths.Add(Path5);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        ResearchButton.ID = ID;
        ResearchButton.ScienceCost = ScienceCost;
        ResearchButton.GoldCost = GoldCost;
        Research.tempID = ID;
        BackgroundDisplay.ID = ID;

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
