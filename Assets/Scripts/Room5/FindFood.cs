using UnityEngine;

public class FindFood : Keyitem
{
    [SerializeField] private ItemData foodData;

    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    private void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        Manager.Instance.InventoryManager.AddItem(foodData);
        Manager.Instance.DialogBox.StartTalk(dialog);
        // Manager.Instance.DialogBox.StartTalk(dialog, () => gameObject.SetActive(false));
    }
}
