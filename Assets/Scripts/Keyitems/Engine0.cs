using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine0 : Keyitem
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
        if (Manager.Instance.myBag.itemList.Contains(energyTank) && energyTank.itemHeld == 3)
        {
            // Debug.Log("You have fixed Engine0!");
            Manager.Instance.room10.isEngine0Fixed = true;
            energyTank.itemHeld = 0;
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
