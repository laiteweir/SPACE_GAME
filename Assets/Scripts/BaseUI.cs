using UnityEngine;
using UnityEngine.InputSystem;

public class BaseUI : MonoBehaviour
{
    protected InputAction backAction;

    protected virtual void Awake()
    {
        backAction = Manager.Instance.playerInput.actions["UI/Cancel"];
    }
    protected virtual void OnEnable()
    {
        backAction.performed += Manager.Instance.uiManager.OnBack;
    }
    protected virtual void OnDisable()
    {
        backAction.performed -= Manager.Instance.uiManager.OnBack;
    }
}
