using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VirtualHarvest : MonoBehaviour
{
    private VirtualHandler vh;

    // Harvest panel
    public GameObject HarvestPanel;

    public TextMeshProUGUI HarvestDesc;

    public TextMeshProUGUI HarvestApples;

    public AudioSource closeBtnSound;

    public Button closeBtn;

    private bool harvested = false;

    void Awake()
    {
        GameObject mainCanvas = GameObject.Find("UIManager");
        vh = mainCanvas.GetComponent<VirtualHandler>();
        HarvestPanel.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!harvested)
        {
            // change this condition for easier testing
            if (vh.getGrowth() >= 100)
            {
                openPanel();
                harvested = true;
            }
        }
    }

    void openPanel()
    {
        HarvestPanel.transform.gameObject.SetActive(true);
        int apples = vh.getApples();
        HarvestApples.text =
            "You have harvested " + apples + " apples from your apple tree.";
        if (apples == 8)
        {
            HarvestDesc.text =
                "A bountiful apple harvest, congragulations! You have taken excellent care of your tree.";
        }
        else if (apples >= 4)
        {
            HarvestDesc.text =
                "A ample apple harvest! You have taken good care of your tree. Remember to adjust your actions to the weather.";
        }
        else if (apples >= 1)
        {
            HarvestDesc.text =
                "An average apple harvest! Watch out for sudden changes in weather.";
        }
        else if (apples == 0)
        {
            HarvestDesc.text =
                "Unfortunately you have not harvest any apples :( Make sure you give your tree the attention it needs!";
        }
    }

    void closePanel()
    {
        closeBtnSound.Play();
        HarvestPanel.transform.gameObject.SetActive(false);
    }
}
