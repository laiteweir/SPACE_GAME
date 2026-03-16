using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room0_event_03 : Keyitem
{
    // Start is called before the first frame update
    [SerializeField] TextAsset textFile;
    private string[] dialog;
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void KeyitemEvent()
    {
        //enable next process
        Manager.Instance.DialogBoxUI.SetActive(true);
        Manager.Instance.DialogBox.TextIsOn = true;
        Manager.Instance.DialogBox.StartTalk(dialog);
        //Debug.Log(Manager.Instance.dialogBox.TextIsOn);
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
