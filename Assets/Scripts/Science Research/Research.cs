using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Research : MonoBehaviour
{
    public static int TimeCost;
    public static int TimeRemaining;
    public static bool ResearchActive;
    public static int ID;
    public static int tempID;
    public static double x;
    public static double y;
    private bool Countdown;
    private bool Unlock;
    public static List<int> Completed = new List<int>();

    public GameObject Button;
    public GameObject Display;
    public GameObject Background;
    public GameObject ResearchText;
    public GameObject FlashingIcon;
    public GameObject Unlockable;


    // Start is called before the first frame update
    void Start()
    {
        ResearchActive = false;
        Countdown = false;
        ID = 000;
        tempID = 000;
        Unlock = false;
        FlashingIcon.GetComponent<Image>().color = new Color32(255, 255, 225, (byte)0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ResearchActive == true)
        {
            Button.SetActive(false);
            FlashingIcon.transform.localPosition = new Vector3((int)x, (int)y, 0f);

            if (Countdown == false)
            {
                TimeRemaining = TimeCost;
                Countdown = true;
                Unlock = false;
                StartCoroutine(Researching());
                ResetFlash();
            } 
        }
        else
        {
            //Button.SetActive(true);
        }
        
    }

    IEnumerator Researching()
    {
        for (int i = 0; i < TimeCost; i++)
        {
            if (Display.activeSelf && tempID == ID)
            {
                ResearchText.GetComponent<Text>().text = "RESEARCHING\n" + TimeRemaining;
            }
            
            yield return new WaitForSeconds(1f);
            TimeRemaining -= 1;
        }

        Countdown = false;
        ResearchActive = false;
        if (Display.activeSelf && tempID == ID)
        {
            ResearchText.GetComponent<Text>().text = "RESEARCHING\nCOMPLETE!";
        }

        if (tempID != ID)
        {
            Button.SetActive(true);
        }

        ResetFlash();
        ResearchComplete();

    }

    public void ResetFlash()
    {
        if(ResearchActive == true)
        {
            StartCoroutine(Flashing());
        }
        else
        {
            FlashingIcon.GetComponent<Image>().color = new Color32(255, 255, 225, (byte)0);
        }
    }

    IEnumerator Flashing()
    {
        for (int i = 100; i < 200; i += 5)
        {
            FlashingIcon.GetComponent<Image>().color = new Color32(255, 255, 225, (byte)i);
            yield return new WaitForSeconds(0.025f);
            if(ResearchActive == false)
            {
                break;
            }
        }

        for (int i = 200; i > 100; i -= 5)
        {
            FlashingIcon.GetComponent<Image>().color = new Color32(255, 255, 225, (byte)i);
            yield return new WaitForSeconds(0.025f);
            if (ResearchActive == false)
            {
                break;
            }
        }

        ResetFlash();

    }

    public void ResearchComplete()
    {
        if (ID == 001)
        {
            Debug.Log("10 Was added to Click Power!");
            Click.clickPower += 10; 
            Completed.Add(ID);
            Debug.Log(BasicsOfCQC.Paths.Count);
            for (int i = 0; i < BasicsOfCQC.Paths.Count; i++)
            {
                BasicsOfCQC.Paths[i].GetComponent<Image>().color = new Color32(0, 255, 0, 255);
            }

            for (int i = 0; i < Recruitment.Dependents.Count; i++)
            {
                if (Completed.Contains(Recruitment.Dependents[i]))
                {
                    Unlock = true;
                }
                else
                {
                    Unlock = false;
                }
            }

            if (Unlock == true)
            {
                if(Background.activeSelf == false)
                {
                    Background.SetActive(true);
                    Unlockable = GameObject.Find("Recruitment");
                    Unlockable.GetComponent<Button>().interactable = true;

                    Unlockable = GameObject.Find("Beginner of CQC");
                    Unlockable.GetComponent<Button>().interactable = true;
                    Background.SetActive(false);
                }
                else
                {
                    Unlockable = GameObject.Find("Recruitment");
                    Unlockable.GetComponent<Button>().interactable = true;

                    Unlockable = GameObject.Find("Beginner of CQC");
                    Unlockable.GetComponent<Button>().interactable = true;
                }
            }
        }
        else if (ID == 002)
        {
            Debug.Log("50 Was added to Click Power!");
            Click.clickPower += 50;
            Completed.Add(ID);
        }
        else if (ID == 003)
        {
            Debug.Log("20 Was added to Click Power!");
            Click.clickPower += 20;
            Completed.Add(ID);
        }
        else
        {
            Debug.Log("NO ID MATCHED!");
        }
    }

}
