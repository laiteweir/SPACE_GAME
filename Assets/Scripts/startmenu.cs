using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class StartMenu : BaseMenu
{
    private void OnEnable()
    {
        backAction.performed += OnBack;
    }
    private void OnDisable()
    {
        backAction.performed -= OnBack;
    }
    protected override void OnBack(InputAction.CallbackContext context)
    {
        // 只有當 Stack 裡不只一個東西（代表有子選單開著）時，才執行返回
        if (Manager.Instance.uiStack.Count > 1)
        {
            base.OnBack(context);
        }
    }
    public void StartGame()
    {
        // Debug.Log("Start Game");
        OnBack();
    }
    // public void Exit()
    // {
    //     Debug.Log("Exit");
    //     Application.Quit();
    // }
}
