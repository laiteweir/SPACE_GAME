using UnityEngine;

public class Engine2 : Keyitem
{
    [SerializeField] private TextAsset start;
    [SerializeField] private TextAsset success;
    private string[] dialogStart;
    private string[] dialogSuccess;

    private void Start()
    {
        dialogStart = start.text.Split('\n');
        dialogSuccess = success.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        Manager.Instance.DialogBox.StartTalkAndOpenSceneUI(dialogStart, "Wire Task", this);
    }
    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseSceneUI("Wire Task");

        if (Manager.Instance.room10.isEngine2Fixed)
        {
            // Debug.Log("You have fixed Engine 2!");
            gameObject.SetActive(false);
            Manager.Instance.DialogBox.StartTalk(dialogSuccess);
        }
    }
}
