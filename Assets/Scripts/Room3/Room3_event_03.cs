using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3_event_03 : Keyitem
{
    [SerializeField] TextAsset file1;
    [SerializeField] TextAsset file2;
    [SerializeField] TextAsset file3;
    [SerializeField] string keycardName;
    [SerializeField] GameObject safe;
    private string[] dialog1;
    private string[] dialog2;
    private string[] dialog3;
    private bool is_trigger = false;
    private bool keycardcontroll = false;

    
    // Start is called before the first frame update
    void Start()
    {
        dialog1 = file1.text.Split("\n");
        dialog2 = file2.text.Split("\n");
        dialog3 = file3.text.Split("\n");
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.dialogBox.TextIsOn == false && is_trigger == true)
        {
            Manager.Instance.room3.room3_event2_1.SetActive(true);
            Manager.Instance.room3.room3_event2_2.SetActive(true);
            Manager.Instance.room3.room3_event2_3.SetActive(true);
            Manager.Instance.room3.room3_event2_4.SetActive(true);
            Manager.Instance.room3.room3_event2_5.SetActive(true);
        }
    }
    public override void KeyitemEvent()
    {

        if (is_trigger == true)
        {
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog3);
        }
        else 
        {
            if (keycardcontroll == true)
            {
                for (int i = 0; i < Manager.Instance.myBag.itemList.Count; ++i)
                {
                    if (Manager.Instance.myBag.itemList[i].itemName == keycardName)
                    {
                        Manager.Instance.ui.SetActive(true);
                        Manager.Instance.dialogBox.TextIsOn = true;
                        Manager.Instance.dialogBox.StartTalk(dialog1);
                        is_trigger = true;
                    }
                    else
                    {
                        Manager.Instance.ui.SetActive(true);
                        Manager.Instance.dialogBox.TextIsOn = true;
                        Manager.Instance.dialogBox.StartTalk(dialog2);
                    }

                }
            }
            else
            {
                if (GameObject.Find("Safe").GetComponent<Safe>().trigger() == true) 
                {
                    Manager.Instance.ui.SetActive(true);
                    Manager.Instance.dialogBox.TextIsOn = true;
                    Manager.Instance.dialogBox.StartTalk(dialog1);
                    is_trigger = true;
                }
                else 
                {
                    Manager.Instance.ui.SetActive(true);
                    Manager.Instance.dialogBox.TextIsOn = true;
                    Manager.Instance.dialogBox.StartTalk(dialog2);
                }
            }
        }
        
    }
    public override void EndKeyitemEvent()
        {
            // Debug.Log("test fire");
        }

}
