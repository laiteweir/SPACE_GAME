using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItem : MonoBehaviour
{
    // Start is called before the first frame update
    public string keyword;
    public bool exist = false;
    [SerializeField] Inventory mybag;
    void Update(){
        if(!exist)
            Check();
    }
    void Check(){
        for(int i=0; i<mybag.itemList.Count ;i++){
            if(mybag.itemList[i].itemName == keyword)
                exist = true;
                Debug.Log("item exist!");
        }
    }

}
