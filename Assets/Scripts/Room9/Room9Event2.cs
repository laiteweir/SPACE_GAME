using UnityEngine;

public class Room9Event2 : Keyitem
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
        Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
    }
    public override void EndKeyitemEvent()
    {
        // Enable next event
        gameObject.SetActive(false);
        Manager.Instance.room9.Room9PCLight.enabled = false;
        next.SetActive(true);
        Manager.Instance.room9.RedFlowerEvent.SetActive(true);
        Manager.Instance.room9.YellowLeafEvent.SetActive(true);
        Manager.Instance.room9.HairEvent.SetActive(true);
        Manager.Instance.room9.WhiteJarEvent.SetActive(true);
        Manager.Instance.room9.FolderEvent.SetActive(true);
    }
}
