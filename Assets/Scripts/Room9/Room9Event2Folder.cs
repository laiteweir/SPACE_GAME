using UnityEngine;

public class Room9Event2Folder : Keyitem
{
    private Item folder;
    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    private void Start()
    {
        folder = Manager.Instance.InventoryManager.InstantiateItem(Manager.Instance.room9.FolderData);
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        Manager.Instance.InventoryManager.AddItem(folder);
        Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
    }
    public override void EndKeyitemEvent()
    {
        gameObject.SetActive(false);
    }
}