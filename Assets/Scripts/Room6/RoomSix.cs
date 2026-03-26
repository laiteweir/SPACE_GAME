using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RoomSix : MonoBehaviour
{
    public GameObject room6Event1;
    [SerializeField] private ItemData cookedFoodData;
    [SerializeField] private Door nextDoor;
    public int situation;
    // Update is called once per frame
    private void Update()
    {
        int index = Manager.Instance.InventoryManager.FindIndexOfItem(cookedFoodData);
        if (index != -1)
        {
            nextDoor.locked = false;
            // Destroy(room6_event1);
            room6Event1.SetActive(false);
        }
    }
}
