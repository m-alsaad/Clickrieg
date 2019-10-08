/**************************************************
 * SCRIPT FOR EXCIVATING
 * 
 * HERE LIES THE MECHANICS OF EXCAVATING
 **************************************************/

 //IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//MAIN
public class Excivating : MonoBehaviour
{

    //VARIABLES
    public int count;               //How many Excavators we got
    public int time;                //How Long Excivating Takes
    private bool ExcavatingActive;   //To set an infinite while loop

    public GameObject Resource;     //Script to Update the extracted Resource from this Script
    public GameObject Text;         //Count Text for number of Excavators we have built       

    // Start is called before the first frame update
    void Start()
    {
        //Set Startup stuff
        ExcavatingActive = false;
        Text.GetComponent<Text>().text = count + " / " + time + "s";
    }

    //Adding an Excivator function
    public void AddExcivator()
    {
        //If it's the first one just got added, start the infinite excivation process
        if(count == 0)
        {
            ExcavatingActive = true;
            StartCoroutine(Excavating());
        }
        //Increase Excivator Variable and Update Text
        count += 1;
        Text.GetComponent<Text>().text = count + " / " + time + "s";
    }

    //Infinite Excivator Timer
    IEnumerator Excavating()
    {
        while (ExcavatingActive == true)
        {
            yield return new WaitForSeconds(time);
            Resource.GetComponent<Resource>().Add(count);
        }
        

    }

    public void ReduceTime(int num)
    {
        time -= num;
        Text.GetComponent<Text>().text = count + " / " + time + "s";
    }
}
