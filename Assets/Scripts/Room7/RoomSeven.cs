using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSeven : MonoBehaviour
{
    private bool goDebug = false;
    // Start is called before the first frame update
    void Start()
    {
        if(goDebug){
            Manager.Instance.SetDebugMode(goDebug,9,-1);        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
