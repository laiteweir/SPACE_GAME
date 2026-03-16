using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, ISelectHandler
{
    [SerializeField] private TMP_Text slotName;
    [SerializeField] private Image slotImage;
    [SerializeField] private TMP_Text slotInfo;
    [SerializeField] private TMP_Text slotQuantity;

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(gameObject.name + " 已被選中！");
    }
    public void SetInventorySlot(Item item)
    {
        slotName.gameObject.SetActive(true);
        slotName.text = item.itemName;
        slotImage.sprite = item.itemImage;
        slotInfo.text = item.itemInfo;
        slotQuantity.gameObject.SetActive(true);
        slotQuantity.text = item.itemQuantity.ToString();
        // 這裡可以擴展顯示數量、提示框等
        // slotImage.gameObject.SetActive(true);
    }
    public void Clear()
    {
        slotName.gameObject.SetActive(false);
        slotName.text = "";
        slotImage.sprite = null;
        slotInfo.text = "";
        slotQuantity.gameObject.SetActive(false);
        slotQuantity.text = "";
        // 這裡可以重置其他狀態，例如數量文字、選取框等
    }
}