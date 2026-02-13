using UnityEngine;

public class BaseMenu : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject tutorialFirstButton;
    [SerializeField] private GameObject settingFirstButton;

    public void Tutorial()
    {
        Manager.Instance.uiManager.OpenUI(tutorial, tutorialFirstButton);
    }
    public void Setting()
    {
        Manager.Instance.uiManager.OpenUI(setting, settingFirstButton);
    }
}
