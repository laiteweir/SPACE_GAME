using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room6Event1 : Keyitem
{
    private int n;
    [SerializeField] private TextAsset textFile0;
    [SerializeField] private TextAsset textFile1;
    [SerializeField] private TextAsset textFile2;
    [SerializeField] private TextAsset textFile3;
    [SerializeField] private ItemData foodData;
    [SerializeField] private ItemData cookedFoodData;
    private Item cookedFood;

    private string[] dialog;
    // Start is called before the first frame update
    private void Start()
    {
        cookedFood = Manager.Instance.InventoryManager.InstantiateItem(cookedFoodData);
    }

    public override void KeyitemEvent()
    {
        int index = Manager.Instance.InventoryManager.items.FindIndex(item => item.itemName == foodData.itemName);
        if (index != -1)
        {
            // Debug.Log("start to cook!");
            n = index;
            StartCook();
        }
        else
        {
            // Debug.Log("there is nothing to cook");
            dialog = textFile0.text.Split('\n');
            Manager.Instance.DialogBoxUI.SetActive(true);
            Manager.Instance.DialogBox.StartTalk(dialog);
        }
    }
    private void StartCook(){
        Manager.Instance.OpenSceneUI("Cook Game", this);
    }
    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseSceneUI("Cook Game");
        if (CookManager.Instance.situation == 1)
        {
            Manager.Instance.InventoryManager.RemoveItem(n, 1);
            Manager.Instance.InventoryManager.AddItem(cookedFood);
            dialog = textFile1.text.Split('\n');
            Manager.Instance.DialogBoxUI.SetActive(true);
            Manager.Instance.DialogBox.StartTalk(dialog);
        }
        else if (CookManager.Instance.situation == 2)
        {
            Manager.Instance.InventoryManager.RemoveItem(n, 1);
            dialog = textFile2.text.Split('\n');
            Manager.Instance.DialogBoxUI.SetActive(true);
            Manager.Instance.DialogBox.StartTalk(dialog);
            // gameObject.SetActive(false);
           
        }
        else if (CookManager.Instance.situation == 3)
        {
            dialog = textFile3.text.Split('\n');
            Manager.Instance.DialogBoxUI.SetActive(true);
            Manager.Instance.DialogBox.StartTalk(dialog);
        }
    }
}
