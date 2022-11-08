using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomZero : MonoBehaviour
{    
    public GameObject room0_event1;
    public GameObject room0_event2;
    public GameObject room0_event3;
    public List<Light2D> room0_event2_light;
    public Light2D room0_bigLight_1;
    [HideInInspector] public bool[] room0_lights = { false, false, false, false };
    
    //public bool createKeyCard = false;
    [SerializeField] GameObject keycard;

    // Start is called before the first frame update
    void Start()
    {
        /*this.Room0_event1 = GameObject.Find("Robot_01_event_01");
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
        this.room0_turn_off_lights_with_no_light();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // only for controll event2 light
    /*public bool room0_turn_off_lights_with_no_light()
    {
        this.Room0_event2_light1.GetComponent<Light2D>().enabled = false;
        this.Room0_event2_light2.GetComponent<Light2D>().enabled = false;
        this.Room0_event2_light3.GetComponent<Light2D>().enabled = false;
        this.Room0_event2_light4.GetComponent<Light2D>().enabled = false;
        this.Room0_bigLight_1.GetComponent<Light2D>().enabled = false;;
        return true;
    }*/
    public bool Room0_turn_off_lights_with_red_light()
    {
        foreach (Light2D light in room0_event2_light)
        {
            light.enabled = true;
            light.color = Color.red;
        }
        return true;
    }
    public bool Room0_turn_on_bigLight()
    {
        foreach (Light2D light in room0_event2_light)
        {
            light.enabled = false;
        }
        /*room0_event2_light1.enabled = false;
        room0_event2_light2.enabled = false;
        room0_event2_light3.enabled = false;
        room0_event2_light4.enabled = false;
        this.Room0_event2_light1.SetActive(false);
        this.Room0_event2_light2.SetActive(false);
        this.Room0_event2_light3.SetActive(false);
        this.Room0_event2_light4.SetActive(false);*/
        room0_bigLight_1.enabled = true;
        room0_bigLight_1.intensity = 1f;
        //createKeyCard = true;
        Instantiate(keycard);
        return true;
    }
    public bool Room0_event2_verify_light_sort(int sortNum)
    {
        // sort num mapping [light1,light2,light3,light4]
        bool result = true;
        for (int i = 0; i < sortNum; ++i)
        {
            if (room0_lights[i] != true){
                result = false;
                Room0_turn_off_lights_with_red_light();
            }
        }
        // check no light on after sortNum
        /*for (int i = this.Room0_lights.Length; i > sortNum; --i){
            if(this.Room0_lights[i-1] == true){
                result = false;
                this.room0_turn_off_lights_with_red_light();
            }
        }*/
        return result;
    }
    // event2 light end
}
