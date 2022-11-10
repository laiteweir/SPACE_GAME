using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1_event_01 :  Keyitem
{
    // Start is called before the first frame update
    [SerializeField] GameObject computer_light;
    //GameObject this_event;

    [SerializeField] TextAsset textFile;
    //private TextAsset dialog01;
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
            Manager.Instance.room0.room0_event1.SetActive(false);
            Manager.Instance.room0.room0_event2.SetActive(true);
            Manager.Instance.room0.Room0_turn_off_lights_with_red_light();
        }
    }
    public override void KeyitemEvent()
    {
        computer_light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color.green;
        // Debug.Log("touch robot 01 in room 0");
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
        // make sure is not first trigger
        trigger_first = false;

        
    }
    public override void EndKeyitemEvent()
    {
         Debug.Log("test fire");
    }
}
