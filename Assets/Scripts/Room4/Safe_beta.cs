using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe_beta : Keyitem
{
    [SerializeField] TextAsset file;
    private string[] dialog;
    private bool is_triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        dialog = file.text.Split("\n");
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.dialogBox.TextIsOn == false && is_triggered == true) 
        {
            Manager.Instance.room3.room3_event4.SetActive(true);
            Manager.Instance.room4.safe.SetActive(false);
            Manager.Instance.room3.room3_event3.SetActive(false);
        }
    }

    public override void KeyitemEvent()
    {
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
        is_triggered = true;



    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
