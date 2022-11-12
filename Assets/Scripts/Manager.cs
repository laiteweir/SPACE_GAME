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
    public RoomZero room0;
    public RoomOne room1;
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
}
