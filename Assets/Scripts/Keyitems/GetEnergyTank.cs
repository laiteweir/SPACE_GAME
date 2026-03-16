using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnergyTank : Keyitem
{
    [SerializeField] private ItemData energyTankData;
    private Item energyTank;
    private TextAsset first;
    private TextAsset second;
    private TextAsset third;
    private string[] dialogFirst;
    private string[] dialogSecond;
    private string[] dialogThird;
    private void Start()
    {
        energyTank = Manager.Instance.InventoryManager.InstantiateItem(energyTankData);
        first = Resources.Load<TextAsset>("Room2/EnergyTank_first");
        second = Resources.Load<TextAsset>("Room2/EnergyTank_second");
        third = Resources.Load<TextAsset>("Room2/EnergyTank_third");
        dialogFirst = first.text.Split('\n');
        dialogSecond = second.text.Split('\n');
        dialogThird = third.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        Manager.Instance.InventoryManager.AddItem(energyTank);
        Manager.Instance.DialogBoxUI.SetActive(true);
        Manager.Instance.DialogBox.TextIsOn = true;
        int energyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(energyTank);
        int energyTankQuantity = Manager.Instance.InventoryManager.items[energyTankIndex].itemQuantity;
        switch (energyTankQuantity)
        {
            case 1:
                Manager.Instance.DialogBox.StartTalk(dialogFirst);
                break;
            case 2:
                Manager.Instance.DialogBox.StartTalk(dialogSecond);
                break;
            case 3:
                Manager.Instance.DialogBox.StartTalk(dialogThird);
                break;
        }
        EndKeyitemEvent();
    }

    public override void EndKeyitemEvent()
    {
        Destroy(this);
    }
}
