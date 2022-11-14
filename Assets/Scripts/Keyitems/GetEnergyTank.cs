using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnergyTank : Keyitem
{
    [SerializeField] Item energyTank;
    public override void KeyitemEvent()
    {
        if (!Manager.Instance.myBag.itemList.Contains(energyTank))
        {
            // if (playerInventory.itemList.Count == 0)
            //    InventoryManager.CreateNewItem(thisItem);
            Manager.Instance.myBag.itemList.Add(energyTank);
            // InventoryManager.itemno++;
        }
        else
        {
            ++energyTank.itemHeld;
        }
        EndKeyitemEvent();
    }

    public override void EndKeyitemEvent()
    {
        gameObject.SetActive(false);
    }
}
