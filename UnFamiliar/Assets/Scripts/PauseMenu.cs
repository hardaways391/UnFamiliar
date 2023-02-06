using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool paused;

    private void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        paused = false;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && !paused) //esc pauses if not paused
        {
            pauseMenu.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
        }
        else if (Input.GetButtonDown("Cancel") && paused) //esc resumes game if paused
        {
            pauseMenu.SetActive(false);
            paused = false;
            Time.timeScale = 1f;
        }
    }
}
