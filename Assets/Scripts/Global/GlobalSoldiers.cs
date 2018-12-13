using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalSoldiers : MonoBehaviour {


    public static int SoldierCount = 1;
    public GameObject TextObject;

	void Update () {
        TextObject.GetComponent<Text>().text = "" + SoldierCount;
	}
}
