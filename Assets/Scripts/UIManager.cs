using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public void OpenUI(GameObject ui, GameObject uiFirstButton)
    {
        ui.SetActive(true);
        Manager.Instance.uiStack.Push(ui);
        SetFocus(uiFirstButton);
    }
    public void OnBack()
    {
        if (Manager.Instance.uiStack.Count == 0)
        {
            return;
        }

        GameObject topUI = Manager.Instance.uiStack.Pop();
        topUI.SetActive(false);
        if (Manager.Instance.uiStack.Count > 0)
        {
            Button button = Manager.Instance.uiStack.Peek().GetComponentInChildren<Button>();
            if (button != null) 
            {
                SetFocus(button.gameObject);
            }
        }
        else
        {
            Manager.Instance.SwitchToPlayer();
        }
    }
    public void OnBack(InputAction.CallbackContext context)
    {
        OnBack();
    }
    public void OnBackStopBottom(InputAction.CallbackContext context)
    {
        if (Manager.Instance.uiStack.Count > 1)
        {
            OnBack();
        }
    }
    private void SetFocus(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }
}