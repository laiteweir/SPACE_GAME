using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool PMOn = false;

    public void Exit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void Close()
    {
        Debug.Log("Close");
        Manager.Instance.PauseManu.SetActive(false);
        Manager.Instance.pause.PMOn = false;
    }
    public void Setting()
    {
        Debug.Log("quit");
    }
    public void Save()
    {
        Debug.Log("quit");
    }
}
