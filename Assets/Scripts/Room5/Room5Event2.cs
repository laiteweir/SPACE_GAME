using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room5Event2 : Keyitem
{
    [SerializeField] private GameObject room5BigLight;
    [SerializeField] private GameObject room6BigLight;

    [SerializeField] private GameObject food1;
    [SerializeField] private GameObject food2;
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
            gameObject.SetActive(false);
            food1.SetActive(true);
            food2.SetActive(true);
        }
    }

    public override void KeyitemEvent()
    {
        room5BigLight.SetActive(true);
        room6BigLight.SetActive(true);
        Manager.Instance.DialogBox.StartTalk(dialog);
        triggerFirst = false;
    }

    public override void EndKeyitemEvent()
    {
        //this.first_trigger = false;
        Destroy(this);
    }
}
