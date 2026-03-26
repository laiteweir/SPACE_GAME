using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCook : Keyitem
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
        int index = Manager.Instance.InventoryManager.FindIndexOfItem(foodData);
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
            Manager.Instance.DialogBox.StartTalk(dialog);
        }
    }
    private void StartCook(){
        Manager.Instance.OpenSceneUI("Cook Game", this);
    }
    public override void EndKeyitemEvent()
    {
        Manager.Instance.CloseSceneUI("Cook Game");
        if (Manager.Instance.room6.situation == 1)
        {
            Manager.Instance.InventoryManager.RemoveItem(n, 1);
            Manager.Instance.InventoryManager.AddItem(cookedFood);
            dialog = textFile1.text.Split('\n');
            Manager.Instance.DialogBox.StartTalk(dialog);
        }
        else if (Manager.Instance.room6.situation == 2)
        {
            Manager.Instance.InventoryManager.RemoveItem(n, 1);
            dialog = textFile2.text.Split('\n');
            Manager.Instance.DialogBox.StartTalk(dialog);
            // gameObject.SetActive(false);
           
        }
        else if (Manager.Instance.room6.situation == 3)
        {
            dialog = textFile3.text.Split('\n');
            Manager.Instance.DialogBox.StartTalk(dialog);
        }
    }
}
