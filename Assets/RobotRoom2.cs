using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRoom2 : Keyitem
{
    [SerializeField] Item hintMap;
    [SerializeField] Item energyTank;
    [SerializeField] Item filledEnergyTank;
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
    }
    public override void KeyitemEvent()
    {
        if (!Manager.Instance.myBag.itemList.Contains(hintMap))
        {
            if (Manager.Instance.myBag.itemList.Count == 0)
            {
                InventoryManager.CreateNewItem(hintMap);
            }
            else
            {
                ++hintMap.itemHeld;
            }
            Manager.Instance.myBag.itemList.Add(hintMap);
        }
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;

        // First time meet
        if (firstMeet)
        {
            firstMeet = false;
            Manager.Instance.dialogBox.StartTalk(dialogFirst);
        }
        // Player hasn't found all energy tanks
        else if (energyTank.itemHeld < 3 && filledEnergyTank.itemHeld == 0 && !Manager.Instance.room10.isEngine0Fixed)
        {
            Manager.Instance.dialogBox.StartTalk(dialogSecond);
        }
        // Player hasn't filled all energy tanks
        else if (filledEnergyTank.itemHeld < 3 && !Manager.Instance.room10.isEngine0Fixed)
        {
            Manager.Instance.dialogBox.StartTalk(dialogThird);
        }
        // Player hasn't fixed engine0
        else if (!Manager.Instance.room10.isEngine0Fixed)
        {
            Manager.Instance.dialogBox.StartTalk(dialogFourth);
        }
        // Player hasn't fixed engine1
        else if (!Manager.Instance.room10.isEngine1Fixed)
        {
            Manager.Instance.dialogBox.StartTalk(dialogFifth);
        }
        else
        {
            Manager.Instance.dialogBox.StartTalk(dialogSixth);
        }
    }

    public override void EndKeyitemEvent()
    {
        Destroy(this);
    }
}
