using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyitem_Legacy : MonoBehaviour
{
    static public bool canFreezeControl = false;
    public static PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void KeyitemEvent()
    {
        //Debug.Log("Something happened!");
        UI.text.SetActive(true);
        UI.TextIsOn = true;
        if (canFreezeControl)
        {
            controller.enabled = false;
        }
    }
}
