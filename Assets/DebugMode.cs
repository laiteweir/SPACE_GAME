using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMode : MonoBehaviour
{
    // Start is called before the first frame update
    private bool goDebug = false;
    private bool global_light_on = false;
    private float x = 16.56f;
    private float y = 13.56f;
    void Start()
    {
        if(goDebug){
            Manager.Instance.SetDebugMode(goDebug,global_light_on,16.56f,13.56f);        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
