using UnityEngine;

public class FETTManager : BaseScene
{
    public static FETTManager Instance;

    [SerializeField] private ItemData energyTankData;
    [SerializeField] private ItemData filledEnergyTankData;

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void CompleteFilling()
    {
        int energyTankIndex = Manager.Instance.InventoryManager.FindIndexOfItem(energyTankData);
        int energyTankQuantity = Manager.Instance.InventoryManager.items[energyTankIndex].itemQuantity;
        Manager.Instance.InventoryManager.RemoveItem(energyTankIndex, 1);
        Manager.Instance.InventoryManager.AddItem(filledEnergyTankData);
        if (energyTankQuantity == 1)
        {
            SceneExit();
        }
    }
}
