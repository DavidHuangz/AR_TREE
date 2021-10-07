using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    private VirtualChart vc;

    public AudioSource closeBtnSound;

    public GameObject dataPanel;

    public TextMeshProUGUI CauseText;

    private string cause;

    public void Start()
    {
        GameObject mainCanvas = GameObject.Find("MainCanvas");
        vc = mainCanvas.GetComponent<VirtualChart>();

        if (vc.condition == "water")
        {
            cause =
                "lack of water. Remember to watch out for any weather changes.";
        }
        else if (vc.condition == "nutrient")
        {
            cause =
                "lack of nutrients. Remember to fertilise your tree for it to grow well.";
        }
        else
        {
            cause =
                "lack of water and nutrients. Remember to check up on your tree.";
        }

        CauseText.text = "Your apple tree has died from " + cause;
    }

    public void closePanel()
    {
        closeBtnSound.Play();

        LeanTween
            .scale(gameObject, new Vector3(0, 0, 0), 0.5f)
            .setOnComplete(DestroyMe);

        dataPanel.transform.gameObject.SetActive(true);
    }

    void DestroyMe()
    {
        Destroy (gameObject);
    }
}
