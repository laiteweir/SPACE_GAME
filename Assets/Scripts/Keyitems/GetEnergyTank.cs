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
            if (Manager.Instance.myBag.itemList.Count == 0)
            {
                InventoryManager.CreateNewItem(energyTank);
            }
            Manager.Instance.myBag.itemList.Add(energyTank);
        }
        ++energyTank.itemHeld;
        EndKeyitemEvent();
    }

    public override void EndKeyitemEvent()
    {
        Destroy(this);
    }
}
