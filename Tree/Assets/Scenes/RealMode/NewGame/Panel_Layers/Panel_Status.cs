using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel_Status : MonoBehaviour
{
    public GameObject gameObject1;
    bool panelBool = false;
    public Button button2;

    void start()
    {
        button2.GetComponent<Image>().color = Color.white;
    }

    // Open Panel
    public void openAndClosePanel()
    {
        if (panelBool == false)
        {
            gameObject1.transform.gameObject.SetActive(true);
            button2.GetComponent<Image>().color = Color.grey;
        }
        else
        {
            gameObject1.transform.gameObject.SetActive(false);
            button2.GetComponent<Image>().color = Color.white;
        }
        panelBool = !panelBool;
    }
}
