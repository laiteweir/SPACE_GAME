using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room0_light_event2_2 : Keyitem
{
    // Start is called before the first frame update
    public override void KeyitemEvent()
    {
        Debug.Log("Light2_touch");
        Manager.Instance.room0.Room0_lights[2-1] = 2;
        bool verify_result = Manager.Instance.room0.room0_event2_verify_light_sort(2);
        if(verify_result == true){
            Manager.Instance.room0.Room0_event2_light2.GetComponent<Light2D>().color = Color.green;
        }
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
