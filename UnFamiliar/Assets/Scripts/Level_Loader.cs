using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    public GameObject optionScreen;
    public void Lvl1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    // LevelLoad allows you to acess the scenes 
    public void LevelLoad(int buildum) => SceneManager.LoadScene(buildum);
}
