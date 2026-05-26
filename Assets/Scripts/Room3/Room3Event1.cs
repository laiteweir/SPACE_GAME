using UnityEngine;

public class Room3Event1 : Keyitem
{
    [SerializeField] private Door door;

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
        gameObject.SetActive(false);
        door.locked = false;
        Manager.Instance.room3.Event2.SetActive(true);
        Manager.Instance.room4.Room4Strongbox.SetActive(true);
        Manager.Instance.room4.Event1.SetActive(true);
        Manager.Instance.room4.Event2.SetActive(true);
        Manager.Instance.room4.Event3.SetActive(true);
        Manager.Instance.room4.Event4.SetActive(true);
    }
}
