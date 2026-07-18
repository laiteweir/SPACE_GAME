using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : BaseUI
{
    [HideInInspector] public GameObject inventoryFirstItem;

    public void OnOpenInventory(InputAction.CallbackContext context)
    {
        Manager.Instance.UIManager.OpenUI(gameObject, inventoryFirstItem);
    }
}
