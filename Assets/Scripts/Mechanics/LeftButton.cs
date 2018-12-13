using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{


    public void ButtonClick()
    {
        if(Battle.CurrentBattle > 1)
        {
            Battle.CurrentBattle -= 1;
        }
        
    }
}
