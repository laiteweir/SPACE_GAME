using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    // Start is called before the first frame update
    public Item thisItem;
    public Inventory playerInventory;
    
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            AddNewItem();
            Destroy(gameObject);
        }
    }
    private void AddNewItem(){
        if(!playerInventory.itemList.Contains(thisItem)){
            if(playerInventory.itemList.Count==0)
                InventoryManager.CreateNewItem(thisItem);
            playerInventory.itemList.Add(thisItem);
            //InventoryManager.itemno++;
        }
        else{
            thisItem.itemHeld +=1 ;
        }
    }
}
