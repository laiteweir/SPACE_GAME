using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class eat : Keyitem
{
    [SerializeField] private TextAsset textFile;
    //private TextAsset dialog01;
    private string[] dialog;
    [SerializeField] private ItemData cookedFoodData;
    [SerializeField] private ItemData shieldData;

    // Start is called before the first frame update
    private void Start()
    {
        dialog = textFile.text.Split('\n');
    }
    public override void KeyitemEvent()
    {
        int cookedFoodIndex = Manager.Instance.InventoryManager.FindIndexOfItem(cookedFoodData);
        if (cookedFoodIndex != -1)
        {
            // Debug.Log("start eating!");
            Manager.Instance.InventoryManager.RemoveItem(cookedFoodIndex, Manager.Instance.InventoryManager.items[cookedFoodIndex].itemQuantity);
            Manager.Instance.DialogBoxUI.SetActive(true);
            Manager.Instance.DialogBox.StartTalk(dialog);
            Manager.Instance.InventoryManager.AddItem(shieldData);
            EndKeyitemEvent();
        }
    }
    public override void EndKeyitemEvent()
    {
        Destroy(this);
    }
}
