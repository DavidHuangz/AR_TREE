using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameNextPanel : MonoBehaviour
{
    public GameObject nextBtn;

    public GameObject Graph1;

    public GameObject Graph2;

    public GameObject Graph3;

    public AudioSource checkInfoBtnSound;

    private int num;

    void Awake()
    {
        Graph1.transform.gameObject.SetActive(true);
        Graph2.transform.gameObject.SetActive(false);
        Graph3.transform.gameObject.SetActive(false);
        num = 1;
    }

    // Next graph
    public void nextGraph()
    {
        checkInfoBtnSound.Play();

        if (num == 1)
        {
            Graph1.transform.gameObject.SetActive(false);
            Graph2.transform.gameObject.SetActive(true);
            Graph3.transform.gameObject.SetActive(false);
            num++;
        }
        else if (num == 2)
        {
            Graph1.transform.gameObject.SetActive(false);
            Graph2.transform.gameObject.SetActive(false);
            Graph3.transform.gameObject.SetActive(true);
            num++;
        }
        else
        {
            Graph1.transform.gameObject.SetActive(true);
            Graph2.transform.gameObject.SetActive(false);
            Graph3.transform.gameObject.SetActive(false);
            num = 1;
        }
    }
}
