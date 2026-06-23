using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Image inventoryImage;
    public TMP_Text inventoryInformation;
    public GameObject slotPrefab;
    public Transform inventoryGrid;
    public int inventoryCapacity = 20;

    [HideInInspector] public List<Item> items = new List<Item>();
    private List<InventorySlot> slots = new List<InventorySlot>();

    private void Awake()
    {
        InitializeInventory(inventoryCapacity);
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
        InventorySlot slotScript = newSlot.GetComponent<InventorySlot>();
        slotScript.Clear();

        if (slots.Count == 0)
        {
            Manager.Instance.Inventory.inventoryFirstItem = newSlot;
        }
        slots.Add(slotScript);
    }
    public Item InstantiateItem(ItemData itemData)
    {
        Item newItem = new Item();
        newItem.Assign(itemData);
        return newItem;
    }
    public void AddItem(ItemData newItemData)
    {
        Item targetItem = items.Find(item => item.itemName == newItemData.itemName);
        if (targetItem != null)
        {
            targetItem.itemQuantity += newItemData.itemQuantity;
            RefreshInventoryGrid();
        }
        else
        {
            if (items.Count < slots.Count)
            {
                Item newItem = InstantiateItem(newItemData);
                items.Add(newItem);
                RefreshInventoryGrid();
            }
            // else
            // {
            //     Debug.Log("背包已滿");
            // }
        }
    }
    public void AddItem(ItemData newItemData, int quantity)
    {
        Item targetItem = items.Find(item => item.itemName == newItemData.itemName);
        if (targetItem != null)
        {
            targetItem.itemQuantity += quantity;
            RefreshInventoryGrid();
        }
        else
        {
            if (items.Count < slots.Count)
            {
                Item newItem = InstantiateItem(newItemData);
                newItem.itemQuantity = quantity;
                items.Add(newItem);
                RefreshInventoryGrid();
            }
            // else
            // {
            //     Debug.Log("背包已滿");
            // }
        }
    }
    public int FindIndexOfItem(ItemData targetItemData)
    {
        return items.FindIndex(item => item.itemName == targetItemData.itemName);
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
    public void DisplayItemDetails(InventorySlot slot)
    {
        bool isEmpty = slot == null || slot.slotImage == null;
        inventoryImage.canvasRenderer.SetAlpha(isEmpty ? 0f : 1f);

        if (!isEmpty)
        {
            inventoryImage.sprite = slot.slotImage;
            inventoryInformation.text = slot.slotInfo;
        }
        else
        {
            inventoryInformation.text = string.Empty;
        }
    }
}
