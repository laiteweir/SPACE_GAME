using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnergyTank : Keyitem
{
    [SerializeField] Item energyTank;
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
        if (!Manager.Instance.myBag.itemList.Contains(energyTank))
        {
            if (Manager.Instance.myBag.itemList.Count == 0)
            {
                InventoryManager.CreateNewItem(energyTank);
            }
            Manager.Instance.myBag.itemList.Add(energyTank);
        }
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        switch (++energyTank.itemHeld)
        {
            case 1:
                Manager.Instance.dialogBox.StartTalk(dialogFirst);
                break;
            case 2:
                Manager.Instance.dialogBox.StartTalk(dialogSecond);
                break;
            case 3:
                Manager.Instance.dialogBox.StartTalk(dialogThird);
                break;
        }
                EndKeyitemEvent();
    }

    public override void EndKeyitemEvent()
    {
        Destroy(this);
    }
}
