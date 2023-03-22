using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject loadCanvas;
    public GameObject mainCanvas;

    public void LoadScene(int sceneId)
   {
        loadCanvas.SetActive(true);
        mainCanvas.SetActive(false);
        StartCoroutine(LoadSceneAsync(sceneId));
   }

   public IEnumerator LoadSceneAsync(int lvlToLoad)
   {
        AsyncOperation opreation = SceneManager.LoadSceneAsync(lvlToLoad);
        yield return null;
   }
}
