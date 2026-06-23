using UnityEngine;

public class Room13_event_Key : MonoBehaviour
{
    [SerializeField] private TextAsset textFile;
    private string[] dialog;
    [SerializeField] private GameObject captain;
    [SerializeField] private Slime_boss_move slime;

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
        captain.SetActive(false);
        slime.gameObject.SetActive(true);
        slime.is_move = true;
    }
}
