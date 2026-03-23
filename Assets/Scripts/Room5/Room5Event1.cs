using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room5Event1 : Keyitem
{
    [SerializeField] private GameObject room_5_light;
    [SerializeField] private GameObject room_6_light;

    [SerializeField] private GameObject next;
    [SerializeField] private TextAsset textFile;

    private string[] dialog;
    private bool triggerFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        //collider = GetComponent<Collider2D>();
        dialog = textFile.text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
        // enable next process
        if (Manager.Instance.DialogBoxUI.activeSelf == false && triggerFirst == false)
        {
            next.SetActive(true);
            // gameObject.SetActive(false);
            triggerFirst = true;
        }
    }

    public override void KeyitemEvent()
    {
        room_5_light.SetActive(true);
        room_6_light.SetActive(true);
        Manager.Instance.DialogBoxUI.SetActive(true);
        Manager.Instance.DialogBox.StartTalk(dialog);
        triggerFirst = false;
    }

    public override void EndKeyitemEvent()
    {
        //this.first_trigger = false;
        Destroy(this);
    }
}
