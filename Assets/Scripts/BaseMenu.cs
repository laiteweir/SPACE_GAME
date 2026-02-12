using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BaseMenu : BaseUI
{
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject tutorialFirstButton;
    [SerializeField] private GameObject settingFirstButton;
    public void Tutorial()
    {
        OpenUI(tutorial, tutorialFirstButton);
    }
    public void Setting()
    {
        OpenUI(setting, settingFirstButton);
    }
}
