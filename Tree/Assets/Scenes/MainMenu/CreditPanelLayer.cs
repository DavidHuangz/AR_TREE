using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CreditPanelLayer : MonoBehaviour
{
    public GameObject gameObject1;

    public AudioSource checkInfoBtnSound;

    public Button button;

    private bool panelBool;

    void start()
    {
        button.GetComponent<Image>().color = new Color(255, 255, 255);
        gameObject1.transform.gameObject.SetActive(false);
        panelBool = false;
    }

    // Open Panel
    public void open_close_layer()
    {
        checkInfoBtnSound.Play();

        if (panelBool == false)
        {
            gameObject1.transform.gameObject.SetActive(true);
            button.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            gameObject1.transform.gameObject.SetActive(false);
            button.GetComponent<Image>().color = new Color(255, 255, 255);
        }
        panelBool = !panelBool;
    }
}
