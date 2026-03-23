using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room0Event3 : Keyitem
{
    // Start is called before the first frame update
    [SerializeField] private TextAsset textFile;
    private string[] dialog;
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        Manager.Instance.DialogBoxUI.SetActive(true);
        Manager.Instance.DialogBox.StartTalk(dialog);
        //Debug.Log(Manager.Instance.DialogBoxUI.activeSelf);
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
