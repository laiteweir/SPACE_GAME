using UnityEngine;

public class Room8Event2 : Keyitem
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
        Manager.Instance.DialogBox.StartTalk(dialog);
    }
}
