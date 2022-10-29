using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageWireTask : Keyitem
{
    public override void KeyitemEvent()
    {
        Manager.OpenScene("Wire_Task");
    }

    public override void EndKeyitemEvent()
    {
        Manager.CloseScene("Wire_Task");
    }
}
