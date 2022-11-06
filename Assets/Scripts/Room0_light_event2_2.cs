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
        Manager.Instance.Room0_lights[2-1] = true;
        Manager.Instance.room0_event2_verify_light_sort(2);
        Manager.Instance.Room0_event2_light2.GetComponent<Light2D>().color = Color.green;
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
