using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FETTManager : MonoBehaviour
{
    public static FETTManager Instance;

    [SerializeField] private ItemData energyTankData;
    [SerializeField] private ItemData filledEnergyTankData;
    private Item energyTank;
    private Item filledEnergyTank;

    private void Awake()
    {
        if (Instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        energyTank = Manager.Instance.InventoryManager.InstantiateItem(energyTankData);
        filledEnergyTank = Manager.Instance.InventoryManager.InstantiateItem(filledEnergyTankData);
    }
    public void Done()
    {
        int energyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(energyTank);
        int energyTankQuantity = Manager.Instance.InventoryManager.items[energyTankIndex].itemQuantity;
        Manager.Instance.InventoryManager.RemoveItem(energyTankIndex, 1);
        Manager.Instance.InventoryManager.AddItem(filledEnergyTank);
        if (energyTankQuantity == 1)
        {
            // Manager.Instance.InventoryManager.items.Remove(energyTank);
            Manager.Instance.returnKeyitem.EndKeyitemEvent();
        }
    }
    public void QuitTask()
    {
        Manager.Instance.returnKeyitem.EndKeyitemEvent();
    }
}
