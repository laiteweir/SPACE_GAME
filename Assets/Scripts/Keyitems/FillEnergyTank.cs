using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillEnergyTank : Keyitem
{
    [SerializeField] TextAsset textFile;
    private string[] dialog;
    [SerializeField] Item energyTank;

    void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        if (energyTank.itemHeld == 0)
        {
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
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
