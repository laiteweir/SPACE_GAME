using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Pause : MonoBehaviour
{
    private bool PMOn = false;
    [SerializeField] GameObject tutorial;
    [SerializeField] GameObject setting;
    [SerializeField] GameObject startMenuFirstButton;
    [SerializeField] GameObject pauseMenuFirstButton;
    [SerializeField] GameObject tutorialFirstButton;
    [SerializeField] GameObject settingFirstButton;
    public void PerformPause()
    {
        gameObject.SetActive(true);
        PMOn = true;
        Manager.Instance.SwitchToUI();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseMenuFirstButton);
    }
    public void Exit()
    {
        //Debug.Log("Exit");
        Application.Quit();
    }
    public void Resume()
    {
        //Debug.Log("Resume");
        gameObject.SetActive(false);
        PMOn = false;
        Manager.Instance.SwitchToPlayer();
    }
    public void Tutorial()
    {
        tutorial.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(tutorialFirstButton);
    }
    public void TutorialBack()
    {
        tutorial.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        if (PMOn)
        {
            EventSystem.current.SetSelectedGameObject(pauseMenuFirstButton);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(startMenuFirstButton);
        }
    }
    public void Setting()
    {
        setting.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingFirstButton);
    }
    public void SettingBack()
    {
        setting.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        if (PMOn)
        {
            EventSystem.current.SetSelectedGameObject(pauseMenuFirstButton);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(startMenuFirstButton);
        }
    }
}
