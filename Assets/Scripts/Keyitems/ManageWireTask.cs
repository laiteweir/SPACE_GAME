using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ManageWireTask : Keyitem
{
    [SerializeField] private TextAsset start;
    [SerializeField] private TextAsset success;
    private string[] dialogStart;
    private string[] dialogSuccess;
    void Start()
    {
        dialogStart = start.text.Split('\n');
        dialogSuccess = success.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        Manager.Instance.DialogBoxUI.SetActive(true);
        Manager.Instance.DialogBox.StartTalkAndOpenSceneUI(dialogStart, "Wire Task", this);
        // Manager.Instance.OpenScene("Wire_Task", this);
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseSceneUI("Wire Task");
        // Debug.Log("You have fixed Engine1!");
        Manager.Instance.room10.engine1Hint.SetActive(false);
        Manager.Instance.DialogBoxUI.SetActive(true);
        Manager.Instance.DialogBox.StartTalk(dialogSuccess);
        Manager.Instance.room10.isEngine1Fixed = true;
        Destroy(this);
    }
}
