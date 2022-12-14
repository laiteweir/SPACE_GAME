using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room7_event_01 : Keyitem
{
    //new Collider2D collider;
    // [SerializeField] GameObject computer_light;
    //GameObject this_event;

    [SerializeField] TextAsset textFile;
    //private TextAsset dialog01;
    private string[] dialog;

    private bool first_trigger = true;
    [SerializeField] public GameObject alien1;
    [SerializeField] public GameObject alien2;
    [SerializeField] public GameObject alien3;
    [SerializeField] public GameObject alien4;
    [SerializeField] public GameObject alien5;

    [SerializeField] public GameObject alien6;
    [SerializeField] public GameObject alien7;
    [SerializeField] public GameObject alien8;
    [SerializeField] public GameObject alien9;
    [SerializeField] public GameObject alien10;

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
        // if (Manager.Instance.dialogBox.TextIsOn == false && trigger_first == false){
        //     Manager.Instance.room0.room0_event1.SetActive(false);
        //     Manager.Instance.room0.room0_event2.SetActive(true);
        //     Manager.Instance.room0.Room0_turn_off_lights_with_red_light();
        // }
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if(this.first_trigger && col.gameObject.name == "Player"){
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
            this.first_trigger = false;
            this.trigger_aliens();
        }
        // Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }    
    public void trigger_aliens(){
        this.alien1.SetActive(true);
        this.alien2.SetActive(true);
        this.alien3.SetActive(true);
        this.alien4.SetActive(true);
        this.alien5.SetActive(true);
        this.alien6.SetActive(true);
        this.alien7.SetActive(true);
        this.alien8.SetActive(true);
        this.alien9.SetActive(true);
        this.alien10.SetActive(true);
    }
    public void stop_aliens(){
        this.alien1.SetActive(false);
        this.alien2.SetActive(false);
        this.alien3.SetActive(false);
        this.alien4.SetActive(false);
        this.alien5.SetActive(false);
        this.alien6.SetActive(false);
        this.alien7.SetActive(false);
        this.alien8.SetActive(false);
        this.alien9.SetActive(false);
        this.alien10.SetActive(false);
    }
    public override void KeyitemEvent()
    {
        // computer_light.GetComponent<Light2D>().color = Color.green;
        // Debug.Log("touch robot 01 in room 0");
        // Manager.Instance.ui.SetActive(true);
        // Manager.Instance.dialogBox.TextIsOn = true;
        // Manager.Instance.dialogBox.StartTalk(dialog);
        // // make sure is not first trigger
        // trigger_first = false;

        
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
