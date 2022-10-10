using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMcommands : MonoBehaviour
{

    public void Exit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void Close()
    {
        Debug.Log("Close");
        Pause.PManu.SetActive(false);

    }
    public void Setting()
    {
        Debug.Log("quit");
    }
    public void Save()
    {
        Debug.Log("quit");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
