using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class News : MonoBehaviour
{

    public GameObject newspaper;
    private int count;

    public int waitTime;

    public AudioSource news;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        while (count <= waitTime)
        {
            count += 1;
            yield return new WaitForSeconds(1f); 
        }
        display();
    }

    private void display()
    {
        news.Play();
        newspaper.SetActive(true);
    }


}
