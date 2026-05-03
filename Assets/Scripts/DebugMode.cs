using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    public bool globalLightOn = false;
    public float x = 0f;
    public float y = 0f;
    private void Start()
    {
        Manager.Instance.SetDebugMode(globalLightOn, x, y);
    }
}