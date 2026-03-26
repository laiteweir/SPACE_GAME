using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomZero : MonoBehaviour
{    
    public Door nextDoor;
    public List<Light2D> room0Event2Light;
    [SerializeField] private Light2D room0BigLight;
    // private bool goDebug = false;
    [HideInInspector] public bool[] room0Lights = { false, false, false, false };
    
    //public bool createKeyCard = false;
    [SerializeField] private GameObject keycard;

    // Start is called before the first frame update
    void Start()
    {
        // if(goDebug){
        //     Manager.Instance.SetDebugMode(goDebug,0,0);        
        // }
        
    }
    public bool Room0TurnOffLightsWithRedLight()
    {
        foreach (Light2D light in room0Event2Light)
        {
            light.enabled = true;
            light.color = Color.red;
        }
        return true;
    }
    public bool Room0TurnOnBigLight()
    {
        foreach (Light2D light in room0Event2Light)
        {
            light.enabled = false;
        }

        room0BigLight.enabled = true;
        Instantiate(keycard);
        return true;
    }
    public bool Room0Event2VerifyLightSort(int sortNum)
    {
        // sort num mapping [light1,light2,light3,light4]
        bool result = true;
        for (int i = 0; i < sortNum; ++i)
        {
            if (room0Lights[i] != true){
                result = false;
                Room0TurnOffLightsWithRedLight();
            }
        }
        return result;
    }
}
