using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
   public GameObject LoadingScreen;
   //public Image LoadingBarFill;

   public void LoadScene(int sceneId)
   {

    StartCoroutine(LoadSceneAsync(sceneId));
 
   }

   IEnumerator LoadSceneAsync(int sceneId)
   {
    AsyncOperation opreation = SceneManager.LoadSceneAsync(sceneId);

    LoadingScreen.SetActive(true);

    //while (!opreation.isDone)
    //{
    //float progressValue = Mathf.Clamp01(opreation.progress / 0.9f);

    //LoadingBarFill.fillAmount = progressValue;

    yield return null;
   //}
   }
}
