using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eat : Keyitem
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
            if(mybag.itemList[i].itemName == keyword + "cooked"){
                exist = true;
                Debug.Log("start eat!");
                mybag.itemList[i].itemName = keyword;
                mybag.itemList.Remove(mybag.itemList[i]);
            }
            if(!exist)
                if(mybag.itemList[i].itemName == keyword )
                    Debug.Log("it is cold");
        }
    }
}
