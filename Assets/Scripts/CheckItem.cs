using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItem : Keyitem
{
    // Start is called before the first frame update
    public string keyword;
    public bool exist = false;
    [SerializeField] Inventory mybag;
    public override void KeyitemEvent(){
        Debug.Log("start check item");
        if(!exist)
            Check();
    }
    public override void EndKeyitemEvent()
    {
        Debug.Log("end check item!");
    }
    public void Check(){
        for(int i=0; i<mybag.itemList.Count ;i++){
            if(mybag.itemList[i].itemName == keyword)
                exist = true;
                Debug.Log("item exist!");
        }
    }

}
