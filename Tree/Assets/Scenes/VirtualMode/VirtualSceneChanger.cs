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
        GameObject mainCanvas = GameObject.Find("UIManager");
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
            vh.save(); // Save the tree data
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void GoToEndGame()
    {
        if (vh.getPlantCondition() != "")
        {
            vh.save(); // Save the tree data
            SceneManager.LoadScene("EndGame");
        }
    }

    public void GoToEndGameBtn()
    {
        vh.save(); // Save the tree data
        SceneManager.LoadScene("EndGame");
    }
}
