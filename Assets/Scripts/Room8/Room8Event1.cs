using UnityEngine;

public class Room8Event1 : MonoBehaviour
{
    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    [SerializeField] private float light_intensity_base = 0.2f;
    private int times = 1;
    private void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    public void FillContainer()
    {
        ++times;
        Manager.Instance.room8.Room8Event1Light.intensity = light_intensity_base * times;
        if (times >= 4)
        {
            Manager.Instance.room8.Room8Event1Light.enabled = false;
            Manager.Instance.room8.Room8BigLight.enabled = true;
            Manager.Instance.DialogBox.StartTalk(dialog, EndDialog);
        }
    }
    private void EndDialog()
    {
        gameObject.SetActive(false);
        Manager.Instance.room8.Room8Event2.SetActive(false);
        Manager.Instance.room8.Door8_1.UnlockDoor();
        Manager.Instance.room8.Door1_2.UnlockDoor();
    }
}
