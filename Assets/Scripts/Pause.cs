using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pause : MonoBehaviour
{
    public bool PMOn = false;
    [SerializeField] GameObject image;
    public void Start() 
    {
        image.SetActive(false);
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
        Manager.Instance.actionMapPlayer.Enable();
    }
    public void Tutorial()
    {
        image.SetActive(true);
        //Debug.Log("Tutorial");
    }
    public void Back() 
    {
        image.SetActive(false);
    }
}
