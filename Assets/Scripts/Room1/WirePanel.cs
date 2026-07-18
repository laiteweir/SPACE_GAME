using UnityEngine;

public class WirePanel : BaseUI
{
    public void StartWatchWirePanel()
    {
        Manager.Instance.UIManager.OpenUI(gameObject);
    }
}