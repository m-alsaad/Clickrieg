using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductionUnit : MonoBehaviour
{
    public string Name;
    public int Count;
    public int SteelCost;
    public int AluminiumCost;
    public int GoldCost;

    private float x;
    private float y;

    public int ScienceCost;
    public double TimeCost;
    private double TimeRemaining;

    private bool ResearchActive;

    public GameObject ProductName;
    public GameObject CostInSteel;
    public GameObject CostInAluminium;
    public GameObject CostInGold;
    public GameObject CostInScience;
    public GameObject CostInTime;
    public GameObject ResearchButton;
    public GameObject BuildButton;
    public GameObject CountText;

    public Image ProductImage;
    public Animator ResearchAnimation;

    public GameObject Steel;
    public GameObject Aluminium;
    public GameObject Gold;
    public GameObject Science;

    
    


    // Start is called before the first frame update
    void Start()
    {
        ProductName.GetComponent<Text>().text = "" + Name;
        CostInSteel.GetComponent<Text>().text = "" + SteelCost;
        CostInAluminium.GetComponent<Text>().text = "" + AluminiumCost;
        CostInGold.GetComponent<Text>().text = "" + GoldCost;
        CostInScience.GetComponent<Text>().text = "" + ScienceCost;
        CostInTime.GetComponent<Text>().text = "" + TimeCost + "s";
        CountText.GetComponent<Text>().text = "" + Count;

        TimeRemaining = TimeCost;

        ResearchActive = false;

        BuildButton.GetComponent<Button>().interactable = false;

        x = CostInTime.transform.position.x;
        y = CostInTime.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartResearch()
    {
        if(Science.GetComponent<Resource>().GetCount() >= ScienceCost)
        {
            Science.GetComponent<Resource>().Subtract(ScienceCost);
            CostInScience.SetActive(false);
            CostInTime.GetComponent<RectTransform>().position = new Vector3(x-5, y, 0);
            ResearchAnimation.SetBool("ResearchActive", true);
            ResearchButton.SetActive(false);
            ResearchActive = true;
            StartCoroutine(Researching());
        }
        
    }


    IEnumerator Researching()
    {
        while(ResearchActive == true)
        {
            yield return new WaitForSeconds(1);

            TimeRemaining -= 1;
            CostInTime.GetComponent<Text>().text = "" + TimeRemaining + "s";


            if(TimeRemaining <= 0)
            {
                CostInTime.SetActive(false);
                CountText.SetActive(true);
                ResearchAnimation.SetBool("ResearchComplete", true);
                ProductImage.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                CostInScience.SetActive(false);
                BuildButton.GetComponent<Button>().interactable = true;
                ResearchActive = false;
            }
        }
        

    }

    public void Produce()
    {
        if((Steel.GetComponent<Resource>().GetCount() >= SteelCost) &&
           (Aluminium.GetComponent<Resource>().GetCount() >= AluminiumCost) &&
           (Gold.GetComponent<Resource>().GetCount() >= GoldCost))
        {
            Steel.GetComponent<Resource>().Subtract(SteelCost);
            Aluminium.GetComponent<Resource>().Subtract(AluminiumCost);
            Gold.GetComponent<Resource>().Subtract(GoldCost);

            GoldCost = (int)(GoldCost * 1.8);
            CostInGold.GetComponent<Text>().text = "" + GoldCost;

            Count += 1;
            CountText.GetComponent<Text>().text = "" + Count;

            Click.clickPower += 10;
        }
    }


}
