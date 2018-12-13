using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalNavy : MonoBehaviour {

    public static int NavyCount;
    public GameObject TextObject;
	
	
	void Update () {
        TextObject.GetComponent<Text>().text = "" + NavyCount;
	}
}
