using UnityEngine;
using System.Collections;

public class Panel_2 : MonoBehaviour
{

    public GameObject gameObject2;
    bool panelBool = false;

    // Open Panel
    public void openAndClosePanel()
    {
        if (panelBool == false)
        {
            gameObject2.transform.gameObject.SetActive(true);
        }
        else
        {
            gameObject2.transform.gameObject.SetActive(false);
        }
        panelBool = !panelBool;
    }
}
