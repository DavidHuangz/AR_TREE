using UnityEngine;
using System.Collections;

public class Panel_3 : MonoBehaviour
{
    public GameObject gameObject3;
    bool panelBool = false;

    // Open Panel
    public void openAndClosePanel()
    {
        if (panelBool == false)
        {
            gameObject3.transform.gameObject.SetActive(true);
        }
        else
        {
            gameObject3.transform.gameObject.SetActive(false);
        }
        panelBool = !panelBool;
    }
}

