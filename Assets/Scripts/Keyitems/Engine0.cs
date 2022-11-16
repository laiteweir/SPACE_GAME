using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine0 : Keyitem
{
    [SerializeField] TextAsset textFile;
    private string[] dialog;
    [SerializeField] Item filledEnergyTank;
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        if (Manager.Instance.myBag.itemList.Contains(filledEnergyTank) && filledEnergyTank.itemHeld == 3)
        {
            // Debug.Log("You have fixed Engine0!");
            Manager.Instance.room10.isEngine0Fixed = true;
            filledEnergyTank.itemHeld = 0;
            EndKeyitemEvent();
        }
        else
        {
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
        }
    }

    public override void EndKeyitemEvent()
    {
        Destroy(this);
    }
}
