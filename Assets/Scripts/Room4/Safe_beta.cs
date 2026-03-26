using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Safe_beta : Keyitem
{
    [SerializeField] private TextAsset file;
    [SerializeField] private ItemData keycardData;
    private Item keycard;
    private string[] dialog;
    private bool is_triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        dialog = file.text.Split("\n");
        keycard = Manager.Instance.InventoryManager.InstantiateItem(keycardData);
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.DialogBoxUI.activeSelf == false && is_triggered == true)
        {
            Manager.Instance.room3.room3_event4.SetActive(true);
            Manager.Instance.room4.safe.SetActive(false);
            Manager.Instance.room3.room3_event3.SetActive(false);
            Manager.Instance.InventoryManager.AddItem(keycard);
            Destroy(this);
        }

    }

    public override void KeyitemEvent()
    {
        Manager.Instance.DialogBoxUI.SetActive(true);
        Manager.Instance.DialogBox.StartTalk(dialog);
        is_triggered = true;
    }
    public override void EndKeyitemEvent()
    {
        // Debug.Log("test fire");
    }
}
