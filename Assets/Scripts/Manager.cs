using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

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
        Room0_event1 = GameObject.Find("Robot_01_event_01");
        Room0_event2 = GameObject.Find("Robot_01_event_02");
        Room0_event2.SetActive(false);
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
