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
    //public GameObject previous;
    [SerializeField] TextAsset textFile0;
    [SerializeField] TextAsset textFile1;
    [SerializeField] TextAsset textFile2;
    [SerializeField] TextAsset textFile3;


    private string[] dialog;
    private bool found ;
    public override void KeyitemEvent(){
        if(!exist)
            Check();
    }
    void Check(){
        found = false;
        for(int i=0; i<mybag.itemList.Count ;i++){
            if(mybag.itemList[i].itemName == keyword){
                found = true;
                Debug.Log("start to cook!");
                n = i;
                StartCook();
                //mybag.itemList[i].itemName = keyword + "cooked";
            }
        }
        if(!exist && !found){
            Debug.Log("there is nothing to cook");
            dialog = textFile0.text.Split('\n');
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
        }
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
            dialog = textFile1.text.Split('\n');
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
        }
        else if(CookData.situation==2){
            mybag.itemList[n].itemHeld =0;
            mybag.itemList.RemoveAt(n);
            //previous.SetActive(true);
            dialog = textFile2.text.Split('\n');
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
            //gameObject.SetActive(false);
           
        }
        else if(CookData.situation==3){
            
            dialog = textFile3.text.Split('\n');
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
        }
    }
}
