using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageWireTask : Keyitem
{
    public override void KeyitemEvent()
    {
        Manager.Instance.OpenScene("Wire_Task", this);
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseScene("Wire_Task");
        // Debug.Log("You have fixed Engine1!");
        Manager.Instance.room10.isEngine1Fixed = true;
        Destroy(this);
    }
}
