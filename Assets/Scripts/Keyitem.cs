using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyitem : MonoBehaviour
{
    public bool canFreezeControl = false;
    public PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void KeyitemEvent()
    {
        Debug.Log("Something happened!");
        if (canFreezeControl)
        {
            controller.enabled = false;
        }
    }
}
