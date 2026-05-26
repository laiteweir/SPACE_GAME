using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInWorld : MonoBehaviour
{
    [SerializeField] private ItemData thisItemData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Manager.Instance.InventoryManager.AddItem(thisItemData);
            Destroy(gameObject);
        }
    }
}
