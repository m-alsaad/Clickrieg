using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{

    public static int clickPower;
    public static int DPS;

    private void Start()
    {
        clickPower = 10;
        DPS = 0;
    }
}
