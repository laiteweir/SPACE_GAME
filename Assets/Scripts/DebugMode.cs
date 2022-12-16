using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    private bool global_light_on = false;
    private float x = 0f;
    private float y = 17f;
    void Start()
    {
        Manager.Instance.SetDebugMode(global_light_on, x, y);
    }
}