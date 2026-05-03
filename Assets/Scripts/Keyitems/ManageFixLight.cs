using UnityEngine;

public class ManageFixLight : Keyitem
{
    public GameObject currentEvent;
    public GameObject next;
    public override void KeyitemEvent()
    {
        Manager.Instance.OpenSceneUI("Fix Light", this);
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseSceneUI("Fix Light");
    }
}
