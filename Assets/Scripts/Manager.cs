using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public GameObject globalLight;
    public GameObject player;
    public PlayerInput playerInput;
    public UIManager uiManager;
    public GameObject startMenuObject;
    public PauseMenu pauseMenu;
    public GameObject dialogBoxUI;
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
    public RoomThirteen room13;
    public Stack<GameObject> uiStack = new Stack<GameObject>();
    public WalkingSound walkingSound;
    public bool iswin = false;
    [HideInInspector] public InputActionMap actionMapPlayer;
    [HideInInspector] public DialogBox dialogBox;
    [HideInInspector] public Keyitem returnKeyitem;

    private void Awake()
    {
        if (Instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        // playerInput = player.GetComponent<PlayerInput>();
        actionMapPlayer = playerInput.actions.FindActionMap("Player");
        dialogBox = dialogBoxUI.GetComponent<DialogBox>();
        uiStack.Push(startMenuObject);
    }

    // ち传 UI 家Α
    public void SwitchToUI()
    {
        playerInput.SwitchCurrentActionMap("UI");
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
    }

    // ち传笴栏家Α
    public void SwitchToPlayer()
    {
        playerInput.SwitchCurrentActionMap("Player");
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }
    public void OpenScene(string name, Keyitem keyitem)
    {
        returnKeyitem = keyitem;
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }
    public void OpenSceneUI(string name, Keyitem keyitem)
    {
        returnKeyitem = keyitem;
        SwitchToUI();
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }
    public void CloseScene(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }
    public void CloseSceneUI(string name)
    {
        SceneManager.UnloadSceneAsync(name);
        SwitchToPlayer();
    }

    public void SetDebugMode(bool global_light_on, float x, float y)
    {
        Vector2 location = new(x, y);
        player.GetComponent<Transform>().position = location;
        if (global_light_on)
        {
            globalLight.GetComponent<Light2D>().enabled = true;
        }
        else
        {
            globalLight.GetComponent<Light2D>().enabled = false;
        }
    }

}
