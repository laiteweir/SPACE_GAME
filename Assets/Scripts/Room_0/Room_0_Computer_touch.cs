using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room_0_Computer_touch : Keyitem
{
    //new Collider2D collider;
    [SerializeField] GameObject computer_light;
    private TextAsset dialog01;

    
    // Start is called before the first frame update
    void Start()
    {
        //collider = GetComponent<Collider2D>();
        dialog01 = Resources.Load<TextAsset>("dialog");

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
        // Debug.Log("touch robot 01 in room 0");
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.ui.GetComponent<ReadText>().StartTalk(dialog01);
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
