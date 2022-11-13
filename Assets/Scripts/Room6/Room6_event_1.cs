using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room6_event_1 : Keyitem
{
    // Start is called before the first frame update
    public string keyword;
    public bool exist = false;
    
    [SerializeField] Inventory mybag;
    public override void KeyitemEvent(){
        if(!exist)
            Check();
    }
    void Check(){
        for(int i=0; i<mybag.itemList.Count ;i++){
            if(mybag.itemList[i].itemName == keyword){
                exist = true;
                Debug.Log("start to cook!");
                mybag.itemList[i].itemName = keyword + "cooked";
            }
        }
        if(!exist)
            Debug.Log("there is nothing to cook");
    }
}
