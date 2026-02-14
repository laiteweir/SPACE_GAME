using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : BaseMenu
{
    private InputAction backAction;
    [SerializeField] GameObject pauseMenuFirstButton;

    private void Awake()
    {
        backAction = Manager.Instance.playerInput.actions["UI/Cancel"];
    }
    private void OnEnable()
    {
        backAction.performed += Manager.Instance.uiManager.OnBack;
    }
    private void OnDisable()
    {
        backAction.performed -= Manager.Instance.uiManager.OnBack;
    }

    public void OnPausePerformed(InputAction.CallbackContext context)
    {
        // Debug.Log("Turn on pause menu");
        Manager.Instance.uiManager.OpenUI(gameObject, pauseMenuFirstButton);
    }
    public void Resume()
    {
        // Debug.Log("Resume");
        Manager.Instance.uiManager.Back();
    }
    public void Exit()
    {
        // Debug.Log("Exit");
        Application.Quit();
    }
}
