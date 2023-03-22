using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFading : MonoBehaviour
{
    public Animator sceneFade;
    public Level_Loader level_Loader;
    // Start is called before the first frame update
    void Start()
    {
        sceneFade.SetTrigger("start");
    }

    public IEnumerator FadeToCity()
    {
        sceneFade.SetTrigger("end");

        yield return new WaitForSeconds(7);

        level_Loader.LoadScene(1);
    }

    public IEnumerator FadeToForest()
    {
        sceneFade.SetTrigger("end");

        yield return new WaitForSeconds(7);

        level_Loader.LoadScene(2);
    }
}
