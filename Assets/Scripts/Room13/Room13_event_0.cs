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
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
    }
}
