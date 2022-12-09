using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Engine0 : Keyitem
{
    [SerializeField] TextAsset success;
    [SerializeField] TextAsset fail;
    private string[] dialogSuccess;
    private string[] dialogFail;
    [SerializeField] Item filledEnergyTank;
    void Start()
    {
        dialogSuccess = success.text.Split('\n');
        dialogFail = fail.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        if (Manager.Instance.myBag.itemList.Contains(filledEnergyTank) && filledEnergyTank.itemHeld >= 3)
        {
            // Debug.Log("You have fixed Engine0!");
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialogSuccess);
            Manager.Instance.room10.isEngine0Fixed = true;
            filledEnergyTank.itemHeld = 0;
            Manager.Instance.room10.engine0_hint.SetActive(false);
            EndKeyitemEvent();
        }
        else
        {
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialogFail);
        }
    }

    public override void EndKeyitemEvent()
    {
        Destroy(this);
    }
}
