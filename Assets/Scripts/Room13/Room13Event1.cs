using UnityEngine;

public class Room13Event1 : MonoBehaviour
{
    [SerializeField] private TextAsset textFile;
    private string[] dialog;
    [SerializeField] private CaptainSlimeMove slimeMove;

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
        transform.parent.gameObject.SetActive(false);
        slimeMove.gameObject.SetActive(true);
    }
}
