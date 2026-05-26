using UnityEngine;

public class GetEnergyTank : Keyitem
{
    [SerializeField] private ItemData energyTankData;

    private TextAsset first;
    private TextAsset second;
    private TextAsset third;
    private string[] dialogFirst;
    private string[] dialogSecond;
    private string[] dialogThird;

    private void Start()
    {
        first = Resources.Load<TextAsset>("Room2/EnergyTank_first");
        second = Resources.Load<TextAsset>("Room2/EnergyTank_second");
        third = Resources.Load<TextAsset>("Room2/EnergyTank_third");
        dialogFirst = first.text.Split('\n');
        dialogSecond = second.text.Split('\n');
        dialogThird = third.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        Manager.Instance.InventoryManager.AddItem(energyTankData);
        int energyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(energyTankData);
        int energyTankQuantity = Manager.Instance.InventoryManager.items[energyTankIndex].itemQuantity;
        switch (energyTankQuantity)
        {
            case 1:
                Manager.Instance.DialogBox.StartTalk(dialogFirst, EndKeyitemEvent);
                break;
            case 2:
                Manager.Instance.DialogBox.StartTalk(dialogSecond, EndKeyitemEvent);
                break;
            case 3:
                Manager.Instance.DialogBox.StartTalk(dialogThird, EndKeyitemEvent);
                break;
        }
    }
    public override void EndKeyitemEvent()
    {
        gameObject.SetActive(false);
    }
}
