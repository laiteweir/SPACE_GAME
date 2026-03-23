using UnityEngine;

public class FindFood : Keyitem
{
    [SerializeField] private ItemData foodData;
    private Item food;
    [SerializeField] private TextAsset textFile;
    [SerializeField] private GameObject next;

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
            Manager.Instance.DialogBox.StartTalk(dialog);
            next.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
