using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room_0_Computer_touch : Keyitem
{
    //new Collider2D collider;
    [SerializeField] GameObject computer_light;
    GameObject this_event;
    GameObject next_event;
    [SerializeField] TextAsset textFile;
    private TextAsset dialog01;
    private string[] dialog;

    // Start is called before the first frame update
    void Start()
    {
        //collider = GetComponent<Collider2D>();
        dialog = textFile.text.Split('\n');
        this_event = GameObject.Find("Robot_01_event_01");
        next_event = GameObject.Find("Robot_01_event_02");
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.X))
        // {
        //     Debug.Log("x");
        // }
    }
    public override void KeyitemEvent()
    {
        computer_light.GetComponent<Light2D>().color = Color.green;
        // Debug.Log("touch robot 01 in room 0");
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
        next_event.SetActive(true);
        this_event.SetActive(false);
        
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
