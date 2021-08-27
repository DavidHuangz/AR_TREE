using UnityEngine;
using System.Collections;

public class Panel_2 : MonoBehaviour
{

    public GameObject gameObject;
    bool panelBool = false;

    // Open Panel
    public void openAndClosePanel()
    {
        if (panelBool == false)
        {
            gameObject.transform.gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.gameObject.SetActive(false);
        }
        panelBool = !panelBool;
    }
}
