using System;
using UnityEngine;

public class FindFood : Keyitem
{
    [SerializeField] private ItemData foodData;
    private Item food;
    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    private void Start()
    {
        food = Manager.Instance.InventoryManager.InstantiateItem(foodData);
        dialog = textFile.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        Manager.Instance.InventoryManager.AddItem(food);
        Manager.Instance.DialogBox.StartTalk(dialog);
        // Manager.Instance.DialogBox.StartTalk(dialog, () => gameObject.SetActive(false));
    }
}
