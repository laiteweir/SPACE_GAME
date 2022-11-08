using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room0_light_event2_2 : Keyitem
{
    [SerializeField] int lightNum;
    public override void KeyitemEvent()
    {
        Debug.Log($"Light{lightNum}_touch");

        if (Manager.Instance.room0.Room0_event2_verify_light_sort(lightNum - 1))
        {
            Manager.Instance.room0.room0_lights[lightNum - 1] = true;
            Manager.Instance.room0.room0_event2_light[lightNum - 1].color = Color.green;
        }

    }
    public override void EndKeyitemEvent()
    {

    }
}
