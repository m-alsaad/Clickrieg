using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System;

public class EnemyImage : MonoBehaviour {

    public Sprite BanditImage;
    public Sprite RabbitImage;
    public Sprite DeerImage;



	
	// Update is called once per frame
	void Update () {
        if(Battle.CurrentBattle < 6)
        {
            GetComponent<Image>().sprite = BanditImage;
            
        }
        else if(Battle.CurrentBattle < 11)
        {
            GetComponent<Image>().sprite = DeerImage;
        }
		
	}
}
