using UnityEngine;

public class WatchWirePanel : Keyitem
{
    public override void KeyitemEvent()
    {
        Manager.Instance.room1.Room1WirePanelUI.StartWatchWirePanel();
    }
}