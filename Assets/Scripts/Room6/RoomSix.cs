using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomSix : MonoBehaviour
{
    public GameObject room6Event1;
    [SerializeField] private ItemData cookedFoodData;
    [SerializeField] private GameObject nextDoor;
    // Update is called once per frame
    private void Update()
    {
        int index = Manager.Instance.InventoryManager.items.FindIndex(item => item.itemName == cookedFoodData.itemName);
        if (index != -1)
        {
            nextDoor.GetComponent<Door>().locked = false;
            // Destroy(room6_event1);
            room6Event1.SetActive(false);
        }
    }
}
