using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class WatchWirePanel : Keyitem
{
    public override void KeyitemEvent()
    {
        Manager.Instance.room1.wirePanel.WatchWirePanelPerformed();
    }
}