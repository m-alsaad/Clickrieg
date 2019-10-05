/**************************************************
 * SCRIPT FOR UI WINDOW DRAGGING
 * 
 * CAN BE USED ON ANY GAMEOBJECTED
 **************************************************/

 //IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//MAIN
public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{

    //VARIABLES
    private Vector3 pos;        //Vector of Object
    private bool start;         //Indicated the beggining of dragging (Helps offsets center of object)
    
    private int width = 200;    //Width of Object
    private int height = 100;   //Height of Object

    private int xPos;           //New X Position if hitting the screen's edge
    private int yPos;           //New Y Position if hitting the screen's edge


    //Dragging
    public void OnDrag(PointerEventData eventData)
    {
        //Offsets the center of obeject away from the mouse
        if (start == true)
        {
            pos = transform.localPosition - Input.mousePosition/2;
            start = false;
        }

        //Object follows the mouse.
        transform.localPosition = Input.mousePosition/2 + pos;
    }


    //End of Dragging
    public void OnEndDrag(PointerEventData eventData)
    {
        start = true;       //Sets this bool true so next drag offsets center of object
    }


    // Start is called before the first frame update
    void Start()
    {
        start = true;
    }


    // Update is called once per frame
    void Update()
    {
        //This keeps the object from leaving the screen.

        if (transform.localPosition.x < width)
        {
            xPos = width;
            transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
        }
        else if (transform.localPosition.x > 1080 - width)
        {
            xPos = 1080 - width;
            transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
        }

        if (transform.localPosition.y < height)
        {
            yPos = height;
            transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
        }
        else if (transform.localPosition.y > 675 - height)
        {
            yPos = 675 - height;
            transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
        }
    }
}
