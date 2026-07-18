using UnityEngine;

[CreateAssetMenu(fileName = "NewKeyCardLockStrategy", menuName = "Strategy/Key Card Lock Strategy", order = 3)]
public class LockStrategyKeyCard : LockStrategy
{
    public override void StartUnlock(Door door)
    {
        int keyCardIndex = Manager.Instance.InventoryManager.FindIndexOfItem(door.keyCardData);
        if (keyCardIndex != -1)
        {
            door.UnlockDoor();
            door.OpenDoor();
        }
        // else
        // {
        //     Debug.Log("You don't have the keycard!");
        // }
    }
}
