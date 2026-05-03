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
        exitAction.performed += OnSceneExit;
    }
    protected virtual void OnDisable()
    {
        exitAction.performed -= OnSceneExit;
    }
    public virtual void SceneExit()
    {
        Manager.Instance.returnKeyitem.EndKeyitemEvent();
    }
    protected virtual void OnSceneExit(InputAction.CallbackContext context)
    {
        SceneExit();
    }
}
