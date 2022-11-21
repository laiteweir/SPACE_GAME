using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    // Start is called before the first frame updateaaa
    private bool goDebug = true;
    private bool global_light_on = true;
    private float x = 0f;
    private float y = -9f;
    void Start()
    {
        if (goDebug)
        {
            Manager.Instance.SetDebugMode(goDebug, global_light_on, x, y);    
        }
    }
}
