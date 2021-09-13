using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    public AudioSource closeBtnSound;

    public GameObject dataPanel;

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
