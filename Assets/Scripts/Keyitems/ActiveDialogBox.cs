using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDialogBox : Keyitem
{
    public override void KeyitemEvent()
    {
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.ui.SetActive(false);
        Manager.Instance.dialogBox.TextIsOn = false;
    }
}
