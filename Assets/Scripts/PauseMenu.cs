using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenu : BaseMenu
{
    [SerializeField] GameObject pauseMenuFirstButton;
    private void OnEnable()
    {
        backAction.performed += OnBack;
    }
    private void OnDisable()
    {
        backAction.performed -= OnBack;
    }
    public void OnPausePerformed(InputAction.CallbackContext context)
    {
        // Debug.Log("Turn on pause menu");
        Manager.Instance.SwitchToUI();
        OpenUI(gameObject, pauseMenuFirstButton);
    }
    public void Resume()
    {
        // Debug.Log("Resume");
        OnBack();
    }
    public void Exit()
    {
        // Debug.Log("Exit");
        Application.Quit();
    }
}
