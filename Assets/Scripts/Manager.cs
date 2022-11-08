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
    public Inventory myBag;
    // the following valuables are for the process
    // [HideInInspector] public GameObject Room0_event1;
    // [HideInInspector] public GameObject Room0_event2;
    // [HideInInspector] public GameObject Room0_event2_light1;
    // [HideInInspector] public GameObject Room0_event2_light2;
    // [HideInInspector] public GameObject Room0_event2_light3;
    // [HideInInspector] public GameObject Room0_event2_light4;
    // [HideInInspector] public GameObject Room0_bigLight_1;
    public RoomZero room0;
    // [HideInInspector] public bool[] Room0_lights = new bool[4];
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
        // Room0_event1 = GameObject.Find("Robot_01_event_01");
        // Room0_event2 = GameObject.Find("Robot_01_event_02");
        // Room0_event2.SetActive(false);
        //     // init room0 light
        // Room0_event2_light1 = GameObject.Find("Room0_light_event2_1");
        // Room0_event2_light2 = GameObject.Find("Room0_light_event2_2");
        // Room0_event2_light3 = GameObject.Find("Room0_light_event2_3");
        // Room0_event2_light4 = GameObject.Find("Room0_light_event2_4");
        // Room0_bigLight_1 = GameObject.Find("Room0_bigLight_1");
        // this.room0_turn_off_lights_with_no_light();

        
    }

    
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
