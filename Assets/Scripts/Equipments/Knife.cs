using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Knife : MonoBehaviour {

    
    public static int Attack = 4;

    public string Name = "Knife";
    public int SteelCost = 1;
    public int AluminiumCost = 0;
    public int GoldCost = 0;

    public int Clicks = 1;
    public int Clicked = 0;

    public static int Count = 0;
    public static int Used = 0;

    public bool StartResearch = false;
    public bool Researched = false;
    public int ResearchNeeded = 50;
    public int ResearchCount = 0;
    public bool Equiped = false;

    bool reset = true;
    

    public GameObject EquipmentName;
    public GameObject CostInSteel;
    public GameObject CostInAluminium;
    public GameObject CostInGold;
    public GameObject NumberOfClicks;
    public GameObject NumberOfKnives;
    public GameObject ResearchProgress;
    public GameObject ResearchButton;
    public GameObject CreateButton;
    public GameObject EquipButton;

    public Image KnifeImage;

    public Animator anim;

    public Sprite Add;
    public Sprite Remove;





    // Update is called once per frame
    void Update () {

        EquipmentName.GetComponent<Text>().text = "" + name;
        CostInSteel.GetComponent<Text>().text = "" + SteelCost;
        CostInAluminium.GetComponent<Text>().text = "" + AluminiumCost;
        CostInGold.GetComponent<Text>().text = "" + GoldCost;
        NumberOfClicks.GetComponent<Text>().text = "" + Clicked + " | " + Clicks;
        NumberOfKnives.GetComponent<Text>().text = "" + Count;
        ResearchProgress.GetComponent<Text>().text = "" + ResearchCount + " | " + ResearchNeeded;

        if (Researched == false)
        {
            CreateButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            CreateButton.GetComponent<Button>().interactable = true;
            ResearchProgress.SetActive(false);
            NumberOfClicks.SetActive(true);
            NumberOfKnives.SetActive(true);
            EquipButton.SetActive(true);

        }

        if (StartResearch == true && Researched == false)
        {
            if(reset == true)
            {
                Debug.Log("Start Researching Knife");
                StartCoroutine(Researching());
                reset = false;
            }
        }

        if(Equiped == true)
        {
            if(Count > 0 && Used < GlobalSoldiers.SoldierCount)
            {
                Player.PlayerEquipmentsAttack += Attack;
                Used += 1;
                Count -= 1;
            }
        }
        else
        {
            if(Used > 0)
            {
                Player.PlayerEquipmentsAttack -= Attack;
                Used -= 1;
                Count += 1;
            }
        }


    }

    public void CreateKnife()
    {
        if (GlobalSteel.SteelCount > 0)
        {
            GlobalSteel.SteelCount -= 1;
            Count += 1;
        }

    }

    public void Research()
    {
        StartResearch = true;
        anim.SetBool("ResearchActive", true);
        ResearchButton.SetActive(false);
        

    }

    IEnumerator Researching()
    {
        yield return new WaitForSeconds(1);
        Debug.Log(ResearchCount);
        if (GlobalScience.TrueScience > 0)
        {
            GlobalScience.ScienceCount -= 1;
            ResearchCount += 1;
            
        }

        if (ResearchCount >= ResearchNeeded)
        {
            Researched = true;
            anim.SetBool("ResearchComplete", true);
            KnifeImage.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            StopCoroutine(Researching());
        }

        
        reset = true;
    }   

    public void Equip()
    {
        if (Equiped == false)
        {
            EquipButton.GetComponent<Image>().sprite = Remove;
            Equiped = true;
            
        }
        else
        {
            EquipButton.GetComponent<Image>().sprite = Add;
            Equiped = false;
  
        }
    }
}
