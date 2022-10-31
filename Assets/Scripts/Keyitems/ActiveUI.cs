using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUI : Keyitem
{
    public override void KeyitemEvent()
    {
        UI.text.SetActive(true);
        UI.TextIsOn = true;
    }

    public override void EndKeyitemEvent()
    {
        UI.text.SetActive(false);
    }
}
