using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room7_robot_07 : Keyitem
{
    [SerializeField] TextAsset textFile;
    private string[] dialog;
    // Start is called before the first frame update
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        //enable next process
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
        //Debug.Log(Manager.Instance.dialogBox.TextIsOn);
    }
}
