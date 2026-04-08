using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, ISelectHandler
{
    [SerializeField] private TMP_Text slotName;
    public Sprite slotImage;
    public string slotInfo;
    [SerializeField] private TMP_Text slotQuantity;

    public void OnSelect(BaseEventData eventData)
    {
        Manager.Instance.InventoryManager.DisplayItemDetails(this);
    }
    public void SetInventorySlot(Item item)
    {
        slotName.gameObject.SetActive(true);
        slotName.text = item.itemName;
        slotImage = item.itemImage;
        slotInfo = item.itemInfo;
        slotQuantity.gameObject.SetActive(true);
        slotQuantity.text = item.itemQuantity.ToString();
        // 這裡可以擴展顯示數量、提示框等
        // slotImage.gameObject.SetActive(true);
    }
    public void Clear()
    {
        slotName.gameObject.SetActive(false);
        slotName.text = string.Empty;
        slotImage = null;
        slotInfo = string.Empty;
        slotQuantity.gameObject.SetActive(false);
        slotQuantity.text = string.Empty;
        // 這裡可以重置其他狀態，例如數量文字、選取框等
    }
}