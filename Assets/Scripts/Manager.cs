using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public GameObject globalLight;

    public GameObject player;
    public PlayerController playerController;
    public GameObject PauseMenu;
    public GameObject ui;
    public GameObject codePanel;
    public Inventory myBag;
    public RoomZero room0;
    public RoomOne room1;
    public RoomTwo room2;
    public RoomThree room3;
    public RoomFour room4;
    public RoomFive room5;
    public RoomSix room6;
    public RoomSeven room7;
    public RoomEight room8;
    public RoomNine room9;
    public RoomTen room10;
    public RoomEleven room11;
    public RoomTwelve room12;
    public RoomThirteen room13;
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

    public void SetDebugMode(bool debug, float x, float y)
    {
        Vector2 location;
        location.x = x;
        location.y = y;
        if(debug == true){
            this.globalLight.GetComponent<Light2D>().enabled = true;
            this.player.GetComponent<Transform>().position = location;
        }
        else{
            this.globalLight.GetComponent<Light2D>().enabled = false;
        }
    }
    public void SetDebugMode(bool debug,bool global_light, float x, float y)
    {
        Vector2 location;
        location.x = x;
        location.y = y;
        if(debug == true){
            this.globalLight.GetComponent<Light2D>().enabled = true;
            this.player.GetComponent<Transform>().position = location;
        }
        else{
            this.globalLight.GetComponent<Light2D>().enabled = false;
        }
        if(global_light == false){
            this.globalLight.GetComponent<Light2D>().enabled = false;
        }
    }
}
