using UnityEngine;

public class WirePanel : BaseUI
{
    public void WatchWirePanelPerformed()
    {
        Manager.Instance.UIManager.OpenUI(gameObject);
    }
}