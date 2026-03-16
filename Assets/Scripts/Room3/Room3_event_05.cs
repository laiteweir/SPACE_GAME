using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3_event_05 : Keyitem
{
    [SerializeField] TextAsset file;
    private string[] dialog;
    private bool is_trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        dialog = file.text.Split("\n");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void KeyitemEvent()
    {
        Manager.Instance.DialogBoxUI.SetActive(true);
        Manager.Instance.DialogBox.TextIsOn = true;
        Manager.Instance.DialogBox.StartTalk(dialog);
        is_trigger = true;
    }

    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
