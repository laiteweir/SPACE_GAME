using UnityEngine;

public class Room9Event1 : MonoBehaviour
{
    [SerializeField] private GameObject next;
    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    private void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Manager.Instance.DialogBox.StartTalk(dialog, EndDialog);
    }
    private void EndDialog()
    {
        Manager.Instance.room9.Room9PCLight.enabled = true;
        Manager.Instance.room9.Room9PCLight.color = Color.yellow;
        gameObject.SetActive(false);
        next.SetActive(true);
    }
}