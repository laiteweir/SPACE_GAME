using UnityEngine;

public class Find_food : Keyitem
{
    [SerializeField] private ItemData foodData;
    private Item food;
    [SerializeField] private TextAsset textFile;
    [SerializeField] private GameObject other;

    private void Start()
    {
        food = Manager.Instance.InventoryManager.InstantiateItem(foodData);
    }
    public override void KeyitemEvent()
    {
        if (Manager.Instance.InventoryManager.FindIndexOfItem(food) == -1)
        {
            Manager.Instance.InventoryManager.AddItem(food);
            // Debug.Log("find some food");

            string[] dialog = textFile.text.Split('\n');
            Manager.Instance.DialogBoxUI.SetActive(true);
            Manager.Instance.DialogBox.TextIsOn = true;
            Manager.Instance.DialogBox.StartTalk(dialog);
            gameObject.SetActive(false);
            other.SetActive(true);
        }
    }
}
