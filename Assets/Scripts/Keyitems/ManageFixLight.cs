using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFixLight : Keyitem
{
    // Start is called before the first frame update
    [SerializeField] GameObject next;
    [SerializeField] GameObject next_event;
    public override void KeyitemEvent()
    {
        Manager.Instance.OpenScene("Fix_Light", this);
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseScene("Fix_Light");
        if(Room_1Data.turn_on_light){
            // next.GetComponent<Door>().enabled = true;
            next.SetActive(false);
            next_event.SetActive(true);
            Destroy(this);
        }
    }
}
