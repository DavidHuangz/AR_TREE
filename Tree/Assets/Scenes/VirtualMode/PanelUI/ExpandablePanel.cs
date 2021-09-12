using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandablePanel : MonoBehaviour
{
    // Button panel
    public GameObject BtnPanel;

    public GameObject BtnInfo;

    // Expandable buttons
    public Button buttonUp;

    public Button buttonDown;

    bool panelBool;

    // Start is called before the first frame update
    void Start()
    {
        buttonUp.transform.gameObject.SetActive(true);
        buttonDown.transform.gameObject.SetActive(false);
        BtnPanel.transform.gameObject.SetActive(false);
        BtnInfo.transform.gameObject.SetActive(false);
        panelBool = false;
    }

    // Open Panel
    public void openAndClosePanel()
    {
        if (panelBool == false)
        {
            BtnPanel.transform.gameObject.SetActive(true);
            BtnInfo.transform.gameObject.SetActive(true);
            buttonUp.transform.gameObject.SetActive(false);
            buttonDown.transform.gameObject.SetActive(true);
        }
        else
        {
            // Close Panel
            BtnPanel.transform.gameObject.SetActive(false);
            BtnInfo.transform.gameObject.SetActive(false);
            buttonUp.transform.gameObject.SetActive(true);
            buttonDown.transform.gameObject.SetActive(false);
        }
        panelBool = !panelBool;
    }
}
