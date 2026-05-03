using UnityEngine;

public class Room9Event2RedFlower : Keyitem
{
    private Item redFlower;
    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    private void Start()
    {
        redFlower = Manager.Instance.InventoryManager.InstantiateItem(Manager.Instance.room9.RedFlowerData);
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        Manager.Instance.InventoryManager.AddItem(redFlower);
        Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
    }
    public override void EndKeyitemEvent()
    {
        gameObject.SetActive(false);
    }
}