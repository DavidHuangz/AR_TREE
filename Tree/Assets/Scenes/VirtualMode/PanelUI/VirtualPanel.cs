using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VirtualPanel : MonoBehaviour
{
    public GameObject gameObject1;

    public GameObject time;

    public GameObject water;

    public GameObject nutrient;

    public GameObject leaf;

    public GameObject ExpandableBtn;

    public AudioSource checkInfoBtnSound;

    public Button button;

    private bool panelBool;

    void start()
    {
        button.GetComponent<Image>().color = new Color(0, 33, 255);
        panelBool = false;
    }

    // Open Panel
    public void openAndClosePanel()
    {
        checkInfoBtnSound.Play();

        if (panelBool == false)
        {
            gameObject1.transform.gameObject.SetActive(true);
            time.transform.gameObject.SetActive(false);
            water.transform.gameObject.SetActive(false);
            nutrient.transform.gameObject.SetActive(false);
            leaf.transform.gameObject.SetActive(false);
            ExpandableBtn.transform.gameObject.SetActive(false);
            button.GetComponent<Image>().color = Color.grey;
        }
        else
        {
            gameObject1.transform.gameObject.SetActive(false);
            time.transform.gameObject.SetActive(true);
            water.transform.gameObject.SetActive(true);
            nutrient.transform.gameObject.SetActive(true);
            leaf.transform.gameObject.SetActive(true);
            ExpandableBtn.transform.gameObject.SetActive(true);
            button.GetComponent<Image>().color = new Color(0, 33, 255);
        }
        panelBool = !panelBool;
    }
}
