using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class Room0_light_event2_4 : Keyitem
{
    // Start is called before the first frame update
    public override void KeyitemEvent()
    {
        Debug.Log("Light4_touch");
        Manager.Instance.room0.Room0_lights[4-1] = true;
        Manager.Instance.room0.room0_event2_verify_light_sort(4);
        Manager.Instance.room0.Room0_event2_light4.GetComponent<Light2D>().color = Color.green;
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
