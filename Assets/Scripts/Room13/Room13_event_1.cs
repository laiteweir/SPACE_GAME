using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room13_event_1 : Keyitem
{
    // Start is called before the first frame update
    [SerializeField] GameObject Boss;
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
        Debug.Log(Manager.Instance.iswin);
        Manager.Instance.CloseScene("BossFight");
        if(Manager.Instance.iswin){
            Manager.Instance.room13.EndGame.SetActive(true);
            Boss.SetActive(false);
        }

    }
}
