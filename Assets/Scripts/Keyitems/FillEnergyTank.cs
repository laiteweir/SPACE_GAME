using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class FillEnergyTank : Keyitem
{
    [SerializeField] private TextAsset first;
    [SerializeField] private TextAsset fail;
    private string[] dialogFirst;
    private string[] dialogFail;
    [SerializeField] private ItemData energyTankData;
    [SerializeField] private ItemData filledEnergyTankData;
    private bool isFirst = true;

    void Start()
    {
        dialogFirst = first.text.Split('\n');
        dialogFail = fail.text.Split('\n');
    }
    private void Update()
    {
        int filledEnergyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(filledEnergyTankData);
        if (filledEnergyTankIndex != -1 && Manager.Instance.InventoryManager.items[filledEnergyTankIndex].itemQuantity >= 3)
        {
            Manager.Instance.room10.refillStationHint.SetActive(false);
        }
    }
    public override void KeyitemEvent()
    {
        int energyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(energyTankData);
        if (isFirst)
        {
            isFirst = false;
            Manager.Instance.DialogBoxUI.SetActive(true);
            Manager.Instance.DialogBox.StartTalk(dialogFirst);
        }
        else if (energyTankIndex != -1 && Manager.Instance.InventoryManager.items[energyTankIndex].itemQuantity == 0)
        {
            Manager.Instance.DialogBoxUI.SetActive(true);
            Manager.Instance.DialogBox.StartTalk(dialogFail);
        }
        else
        {
            Manager.Instance.OpenSceneUI("Fill Energy Tank Task", this);
        }
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseSceneUI("Fill Energy Tank Task");
    }
}
