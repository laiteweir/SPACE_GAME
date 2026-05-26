using UnityEngine;

public class Engine1 : Keyitem
{
    [SerializeField] private TextAsset success;
    [SerializeField] private TextAsset fail;
    private string[] dialogSuccess;
    private string[] dialogFail;

    [SerializeField] private ItemData filledEnergyTankData;

    private void Start()
    {
        dialogSuccess = success.text.Split('\n');
        dialogFail = fail.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        int filledEnergyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(filledEnergyTankData);
        if (filledEnergyTankIndex != -1 && Manager.Instance.InventoryManager.items[filledEnergyTankIndex].itemQuantity >= 3)
        {
            Manager.Instance.DialogBox.StartTalk(dialogSuccess, EndKeyitemEvent);
        }
        else
        {
            Manager.Instance.DialogBox.StartTalk(dialogFail);
        }
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("You have fixed Engine 1!");
        int filledEnergyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(filledEnergyTankData);
        Manager.Instance.InventoryManager.RemoveItem(filledEnergyTankIndex, Manager.Instance.InventoryManager.items[filledEnergyTankIndex].itemQuantity);
        gameObject.SetActive(false);
        Manager.Instance.room10.isEngine1Fixed = true;
    }
}
