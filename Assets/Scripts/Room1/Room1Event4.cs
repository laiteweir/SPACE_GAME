using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Event4 : Keyitem
{
    [SerializeField] private TextAsset textFile;
    //private TextAsset dialog01;
    private string[] dialog;
    [SerializeField] private GameObject nextDoor;
    // Start is called before the first frame update
    void Start()
    {
        //collider = GetComponent<Collider2D>();
        dialog = textFile.text.Split('\n');
        // this_event = GameObject.Find("Robot_01_event_01");
    }
    public override void KeyitemEvent()
    {
        //computer_light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color.green;
        // Debug.Log("touch robot 01 in room 0");
        Manager.Instance.DialogBoxUI.SetActive(true);
        Manager.Instance.DialogBox.StartTalk(dialog);
        // make sure is not first trigger
        nextDoor.GetComponent<Door>().locked = false;
        Destroy(this);
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
