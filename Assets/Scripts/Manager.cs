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

    [SerializeField] private Light2D globalLight;
    [SerializeField] private WalkingSound walkingSound;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private UIManager uiManager;
    private Stack<GameObject> uiStack = new Stack<GameObject>();
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private GameObject startMenuObject;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject dialogBoxUI;
    private DialogBox dialogBox;
    [SerializeField] private GameObject codePanel;
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
    
    public bool iswin = false;
    [HideInInspector] public InputActionMap actionMapPlayer;

    [HideInInspector] public Keyitem returnKeyitem;

    public GameObject Player { get => player; }
    public PlayerInput PlayerInput { get => playerInput; }
    public UIManager UIManager { get => uiManager; }
    public Stack<GameObject> UIStack { get => uiStack; }
    public InventoryManager InventoryManager { get => inventoryManager; }
    public PauseMenu PauseMenu { get => pauseMenu; }
    public Inventory Inventory { get => inventory; }
    public GameObject DialogBoxUI { get => dialogBoxUI; }
    public DialogBox DialogBox { get => dialogBox; private set => dialogBox = value; }
    public GameObject CodePanel { get => codePanel; }
    public WalkingSound WalkingSound { get => walkingSound; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        if (transform.parent == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        // playerInput = player.GetComponent<PlayerInput>();
        actionMapPlayer = PlayerInput.actions.FindActionMap("Player");
        DialogBox = DialogBoxUI.GetComponent<DialogBox>();
        UIStack.Push(startMenuObject);
    }

    // ち传 UI 家Α
    public void SwitchToUI()
    {
        PlayerInput.SwitchCurrentActionMap("UI");
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
    }
    // ち传笴栏家Α
    public void SwitchToPlayer()
    {
        PlayerInput.SwitchCurrentActionMap("Player");
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
        // Debug.Log("OpenSceneUI!");
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
    public IEnumerator OpenSceneRoutine(string sceneName, Keyitem keyitem)
    {
        OpenScene(sceneName, keyitem);
        yield break;
    }
    public IEnumerator OpenSceneUIRoutine(string sceneName, Keyitem keyitem)
    {
        OpenSceneUI(sceneName, keyitem);
        yield break;
    }

    public void SetDebugMode(bool globalLightOn, float x, float y)
    {
        Vector2 location = new(x, y);
        Player.transform.position = location;
        if (globalLightOn)
        {
            globalLight.enabled = true;
        }
        else
        {
            globalLight.enabled = false;
        }
    }

}
