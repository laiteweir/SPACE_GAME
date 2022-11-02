using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room_0_Computer_touch : Keyitem
{
    new Collider2D collider;
    GameObject computer_light;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        computer_light = GameObject.Find("Robot_01_Light_1");

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.X))
        // {
        //     Debug.Log("x");
        // }
    }
    public override void KeyitemEvent()
    {
        computer_light.GetComponent<Light2D>().color = Color.green;
        Debug.Log("test fire");
        UI.text.SetActive(true);
        UI.TextIsOn = true;
    }
    public override void EndKeyitemEvent()
    {
        Debug.Log("test fire");
    }
}
