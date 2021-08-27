using UnityEngine;
using System.Collections;

public class Panel_1 : MonoBehaviour
{
    public GameObject gameObject1;
    bool panelBool = false;

    // Open Panel
    public void openAndClosePanel()
    {
        if (panelBool == false)
        {
            gameObject1.transform.gameObject.SetActive(true);
        } else
        {
            gameObject1.transform.gameObject.SetActive(false);
        }
        panelBool = !panelBool;
    }
}
