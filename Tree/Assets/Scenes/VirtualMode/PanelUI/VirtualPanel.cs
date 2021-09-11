using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VirtualPanel : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject Water;
    public GameObject Nutrient;
    public GameObject Leaf;
    public GameObject ExpandableBtn;
    bool panelBool;
    public Button button;

    void start()
    {
        button.GetComponent<Image>().color = new Color(0,33,255);
        panelBool = false;
    }

    // Open Panel
    public void openAndClosePanel()
    {
        if (panelBool == false)
        {
            gameObject1.transform.gameObject.SetActive(true);
            Water.transform.gameObject.SetActive(false);
            Nutrient.transform.gameObject.SetActive(false);
            Leaf.transform.gameObject.SetActive(false);
            ExpandableBtn.transform.gameObject.SetActive(false);
            button.GetComponent<Image>().color = Color.grey;
        }
        else
        {
            gameObject1.transform.gameObject.SetActive(false);
            Water.transform.gameObject.SetActive(true);
            Nutrient.transform.gameObject.SetActive(true);
            Leaf.transform.gameObject.SetActive(true);
            ExpandableBtn.transform.gameObject.SetActive(true);
            button.GetComponent<Image>().color = new Color(0,33,255);
        }
        panelBool = !panelBool;
    }
}
