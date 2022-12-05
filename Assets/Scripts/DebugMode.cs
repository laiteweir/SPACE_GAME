using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    // Start is called before the first frame updateaaa
    private bool goDebug = false;
    private bool global_light_on = false;
    private float x = 8f;
    private float y = -7f;
    void Start()
    {
        if (goDebug)
        {
            Manager.Instance.SetDebugMode(goDebug, global_light_on, x, y);    
        }
    }
}