using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalHappiness : MonoBehaviour {

    public static int HappinessCount;
    public GameObject HappinessText;

    public int IN_HappinessCount;

	
	void Update () {
        IN_HappinessCount = HappinessCount;

        HappinessText.GetComponent<Text>().text = "" + IN_HappinessCount;
	}
}
