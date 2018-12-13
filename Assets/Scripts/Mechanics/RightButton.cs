using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : MonoBehaviour {


    public void ButtonClick()
    {
        Battle.CurrentBattle += 1;
    }
}
