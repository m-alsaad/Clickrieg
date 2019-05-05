using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    public int count = 0;
    public GameObject TextObject;

    void Update()
    {
        TextObject.GetComponent<Text>().text = "" + count;
    }

    public int GetCount()
    {
        return count;
    }
    public void Add(int num)
    {
        count += num;
    }
    public void Subtract(int num)
    {
        count -= num;
    }

}
