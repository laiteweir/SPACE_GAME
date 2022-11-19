using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room5_event_01 : Keyitem
{
    // Start is called before the first frame update
    [SerializeField] GameObject room_5_light;
    [SerializeField] GameObject room_6_light;

    [SerializeField] GameObject next;
    [SerializeField] TextAsset textFile;

    private string[] dialog;

    

    public override void KeyitemEvent()
    {
       room_5_light.SetActive(true);
       room_6_light.SetActive(true);
       next.SetActive(true);
       dialog = textFile.text.Split('\n');
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
    }

    public override void EndKeyitemEvent()
    {
        //this.first_trigger = false;
        Destroy(this);
    }
}
