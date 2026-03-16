using UnityEngine;

public class BaseMenu : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject tutorialFirstButton;
    [SerializeField] private GameObject settingFirstButton;

    public void Tutorial()
    {
        Manager.Instance.UIManager.OpenUI(tutorial, tutorialFirstButton);
    }
    public void Setting()
    {
        Manager.Instance.UIManager.OpenUI(setting, settingFirstButton);
    }
}
