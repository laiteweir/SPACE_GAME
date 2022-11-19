using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room6_event_1 : Keyitem
{
    // Start is called before the first frame update
    public string keyword;
    public bool exist = false;
    int n;
    
    [SerializeField] Inventory mybag;
    public override void KeyitemEvent(){
        if(!exist)
            Check();
    }
    void Check(){
        for(int i=0; i<mybag.itemList.Count ;i++){
            if(mybag.itemList[i].itemName == keyword){
                //exist = true;
                Debug.Log("start to cook!");
                n = i;
                StartCook();
                //mybag.itemList[i].itemName = keyword + "cooked";
            }
        }
        if(!exist)
            Debug.Log("there is nothing to cook");
    }

    void StartCook(){
        Manager.Instance.OpenScene("CookGame", this);
    }

    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseScene("CookGame");
        if(CookData.situation==1){
            exist = true;
            mybag.itemList[n].itemName = keyword + "cooked";
        }
        else if(CookData.situation==2){

        }
        else if(CookData.situation==3){

        }
    }
}
