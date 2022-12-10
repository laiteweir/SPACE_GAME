using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find_food : Keyitem
{
    // Start is called before the first frame update
    [SerializeField] Inventory mybag;
    public Item food;
    bool is_find = false;
    [SerializeField] TextAsset textFile;
    public GameObject other;

    private string[] dialog;
    public override void KeyitemEvent(){
        
        if(!mybag.itemList.Contains(food)){
            food.itemName = "Food";
            food.itemHeld=1;
            mybag.itemList.Add(food);
            //food.itemHeld=1;
    
            InventoryManager.CreateNewItem(food);
            Debug.Log("find some food");
            is_find = true;
            dialog = textFile.text.Split('\n');
            Manager.Instance.ui.SetActive(true);
            Manager.Instance.dialogBox.TextIsOn = true;
            Manager.Instance.dialogBox.StartTalk(dialog);
            gameObject.SetActive(false);
            other.SetActive(true);
        }
    }
}
