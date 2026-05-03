using UnityEngine;

public class Room7Event1 : MonoBehaviour
{
    [SerializeField] private GameObject next;

    [SerializeField] TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Manager.Instance.DialogBox.StartTalk(dialog, EndDialog);
        }
    }
    private void EndDialog()
    {
        Manager.Instance.room7.ActiveAliens();
        gameObject.SetActive(false);
        next.SetActive(true);
    }
}
