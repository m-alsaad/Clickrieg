/**************************************************
 * SCRIPT FOR EACH CONSTRUCTION UNIT
 * 
 * HERE LIES THE MECHANICS STARTING MECHANICS ON BUILDING
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//MAIN
public class ConstructionMilitaryFactory : MonoBehaviour
{
    //Variables
    public string Title;            //Title of Building Unit
    public Image Icon;              //Icon of Building Unit
    public int count;               //Count of the Building Unit
    public int GoldCost;            //Current Cost of new Building Unit
    public double TimeCost;         //How long it takes to construct Building Unit
    public double TimeRemaining;    //How long left to finish contruction **MAY NOT NEED THIS HERE**

    public GameObject TitleText;    //Title Text for this Building Unit Layout
    public GameObject IconObject;   //Icon for this Building Unit Layout
    public GameObject CountText;    //Count Text for this Building Unit Layout
    public GameObject InLineText;   //In Line Text for this Building Unit Layout
    public GameObject GoldCostText; //Gold Cost Text for this Building Unit Layout
    public GameObject TimeCostText; //Time Cost Text for this Building Unit Layout

    public GameObject Gold;         //Gold Script

    public GameObject Construction; //Building Script (Where the next building process happens)



    // Start is called before the first frame update
    void Start()
    {
        //Initiate and set everything in place.
        TitleText.GetComponent<Text>().text = "" + Title;
        CountText.GetComponent<Text>().text = "" + count;
        InLineText.GetComponent<Text>().text = "0";
        GoldCostText.GetComponent<Text>().text = GoldCost + " Gold";
        TimeCostText.GetComponent<Text>().text = TimeCost + "s";

        BuildingMilitaryFactory.TimeCost = TimeCost;
        BuildingMilitaryFactory.TimeRemaining = TimeRemaining;
    }

    //Building Button
    public void BuildButtonClick()
    {   
        //Checks if we have enough gold to begin construction
        if(Gold.GetComponent<Resource>().GetCount() >= GoldCost)
        {
            //Update Gold
            Gold.GetComponent<Resource>().Subtract(GoldCost);
            GoldCost = (int)(GoldCost * 1.25);
            GoldCostText.GetComponent<Text>().text = GoldCost + " Gold";

            //Add InLine
            BuildingMilitaryFactory.InLine += 1;

            //Call StartBuilding Script
            Construction.GetComponent<BuildingMilitaryFactory>().StartBuilding();

            
        }
    }

    //Script to add Count and update Text
    public void AddCount(int num)
    {
        count += num;
        CountText.GetComponent<Text>().text = "" + count;
    }

 
}
