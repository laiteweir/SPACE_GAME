using UnityEngine;

public class Room1Event3 : Keyitem
{
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
        gameObject.SetActive(false);
        Manager.Instance.room1.Robot2Notice.gameObject.SetActive(false);
    }
}
