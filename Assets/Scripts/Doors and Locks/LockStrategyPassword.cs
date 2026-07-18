using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPasswordLockStrategy", menuName = "Strategy/Password Lock Strategy", order = 2)]
public class LockStrategyPassword : LockStrategy
{
    private IEnumerator UnlockWithPassword(Door door)
    {
        CodePanel codePanel = Manager.Instance.CodePanel.GetComponent<CodePanel>();
        if (codePanel.DoorOpen)
        {
            door.UnlockDoor();
            door.OpenDoor();
            yield break;
        }
        codePanel.OpenCodePanel();
        while (!codePanel.DoorOpen)
        {
            if (!Manager.Instance.CodePanel.activeSelf)
            {
                codePanel.Clear();
                yield break;
            }
            else
            {
                yield return null;
            }
        }
        Manager.Instance.UIManager.Back();
        door.UnlockDoor();
        door.OpenDoor();
        yield break;
    }

    public override void StartUnlock(Door door)
    {
        door.StartCoroutine(UnlockWithPassword(door));
    }
}
