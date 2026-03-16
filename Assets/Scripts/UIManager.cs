using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public void OpenUI(GameObject ui, GameObject uiFirstButton)
    {
        Manager.Instance.SwitchToUI();
        ui.SetActive(true);
        Manager.Instance.UIStack.Push(ui);
        SetFocus(uiFirstButton);
    }
    public void Back()
    {
        if (Manager.Instance.UIStack.Count == 0)
        {
            return;
        }

        GameObject topUI = Manager.Instance.UIStack.Pop();
        topUI.SetActive(false);
        if (Manager.Instance.UIStack.Count > 0)
        {
            Button button = Manager.Instance.UIStack.Peek().GetComponentInChildren<Button>();
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
        Back();
    }
    public void OnBackStopBottom(InputAction.CallbackContext context)
    {
        if (Manager.Instance.UIStack.Count > 1)
        {
            Back();
        }
    }
    private void SetFocus(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }
}