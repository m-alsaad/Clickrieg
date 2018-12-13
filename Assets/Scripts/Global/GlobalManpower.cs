using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManpower : MonoBehaviour {

    public static int ManpowerCount = 10;

    public GameObject TextObject;

	
	// Update is called once per frame
	void Update () {

        TextObject.GetComponent<Text>().text = "" + ManpowerCount;
		
	}
}
