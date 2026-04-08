using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInWorld : MonoBehaviour
{
    [SerializeField] private ItemData thisItemData;
    private Item thisItem;
    // Start is called before the first frame update
    private void Start()
    {
        thisItem = Manager.Instance.InventoryManager.InstantiateItem(thisItemData);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Manager.Instance.InventoryManager.AddItem(thisItem);
            Destroy(gameObject);
        }
    }
}
