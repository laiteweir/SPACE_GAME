using UnityEngine;

public class Room9Event2YellowLeaf : Keyitem
{
    private Item yellowLeaf;
    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    private void Start()
    {
        yellowLeaf = Manager.Instance.InventoryManager.InstantiateItem(Manager.Instance.room9.YellowLeafData);
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        Manager.Instance.InventoryManager.AddItem(yellowLeaf);
        Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
    }
    public override void EndKeyitemEvent()
    {
        gameObject.SetActive(false);
    }
}