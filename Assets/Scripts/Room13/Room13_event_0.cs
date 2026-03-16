using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room13_event_0 : Keyitem
{
    // Start is called before the first frame update
    [SerializeField] TextAsset textFile;
    private string[] dialog;
    
    //public Item shield;
    void Start(){
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent(){
        Manager.Instance.DialogBoxUI.SetActive(true);
        Manager.Instance.DialogBox.TextIsOn = true;
        Manager.Instance.DialogBox.StartTalk(dialog);
    }
}
