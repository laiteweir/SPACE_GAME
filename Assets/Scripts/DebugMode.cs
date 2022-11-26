using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    // Start is called before the first frame updateaaa
    private bool goDebug = true;
    private bool global_light_on = false;
    private float x = 8.32f;
    private float y = -2.66f;
    void Start()
    {
        if (goDebug)
        {
            Manager.Instance.SetDebugMode(goDebug, global_light_on, x, y);    
        }
    }
}