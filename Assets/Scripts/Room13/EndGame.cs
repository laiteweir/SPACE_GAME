using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : Keyitem
{
    private TextAsset first;
    private string[] dialogFirst;
    private void Start()
    {
        first = Resources.Load<TextAsset>("Room2/EnergyTank_first");
        dialogFirst = first.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalkAndOpenScene(dialogFirst, "Ending", this);
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseScene("Ending");
    }
}
