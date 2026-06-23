using UnityEngine;

public class eat : Keyitem
{
    [SerializeField] private TextAsset textFile;
    private string[] dialog;
    [SerializeField] private ItemData cookedFoodData;
    [SerializeField] private ItemData shieldData;

    // Start is called before the first frame update
    private void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        int cookedFoodIndex = Manager.Instance.InventoryManager.FindIndexOfItem(cookedFoodData);
        if (cookedFoodIndex != -1)
        {
            // Debug.Log("start eating!");
            Manager.Instance.InventoryManager.RemoveItem(cookedFoodIndex, Manager.Instance.InventoryManager.items[cookedFoodIndex].itemQuantity);
            Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
        }
    }
    public override void EndKeyitemEvent()
    {
        Manager.Instance.InventoryManager.AddItem(shieldData);
        Destroy(this);
    }
}
