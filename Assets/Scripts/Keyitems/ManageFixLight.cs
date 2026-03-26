using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFixLight : Keyitem
{
    [SerializeField] private GameObject currentEvent;
    [SerializeField] private GameObject next;
    public override void KeyitemEvent()
    {
        Manager.Instance.OpenSceneUI("Fix Light", this);
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseSceneUI("Fix Light");
        if (Manager.Instance.room1.turnOnLight)
        {
            // next.GetComponent<Door>().enabled = true;
            gameObject.SetActive(false);
            currentEvent.SetActive(false);
            next.SetActive(true);
        }
    }
}
