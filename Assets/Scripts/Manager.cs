using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public GameObject player;
    public GameObject PauseMenu;
    public GameObject ui;
    public GameObject codePanel;
    // the following valuables are for the process
    public GameObject Room0_event1;
    public GameObject Room0_event2;
    public GameObject Room0_event2_light1;
    public GameObject Room0_event2_light2;
    public GameObject Room0_event2_light3;
    public GameObject Room0_event2_light4;
    public GameObject Room0_bigLight_1;
    public bool[] Room0_lights = new bool[4];
    // process controller end
    [HideInInspector] public InputActionMap actionMapPlayer;
    [HideInInspector] public Pause pause;
    [HideInInspector] public DialogBox dialogBox;
    [HideInInspector] public Keyitem returnKeyitem;

    void Awake()
    {
        Instance = this;
        actionMapPlayer = player.GetComponent<PlayerInput>().actions.FindActionMap("Player");
        pause = PauseMenu.GetComponent<Pause>();
        dialogBox = ui.GetComponent<DialogBox>();
        // process controller
        // Debug.Log("in");
        // room0
        Room0_event1 = GameObject.Find("Robot_01_event_01");
        Room0_event2 = GameObject.Find("Robot_01_event_02");
        Room0_event2.SetActive(false);
            // init room0 light
        Room0_event2_light1 = GameObject.Find("Room0_light_event2_1");
        Room0_event2_light2 = GameObject.Find("Room0_light_event2_2");
        Room0_event2_light3 = GameObject.Find("Room0_light_event2_3");
        Room0_event2_light4 = GameObject.Find("Room0_light_event2_4");
        Room0_bigLight_1 = GameObject.Find("Room0_bigLight_1");
        this.room0_turn_off_lights_with_no_light();

        
    }
    // only for controll event2 light
    public bool room0_turn_off_lights_with_no_light()
    {
        Room0_event2_light1.GetComponent<Light2D>().enabled = false;
        Room0_event2_light2.GetComponent<Light2D>().enabled = false;
        Room0_event2_light3.GetComponent<Light2D>().enabled = false;
        Room0_event2_light4.GetComponent<Light2D>().enabled = false;
        Room0_bigLight_1.GetComponent<Light2D>().enabled = false;;
        return true;
    }
    public bool room0_turn_off_lights_with_red_light()
    {
        Room0_event2_light1.GetComponent<Light2D>().enabled = true;
        Room0_event2_light2.GetComponent<Light2D>().enabled = true;
        Room0_event2_light3.GetComponent<Light2D>().enabled = true;
        Room0_event2_light4.GetComponent<Light2D>().enabled = true;
        //turn to red
        Room0_event2_light1.GetComponent<Light2D>().color = Color.red;
        Room0_event2_light2.GetComponent<Light2D>().color = Color.red;
        Room0_event2_light3.GetComponent<Light2D>().color = Color.red;
        Room0_event2_light4.GetComponent<Light2D>().color = Color.red;
        this.Room0_lights = new bool[4] {false,false,false,false};
        return true;
    }
    public bool room0_turn_on_bigLight()
    {
        Room0_event2_light1.GetComponent<Light2D>().enabled = false;
        Room0_event2_light2.GetComponent<Light2D>().enabled = false;
        Room0_event2_light3.GetComponent<Light2D>().enabled = false;
        Room0_event2_light4.GetComponent<Light2D>().enabled = false;
        Room0_bigLight_1.GetComponent<Light2D>().enabled = true;
        return true;
    }
    public bool room0_event2_verify_light_sort(int sortNum)
    {
        // sort num mapping [light1,light2,light3,light4]
        bool result = false;
        for (int i = 0; i < sortNum; i++)
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
        for (int i = this.Room0_lights.Length; i > sortNum; i--){
            if(this.Room0_lights[i-1] == true){
                result = false;
                this.room0_turn_off_lights_with_red_light();
            }
        }
        return result;
    }
    // event2 light end
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("Turn on Pause menu");
            actionMapPlayer.Disable();
            PauseMenu.SetActive(true);
            pause.PMOn = true;
        }
    }

    public void OpenScene(string name, Keyitem keyitem)
    {
        returnKeyitem = keyitem;
        actionMapPlayer.Disable();
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    public void CloseScene(string name)
    {
        SceneManager.UnloadSceneAsync(name);
        actionMapPlayer.Enable();
    }
}
