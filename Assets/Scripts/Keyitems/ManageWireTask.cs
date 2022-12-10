using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ManageWireTask : Keyitem
{
    [SerializeField] TextAsset start;
    [SerializeField] TextAsset success;
    private string[] dialogStart;
    private string[] dialogSuccess;
    void Start()
    {
        dialogStart = start.text.Split('\n');
        dialogSuccess = success.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalkAndOpenScene(dialogStart, "Wire_Task", this);
        // Manager.Instance.OpenScene("Wire_Task", this);
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseScene("Wire_Task");
        // Debug.Log("You have fixed Engine1!");
        Manager.Instance.room10.engine1_hint.SetActive(false);
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialogSuccess);
        Manager.Instance.room10.isEngine1Fixed = true;
        Destroy(this);
    }
}
