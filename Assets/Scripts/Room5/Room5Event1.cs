using UnityEngine;

public class Room5Event1 : MonoBehaviour
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
        if (other.CompareTag("Player"))
        {
            Manager.Instance.DialogBox.StartTalk(dialog, EndDialog);
        }
    }

    private void EndDialog()
    {
        gameObject.SetActive(false);
        next.SetActive(true);
    }
}
