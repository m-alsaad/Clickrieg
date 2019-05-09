using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductionUnit : MonoBehaviour
{
    public string Name;
    public int SteelCost;
    public int AluminiumCost;
    public int GoldCost;

    public int ScienceCost;
    public double TimeCost;
    private double TimeRemaining;

    private int count;

    private bool ResearchActive;

    public GameObject ProductName;
    public GameObject CostInSteel;
    public GameObject CostInAluminium;
    public GameObject CostInGold;
    public GameObject CostInScience;
    public GameObject CostInTime;
    public GameObject ResearchButton;
    public GameObject BuildButton;

    public Image ProductImage;
    public Image TimeCircle;
    public Animator ResearchAnimation;

    
    


    // Start is called before the first frame update
    void Start()
    {
        ProductName.GetComponent<Text>().text = "" + Name;
        CostInSteel.GetComponent<Text>().text = "" + SteelCost;
        CostInAluminium.GetComponent<Text>().text = "" + AluminiumCost;
        CostInGold.GetComponent<Text>().text = "" + GoldCost;
        CostInScience.GetComponent<Text>().text = "" + ScienceCost;
        CostInTime.GetComponent<Text>().text = "" + TimeCost + "s";

        TimeRemaining = TimeCost;

        ResearchActive = false;

        BuildButton.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartResearch()
    {
        ResearchAnimation.SetBool("ResearchActive", true);
        ResearchButton.SetActive(false);
        ResearchActive = true;
        StartCoroutine(Researching());
    }


    IEnumerator Researching()
    {
        while(ResearchActive == true)
        {
            yield return new WaitForSeconds(1);

            TimeRemaining -= 1;
            CostInTime.GetComponent<Text>().text = "" + TimeRemaining + "s";
            TimeCircle.fillAmount = (float)(TimeRemaining/TimeCost);

            if(TimeRemaining <= 0)
            {
                //ResearchAnimation.SetBool("ResearchActive", false);
                ResearchAnimation.SetBool("ResearchComplete", true);
                ProductImage.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                CostInScience.SetActive(false);
                BuildButton.GetComponent<Button>().interactable = true;
                ResearchActive = false;
            }
        }
        

    }
}
