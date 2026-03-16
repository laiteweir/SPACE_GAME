using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Image inventoryImage;
    public TMP_Text inventoryInformation;
    public GameObject slotPrefab;
    public Transform inventoryGrid;
    public int inventoryCapacity = 20;
    // public int itemNumber;

    public List<Item> items = new List<Item>();
    private List<InventorySlot> slots = new List<InventorySlot>();

    private void Start()
    {
        InitializeInventory(inventoryCapacity);
        // items.Add(null);
        // items.Add(null);
        RefreshInventoryGrid();
    }
    private void InitializeInventory(int count)
    {
        for (int i = 0; i < count; ++i)
        {
            CreateNewSlot();
        }
    }
    private void CreateNewSlot()
    {
        GameObject newSlot = Instantiate(slotPrefab, inventoryGrid);
        // 確保新物件的本地縮放和位置正確 (Grid Layout Group 會自動處理位置，但重置一下更安全)
        // newSlot.transform.localPosition = Vector3.zero;
        // newSlot.transform.localScale = Vector3.one;

        InventorySlot slotScript = newSlot.GetComponent<InventorySlot>();
        slotScript.Clear();
        slots.Add(slotScript);
    }
    public Item InstantiateItem(ItemData itemData)
    {
        Item newItem = new Item();
        newItem.Assign(itemData);
        return newItem;
    }
    public void AddItem(Item newItem)
    {
        Item targetItem = items.Find(item => item.itemName == newItem.itemName);
        if (targetItem != null)
        {
            targetItem.itemQuantity += newItem.itemQuantity;
            RefreshInventoryGrid();
        }
        else
        {
            if (items.Count < slots.Count)
            {
                items.Add(newItem);
                RefreshInventoryGrid();
            }
            // else
            // {
            //     Debug.Log("背包已滿");
            // }
        }
    }
    public int FindIndexOfItem(Item targetItem)
    {
        return items.FindIndex(item => item.itemName == targetItem.itemName);
    }
    public void RemoveItem(int index, int quantity)
    {
        if (index >= 0 && index < items.Count && items[index].itemQuantity >= quantity)
        {
            items[index].itemQuantity -= quantity;
            if (items[index].itemQuantity == 0)
            {
                items.RemoveAt(index);
            }
            RefreshInventoryGrid();
        }
        // else
        // {
        //     Debug.Log("物品數量不足");
        // }
    }
    public void RefreshInventoryGrid()
    {
        // 如果物品數量超過當前背包大小，動態擴充
        // if (items.Count > slots.Count)
        // {
        //     int needed = items.Count - slots.Count;
        //     InitializeInventory(needed);
        // }

        for (int i = 0; i < slots.Count; ++i)
        {

            if (i < items.Count && items[i] != null)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].SetInventorySlot(items[i]);
            }
            else
            {
                slots[i].Clear();
            }
        }
    }
}
