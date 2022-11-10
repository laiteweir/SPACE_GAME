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
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
        //Debug.Log(Manager.Instance.dialogBox.TextIsOn);
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
