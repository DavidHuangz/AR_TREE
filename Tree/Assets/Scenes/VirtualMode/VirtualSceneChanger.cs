using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirtualSceneChanger : MonoBehaviour
{
    private VirtualHandler vh;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject mainCanvas = GameObject.Find("MainCanvas");
        vh = mainCanvas.GetComponent<VirtualHandler>();
    }

    // Update is called once per frame
    private void Update()
    {
        EscapeKey();
        GoToEndGame();
    }

    private void EscapeKey()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void GoToEndGame()
    {
        if (vh.getWater() <= 0 || vh.getNutrient() <= 0)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
