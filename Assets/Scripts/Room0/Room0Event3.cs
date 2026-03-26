using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room0Event3 : Keyitem
{
    // Start is called before the first frame update
    [SerializeField] private TextAsset textFile;
    private string[] dialog;
    private bool triggerFirst = true;
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    // Update is called once per frame
    private void Update()
    {
        //enable next process
        if (Manager.Instance.DialogBoxUI.activeSelf == false && triggerFirst == false)
        {
            gameObject.SetActive(false);
            Manager.Instance.room0.nextDoor.locked = false;
        }
    }

    public override void KeyitemEvent()
    {
        Manager.Instance.DialogBox.StartTalk(dialog);
        triggerFirst = false;
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
