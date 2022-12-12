using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFour_event1_3 : Keyitem
{
    [SerializeField] TextAsset file;
    [SerializeField] GameObject safe;
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
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);



    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
