using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseUI : MonoBehaviour
{
    protected InputAction backAction;

    protected virtual void Awake()
    {
        backAction = Manager.Instance.PlayerInput.actions["UI/Cancel"];
    }
    protected virtual void OnEnable()
    {
        backAction.performed += Manager.Instance.UIManager.OnBack;
    }
    protected virtual void OnDisable()
    {
        backAction.performed -= Manager.Instance.UIManager.OnBack;
    }
}
