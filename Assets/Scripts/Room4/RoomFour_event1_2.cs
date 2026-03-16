using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFour_event1_2 : Keyitem
{
    [SerializeField] TextAsset file;
    
    private string[] dialog;
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
        Manager.Instance.room4.event2 = true;



    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
