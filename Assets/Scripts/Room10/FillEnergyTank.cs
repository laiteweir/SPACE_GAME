using UnityEngine;

public class FillEnergyTank : Keyitem
{
    [SerializeField] private TextAsset first;
    [SerializeField] private TextAsset fail;
    private string[] dialogFirst;
    private string[] dialogFail;

    [SerializeField] private ItemData energyTankData;
    [SerializeField] private ItemData filledEnergyTankData;

    private bool isFirst = true;

    private void Start()
    {
        dialogFirst = first.text.Split('\n');
        dialogFail = fail.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        if (isFirst)
        {
            isFirst = false;
            Manager.Instance.DialogBox.StartTalk(dialogFirst, EndFirstDialog);
            return;
        }

        int energyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(energyTankData);
        if (energyTankIndex != -1)
        {
            Manager.Instance.OpenSceneUI("Fill Energy Tank Task", this);
        }
        else
        {
            Manager.Instance.DialogBox.StartTalk(dialogFail);
        }
    }
    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseSceneUI("Fill Energy Tank Task");
        int filledEnergyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(filledEnergyTankData);
        if (filledEnergyTankIndex != -1 && Manager.Instance.InventoryManager.items[filledEnergyTankIndex].itemQuantity >= 3)
        {
            Manager.Instance.room10.refillStationHint.SetActive(false);
        }
    }

    private void EndFirstDialog()
    {
        int energyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(energyTankData);
        if (energyTankIndex != -1)
        {
            Manager.Instance.OpenSceneUI("Fill Energy Tank Task", this);
        }
    }
}
