using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool PMOn = false;

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
        Manager.Instance.actionMapPlayer.Enable();
    }
    public void Settings()
    {
        //Debug.Log("Settings");
    }
}
