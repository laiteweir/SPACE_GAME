using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    public static InventoryManager instance;
    public Inventory maybag;
    public GameObject slotgrid;
    public Slot slotprefab;
    public Text description;
    public static int itemno;
    public static Slot newitem;
    public GameObject MG;
    public GameObject Txt;
    public bool isopen = false;
    bool is_empty = true;
        void Awake(){
        if(instance!= null){
            Destroy(this);
        }
        instance = this;
    }
    void Start(){
        for(int i =0 ;i<maybag.itemList.Count;i++)
            maybag.itemList[i].itemHeld=0;
        maybag.itemList.Clear();
        itemno=0;
    }
    void Update(){
        Change_item();
        Close_Bag();
        //Debug.Log(itemno);
        if(itemno!=0 && is_empty){
            display_item(0);
            is_empty = false;
        }   
    }
    public static void CreateNewItem(Item item){
        if(itemno==0){
            newitem = Instantiate(instance.slotprefab, instance.slotgrid.transform.position, Quaternion.identity);
            Debug.Log("create item");
            newitem.gameObject.transform.SetParent(instance.slotgrid.transform); 
            newitem.slotItem = item;
            newitem.slotImage.sprite = item.itemImage;
            itemno++;
        }
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
        Debug.Log("display "+number);
        newitem.slotItem = maybag.itemList[number];
        newitem.slotImage.sprite = maybag.itemList[number].itemImage;
        description.text = maybag.itemList[number].itemInfo;
        Debug.Log("display item");
    }

    public void Close_Bag(){
        if(Input.GetKeyDown(KeyCode.O)){
            isopen = !isopen;
            MG.SetActive(isopen);
            Txt.SetActive(isopen);
            Debug.Log(itemno);
            if(itemno !=0 ){
                display_item(0);
            }
        }
    }
}
