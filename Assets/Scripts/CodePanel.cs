using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CodePanel : BaseUI
{
    [SerializeField] private string passward = "0000";
    [SerializeField] private TMP_Text codeContext;
    
    [SerializeField] private GameObject codePanelFirstButton;
    private InputAction backspaceAction;
    private InputAction digit0Action;
    private InputAction digit1Action;
    private InputAction digit2Action;
    private InputAction digit3Action;
    private InputAction digit4Action;
    private InputAction digit5Action;
    private InputAction digit6Action;
    private InputAction digit7Action;
    private InputAction digit8Action;
    private InputAction digit9Action;
    private string codeValue = "";
    private bool doorOpen = false;

    // door_open Getter
    public bool GetDoorOpen()
    {
        return doorOpen;
    }
    // door_open Setter
    public void SetDoorOpen(bool input)
    {
        doorOpen = input;
    }

    protected override void Awake()
    {
        base.Awake();
        backspaceAction = Manager.Instance.PlayerInput.actions["UI/Backspace"];
        digit0Action = Manager.Instance.PlayerInput.actions["UI/Digit0"];
        digit1Action = Manager.Instance.PlayerInput.actions["UI/Digit1"];
        digit2Action = Manager.Instance.PlayerInput.actions["UI/Digit2"];
        digit3Action = Manager.Instance.PlayerInput.actions["UI/Digit3"];
        digit4Action = Manager.Instance.PlayerInput.actions["UI/Digit4"];
        digit5Action = Manager.Instance.PlayerInput.actions["UI/Digit5"];
        digit6Action = Manager.Instance.PlayerInput.actions["UI/Digit6"];
        digit7Action = Manager.Instance.PlayerInput.actions["UI/Digit7"];
        digit8Action = Manager.Instance.PlayerInput.actions["UI/Digit8"];
        digit9Action = Manager.Instance.PlayerInput.actions["UI/Digit9"];
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        backspaceAction.performed += OnDelete;
        digit0Action.performed += OnDigit0;
        digit1Action.performed += OnDigit1; 
        digit2Action.performed += OnDigit2;
        digit3Action.performed += OnDigit3;
        digit4Action.performed += OnDigit4;
        digit5Action.performed += OnDigit5;
        digit6Action.performed += OnDigit6;
        digit7Action.performed += OnDigit7;
        digit8Action.performed += OnDigit8;
        digit9Action.performed += OnDigit9;
    }
    protected override void OnDisable()
    {
        backspaceAction.performed -= OnDelete;
        digit0Action.performed -= OnDigit0;
        digit1Action.performed -= OnDigit1;
        digit2Action.performed -= OnDigit2;
        digit3Action.performed -= OnDigit3;
        digit4Action.performed -= OnDigit4;
        digit5Action.performed -= OnDigit5;
        digit6Action.performed -= OnDigit6;
        digit7Action.performed -= OnDigit7;
        digit8Action.performed -= OnDigit8;
        digit9Action.performed -= OnDigit9;
        base.OnDisable();
    }

    public void OpenCodePanel()
    {
        // Debug.Log("Turn on pause menu");
        Manager.Instance.UIManager.OpenUI(gameObject, codePanelFirstButton);
    }
    // Update is called once per frame
    void Update()
    {
        codeContext.text = codeValue;
    }

    public void AddDigit(string digit)
    {
        // Debug.Log(digit);
        if (codeValue.Length < 4)
        {
            codeValue += digit;
            // Debug.Log(codeValue);
        }
    }
    public void Clear()
    {
        codeValue = "";
        // Debug.Log("Clear input!");
    }
    public void Confirm()
    {
        if (codeValue == passward)
        {
            SetDoorOpen(true);
            // Debug.Log("The door is opened");
        }
    }
    public void Delete()
    {
        if (codeValue.Length > 0)
        {
            codeValue = codeValue[0..^1]; // Delete the last digit
        }
        // Debug.Log(codeValue);
    }
    private void OnDelete(InputAction.CallbackContext context)
    {
        Delete();
    }
    private void OnDigit0(InputAction.CallbackContext context)
    {
        AddDigit("0");
    }
    private void OnDigit1(InputAction.CallbackContext context)
    {
        AddDigit("1");
    }
    private void OnDigit2(InputAction.CallbackContext context)
    {
        AddDigit("2");
    }
    private void OnDigit3(InputAction.CallbackContext context)
    {
        AddDigit("3");
    }
    private void OnDigit4(InputAction.CallbackContext context)
    {
        AddDigit("4");
    }
    private void OnDigit5(InputAction.CallbackContext context)
    {
        AddDigit("5");
    }
    private void OnDigit6(InputAction.CallbackContext context)
    {
        AddDigit("6");
    }
    private void OnDigit7(InputAction.CallbackContext context)
    {
        AddDigit("7");
    }
    private void OnDigit8(InputAction.CallbackContext context)
    {
        AddDigit("8");
    }
    private void OnDigit9(InputAction.CallbackContext context)
    {
        AddDigit("9");
    }
}