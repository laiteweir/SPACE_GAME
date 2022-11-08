using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Robot_01_event_02 : Keyitem
{
    [SerializeField] TextAsset textFile;
    private string[] dialog;
    // Start is called before the first frame update
    void Start()
    {
        dialog = textFile.text.Split('\n');

    }

    // Update is called once per frame
    void Update()
    {
        if(TrueForAll(Manager.Instance.room0.Room0_lights)){
            Manager.Instance.room0.Room0_bigLight_1.GetComponent<Light2D>().enabled = true;
            Manager.Instance.room0.room0_turn_on_bigLight();
            Manager.Instance.room0.Room0_event2.SetActive(false);
            Manager.Instance.room0.Room0_event3.SetActive(true);

        }
    }

    private bool TrueForAll(int[] all_lights){
        for (int i = 0; i < all_lights.Length; ++i)
        {
            if (all_lights[i] != i+1){
                return false;
            }
        }
        return true;
    }
    public override void KeyitemEvent()
    {
        //enable next process
        Manager.Instance.ui.SetActive(true);
        Manager.Instance.dialogBox.TextIsOn = true;
        Manager.Instance.dialogBox.StartTalk(dialog);
        Debug.Log(Manager.Instance.dialogBox.TextIsOn);
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
