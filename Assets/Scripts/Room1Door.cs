using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Door : MonoBehaviour
{
    public bool canFreezeControl = false;
    public PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Room1DoorEvent()
    {
        Debug.Log("Try to open Room1 door");
        if (canFreezeControl)
        {
            controller.enabled = false;
        }
    }
}
