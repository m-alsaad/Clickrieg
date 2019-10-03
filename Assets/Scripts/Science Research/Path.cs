/**************************************************
 * SCRIPT FOR AUTO ADJUSTING THE PATHS BETWEEN
 * SCIENCE MATERIALS IN EDIT MODE
 **************************************************/

//IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Execute this script during Edit Mode
[ExecuteInEditMode]
//MAIN
public class Path : MonoBehaviour
{
    //Game Objects
    //Science Materials Objects. End is Dependent of Start
    public GameObject scienceStart;
    public GameObject scienceEnd;

    //VARIABLES
    public bool execute;    //Bool wither to execute this script or not

    //x and y of Path
    float x;
    float y;

    //x and y of Science Materials. 1=Start, 2=End
    float x1;
    float y1;
    float x2;
    float y2;
   
    float length;   //Width of Path
    float angle;    //Angle of Path
    


    // Start is called before the first frame update 
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if(execute == true)
        {

            //Get Path Location
            x = (scienceStart.transform.localPosition.x + scienceEnd.transform.localPosition.x) / 2;
            y = (scienceStart.transform.localPosition.y + scienceEnd.transform.localPosition.y) / 2;
            this.transform.localPosition = new Vector3(x, y, 0);

            //Get Path Width
            length = Vector3.Distance(scienceStart.transform.localPosition, scienceEnd.transform.localPosition);
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(length, 5);

            //Get x and y of Science Materials
            x1 = (scienceStart.transform.localPosition.x);
            y1 = (scienceStart.transform.localPosition.y);
            x2 = (scienceEnd.transform.localPosition.x);
            y2 = (scienceEnd.transform.localPosition.y);

            //Get Angle of Path
            if (((scienceStart.transform.localPosition.x < scienceEnd.transform.localPosition.x) &&
                (scienceStart.transform.localPosition.y > scienceEnd.transform.localPosition.y)) ||
                ((scienceStart.transform.localPosition.x > scienceEnd.transform.localPosition.x) &&
                (scienceStart.transform.localPosition.y < scienceEnd.transform.localPosition.y)))
            {
                angle = (Mathf.Rad2Deg * Mathf.Atan(Mathf.Abs(x1 - x2) / Mathf.Abs(y1 - y2))) + 90;
            }
            if (((scienceStart.transform.localPosition.x < scienceEnd.transform.localPosition.x) &&
                (scienceStart.transform.localPosition.y < scienceEnd.transform.localPosition.y)) ||
                ((scienceStart.transform.localPosition.x > scienceEnd.transform.localPosition.x) &&
                (scienceStart.transform.localPosition.y > scienceEnd.transform.localPosition.y)))
            {
                angle = Mathf.Rad2Deg * Mathf.Atan(Mathf.Abs(y1 - y2) / Mathf.Abs(x1 - x2));
            }

            //Set Angle of Path
            this.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, angle);



        }
    }
}
