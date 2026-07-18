using UnityEngine;

public class Room10Event2 : Keyitem
{
    [SerializeField] private ItemData hintMapData;
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

    private void Start()
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
    }

    public override void KeyitemEvent()
    {        
        // First time meet
        if (firstMeet)
        {
            firstMeet = false;
            Manager.Instance.DialogBox.StartTalk(dialogFirst, EndFirstDialog);
            return;
        }

        if (Manager.Instance.room10.isEngine1Fixed)
        {
            if (!Manager.Instance.room10.isEngine2Fixed)
            {
                Manager.Instance.DialogBox.StartTalk(dialogFifth);
            }
            else
            {
                Manager.Instance.DialogBox.StartTalk(dialogSixth, EndKeyitemEvent);
            }
            return;
        }

        int energyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(energyTankData);
        int filledEnergyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(filledEnergyTankData);
        int emptyCount = (energyTankIndex == -1) ? 0 : Manager.Instance.InventoryManager.items[energyTankIndex].itemQuantity;
        int filledCount = (filledEnergyTankIndex == -1) ? 0 : Manager.Instance.InventoryManager.items[filledEnergyTankIndex].itemQuantity;
        int totalCount = emptyCount + filledCount;

        if (filledCount >= 3)
        {
            Manager.Instance.DialogBox.StartTalk(dialogFourth);
        }
        else if (totalCount >= 3)
        {
            Manager.Instance.DialogBox.StartTalk(dialogThird);
        }
        else
        {
            Manager.Instance.DialogBox.StartTalk(dialogSecond);
        }
    }
    public override void EndKeyitemEvent()
    {
        gameObject.SetActive(false);
        Manager.Instance.room0.UnlockRoom11Door();
    }

    private void EndFirstDialog()
    {
        Manager.Instance.InventoryManager.AddItem(hintMapData);
    }
}
