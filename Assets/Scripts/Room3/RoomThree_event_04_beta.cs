using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomThree_event_04_beta : Keyitem
{
    [SerializeField] TextAsset file;
    [SerializeField] GameObject door;
    [SerializeField] GameObject finaldoor1;
    [SerializeField] GameObject finaldoor2;
    [SerializeField] GameObject finaldoor3;
    [SerializeField] GameObject room3_light;
    [SerializeField] GameObject room4_light;
    private string[] dialog;
    private bool is_trigger = false;
    
    // Start is called before the first frame update
    void Start()
    {
        dialog = file.text.Split("\n");
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
            Manager.Instance.room3.room3_event2_5.SetActive(true);
            
            room3_light.SetActive(true);
            room4_light.SetActive(true);
            door.GetComponent<Door>().locked = false;
            finaldoor1.GetComponent<Door>().locked = false;
            finaldoor2.GetComponent<Door>().locked = false;
            finaldoor3.GetComponent<Door>().locked = false;
            Destroy(this);
            Manager.Instance.room3.room3_event4.SetActive(false);
        }
    }

    public override void KeyitemEvent()
    {
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
        is_trigger = true;



    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
