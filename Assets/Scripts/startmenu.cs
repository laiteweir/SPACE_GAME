using UnityEngine;
using UnityEngine.InputSystem;

public class StartMenu : BaseMenu
{
    private InputAction backAction;

    private void Awake()
    {
        backAction = Manager.Instance.PlayerInput.actions["UI/Cancel"];
    }
    private void OnEnable()
    {
        backAction.performed += Manager.Instance.UIManager.OnBackStopBottom;
    }
    private void OnDisable()
    {
        backAction.performed -= Manager.Instance.UIManager.OnBackStopBottom;
    }

    public void StartGame()
    {
        // Debug.Log("Start Game");
        Manager.Instance.UIManager.Back();
    }
    // public void Exit()
    // {
    //     Debug.Log("Exit");
    //     Application.Quit();
    // }
}
