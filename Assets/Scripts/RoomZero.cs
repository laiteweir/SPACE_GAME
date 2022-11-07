using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomZero : MonoBehaviour
{    
    [HideInInspector] public GameObject Room0_event1;
    [HideInInspector] public GameObject Room0_event2;
    [HideInInspector] public GameObject Room0_event3;
    [HideInInspector] public GameObject Room0_event2_light1;
    [HideInInspector] public GameObject Room0_event2_light2;
    [HideInInspector] public GameObject Room0_event2_light3;
    [HideInInspector] public GameObject Room0_event2_light4;
    [HideInInspector] public GameObject Room0_bigLight_1;
    [HideInInspector] public bool[] Room0_lights = new bool[4];

    // Start is called before the first frame update
    void Start()
    {
        this.Room0_event1 = GameObject.Find("Robot_01_event_01");
        this.Room0_event2 = GameObject.Find("Robot_01_event_02");
        this.Room0_event3 = GameObject.Find("Robot_01_event_03");
        this.Room0_event2.SetActive(false);
        this.Room0_event3.SetActive(false);
            // init room0 light
        this.Room0_event2_light1 = GameObject.Find("Room0_light_event2_1");
        this.Room0_event2_light2 = GameObject.Find("Room0_light_event2_2");
        this.Room0_event2_light3 = GameObject.Find("Room0_light_event2_3");
        this.Room0_event2_light4 = GameObject.Find("Room0_light_event2_4");
        this.Room0_bigLight_1 = GameObject.Find("Room0_bigLight_1");
        this.room0_turn_off_lights_with_no_light();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // only for controll event2 light
    public bool room0_turn_off_lights_with_no_light()
    {
        this.Room0_event2_light1.GetComponent<Light2D>().enabled = false;
        this.Room0_event2_light2.GetComponent<Light2D>().enabled = false;
        this.Room0_event2_light3.GetComponent<Light2D>().enabled = false;
        this.Room0_event2_light4.GetComponent<Light2D>().enabled = false;
        this.Room0_bigLight_1.GetComponent<Light2D>().enabled = false;;
        return true;
    }
    public bool room0_turn_off_lights_with_red_light()
    {
        this.Room0_event2_light1.GetComponent<Light2D>().enabled = true;
        this.Room0_event2_light2.GetComponent<Light2D>().enabled = true;
        this.Room0_event2_light3.GetComponent<Light2D>().enabled = true;
        this.Room0_event2_light4.GetComponent<Light2D>().enabled = true;
        //turn to red
        this.Room0_event2_light1.GetComponent<Light2D>().color = Color.red;
        this.Room0_event2_light2.GetComponent<Light2D>().color = Color.red;
        this.Room0_event2_light3.GetComponent<Light2D>().color = Color.red;
        this.Room0_event2_light4.GetComponent<Light2D>().color = Color.red;
        this.Room0_lights = new bool[4] {false,false,false,false};
        return true;
    }
    public bool room0_turn_on_bigLight()
    {
        this.Room0_event2_light1.GetComponent<Light2D>().enabled = false;
        this.Room0_event2_light2.GetComponent<Light2D>().enabled = false;
        this.Room0_event2_light3.GetComponent<Light2D>().enabled = false;
        this.Room0_event2_light4.GetComponent<Light2D>().enabled = false;
        this.Room0_event2_light1.SetActive(false);
        this.Room0_event2_light2.SetActive(false);
        this.Room0_event2_light3.SetActive(false);
        this.Room0_event2_light4.SetActive(false);
        this.Room0_bigLight_1.GetComponent<Light2D>().enabled = true;
        this.Room0_bigLight_1.GetComponent<Light2D>().intensity = 1;
        return true;
    }
    public bool room0_event2_verify_light_sort(int sortNum)
    {
        // sort num mapping [light1,light2,light3,light4]
        bool result = false;
        for (int i = 0; i < sortNum; ++i)
        {
            if(this.Room0_lights[i] == true){
                result = true;
            }
            else{
                result = false;
                this.room0_turn_off_lights_with_red_light();
            }
        }
        // check no light on after sortNum
        for (int i = this.Room0_lights.Length; i > sortNum; --i){
            if(this.Room0_lights[i-1] == true){
                result = false;
                this.room0_turn_off_lights_with_red_light();
            }
        }
        return result;
    }
    // event2 light end
}
