using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeitem : Keyitem
{
    
    public Item Object;
    public GameObject UI;
    public GameObject slotgrid;
    public Slot slotprefab;
    public static Slot See;
    bool is_watching = false;
    void Update(){
        if(Input.GetKeyDown(KeyCode.X)&&is_watching){
            is_watching = false;
            EndKeyitemEvent();
        }
    }

    public override void KeyitemEvent()
    {
        See = Instantiate(slotprefab, slotgrid.transform.position, Quaternion.identity);
        // See.transform.localscale = new Vector3(0.5, 0.5,0.5);
        See.gameObject.transform.SetParent(slotgrid.transform); 
        Manager.Instance.actionMapPlayer.Disable();
        See.slotItem = Object;
        See.slotImage.sprite = Object.itemImage;
        is_watching = true;
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.actionMapPlayer.Enable();
        See.Clean();
    }
}
