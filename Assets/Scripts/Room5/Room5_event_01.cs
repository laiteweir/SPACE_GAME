using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room5_event_01 : Keyitem
{
    // Start is called before the first frame update
    [SerializeField] GameObject room_5_light;
    [SerializeField] GameObject next;
    public override void KeyitemEvent()
    {
       room_5_light.SetActive(true);
       next.SetActive(true);
    }

    public override void EndKeyitemEvent()
    {
        Destroy(this);
    }
}
