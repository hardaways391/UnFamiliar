using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParentWithChild : MonoBehaviour
{
    public GameObject child;

    private void Update()
    {
        transform.position = child.transform.position;
    }
}
