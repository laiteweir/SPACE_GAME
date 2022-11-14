using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomZero : MonoBehaviour
{    
    public GameObject room0_event1;
    public GameObject room0_event2;
    public GameObject room0_event3;
    public List<Light2D> room0_event2_light;
    public Light2D room0_bigLight_1;
    private bool goDebug = false;
    [HideInInspector] public bool[] room0_lights = { false, false, false, false };
    
    //public bool createKeyCard = false;
    [SerializeField] GameObject keycard;

    // Start is called before the first frame update
    void Start()
    {
        if(goDebug){
            Manager.Instance.SetDebugMode(goDebug,0,0);        
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Room0_turn_off_lights_with_red_light()
    {
        foreach (Light2D light in room0_event2_light)
        {
            light.enabled = true;
            light.color = Color.red;
        }
        return true;
    }
    public bool Room0_turn_on_bigLight()
    {
        foreach (Light2D light in room0_event2_light)
        {
            light.enabled = false;
        }

        room0_bigLight_1.enabled = true;
        Instantiate(keycard);
        return true;
    }
    public bool Room0_event2_verify_light_sort(int sortNum)
    {
        // sort num mapping [light1,light2,light3,light4]
        bool result = true;
        for (int i = 0; i < sortNum; ++i)
        {
            if (room0_lights[i] != true){
                result = false;
                Room0_turn_off_lights_with_red_light();
            }
        }
        return result;
    }
}
