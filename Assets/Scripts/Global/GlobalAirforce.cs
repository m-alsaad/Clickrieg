using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAirforce : MonoBehaviour {

    public static int AirforceCount;
    public GameObject TextObject;
	
	
	void Update () {
        TextObject.GetComponent<Text>().text = "" + AirforceCount;
	}
}
