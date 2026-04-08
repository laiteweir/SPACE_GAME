using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : BaseUI
{
    [HideInInspector] public GameObject inventoryFirstItem;

    public void OnInventoryPerformed(InputAction.CallbackContext context)
    {
        Manager.Instance.UIManager.OpenUI(gameObject, inventoryFirstItem);
    }
}
