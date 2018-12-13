using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalArmoured : MonoBehaviour {

    public static int ArmouredCount;
    public GameObject TextObject;
	
	
	void Update () {
        TextObject.GetComponent<Text>().text = "" + ArmouredCount;
	}
}
