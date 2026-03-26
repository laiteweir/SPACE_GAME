using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Room10Event2 : MonoBehaviour
{
    [SerializeField] private ItemData hintMapData;
    [SerializeField] private TextAsset textFile;
    private string[] dialog;
    // Start is called before the first frame update
    void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.room10.isEngine0Fixed && Manager.Instance.room10.isEngine1Fixed && !Manager.Instance.DialogBoxUI.activeSelf)
        {
            // Debug.Log("You have fixed both engines!");
            Manager.Instance.room10.room10BigLight.enabled = true;
            Manager.Instance.room2.room2BigLight.enabled = true;
            int index = Manager.Instance.InventoryManager.FindIndexOfItem(hintMapData);
            if (index != -1)
            {
                Manager.Instance.InventoryManager.RemoveItem(index, 1);
                Manager.Instance.DialogBox.StartTalk(dialog);
                Manager.Instance.room10.UnlockDoor();
                Manager.Instance.room10.room10Event2.SetActive(false);
                Destroy(this);
            }
        }
    }
}
