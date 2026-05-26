using UnityEngine;

public class Room10Event1 : MonoBehaviour
{
    [SerializeField] private GameObject next;

    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    private void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Manager.Instance.DialogBox.StartTalk(dialog, EndDialog);
        }
    }

    private void EndDialog()
    {
        Manager.Instance.room10.Engine1.SetActive(true);
        Manager.Instance.room10.Engine2.SetActive(true);
        Manager.Instance.room10.Room10Event2.SetActive(true);
        gameObject.SetActive(false);
        next.SetActive(true);
    }
}
