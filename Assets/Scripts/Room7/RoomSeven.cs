using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSeven : MonoBehaviour
{
    private bool goDebug = true;
    public GameObject room7_event_01;
    public GameObject room7_event_02;

    // Start is called before the first frame update
    void Start()
    {


        if(goDebug){
            Manager.Instance.SetDebugMode(goDebug,false,16.56f,13.56f);        
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }

}
