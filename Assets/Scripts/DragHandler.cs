using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector3 pos;
    int yPos;
    int xPos;
    private bool start;
    private int width = 240;
    private int height = 125;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Draging!");
        if (start == true)
        {
            pos = transform.localPosition - Input.mousePosition;
            start = false;
        }

   
        transform.localPosition = Input.mousePosition + pos;
        
        
        

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        start = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x < width)
        {
            Debug.Log("1");
            xPos = width;
            transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
        }
        else if (transform.localPosition.x > Screen.width - width)
        {
            Debug.Log("2");
            xPos = Screen.width - width;
            transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
        }

        if (transform.localPosition.y < height)
        {
            Debug.Log("3");
            yPos = height;
            transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
        }
        else if (transform.localPosition.y > Screen.height - height)
        {
            Debug.Log("4");
            yPos = Screen.height - height;
            transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
        }
    }
}
