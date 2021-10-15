using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsOneTime : MonoBehaviour
{
    public AudioSource closeBtnSound;

    public void closePanel()
    {
        closeBtnSound.Play();

        LeanTween
            .scale(gameObject, new Vector3(0, 0, 0), 0.5f)
            .setOnComplete(DestroyMe);
    }

    void DestroyMe()
    {
        Destroy (gameObject);
    }
}
