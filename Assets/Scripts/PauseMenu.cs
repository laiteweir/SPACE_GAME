using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : BaseMenu
{
    private InputAction backAction;
    [SerializeField] private GameObject pauseMenuFirstButton;

    private void Awake()
    {
        backAction = Manager.Instance.PlayerInput.actions["UI/Cancel"];
    }
    private void OnEnable()
    {
        backAction.performed += Manager.Instance.UIManager.OnBack;
    }
    private void OnDisable()
    {
        backAction.performed -= Manager.Instance.UIManager.OnBack;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        // Debug.Log("Turn on pause menu");
        Manager.Instance.UIManager.OpenUI(gameObject, pauseMenuFirstButton);
    }
    public void Resume()
    {
        // Debug.Log("Resume");
        Manager.Instance.UIManager.Back();
    }
    public void Exit()
    {
        // Debug.Log("Exit");
        Application.Quit();
    }
}
