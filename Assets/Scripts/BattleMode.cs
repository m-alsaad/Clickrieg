using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleMode : MonoBehaviour
{

    private GameObject ManpowerResource;

    public GameObject InfAvailText;
    public GameObject willUseInfText;
    public GameObject willUseInfTopText;
    public GameObject Button;
    public GameObject Army;
    public GameObject ArmyContainer;
    private GameObject Go;

    private int availableInf;
    private int willUseInf;
    private int UsedInf;

    // Start is called before the first frame update
    void Start()
    {
        ManpowerResource = GameObject.Find("Top Bar/Manpower");
        
        willUseInf = 0;
        UsedInf = 0;
        availableInf = ManpowerResource.GetComponent<Resource>().GetCount() - willUseInf - UsedInf;
        InfAvailText.GetComponent<Text>().text = "" + availableInf;
    }

    // Update is called once per frame
    void Update()
    {
        availableInf = ManpowerResource.GetComponent<Resource>().GetCount() -willUseInf- UsedInf;
        InfAvailText.GetComponent<Text>().text = "" + availableInf;
        willUseInfText.GetComponent<Text>().text = "" + willUseInf;
        willUseInfTopText.GetComponent<Text>().text = "" + willUseInf;
        if (willUseInf > 0)
        {
            Button.GetComponent<Button>().interactable = true;
        }
        else
        {
            Button.GetComponent<Button>().interactable = false;
        }
    }

    public void Add()
    {
        if(availableInf > 0)
        {
            willUseInf += 1;
        }
    }

    public void Subtract()
    {
        if (willUseInf > 0)
        {
            willUseInf -= 1;
        }
    }

    public void Create()
    {
        UsedInf += willUseInf;
        

        Go = Instantiate(Army, transform.position, Quaternion.identity);
        Go.transform.parent = ArmyContainer.transform;
        Go.transform.localScale = new Vector3(1, 1, 0);
        Go.GetComponent<Army>().infUpdate(willUseInf);

        willUseInf = 0;
    }

    public void Refund(int num)
    {
        UsedInf -= num;
    }
}
