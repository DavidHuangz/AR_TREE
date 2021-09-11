using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandablePanel : MonoBehaviour
{

    public GameObject Water;
    public GameObject Nutrient;
    public GameObject CheckInfo;
    public GameObject Leaf;
    public Button buttonUp;
    public Button buttonDown;
    bool panelBool;

    // Start is called before the first frame update
    void Start()
    {
        Water.transform.gameObject.SetActive(false);
        Nutrient.transform.gameObject.SetActive(false);
        CheckInfo.transform.gameObject.SetActive(false);
        Leaf.transform.gameObject.SetActive(false);
        buttonUp.transform.gameObject.SetActive(true);
        buttonDown.transform.gameObject.SetActive(false);
        panelBool = false;
    }

    // Open Panel
    public void openAndClosePanel()
    {
        if (panelBool == false)
        {
            Water.transform.gameObject.SetActive(true);
            Nutrient.transform.gameObject.SetActive(true);
            CheckInfo.transform.gameObject.SetActive(true);
            Leaf.transform.gameObject.SetActive(true);

            buttonUp.transform.gameObject.SetActive(false);
            buttonDown.transform.gameObject.SetActive(true);
    } 
    else
    {
        // Close Panel
            Water.transform.gameObject.SetActive(false);
            Nutrient.transform.gameObject.SetActive(false);
            CheckInfo.transform.gameObject.SetActive(false);
            Leaf.transform.gameObject.SetActive(false);

            buttonUp.transform.gameObject.SetActive(true);
            buttonDown.transform.gameObject.SetActive(false);
    }
        panelBool = !panelBool;
    }
}
