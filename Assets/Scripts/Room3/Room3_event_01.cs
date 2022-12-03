using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3_event_01 : Keyitem
{
    [SerializeField] TextAsset file;
    [SerializeField] GameObject door;
    // Start is called before the first frame update
    private string[] dialog;
    private bool is_trigger = false;
    void Start()
    {
        dialog = file.text.Split("\n");
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.dialogBox.TextIsOn == false && is_trigger == true)
        {
            Manager.Instance.room3.room3_event3.SetActive(true);
            Manager.Instance.room3.room3_event1.SetActive(false);
        }
    }
    public override void KeyitemEvent()
    {
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
        door.GetComponent<Door>().locked = false;
        is_trigger = true;


    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
