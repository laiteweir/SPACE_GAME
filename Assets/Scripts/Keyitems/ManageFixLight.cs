using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFixLight : Keyitem
{
    // Start is called before the first frame update
    public override void KeyitemEvent()
    {
        Manager.Instance.OpenScene("Fix_Light", this);
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseScene("Fix_Light");
        Destroy(this);
    }
}
