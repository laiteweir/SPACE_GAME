using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Engine0 : Keyitem
{
    [SerializeField] private TextAsset success;
    [SerializeField] private TextAsset fail;
    private string[] dialogSuccess;
    private string[] dialogFail;
    [SerializeField] private ItemData filledEnergyTankData;
    void Start()
    {
        dialogSuccess = success.text.Split('\n');
        dialogFail = fail.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        int filledEnergyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(filledEnergyTankData);
        if (filledEnergyTankIndex != -1 && Manager.Instance.InventoryManager.items[filledEnergyTankIndex].itemQuantity >= 3)
        {
            // Debug.Log("You have fixed Engine0!");
            Manager.Instance.DialogBoxUI.SetActive(true);
            Manager.Instance.DialogBox.StartTalk(dialogSuccess);
            Manager.Instance.room10.isEngine0Fixed = true;
            Manager.Instance.InventoryManager.RemoveItem(filledEnergyTankIndex, Manager.Instance.InventoryManager.items[filledEnergyTankIndex].itemQuantity);
            Manager.Instance.room10.engine0Hint.SetActive(false);
            EndKeyitemEvent();
        }
        else
        {
            Manager.Instance.DialogBoxUI.SetActive(true);
            Manager.Instance.DialogBox.StartTalk(dialogFail);
        }
    }

    public override void EndKeyitemEvent()
    {
        Destroy(this);
    }
}
