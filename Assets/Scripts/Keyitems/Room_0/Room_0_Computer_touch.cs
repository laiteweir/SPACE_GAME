using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room_0_Computer_touch : Keyitem
{
    //new Collider2D collider;
    [SerializeField] GameObject computer_light;
    GameObject this_event;

    [SerializeField] TextAsset textFile;
    private TextAsset dialog01;
    private string[] dialog;
    private bool trigger_first = true;

    // Start is called before the first frame update
    void Start()
    {
        //collider = GetComponent<Collider2D>();
        dialog = textFile.text.Split('\n');
        // this_event = GameObject.Find("Robot_01_event_01");
    }

    // Update is called once per frame
    void Update()
    {
        //enable next process
        if (Manager.Instance.dialogBox.TextIsOn == false && trigger_first == false){
            Manager.Instance.Room0_event1.SetActive(false);
            Manager.Instance.Room0_event2.SetActive(true);
        }
    }
    public override void KeyitemEvent()
    {
        computer_light.GetComponent<Light2D>().color = Color.green;
        // Debug.Log("touch robot 01 in room 0");
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
        // make sure is not first trigger
        trigger_first = false;

        
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
