using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject Water;
    public GameObject Nutrient;
    bool panelBool = false;
    public Button button;

    void start()
    {
        button.GetComponent<Image>().color = Color.white;
    }

    // Open Panel
    public void openAndClosePanel()
    {
        if (panelBool == false)
        {
            gameObject1.transform.gameObject.SetActive(true);
            Water.transform.gameObject.SetActive(false);
            Nutrient.transform.gameObject.SetActive(false);
            button.GetComponent<Image>().color = Color.grey;
        }
        else
        {
            gameObject1.transform.gameObject.SetActive(false);
            Water.transform.gameObject.SetActive(true);
            Nutrient.transform.gameObject.SetActive(true);
            button.GetComponent<Image>().color = Color.white;
        }
        panelBool = !panelBool;
    }
}
