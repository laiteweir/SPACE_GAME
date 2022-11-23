using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room13_event_1 : Keyitem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void KeyitemEvent(){
        Manager.Instance.OpenScene("BossFight", this);
    }

    public override void EndKeyitemEvent(){
        Manager.Instance.CloseScene("BossFight");
    }
}
