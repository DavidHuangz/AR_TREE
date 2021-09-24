using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harvestableApples : MonoBehaviour
{
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
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
    }
}
