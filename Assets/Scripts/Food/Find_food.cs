using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find_food : Keyitem
{
    // Start is called before the first frame update
    [SerializeField] Inventory mybag;
    public Item food;
    bool is_find = false;
    public override void KeyitemEvent(){
        if(is_find)
            return;
        if(!mybag.itemList.Contains(food)){
            food.itemName = "Food";
            mybag.itemList.Add(food);
        }
        else{
            food.itemHeld +=1 ;
        }
        InventoryManager.CreateNewItem(food);
        Debug.Log("find some food");
        is_find = true;
    }
}
