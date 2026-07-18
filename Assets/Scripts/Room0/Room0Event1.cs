using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Room0Event1 : Keyitem
{
    [SerializeField] private GameObject next;
    // [SerializeField] private Light2D computerLight;

    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    private void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    public override void KeyitemEvent()
    {
        // computerLight.enabled = false;
        Manager.Instance.DialogBox.StartTalk(dialog, EndKeyitemEvent);
    }
    public override void EndKeyitemEvent()
    {
        // Enable next event
        Manager.Instance.room0.Room0TurnOffLightsWithRedLight();
        gameObject.SetActive(false);
        next.SetActive(true);
    }
}
