using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room0Event1 : Keyitem
{
    [SerializeField] private GameObject next;
    //new Collider2D collider;
    [SerializeField] private GameObject computerLight;
    //GameObject this_event;

    [SerializeField] private TextAsset textFile;
    //private TextAsset dialog01;
    private string[] dialog;
    private bool triggerFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        //collider = GetComponent<Collider2D>();
        dialog = textFile.text.Split('\n');
        // this_event = GameObject.Find("Robot_01_event_01");
    }

    // Update is called once per frame
    void Update()
    {
        //enable next process
        if (Manager.Instance.DialogBoxUI.activeSelf == false && triggerFirst == false)
        {
            Manager.Instance.room0.Room0TurnOffLightsWithRedLight();
            next.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public override void KeyitemEvent()
    {
        computerLight.GetComponent<Light2D>().enabled = false;
        // Debug.Log("touch robot 01 in room 0");
        Manager.Instance.DialogBoxUI.SetActive(true);
        Manager.Instance.DialogBox.StartTalk(dialog);
        // make sure is not first trigger
        triggerFirst = false;
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
