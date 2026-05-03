using UnityEngine;

public class Room9Event4 : Keyitem
{
    [SerializeField] private GameObject next;
    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    private void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        int index = Manager.Instance.InventoryManager.FindIndexOfItem(Manager.Instance.room9.RedFlowerData);
        Manager.Instance.InventoryManager.RemoveItem(index, 1);
        index = Manager.Instance.InventoryManager.FindIndexOfItem(Manager.Instance.room9.YellowLeafData);
        Manager.Instance.InventoryManager.RemoveItem(index, 1);
        index = Manager.Instance.InventoryManager.FindIndexOfItem(Manager.Instance.room9.HairData);
        Manager.Instance.InventoryManager.RemoveItem(index, 1);
        index = Manager.Instance.InventoryManager.FindIndexOfItem(Manager.Instance.room9.WhiteJarData);
        Manager.Instance.InventoryManager.RemoveItem(index, 1);
        index = Manager.Instance.InventoryManager.FindIndexOfItem(Manager.Instance.room9.FolderData);
        Manager.Instance.InventoryManager.RemoveItem(index, 1);

        Manager.Instance.room9.Room9BigLight.enabled = true;
        Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
    }
    public override void EndKeyitemEvent()
    {
        // Enable next event
        gameObject.SetActive(false);
        next.SetActive(true);
        Manager.Instance.room8.Robot3.SetActive(true);
        Manager.Instance.room8.Room8WhiteSlime1.SetActive(true);
        Manager.Instance.room8.Room8WhiteSlime2.SetActive(true);
        Manager.Instance.room8.Room8WhiteSlime3.SetActive(true);
    }
}
