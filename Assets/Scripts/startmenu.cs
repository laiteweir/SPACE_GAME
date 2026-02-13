using UnityEngine;
using UnityEngine.InputSystem;

public class StartMenu : BaseMenu
{
    private InputAction backAction;

    private void Awake()
    {
        backAction = Manager.Instance.playerInput.actions["UI/Cancel"];
    }
    private void OnEnable()
    {
        backAction.performed += Manager.Instance.uiManager.OnBackStopBottom;
    }
    private void OnDisable()
    {
        backAction.performed -= Manager.Instance.uiManager.OnBackStopBottom;
    }

    public void StartGame()
    {
        // Debug.Log("Start Game");
        Manager.Instance.uiManager.OnBack();
    }
    // public void Exit()
    // {
    //     Debug.Log("Exit");
    //     Application.Quit();
    // }
}
