using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void VirtualMode () {
        SceneManager.LoadScene("VirtualPlantMode");
    }

        public void RealMode () {
        SceneManager.LoadScene("RealPlantMode");
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
