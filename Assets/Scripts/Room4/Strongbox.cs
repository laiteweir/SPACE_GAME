using UnityEngine;

public class Strongbox : Keyitem
{
    [SerializeField] private ItemData keyCardData;

    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    private void Start()
    {
        dialog = textFile.text.Split("\n");
    }

    public override void KeyitemEvent()
    {
        Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
    }
    public override void EndKeyitemEvent()
    {
        Manager.Instance.InventoryManager.AddItem(keyCardData);
        gameObject.SetActive(false);
        Manager.Instance.room3.Event2.SetActive(false);
        Manager.Instance.room3.Event3.SetActive(true);
    }
}
