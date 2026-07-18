using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseScene : MonoBehaviour
{
    protected InputAction exitAction;

    protected virtual void Awake()
    {
        exitAction = Manager.Instance.PlayerInput.actions["UI/Cancel"];
    }
    protected virtual void OnEnable()
    {
        exitAction.performed += OnExitScene;
    }
    protected virtual void OnDisable()
    {
        exitAction.performed -= OnExitScene;
    }
    public virtual void ExitScene()
    {
        Manager.Instance.returnKeyitem.EndKeyitemEvent();
    }
    protected virtual void OnExitScene(InputAction.CallbackContext context)
    {
        ExitScene();
    }
}
