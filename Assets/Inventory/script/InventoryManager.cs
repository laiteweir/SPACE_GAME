using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    static InventoryManager instance;
    public Inventory maybag;
    public GameObject slotgrid;
    public Slot slotprefab;
    public Text description;
    public static int itemno=0;
    public static Slot newitem;
    public GameObject MG;
    public bool isopen = false;
    void Awake(){
        if(instance!= null){
            Destroy(this);
        }
        instance = this;
    }
    void Update(){
        Change_item();
        Close_Bag();
    }
    public static void CreateNewItem(Item item){
        newitem = Instantiate(instance.slotprefab, instance.slotgrid.transform.position, Quaternion.identity);
        Debug.Log("create item");
        newitem.gameObject.transform.SetParent(instance.slotgrid.transform); 
        newitem.slotItem = item;
        newitem.slotImage.sprite = item.itemImage;
        itemno++;
    }
    private void Change_item(){
        if(Input.GetKeyDown(KeyCode.Q)&& isopen){
            Debug.Log(itemno);
            itemno--;
            if(itemno < 0)
                itemno =0;
            itemno %= maybag.itemList.Count;
            display_item(itemno);
        }
        else if(Input.GetKeyDown(KeyCode.E)&& isopen){
            Debug.Log(itemno);
            itemno++;
            itemno %= maybag.itemList.Count;
            display_item(itemno);
        }
    }
    public void display_item(int number){
        newitem.slotItem = maybag.itemList[number];
        newitem.slotImage.sprite = maybag.itemList[number].itemImage;
        //newitem.Text = maybag.itemList[number].itemInfo;
    }
    public void Close_Bag(){
        if(Input.GetKeyDown(KeyCode.O)){
            isopen = !isopen;
            MG.SetActive(isopen);
        }
    }
}
