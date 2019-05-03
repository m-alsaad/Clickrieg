using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Resource : MonoBehaviour
{
    public int countssssss = 5;

    public Resource(int countssssss)
    {
        this.countssssss = countssssss;
    }

    public Resource()
    {
    }

    //public int Get()
    //{
    //    return count;
    //}

    //protected void Add(int num)
    //{
    //    count += num;
    //}

    //protected void Subtract(int num)
    //{
    //    count -= num;
    //}

}
