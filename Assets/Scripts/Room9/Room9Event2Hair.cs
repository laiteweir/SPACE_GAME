using UnityEngine;

public class Room9Event2Hair : Keyitem
{
    private Item hair;
    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    private void Start()
    {
        hair = Manager.Instance.InventoryManager.InstantiateItem(Manager.Instance.room9.HairData);
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        Manager.Instance.InventoryManager.AddItem(hair);
        Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
    }
    public override void EndKeyitemEvent()
    {
        gameObject.SetActive(false);
    }
}