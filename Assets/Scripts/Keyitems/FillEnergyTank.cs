using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillEnergyTank : Keyitem
{
    [SerializeField] TextAsset first;
    [SerializeField] TextAsset fail;
    private string[] dialogFirst;
    private string[] dialogFail;
    [SerializeField] Item energyTank;
    private bool isFirst = true;

    void Start()
    {
        dialogFirst = first.text.Split('\n');
        dialogFail = fail.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        if (isFirst)
        {
            isFirst = false;
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialogFirst);
        }
        else if (energyTank.itemHeld == 0)
        {
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialogFail);
        }
        else
        {
            Manager.Instance.OpenScene("Fill_Energy_Tank_Task", this);
        }
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseScene("Fill_Energy_Tank_Task");
    }
}
