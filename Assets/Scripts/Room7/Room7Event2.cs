using UnityEngine;

public class Room7Event2 : MonoBehaviour
{
    [SerializeField] TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Manager.Instance.room7.DeactiveAliens();
            Manager.Instance.DialogBox.StartTalk(dialog, EndDialog);
        }
    }

    private void EndDialog()
    {
        gameObject.SetActive(false);
    }
}
