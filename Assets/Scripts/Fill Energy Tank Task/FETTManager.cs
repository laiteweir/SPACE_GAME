using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FETTManager : MonoBehaviour
{
    public static FETTManager Instance;

    [SerializeField] Item energyTank;
    [SerializeField] Item filledEnergyTank;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void Done()
    {
        --energyTank.itemHeld;
        if (!Manager.Instance.myBag.itemList.Contains(filledEnergyTank))
        {
            if (Manager.Instance.myBag.itemList.Count == 0)
            {
                InventoryManager.CreateNewItem(filledEnergyTank);
            }
            else
            {
                ++filledEnergyTank.itemHeld;
            }
            Manager.Instance.myBag.itemList.Add(filledEnergyTank);
        }
        else
        {
            ++filledEnergyTank.itemHeld;
        }
        if (energyTank.itemHeld == 0)
        {
            Manager.Instance.myBag.itemList.Remove(energyTank);
            Manager.Instance.returnKeyitem.EndKeyitemEvent();
        }
    }
}
