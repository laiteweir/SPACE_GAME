using UnityEngine;

[CreateAssetMenu(fileName = "NewBasicLockStrategy", menuName = "Strategy/Basic Lock Strategy", order = 1)]
public class LockStrategyBasic : LockStrategy
{
    public override void StartUnlock(Door door)
    {
        Manager.Instance.DialogBox.StartTalk(door.dialog);
    }
}
