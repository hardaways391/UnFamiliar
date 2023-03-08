using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSouls : MonoBehaviour
{
    [SerializeField] private SoulCounter soulCounter;
    void Start()
    {
        soulCounter.soulsNum = 0;
    }
}
