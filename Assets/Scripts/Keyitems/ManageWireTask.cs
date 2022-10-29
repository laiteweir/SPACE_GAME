using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageWireTask : Keyitem
{
    public override void KeyitemEvent()
    {
        Manager.OpenScene("Wire_Task", this);
    }

    public override void EndKeyitemEvent()
    {
        Manager.CloseScene("Wire_Task");
        Destroy(this);
    }
}
