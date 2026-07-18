using UnityEngine;

public class Room3Event3 : Keyitem
{
    [SerializeField] private TextAsset textFile;
    private string[] dialog;
    [SerializeField] private ItemData keyCardData;

    // Start is called before the first frame update
    private void Start()
    {
        dialog = textFile.text.Split("\n");
    }

    public override void KeyitemEvent()
    {
        int keyCardIndex = Manager.Instance.InventoryManager.FindIndexOfItem(keyCardData);
        if (keyCardIndex != -1)
        {
            Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
        }
    }
    public override void EndKeyitemEvent()
    {
        Manager.Instance.room3.ConsoleLight.enabled = false;
        Manager.Instance.room3.ConsoleMarker.SetActive(false);
        Manager.Instance.room3.Room3BigLight.enabled = true;
        Manager.Instance.room4.Room4BigLight.enabled = true;
        // Manager.Instance.room3.UnlockRoom4Door();
        gameObject.SetActive(false);
        Manager.Instance.room3.File1.SetActive(true);
        Manager.Instance.room3.File2.SetActive(true);
        Manager.Instance.room3.File3.SetActive(true);
        Manager.Instance.room3.File4.SetActive(true);
        Manager.Instance.room3.File5.SetActive(true);
    }
}
