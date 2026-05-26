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

    private string[] dialog;

    private enum Condition
    {
        Cooked,
        Burnt,
        Undercooked
    }

    public override void KeyitemEvent()
    {
        int index = Manager.Instance.InventoryManager.FindIndexOfItem(foodData);
        if (index != -1)
        {
            // Debug.Log("start cooking!");
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
        Condition situation = Condition.Undercooked;
        if (CookManager.Instance.Burnt == true)
        {
            situation = Condition.Burnt;
        }
        else if (CookManager.Instance.Cooked == true)
        {
            situation = Condition.Cooked;
        }
        else if (CookManager.Instance.Undercooked == true)
        {
            situation = Condition.Undercooked;
        }

        Manager.Instance.CloseSceneUI("Cook Game");

        if (situation == Condition.Cooked)
        {
            Manager.Instance.InventoryManager.RemoveItem(n, 1);
            Manager.Instance.InventoryManager.AddItem(cookedFoodData);
            Manager.Instance.room5.Food1.SetActive(false);
            Manager.Instance.room5.Food2.SetActive(false);
            dialog = textFile1.text.Split('\n');
            Manager.Instance.DialogBox.StartTalk(dialog);
        }
        else if (situation == Condition.Burnt)
        {
            Manager.Instance.InventoryManager.RemoveItem(n, 1);
            dialog = textFile2.text.Split('\n');
            Manager.Instance.DialogBox.StartTalk(dialog);
            // gameObject.SetActive(false);
           
        }
        else if (situation == Condition.Undercooked)
        {
            dialog = textFile3.text.Split('\n');
            Manager.Instance.DialogBox.StartTalk(dialog);
        }
    }
}
