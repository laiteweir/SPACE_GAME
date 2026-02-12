using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
    protected InputAction backAction;
    protected void Awake()
    {
        backAction = Manager.Instance.playerInput.actions["UI/Cancel"];
    }
    public void OpenUI(GameObject ui, GameObject uiFirstButton)
    {
        ui.SetActive(true);
        Manager.Instance.uiStack.Push(ui);
        SetFocus(uiFirstButton);
    }
    public virtual void OnBack()
    {
        if (Manager.Instance.uiStack.Count != 0)
        {
            GameObject topUI = Manager.Instance.uiStack.Pop();
            topUI.SetActive(false);
            if (Manager.Instance.uiStack.Count != 0)
            {
                Button button = Manager.Instance.uiStack.Peek().GetComponentInChildren<Button>();
                SetFocus(button.gameObject);
            }
            else
            {
                Manager.Instance.SwitchToPlayer();
            }
        }
    }
    protected virtual void OnBack(InputAction.CallbackContext context)
    {
        OnBack();
    }
    protected void SetFocus(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }
}