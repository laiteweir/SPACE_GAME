using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1_event_04 : Keyitem
{
    // Start is called before the first frame update
    
    [SerializeField] TextAsset textFile;
    //private TextAsset dialog01;
    private string[] dialog;
    private bool trigger_first = true;
    [SerializeField] GameObject next ;
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

    }
    public override void KeyitemEvent()
    {
        //computer_light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color.green;
        // Debug.Log("touch robot 01 in room 0");
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
        // make sure is not first trigger
        next.GetComponent<Door>().locked = false;
        Destroy(this);
        trigger_first = false;

        
    }
    public override void EndKeyitemEvent()
    {
         Debug.Log("test fire");
    }
}
