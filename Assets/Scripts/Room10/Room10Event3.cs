using UnityEngine;

public class Room10Event3 : MonoBehaviour
{
    [SerializeField] private ItemData hintMapData;

    [SerializeField] private TextAsset textFile;
    private string[] dialog;

    // Start is called before the first frame update
    private void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    // Update is called once per frame
    private void Update()
    {
        if (!Manager.Instance.room10.isEngine1Fixed || !Manager.Instance.room10.isEngine2Fixed || Manager.Instance.DialogBoxUI.activeSelf)
        {
            return;
        }

        // Debug.Log("You have fixed both engines!");
        Manager.Instance.room2.Room2BigLight.enabled = true;
        Manager.Instance.room10.Room10BigLight.enabled = true;
        Manager.Instance.DialogBox.StartTalk(dialog, EndDialog);

        int index = Manager.Instance.InventoryManager.FindIndexOfItem(hintMapData);
        if (index != -1)
        {
            Manager.Instance.InventoryManager.RemoveItem(index, 1);
        }
    }

    private void EndDialog()
    {
        gameObject.SetActive(false);
        Manager.Instance.room10.UnlockDoor();
    }
}
