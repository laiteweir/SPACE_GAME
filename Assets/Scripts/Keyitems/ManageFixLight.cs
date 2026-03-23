using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFixLight : Keyitem
{
    // Start is called before the first frame update
    [SerializeField] GameObject next;
    [SerializeField] GameObject nextEvent;
    public override void KeyitemEvent()
    {
        Manager.Instance.OpenSceneUI("Fix Light", this);
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseSceneUI("Fix Light");
        if(Manager.Instance.room1.turnOnLight)
        {
            // next.GetComponent<Door>().enabled = true;
            next.SetActive(false);
            nextEvent.SetActive(true);
            Destroy(this);
        }
    }
}
