using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private float time = 0f;
    private bool emit = false;
    public float randNum;

    public Material flickerMat;

    private void Start()
    {
        RandGenerate();
    }
    void Update()
    {
        if (time >= randNum)
        {
            emit = !emit;
            if (emit)
            {
                flickerMat.EnableKeyword("_EMISSION");
            }
            else
            {
                flickerMat.DisableKeyword("_EMISSION");
            }
            time = 0f;
            RandGenerate();
        }

        time += Time.deltaTime;
    }

    public void RandGenerate()
    {
        randNum = Random.Range(0.1f, 2.25f);
    }
}
