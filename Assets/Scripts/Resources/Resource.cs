/**************************************************
 * SCRIPT FOR TRACKING ALL RESOURCES IN THE GAME
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//MAIN
public class Resource : MonoBehaviour
{
    //VARIABLES
    public int count = 0;               //Number of available resource
    public GameObject TextObject;       //Text Displaying the Count of resource

    
    void Start()
    {
        //Update Text on Start Up
        TextObject.GetComponent<Text>().text = "" + count;
    }

    //Get Amount of Resource
    public int GetCount()
    {
        return count;
    }
    //Add to Resource
    public void Add(int num)
    {
        count += num;
        TextObject.GetComponent<Text>().text = "" + count;
    }
    //Subtract to Resource
    public void Subtract(int num)
    {
        count -= num;
        TextObject.GetComponent<Text>().text = "" + count;
    }

}
