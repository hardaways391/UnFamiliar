using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // LevelLoad allows you to acess the scenes 
    public void LevelLoad(int buildum) => SceneManager.LoadScene(buildum);
}
