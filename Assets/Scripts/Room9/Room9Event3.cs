using UnityEngine;

public class Room9Event3 : Keyitem
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
        int index1 = Manager.Instance.InventoryManager.FindIndexOfItem(Manager.Instance.room9.RedFlowerData);
        int index2 = Manager.Instance.InventoryManager.FindIndexOfItem(Manager.Instance.room9.YellowLeafData);
        int index3 = Manager.Instance.InventoryManager.FindIndexOfItem(Manager.Instance.room9.HairData);
        int index4 = Manager.Instance.InventoryManager.FindIndexOfItem(Manager.Instance.room9.WhiteJarData);
        int index5 = Manager.Instance.InventoryManager.FindIndexOfItem(Manager.Instance.room9.FolderData);
        if (index1 == -1 || index2 == -1 || index3 == -1 || index4 == -1 || index5 == -1)
        {
            return;
        }
        Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
    }
    public override void EndKeyitemEvent()
    {
        // Enable next event
        gameObject.SetActive(false);
        next.SetActive(true);
    }
}
