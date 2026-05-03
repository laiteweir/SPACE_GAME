using UnityEngine;

public class Room9Event2WhiteJar : Keyitem
{
    private Item whiteJar;
    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    private void Start()
    {
        whiteJar = Manager.Instance.InventoryManager.InstantiateItem(Manager.Instance.room9.WhiteJarData);
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        Manager.Instance.InventoryManager.AddItem(whiteJar);
        Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
    }
    public override void EndKeyitemEvent()
    {
        gameObject.SetActive(false);
    }
}