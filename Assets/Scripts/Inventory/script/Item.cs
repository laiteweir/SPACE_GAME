using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemImage;
    public string itemInfo;
    public int itemQuantity;

    public void Assign(ItemData data)
    {
        itemName = data.itemName;
        itemImage = data.itemImage;
        itemInfo = data.itemInfo;
        itemQuantity = data.itemQuantity;
    }
}
