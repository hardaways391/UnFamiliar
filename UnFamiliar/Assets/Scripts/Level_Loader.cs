using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    public GameObject optionScreen;
    public void Forest()
    {
        SceneManager.LoadScene("Forest");
    }

    public void City()
    {
        SceneManager.LoadScene("City");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    // LevelLoad allows you to acess the scenes 
    public void LevelLoad(int buildum) => SceneManager.LoadScene(buildum);
}
