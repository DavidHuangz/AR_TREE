using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harvestableApples : MonoBehaviour
{
    // Access other classes
    private VirtualHandler vh;

    public GameObject appleInfo;

    public GameObject apple1;

    public GameObject apple2;

    public GameObject apple3;

    public GameObject apple4;

    public GameObject apple5;

    public GameObject apple6;

    public GameObject apple7;

    public GameObject apple8;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject mainCanvas = GameObject.Find("UIManager");
        vh = mainCanvas.GetComponent<VirtualHandler>();

        appleInfo.transform.gameObject.SetActive(false);
        apple1.transform.gameObject.SetActive(false);
        apple2.transform.gameObject.SetActive(false);
        apple3.transform.gameObject.SetActive(false);
        apple4.transform.gameObject.SetActive(false);
        apple5.transform.gameObject.SetActive(false);
        apple6.transform.gameObject.SetActive(false);
        apple7.transform.gameObject.SetActive(false);
        apple8.transform.gameObject.SetActive(false);
    }

    // Enable apple status when reaching mature tree
    void Update()
    {
        int stage = (int) vh.getGrowth();
        int apples = vh.getApples();

        if (stage > 84)
        {
            appleInfo.transform.gameObject.SetActive(true);

            if (apples >= 1)
            {
                apple1.transform.gameObject.SetActive(true);
            }
            else
            {
                apple1.transform.gameObject.SetActive(false);
            }

            if (apples >= 2)
            {
                apple2.transform.gameObject.SetActive(true);
            }
            else
            {
                apple2.transform.gameObject.SetActive(false);
            }

            if (apples >= 3)
            {
                apple3.transform.gameObject.SetActive(true);
            }
            else
            {
                apple3.transform.gameObject.SetActive(false);
            }

            if (apples >= 4)
            {
                apple4.transform.gameObject.SetActive(true);
            }
            else
            {
                apple4.transform.gameObject.SetActive(false);
            }

            if (apples >= 5)
            {
                apple5.transform.gameObject.SetActive(true);
            }
            else
            {
                apple5.transform.gameObject.SetActive(false);
            }

            if (apples >= 6)
            {
                apple6.transform.gameObject.SetActive(true);
            }
            else
            {
                apple6.transform.gameObject.SetActive(false);
            }

            if (apples >= 7)
            {
                apple7.transform.gameObject.SetActive(true);
            }
            else
            {
                apple7.transform.gameObject.SetActive(false);
            }

            if (apples >= 8)
            {
                apple8.transform.gameObject.SetActive(true);
            }
            else
            {
                apple8.transform.gameObject.SetActive(false);
            }
        }
    }
}
