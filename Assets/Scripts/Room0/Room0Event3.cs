using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room0Event3 : Keyitem
{
    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
    }
    public override void EndKeyitemEvent()
    {
        gameObject.SetActive(false);
        Manager.Instance.room0.Robot1Notice.gameObject.SetActive(false);
        // Manager.Instance.room0.nextDoor.locked = false;
    }
}
