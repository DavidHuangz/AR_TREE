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

    public TextMeshProUGUI DiseaseText;

    private string cause;

    private string diseaseName;

    public void Start()
    {
        GameObject mainCanvas = GameObject.Find("MainCanvas");
        vc = mainCanvas.GetComponent<VirtualChart>();

        if (vc.condition == "water")
        {
            diseaseName = "Drought";
            cause =
                " causes wilting, yellowing of the leaves, and premature fruit drop. Remember to water your plant regularly and adapt to any weather changes.";
        }
        else if (vc.condition == "nutrient")
        {
            diseaseName = "Interveinal chlorosis";
            cause =
                " causes deficiency of several micro-nutrients, namely iron, zinc and manganese. Yellowing of the leaves can be a hint of the disease. Remember to fertilise your tree for it to grow well.";
        }
        else
        {
            diseaseName = "leaf-eating insects";
            cause =
                " will feed on the leaf and could restrict how well the tree absorbs carbon and sunlight. To prevent insect infestations, do your best to keep your trees healthy by watering and fertilising regularly.";
        }

        DiseaseText.text = "Your apple tree died from " + diseaseName;
        CauseText.text = diseaseName + cause;
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
