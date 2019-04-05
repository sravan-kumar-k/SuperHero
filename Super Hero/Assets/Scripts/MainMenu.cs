using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Level_1()
    {
        SceneManager.LoadScene("1_level");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
