using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToMainMenu : MonoBehaviour
{
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
