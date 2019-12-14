using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Army : MonoBehaviour
{
    private int count;
    public GameObject infText;

    public GameObject item;
    private GameObject BATTLE;

    public void Start()
    {
        BATTLE = GameObject.Find("Top Bar/Angled Bar/Battle");
    }

    public void infUpdate(int num)
    {
        count = num;
        infText.GetComponent<Text>().text = "" + count;
    }

    public int getCount()
    {
        return count;
    }

    public void delete()
    {
        BATTLE.GetComponent<BattleMode>().Refund(count);
        Destroy(item);
    }
}
