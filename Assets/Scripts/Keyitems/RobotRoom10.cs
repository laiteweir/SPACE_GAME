using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRoom10 : Keyitem
{
    [SerializeField] private ItemData hintMapData;
    private Item hintMap;
    [SerializeField] private ItemData energyTankData;
    [SerializeField] private ItemData filledEnergyTankData;
    private TextAsset first;
    private TextAsset second;
    private TextAsset third;
    private TextAsset fourth;
    private TextAsset fifth;
    private TextAsset sixth;
    private string[] dialogFirst;
    private string[] dialogSecond;
    private string[] dialogThird;
    private string[] dialogFourth;
    private string[] dialogFifth;
    private string[] dialogSixth;

    private bool firstMeet = true;
    void Start()
    {
        first = Resources.Load<TextAsset>("Room2/Robot_first");
        second = Resources.Load<TextAsset>("Room2/Robot_second");
        third = Resources.Load<TextAsset>("Room2/Robot_third");
        fourth = Resources.Load<TextAsset>("Room2/Robot_fourth");
        fifth = Resources.Load<TextAsset>("Room2/Robot_fifth");
        sixth = Resources.Load<TextAsset>("Room2/Robot_sixth");
        dialogFirst = first.text.Split('\n');
        dialogSecond = second.text.Split('\n');
        dialogThird = third.text.Split('\n');
        dialogFourth = fourth.text.Split('\n');
        dialogFifth = fifth.text.Split('\n');
        dialogSixth = sixth.text.Split('\n');
        hintMap = Manager.Instance.InventoryManager.InstantiateItem(hintMapData);
    }
    public override void KeyitemEvent()
    {
        int energyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(energyTankData);
        int filledEnergyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(filledEnergyTankData);
        Manager.Instance.InventoryManager.AddItem(hintMap);
        // First time meet
        if (firstMeet)
        {
            firstMeet = false;
            Manager.Instance.DialogBox.StartTalk(dialogFirst);
        }
        // Player hasn't found all energy tanks
        else if (energyTankIndex == -1 || (Manager.Instance.InventoryManager.items[energyTankIndex].itemQuantity < 3 && Manager.Instance.InventoryManager.items[filledEnergyTankIndex].itemQuantity == 0 && !Manager.Instance.room10.isEngine0Fixed))
        {
            Manager.Instance.DialogBox.StartTalk(dialogSecond);
        }
        // Player hasn't filled all energy tanks
        else if (filledEnergyTankIndex == -1 || (Manager.Instance.InventoryManager.items[filledEnergyTankIndex].itemQuantity < 3 && !Manager.Instance.room10.isEngine0Fixed))
        {
            Manager.Instance.DialogBox.StartTalk(dialogThird);
        }
        // Player hasn't fixed engine0
        else if (!Manager.Instance.room10.isEngine0Fixed)
        {
            Manager.Instance.DialogBox.StartTalk(dialogFourth);
        }
        // Player hasn't fixed engine1
        else if (!Manager.Instance.room10.isEngine1Fixed)
        {
            Manager.Instance.DialogBox.StartTalk(dialogFifth);
        }
        else
        {
            Manager.Instance.DialogBox.StartTalk(dialogSixth);
        }
    }

    public override void EndKeyitemEvent()
    {
        Destroy(this);
    }
}
