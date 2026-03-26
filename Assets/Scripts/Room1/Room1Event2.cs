using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Event2 : Keyitem
{
    [SerializeField] private GameObject next;
    [SerializeField] private TextAsset textFile;
    //private TextAsset dialog01;
    private string[] dialog;
    // Start is called before the first frame update
    void Start()
    {
        //collider = GetComponent<Collider2D>();
        dialog = textFile.text.Split('\n');
        // this_event = GameObject.Find("Robot_01_event_01");
    }
    public override void KeyitemEvent()
    {
        Manager.Instance.DialogBox.StartTalk(dialog);
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
