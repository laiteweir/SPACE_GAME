using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eat : Keyitem
{
    // Start is called before the first frame update
    public string keyword;
    public bool exist = false;
    [SerializeField] Inventory mybag;
    [SerializeField] TextAsset textFile;
    //private TextAsset dialog01;
    private string[] dialog;
    public Item shield;
    void Start(){
        dialog = textFile.text.Split('\n');
    }
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
                Manager.Instance.ui.SetActive(true);
                Manager.Instance.dialogBox.TextIsOn = true;
                Manager.Instance.dialogBox.StartTalk(dialog);
                mybag.itemList.Add(shield);
                shield.itemHeld = 1;
            }
            if(!exist)
                if(mybag.itemList[i].itemName == keyword )
                    Debug.Log("it is cold");
        }
    }
}
