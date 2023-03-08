using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoulCounter : ScriptableObject
{
    public int soulsNum;
    
    public int value
    {
        get { return soulsNum; }
        set { value = soulsNum; }
    }
}
